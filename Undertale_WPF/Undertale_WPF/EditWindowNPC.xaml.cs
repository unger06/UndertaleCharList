using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Undertale_WPF
{
    /// <summary>
    /// Interaction logic for EditWindowNPC.xaml
    /// </summary>
    public partial class EditWindowNPC : Window
    {
        public ItemsCB ItemsCBAppearance { get; set; }
        Npc npc = new Npc();

        public EditWindowNPC(object selectedItem)
        {
            InitializeComponent();

            npc = (Npc)selectedItem;

            List<string> itemsAppearance = new List<string> { "Ruins", "Snowdin", "Waterfall", "Hotland", "The Core", "New Home" };
            ItemsCBAppearance = new ItemsCB(itemsAppearance);

            ItemsCBAppearance.Items = itemsAppearance;
            ItemsCBAppearance.Appearances = npc.Appearances;

            DataContext = this;
            SetExistingData();
        }

        private void SetExistingData()
        {
            nameNpc.Text = npc.Name;
            AppearancesNpc.SelectedItems = npc.Appearances;
            roleNpc.Text = npc.Role;
            statusNpc.Text = npc.Status;
        }

        private async void UpdateItemAsync_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameNpc.Text) && AppearancesNpc.SelectedItems.Count != 0 && !string.IsNullOrWhiteSpace(roleNpc.Text))
            {
                Npc npc = BuildFinalNpc();

                await UpdateItemAsync(npc);
            }
            else
            {
                MessageBox.Show("Please fill out the required fields which are marked with a star (<name>*)!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private async Task UpdateItemAsync(Npc npc)
        {
            // FIX THE ISSUE WITH UPDATING (PUT-METHODS) NOT ALLOWED

            using (var httpClient = new HttpClient())
            {
                // Set the base URL of your API
                httpClient.BaseAddress = new Uri("http://localhost:6969/char/npc");

                // Set the Accept header to JSON
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Serialize the Item object to JSON

                var json = JsonConvert.SerializeObject(npc);
                Console.WriteLine(npc.Id);
                // Send the PUT request to the API
                var response = await httpClient.PutAsync($"/{npc.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                // Throw an exception if the response is not successful
                response.EnsureSuccessStatusCode();
            }
            this.Close();
        }

        private Npc BuildFinalNpc()
        {
            List<string> appearances = new List<string>();

            foreach (string appearance in AppearancesNpc.SelectedItems)
            {
                appearances.Add(appearance);
            }

            Npc finalNpc = new Npc(
                npc.Id,
                nameNpc.Text,
                appearances,
                roleNpc.Text,
                statusNpc.Text);

            return finalNpc;
        }
        
        private void ResetData()
        {
            nameNpc.Name = npc.Name;
            AppearancesNpc.SelectedItems = npc.Appearances;
            roleNpc.Text = npc.Role;
            statusNpc.Text = npc.Status;
        }
    }
}
