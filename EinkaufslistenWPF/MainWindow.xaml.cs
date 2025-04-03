using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace EinkaufslistenWPF
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:7104/") };

        public MainWindow()
        {
            InitializeComponent();
            LadeEinkaufsitems();
        }

        private async void LadeEinkaufsitems()
        {
            try
            {
                var response = await client.GetAsync("api/EinkaufsItems");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<List<EinkaufsItem>>(json);
                    EinkaufslisteGrid.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Fehler beim Laden der Einkaufsitems.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }
        }

        private async void LadenButton_Click(object sender, RoutedEventArgs e)
        {
            if (BenutzerAuswahl.SelectedItem is ComboBoxItem selectedItem)
            {
                string benutzerId = selectedItem.Tag.ToString();
                await LadeEinkaufsItemsFürBenutzer(benutzerId);
            }
        }

        private async Task LadeEinkaufsItemsFürBenutzer(string benutzerId)
        {
            try
            {
                var response = await client.GetAsync($"api/EinkaufsItems/benutzer/{benutzerId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<List<EinkaufsItem>>(json);
                    EinkaufslisteGrid.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Keine Einkaufsitems für diesen Benutzer gefunden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }
        }

        private async void HinzufügenButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EditItemDialog("", 1);
            if (dialog.ShowDialog() == true)
            {
                if (BenutzerAuswahl.SelectedItem is ComboBoxItem selectedItem)
                {
                    string benutzerIdString = selectedItem.Tag?.ToString();
                    if (int.TryParse(benutzerIdString, out int benutzerId))
                    {
                        var neuesItem = new EinkaufsItem
                        {
                            Name = dialog.NeuerName,
                            Menge = dialog.NeueMenge,
                            Gekauft = false,
                            ErstelltAm = DateTime.Now,
                            RowVersion = new byte[0],  
                            BenutzerId = benutzerId   
                        };

                        var response = await client.PostAsJsonAsync("api/EinkaufsItems", neuesItem);
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            LadeEinkaufsitems();
                        }
                        else
                        {
                            MessageBox.Show($"Fehler beim Hinzufügen: {response.StatusCode}\n{responseBody}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kein Benutzer ausgewählt oder ungültige Benutzer-ID.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }



        private async void BearbeitenButton_Click(object sender, RoutedEventArgs e)
        {
            if (EinkaufslisteGrid.SelectedItem is EinkaufsItem ausgewähltesItem)
            {
                var dialog = new EditItemDialog(ausgewähltesItem.Name, ausgewähltesItem.Menge);
                if (dialog.ShowDialog() == true)
                {
                    ausgewähltesItem.Name = dialog.NeuerName;
                    ausgewähltesItem.Menge = dialog.NeueMenge;

                    var response = await client.PutAsJsonAsync($"api/EinkaufsItems/{ausgewähltesItem.Id}", ausgewähltesItem);

                    string responseBody = await response.Content.ReadAsStringAsync(); 

                    if (response.IsSuccessStatusCode)
                    {
                        LadeEinkaufsitems();
                    }
                    else
                    {
                        MessageBox.Show($"Fehler beim Bearbeiten: {response.StatusCode}\n{responseBody}"); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte einen Eintrag auswählen!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private async void LöschenButton_Click(object sender, RoutedEventArgs e)
        {
            if (EinkaufslisteGrid.SelectedItem is EinkaufsItem ausgewähltesItem)
            {
                var result = MessageBox.Show($"Möchtest du '{ausgewähltesItem.Name}' wirklich löschen?", "Löschen", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var response = await client.DeleteAsync($"api/EinkaufsItems/{ausgewähltesItem.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        LadeEinkaufsitems();
                    }
                    else
                    {
                        MessageBox.Show("Fehler beim Löschen.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte wähle ein Item zum Löschen aus.");
            }
        }
    }

    public class EinkaufsItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Menge { get; set; }
        public bool Gekauft { get; set; }
        public DateTime ErstelltAm { get; set; }
        public int BenutzerId { get; set; } 
        public byte[] RowVersion { get; set; }
    }

}
