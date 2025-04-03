using System.Windows;

namespace EinkaufslistenWPF
{
    public partial class TextInputDialog : Window
    {
        public string Answer { get; private set; }

        public TextInputDialog(string message, string defaultText = "")
        {
            InitializeComponent();
            MessageText.Text = message;
            InputTextBox.Text = defaultText;
            InputTextBox.Focus();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Answer = InputTextBox.Text;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
