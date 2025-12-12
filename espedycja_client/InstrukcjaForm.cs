using System;
using System.Drawing;
using System.Windows.Forms;

namespace espedycja_client
{
    public partial class InstrukcjaForm : Form
    {
        public InstrukcjaForm()
        {
            InitializeComponent();
            KonfigurujOkno();
            WypelnijTresc();
        }

        private void KonfigurujOkno()
        {
            this.Text = "Instrukcja Obsługi";
            this.Size = new Size(650, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;

            if (richTextBox1 != null)
            {
                richTextBox1.Dock = DockStyle.Fill;
                richTextBox1.BackColor = Color.White;
                richTextBox1.BorderStyle = BorderStyle.None;
                richTextBox1.ReadOnly = true;
                richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
                // Marginesy (lewy, prawy)
                richTextBox1.Padding = new Padding(20);
            }
        }

        private void WypelnijTresc()
        {
            richTextBox1.Clear();

            // Ustawienia stylów
            Font fontTytul = new Font("Segoe UI", 18, FontStyle.Bold);
            Font fontNaglowek = new Font("Segoe UI", 12, FontStyle.Bold);
            Font fontTekst = new Font("Segoe UI", 10, FontStyle.Regular);
            Font fontPogrubiony = new Font("Segoe UI", 10, FontStyle.Bold);

            Color kolorTytul = Color.DarkSlateBlue;
            Color kolorNaglowek = Color.Black;
            Color kolorTekst = Color.FromArgb(64, 64, 64);

            // --- TREŚĆ ---

            // Tytuł
            WstawTekst("INSTRUKCJA OBSŁUGI\n", fontTytul, kolorTytul, 0);
            WstawTekst("E-SPEDYCJA CLIENT v1.0\n\n", fontTekst, Color.Gray, 0);

            // Sekcja 1
            WstawTekst("1. PIERWSZE URUCHOMIENIE\n", fontNaglowek, kolorNaglowek, 0);
            WstawTekst("Aby aplikacja działała poprawnie, wymagany jest plugin telemetryczny SCS.\n\n", fontTekst, kolorTekst, 0);

            WstawTekst("• Krok A: ", fontPogrubiony, kolorTekst, 20);
            WstawTekst("Kliknij przycisk 'Zainstaluj Plugin' w głównym oknie.\n", fontTekst, kolorTekst, 0);

            WstawTekst("• Krok B: ", fontPogrubiony, kolorTekst, 20);
            WstawTekst("Wskaż główny folder gry na dysku.\n", fontTekst, kolorTekst, 0);
            WstawTekst("(Zazwyczaj: Steam\\steamapps\\common\\Euro Truck Simulator 2)\n", new Font("Consolas", 9, FontStyle.Italic), Color.Gray, 40);

            WstawTekst("• Krok C: ", fontPogrubiony, kolorTekst, 20);
            WstawTekst("Po komunikacie o sukcesie uruchom grę.\n\n\n", fontTekst, kolorTekst, 0);

            // Sekcja 2
            WstawTekst("2. ŁĄCZENIE Z SYSTEMEM\n", fontNaglowek, kolorNaglowek, 0);
            WstawTekst("Po uruchomieniu aplikacji wykonaj następujące kroki:\n\n", fontTekst, kolorTekst, 0);

            WstawTekst("1. ", fontPogrubiony, kolorTekst, 20);
            WstawTekst("Wklej swój KLUCZ API w polu tekstowym.\n", fontTekst, kolorTekst, 0);

            WstawTekst("2. ", fontPogrubiony, kolorTekst, 20);
            WstawTekst("Kliknij przycisk 'Połącz / Start'.\n", fontTekst, kolorTekst, 0);

            WstawTekst("3. ", fontPogrubiony, kolorTekst, 20);
            WstawTekst("Wejdź do gry i wsiądź do ciężarówki.\n", fontTekst, kolorTekst, 0);

            WstawTekst("Status zmieni się na: ", fontTekst, kolorTekst, 20);
            WstawTekst("Wysyłanie danych...\n\n\n", fontPogrubiony, Color.Green, 0);

            // Sekcja 3
            WstawTekst("3. AUTOMATYCZNE WYSYŁANIE TRAS\n", fontNaglowek, kolorNaglowek, 0);
            WstawTekst("System działa w tle i jest bezobsługowy:\n\n", fontTekst, kolorTekst, 0);

            WstawTekst("➤ System sam wykrywa podpięcie naczepy.\n", fontTekst, kolorTekst, 20);
            WstawTekst("➤ System sam wysyła dane startowe (Miasto + Firma).\n", fontTekst, kolorTekst, 20);
            WstawTekst("➤ Po oddaniu naczepy trasa jest automatycznie zamykana i wysyłana na serwer.\n\n", fontTekst, kolorTekst, 20);

            WstawTekst("INFO: ", fontPogrubiony, Color.DodgerBlue, 20);
            WstawTekst("O zakończeniu trasy poinformuje Cię dymek w rogu ekranu.\n\n\n", fontTekst, kolorTekst, 0);

            // Sekcja 4
            WstawTekst("4. WIRTUALNY TACHOGRAF\n", fontNaglowek, kolorNaglowek, 0);
            WstawTekst("Aplikacja pilnuje Twojego czasu pracy zgodnie z przepisami:\n\n", fontTekst, kolorTekst, 0);

            WstawTekst("■ KOLOR ZIELONY: ", fontPogrubiony, Color.Green, 20);
            WstawTekst("Czas w normie (poniżej 4h 15min).\n", fontTekst, kolorTekst, 0);

            WstawTekst("■ KOLOR POMARAŃCZOWY: ", fontPogrubiony, Color.DarkOrange, 20);
            WstawTekst("Ostrzeżenie (pozostało 15 min).\n", fontTekst, kolorTekst, 0);

            WstawTekst("■ KOLOR CZERWONY: ", fontPogrubiony, Color.Red, 20);
            WstawTekst("Przekroczenie czasu pracy! Zjedź na pauzę.\n\n", fontTekst, kolorTekst, 0);

            WstawTekst("Aby zresetować czas, wyłącz silnik na minimum 15 minut.\n\n\n", fontTekst, kolorTekst, 20);

            // Stopka
            WstawTekst("__________________________________________________\n", fontTekst, Color.LightGray, 0);
            WstawTekst("e-Spedycja Client | Wszelkie prawa zastrzeżone.", new Font("Segoe UI", 8), Color.Gray, 0);

            // Przewiń na górę
            richTextBox1.Select(0, 0);
            richTextBox1.ScrollToCaret();
        }

        // Pomocnicza metoda do ładnego formatowania
        private void WstawTekst(string tekst, Font font, Color kolor, int wciecie)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;

            richTextBox1.SelectionFont = font;
            richTextBox1.SelectionColor = kolor;
            richTextBox1.SelectionIndent = wciecie;

            richTextBox1.AppendText(tekst);

            // Reset wcięcia dla kolejnych linii (ważne!)
            richTextBox1.SelectionIndent = 0;
        }
    }
}