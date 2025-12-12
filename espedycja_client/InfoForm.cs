using System;
using System.Drawing;
using System.Windows.Forms;

namespace espedycja_client
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
            KonfigurujOkno();
            WypelnijTresc();
        }

        private void KonfigurujOkno()
        {
            this.Text = "O Aplikacji";
            this.Size = new Size(450, 500); // Mniejsze, zgrabne okno
            this.StartPosition = FormStartPosition.CenterParent; // Pojawi się na środku głównego okna
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Sztywne okno dialogowe (bez zmiany rozmiaru)
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            if (richTextBox1 != null)
            {
                richTextBox1.Dock = DockStyle.Fill;
                richTextBox1.BackColor = Color.White;
                richTextBox1.BorderStyle = BorderStyle.None;
                richTextBox1.ReadOnly = true;
                richTextBox1.ScrollBars = RichTextBoxScrollBars.None; // Bez pasków przewijania (estetyczniej)
            }
        }

        private void WypelnijTresc()
        {
            richTextBox1.Clear();

            // Ustawienia stylów
            Font fontTytul = new Font("Segoe UI", 22, FontStyle.Bold);
            Font fontWersja = new Font("Segoe UI", 11, FontStyle.Regular);
            Font fontOpis = new Font("Segoe UI", 10, FontStyle.Italic);
            Font fontNaglowek = new Font("Segoe UI", 10, FontStyle.Bold);
            Font fontTekst = new Font("Segoe UI", 10, FontStyle.Regular);

            Color kolorBrand = Color.DarkSlateBlue;
            Color kolorSzary = Color.Gray;

            // Pobranie wersji aplikacji
            string wersja = Application.ProductVersion.Split('+')[0];

            // --- TREŚĆ ---

            // 1. Nazwa i Wersja
            WstawTekst("\n", fontTekst, Color.Black); // Odstęp
            WstawTekst("e-SPEDYCJA CLIENT\n", fontTytul, kolorBrand);
            WstawTekst($"Wersja {wersja}\n\n", fontWersja, Color.Black);

            // 2. Linia oddzielająca
            WstawTekst("____________________________________\n\n", fontTekst, Color.LightGray);

            // 3. Opis
            WstawTekst("Profesjonalny system telemetryczny\ndla Euro Truck Simulator 2.\n\n", fontOpis, Color.DimGray);

            // 4. Sekcja techniczna
            WstawTekst("Status Systemu:\n", fontNaglowek, Color.Black);
            WstawTekst("Stabilny\n\n", fontTekst, Color.Green);

            WstawTekst("Technologia:\n", fontNaglowek, Color.Black);
            WstawTekst(".NET 6 / SCSSdkClient / LiveMaps API\n\n", fontTekst, kolorSzary);

            WstawTekst("Deweloper:\n", fontNaglowek, Color.Black);
            WstawTekst("e-Spedycja Dev Team\n\n", fontTekst, kolorSzary);

            WstawTekst("Kontakt / Support:\n", fontNaglowek, Color.Black);
            WstawTekst("administracja@e-spedycja.cloud\n\n", fontTekst, Color.DodgerBlue);

            // 5. Stopka
            WstawTekst("\n\n", fontTekst, Color.Black);
            WstawTekst($"© {DateTime.Now.Year} Wszelkie prawa zastrzeżone.", new Font("Segoe UI", 8), Color.Silver);

            // Usunięcie zaznaczenia na starcie
            richTextBox1.SelectionLength = 0;
        }

        // Metoda pomocnicza z centrowaniem tekstu
        private void WstawTekst(string tekst, Font font, Color kolor)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;

            richTextBox1.SelectionFont = font;
            richTextBox1.SelectionColor = kolor;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center; // CENTROWANIE

            richTextBox1.AppendText(tekst);
        }
    }
}