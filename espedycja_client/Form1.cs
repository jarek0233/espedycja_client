using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SCSSdkClient;
using SCSSdkClient.Object;
using DiscordRPC; // To jest z tej nowej paczki NuGet
using WMPLib;     // To jest do Radia (systemowe)


namespace espedycja_client
{
    public partial class Form1 : Form
    {
        // --- KONFIGURACJA ---
        private const string API_URL = "https://e-spedycja.cloud/api/telemetry/update";
        // TUTAJ WKLEJ SWOJE ID Z DISCORD DEVELOPER PORTAL:
        private const string DISCORD_APP_ID = "1449160950182580267";

        // --- ZMIENNE GŁÓWNE ---
        private SCSSdkTelemetry _telemetry;
        private readonly HttpClient _httpClient;

        // Discord i Radio
        private DiscordRpcClient _discordClient;
        private WindowsMediaPlayer _player;

        // Zmienne Tachografu
        private double _localSessionMinutes = 0;
        private DateTime _lastTickTime = DateTime.Now;

        // Flagi
        private bool _warnedTacho = false;
        private bool _violationTacho = false;
        private bool _wasOnJob = false;

        public Form1()
        {
            InitializeComponent();

            // 1. Wersja i Pasek
            string version = Application.ProductVersion.Split('+')[0];
            tsVersion.Text = $"v.{version}";
            tsStatus.Text = "Gotowy - Rozłączono";

            // 2. HTTP i SDK
            _httpClient = new HttpClient();
            _telemetry = new SCSSdkTelemetry();
            _telemetry.Data += Telemetry_Data;

            // 3. Timer
            timerSend.Interval = 1000;
            timerSend.Tick += TimerSend_Tick;

            // 4. INICJALIZACJA DISCORDA
            InitializeDiscord();

            // 5. INICJALIZACJA RADIA
            InitializeRadio();

            // 6. Notify Icon
            if (notifyIcon1.Icon == null) notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.Visible = true;
        }

        // ==========================================
        // SEKCJA DISCORD RICH PRESENCE
        // ==========================================
        private void InitializeDiscord()
        {
            _discordClient = new DiscordRpcClient(DISCORD_APP_ID);

            // Ustawiamy przyciski (opcjonalnie, np. link do strony spedycji)
            _discordClient.OnReady += (sender, e) => { Console.WriteLine("Discord Ready!"); };
            _discordClient.Initialize();
        }

        private void UpdateDiscord(TelemetryPayload p)
        {
            if (_discordClient == null || !_discordClient.IsInitialized) return;

            if (p.SpeedKmh == 0 && p.TruckModel == null)
            {
                // Gdy gra wyłączona lub menu
                _discordClient.SetPresence(new RichPresence()
                {
                    Details = "W menu / Postój",
                    State = "Oczekiwanie na trasę",
                    Assets = new Assets()
                    {
                        LargeImageKey = "logo_duze", // Musisz wgrać plik o takiej nazwie w Discord Dev Portal
                        LargeImageText = "e-Spedycja System",
                        SmallImageKey = "idle",
                        SmallImageText = "Pauza"
                    }
                });
                return;
            }

            // Gdy w trasie
            string details = p.HasTrailer
                ? $"Trasa: {p.SourceCity} -> {p.DestinationCity}"
                : "Jazda swobodna (Bez ładunku)";

            string state = p.HasTrailer
                ? $"{p.CargoId} ({p.CargoWeight}t) | {p.TruckModel}"
                : $"Model: {p.TruckModel} | {(int)p.SpeedKmh} km/h";

            _discordClient.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Timestamps = new Timestamps(), // Można dodać czas startu
                Assets = new Assets()
                {
                    LargeImageKey = "logo_duze", // Nazwa obrazka w Discord Dev Portal
                    LargeImageText = "e-Spedycja",
                    SmallImageKey = "truck",     // Opcjonalnie mała ikonka
                    SmallImageText = $"{(int)p.SpeedKmh} km/h"
                }
            });
        }

        // ==========================================
        // SEKCJA RADIO ODTWARZACZ
        // ==========================================
        private void InitializeRadio()
        {
            _player = new WindowsMediaPlayer();
            _player.settings.autoStart = false;

            // Dodajmy przykładowe stacje do ComboBoxa
            cbRadioStation.Items.Add(new RadioStation("RMF FM", "http://217.74.72.11/rmf_fm"));
            cbRadioStation.Items.Add(new RadioStation("Eska Rock", "http://waw02-03.ic.smcdn.pl/t040-1.mp3"));
            cbRadioStation.Items.Add(new RadioStation("Truckers.FM", "http://radio.truckers.fm/"));
            cbRadioStation.Items.Add(new RadioStation("OpenFM - Praca", "http://stream.open.fm/115"));

            cbRadioStation.DisplayMember = "Name"; // Wyświetlaj nazwę
            cbRadioStation.SelectedIndex = 0;

            // Obsługa głośności (jeśli masz suwak tbVolume)
            if (tbVolume != null)
            {
                tbVolume.Minimum = 0;
                tbVolume.Maximum = 100;
                tbVolume.Value = 50;
                tbVolume.Scroll += (s, e) => { _player.settings.volume = tbVolume.Value; };
            }
        }

        // Obsługa przycisku PLAY
        private void btnRadioPlay_Click(object sender, EventArgs e)
        {
            if (cbRadioStation.SelectedItem is RadioStation station)
            {
                _player.URL = station.Url;
                _player.controls.play();
                tsStatus.Text = $"Radio: Gram {station.Name}";
            }
        }

        // Obsługa przycisku STOP
        private void btnRadioStop_Click(object sender, EventArgs e)
        {
            _player.controls.stop();
            tsStatus.Text = "Radio zatrzymane";
        }

        // Klasa pomocnicza do listy stacji
        public class RadioStation
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public RadioStation(string name, string url) { Name = name; Url = url; }
        }

        // ==========================================
        // STANDARDOWA LOGIKA (TIMER, API, UI)
        // ==========================================

        // ... (Tu pozostaje Twój kod: btnInstallPlugin_Click, Telemetry_Data, btnStart_Click) ...

        // UWAGA: Skopiuj swoje stare metody btnInstallPlugin_Click, btnStart_Click i wklej je tutaj,
        // lub zostaw jeśli nie usuwałeś. Poniżej wklejam tylko TimerSend_Tick bo tam są zmiany.

        // --- INSTALACJA PLUGINU ---
        private void btnInstallPlugin_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Wskaż folder gry ETS2";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string gamePath = fbd.SelectedPath;
                    string pluginsPath = Path.Combine(gamePath, "bin", "win_x64", "plugins");
                    try
                    {
                        if (!Directory.Exists(pluginsPath)) Directory.CreateDirectory(pluginsPath);
                        string source = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scs-telemetry.dll");
                        string dest = Path.Combine(pluginsPath, "scs-telemetry.dll");
                        if (File.Exists(source)) { File.Copy(source, dest, true); MessageBox.Show("Sukces!"); }
                        else MessageBox.Show("Brak pliku DLL!");
                    }
                    catch (Exception ex) { MessageBox.Show($"Błąd: {ex.Message}"); }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApiKey.Text)) { MessageBox.Show("Klucz API!"); return; }
            if (timerSend.Enabled) { timerSend.Stop(); btnStart.Text = "Start"; tsStatus.Text = "Stop"; }
            else { _lastTickTime = DateTime.Now; timerSend.Start(); btnStart.Text = "Stop"; tsStatus.Text = "Oczekiwanie..."; }
        }

        private void Telemetry_Data(SCSSdkClient.Object.SCSTelemetry data, bool newTimestamp)
        {
            _currentData = data;
        }

        // ==========================================
        // GŁÓWNA PĘTLA
        // ==========================================
        private async void TimerSend_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            // 1. Sprawdzenie czy gra działa
            if (_currentData == null || _currentData.SdkActive == false)
            {
                tsStatus.Text = "Gra nie jest aktywna / Pauza";
                tsStatus.ForeColor = Color.Red;
                _lastTickTime = now;

                // DISCORD: Reset statusu gdy gra wyłączona
                _discordClient.SetPresence(new RichPresence() { Details = "Oczekiwanie na grę...", State = "Aplikacja włączona" });

                return;
            }

            tsStatus.Text = "Wysyłanie danych...";
            tsStatus.ForeColor = Color.Blue;

            // 2. TACHOGRAF
            double timeDiffMinutes = (now - _lastTickTime).TotalMinutes;
            _lastTickTime = now;
            bool engineOn = _currentData.TruckValues.CurrentValues.DashboardValues.RPM > 10;
            if (engineOn) _localSessionMinutes += timeDiffMinutes;

            TimeSpan t = TimeSpan.FromMinutes(_localSessionMinutes);
            lblSessionTime.Text = string.Format("{0:D2}:{1:D2}", (int)t.TotalHours, t.Minutes);

            if (_localSessionMinutes < 240) { lblSessionTime.ForeColor = Color.Black; lblTachoStatus.Text = "W Normie"; lblTachoStatus.ForeColor = Color.Green; }
            else if (_localSessionMinutes < 270) { lblSessionTime.ForeColor = Color.DarkOrange; lblTachoStatus.Text = "Zbliża się PAUZA!"; lblTachoStatus.ForeColor = Color.DarkOrange; }
            else { lblSessionTime.ForeColor = Color.Red; lblTachoStatus.Text = "PRZEKROCZENIE!"; lblTachoStatus.ForeColor = Color.Red; }

            // 3. PRZYGOTOWANIE PAYLOADU
            var truck = _currentData.TruckValues;
            var dashboard = truck.CurrentValues.DashboardValues;
            bool hasTrailer = _currentData.TrailerValues.Length > 0 && _currentData.TrailerValues[0].Attached;

            var payload = new TelemetryPayload
            {
                ApiKey = txtApiKey.Text,
                CoordinateX = FixDouble(truck.CurrentValues.PositionValue.Position.X),
                CoordinateZ = FixDouble(truck.CurrentValues.PositionValue.Position.Z),
                SpeedKmh = FixFloat(dashboard.Speed.Kph),
                Heading = FixFloat(truck.CurrentValues.PositionValue.Orientation.Heading),
                TruckModel = $"{truck.ConstantsValues.BrandId} {truck.ConstantsValues.Name}",
                PlateNumber = truck.ConstantsValues.LicensePlate,
                Odometer = dashboard.Odometer,
                FuelAmount = dashboard.FuelValue.Amount,
                FuelAverage = dashboard.FuelValue.AverageConsumption,
                DamageTruck = FixFloat(truck.CurrentValues.DamageValues.Cabin),
                HasTrailer = hasTrailer,
                CargoId = "",
                SourceCity = "",
                DestinationCity = "",
                SourceCompany = "",
                DestinationCompany = "",
                CargoWeight = 0,
                DamageTrailer = 0,
                DamageCargo = 0
            };

            lblSpeed.Text = $"{(int)payload.SpeedKmh} km/h";
            lblTruckModel.Text = payload.TruckModel;
            lblFuel.Text = $"Paliwo: {(int)payload.FuelAmount} L";
            UpdateProgressBar(pbTruckDamage, payload.DamageTruck);

            // 4. LOGIKA TRASY
            if (hasTrailer)
            {
                var job = _currentData.JobValues;
                var trailer = _currentData.TrailerValues[0];

                payload.CargoId = job.CargoValues.Name ?? "Nieznany";
                payload.CargoWeight = (int)(job.CargoValues.Mass / 1000);

                string rawSourceCity = job.CitySource ?? "Start";
                string rawSourceCompany = job.CompanySource ?? "";
                string rawDestCity = job.CityDestination ?? "Cel";
                string rawDestCompany = job.CompanyDestination ?? "";

                payload.SourceCity = !string.IsNullOrEmpty(rawSourceCompany) ? $"{rawSourceCity} ({rawSourceCompany})" : rawSourceCity;
                payload.DestinationCity = !string.IsNullOrEmpty(rawDestCompany) ? $"{rawDestCity} ({rawDestCompany})" : rawDestCity;

                payload.SourceCompany = rawSourceCompany;
                payload.DestinationCompany = rawDestCompany;
                payload.DamageTrailer = FixFloat(trailer.DamageValues.Chassis);
                payload.DamageCargo = FixFloat(trailer.DamageValues.Cargo);

                lblRoute.Text = $"{payload.SourceCity} > {payload.DestinationCity}";
                lblSourceComp.Text = rawSourceCompany; lblDestComp.Text = rawDestCompany;
                lblCargo.Text = payload.CargoId; lblWeight.Text = $"{payload.CargoWeight} t";

                UpdateProgressBar(pbTrailerDamage, payload.DamageTrailer);
                UpdateProgressBar(pbCargoDamage, payload.DamageCargo);
                _wasOnJob = true;
            }
            else
            {
                if (_wasOnJob) { ShowNotification("System", "Trasa zakończona!", ToolTipIcon.Info); _wasOnJob = false; }
                lblRoute.Text = "Wolny"; lblSourceComp.Text = ""; lblDestComp.Text = "";
                lblCargo.Text = ""; lblWeight.Text = "";
                pbTrailerDamage.Value = 0; pbCargoDamage.Value = 0;
            }

            // 5. UPDATE DISCORD
            UpdateDiscord(payload);

            // 6. WYSYŁKA
            await SendToApi(payload);
        }

        private async Task SendToApi(TelemetryPayload payload)
        {
            try
            {
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(API_URL, content);
                if (response.IsSuccessStatusCode) { tsStatus.Text = "Połączono"; tsStatus.ForeColor = Color.Green; }
                else { tsStatus.Text = $"Błąd API: {response.StatusCode}"; tsStatus.ForeColor = Color.Red; }
            }
            catch { tsStatus.Text = "Błąd sieci"; tsStatus.ForeColor = Color.Red; }
        }

        // --- POMOCNICZE ---
        private void ShowNotification(string t, string m, ToolTipIcon i) { notifyIcon1.Visible = true; notifyIcon1.ShowBalloonTip(3000, t, m, i); }
        private void UpdateProgressBar(ProgressBar pb, float val) { int v = (int)(val * 100); if (v > 100) v = 100; if (v < 0) v = 0; pb.Value = v; }
        private float FixFloat(float v) => (float.IsNaN(v) || float.IsInfinity(v)) ? 0f : v;
        private double FixDouble(double v) => (double.IsNaN(v) || double.IsInfinity(v)) ? 0d : v;

        private void instrukcjaObsługiToolStripMenuItem_Click(object sender, EventArgs e) { new InstrukcjaForm().Show(); }
        private void oAplikacjiToolStripMenuItem_Click(object sender, EventArgs e) { new InfoForm().ShowDialog(); }
        private void tsStatus_Click(object sender, EventArgs e) { }
        private void menedżerTrasToolStripMenuItem_Click(object sender, EventArgs e) { }
    }

    // Klasa modelu (TelemetryPayload) bez zmian... (masz ją na dole swojego pliku)
    // Upewnij się, że nie skasowałeś klasy TelemetryPayload
    public class TelemetryPayload
    {
        public string ApiKey { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateZ { get; set; }
        public float SpeedKmh { get; set; }
        public float Heading { get; set; }
        public string TruckModel { get; set; }
        public string PlateNumber { get; set; }
        public bool HasTrailer { get; set; }
        public string CargoId { get; set; }
        public int CargoWeight { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public string SourceCompany { get; set; }
        public string DestinationCompany { get; set; }
        public double FuelAmount { get; set; }
        public double FuelAverage { get; set; }
        public float DamageTruck { get; set; }
        public float DamageTrailer { get; set; }
        public float DamageCargo { get; set; }
        public double Odometer { get; set; }
    }
}