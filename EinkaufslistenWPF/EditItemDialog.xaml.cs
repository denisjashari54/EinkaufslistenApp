using System.Windows;

namespace EinkaufslistenWPF
{
    public partial class EditItemDialog : Window
    {
        public string NeuerName { get; private set; }
        public int NeueMenge { get; private set; }

        public EditItemDialog(string aktuellerName, int aktuelleMenge)
        {
            InitializeComponent();
            NameTextBox.Text = aktuellerName;
            MengeTextBox.Text = aktuelleMenge.ToString();
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            NeuerName = NameTextBox.Text;

            if (int.TryParse(MengeTextBox.Text, out int menge))
            {
                NeueMenge = menge;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Bitte eine gültige Zahl für die Menge eingeben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
