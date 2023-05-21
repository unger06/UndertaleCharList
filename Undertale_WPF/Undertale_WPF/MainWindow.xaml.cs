using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Undertale_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ItemsCB ItemsCBAppearance { get; set; }
        List<MainChar.Ability> abilities = new List<MainChar.Ability>();
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();

            List<string> itemsAppearance = new List<string> { "Ruins", "Snowdin", "Waterfall", "Hotland", "The Core", "New Home" };
            ItemsCBAppearance = new ItemsCB(itemsAppearance);
            mainCharControls.Visibility = Visibility.Collapsed;
            npcControls.Visibility = Visibility.Collapsed;
            vendorControls.Visibility = Visibility.Collapsed;

            DataContext = this;    
        }

        private void IsNumerical(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch(checkCharacterType())
            {
                case "mainChar":
                    {
                        // Get the selected item from the ListView
                        var selectedItem = myListView.SelectedItem;

                        // Create a new instance of the edit window
                        var editWindow = new EditWindow(selectedItem);

                        // Show the edit window
                        editWindow.ShowDialog();
                        break;
                    }

                case "npc":
                    {
                        var selectedItem = myListView.SelectedItem;
                        var editWindow = new EditWindowNPC(selectedItem);
                        editWindow.ShowDialog();
                        break;
                    }

                /*case "vendor":
                    {
                        var selectedItem = myListView.SelectedItem;
                        var editWindow = new EditWindowVendor(selectedItem);
                        editWindow.ShowDialog();
                        break;
                    }*/
            }

        }

        private async void radioBtnAll_Click(object sender, RoutedEventArgs e)
        {
            var response = await client.GetAsync("http://localhost:6969/char");
            //var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            if (response.IsSuccessStatusCode)
            {
                // USE SOMETHING ELSE INSTEAD OF THE INTERFACE / THROWS AN ERROR
                var json = await response.Content.ReadAsStringAsync();
                var chars = JsonConvert.DeserializeObject<List<Interface1>>(json);

                if (chars != null)
                {
                    //lstChars.Items.Clear();

                    foreach (Interface1 i in chars)
                    {
                        //lstChars.Items.Add(i.Name);
                    }
                }
            }
            else
            {
                //lstChars.Items.Add("Couldn't get Data!");
            }
        }

        private async void radioBtnMain_Click(object sender, RoutedEventArgs e)
        {
            var response = await client.GetAsync("http://localhost:6969/char/mainChar");
            //var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var mainChars = JsonConvert.DeserializeObject<List<MainChar>>(json);

                if (mainChars != null)
                {
                    // FOR lstChars AND NOT FOR THE LISTVIEW //
                    //lstChars.Items.Clear();
                    myListView.ItemsSource = mainChars;

                    mainCharControls.Visibility = Visibility.Visible;
                    npcControls.Visibility = Visibility.Collapsed;
                    vendorControls.Visibility = Visibility.Collapsed;
                    // FOR lstChars AND NOT FOR THE LISTVIEW //
                    /*foreach (MainChar mc in mainChars)
                    {
                        lstChars.Items.Add(mc.Name);
                    }*/
                }
            }
            else
            {
                // FOR lstChars AND NOT FOR THE LISTVIEW //
                //lstChars.Items.Add("Couldn't get Data!");
                myListView.Items.Add("Couldn't get Data!");
            }
        }

        private async void radioBtnNpc_Click(object sender, RoutedEventArgs e)
        {
            var response = await client.GetAsync("http://localhost:6969/char/npc");
            //var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var npcs = JsonConvert.DeserializeObject<List<Npc>>(json);

                if (npcs != null)
                {
                    // FOR lstChars AND NOT FOR THE LISTVIEW //
                    //lstChars.Items.Clear();
              
                    myListView.ItemsSource = npcs;

                    mainCharControls.Visibility = Visibility.Collapsed;
                    npcControls.Visibility = Visibility.Visible;
                    vendorControls.Visibility = Visibility.Collapsed;
                    // FOR lstChars AND NOT FOR THE LISTVIEW //
                    /*foreach (Npc n in npcs)
                    {
                        lstChars.Items.Add(n.Name);
                    }*/
                }
            }
            else
            {
                // FOR lstChars AND NOT FOR THE LISTVIEW //
                //lstChars.Items.Add("Couldn't get Data!");
                myListView.Items.Add("Couldn't get Data!");
            }
        }

        private async void radioBtnVendor_Click(object sender, RoutedEventArgs e)
        {
            var response = await client.GetAsync("http://localhost:6969/char/vendor");
            //var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var vendors = JsonConvert.DeserializeObject<List<Vendor>>(json);

                if(vendors != null)
                {
                    // FOR lstChars AND NOT FOR THE LISTVIEW //
                    //lstChars.Items.Clear();
                    myListView.ItemsSource = vendors;

                    mainCharControls.Visibility = Visibility.Collapsed;
                    npcControls.Visibility = Visibility.Collapsed;
                    vendorControls.Visibility = Visibility.Visible;
                    // FOR lstChars AND NOT FOR THE LISTVIEW //
                    /*foreach (Vendor v in vendors)
                    {
                        lstChars.Items.Add(v.Name);
                    }*/
                }
            }
            else
            {
                // FOR lstChars AND NOT FOR THE LISTVIEW //
                //lstChars.Items.Add("Couldn't get Data!");
                myListView.Items.Add("Couldn't get Data!");
            }
        }

        private void abilityName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                addAbilityName();
            }
        }

        private void abilityFeature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                addAbilityFeature();
            }
        }
        private void abilityFeature_OnClick(object sender, RoutedEventArgs e)
        {
            addAbilityFeature();
        }

        private void abilityName_OnClick(object sender, RoutedEventArgs e)
        {
            addAbilityName();
        }

        private void addAbilityName()
        {
            if (!string.IsNullOrWhiteSpace(abilityNameMC.Text))
            {
                if (abilities.Count == 0)
                {
                    MainChar.Ability newAbility = new MainChar.Ability(abilityNameMC.Text, new List<string>());
                    abilities.Add(newAbility);
                    abilityNameLB.Items.Add(newAbility.Name);
                    abilityNameMC.Clear();
                }
                else if (abilities.Count > 0)
                {
                    bool isValid = true;

                    foreach (MainChar.Ability ab in abilities)
                    {
                        if (ab.Name.ToLower().Equals(abilityNameMC.Text.ToLower()))
                        {
                            isValid = false;
                            MessageBox.Show("Ability Name already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                    }
                    if (isValid)
                    {
                        MainChar.Ability newAbility = new MainChar.Ability(abilityNameMC.Text, new List<string>());
                        abilities.Add(newAbility);
                        abilityNameLB.Items.Add(newAbility.Name);
                        abilityNameMC.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot add an empty Abillity Name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void addAbilityFeature()
        {
            if (!string.IsNullOrWhiteSpace(abilityFeatureMC.Text))
            {
                if (abilityNameLB.SelectedItem != null)
                {
                    // Get the selected item from the ListBox
                    string selectedItem = abilityNameLB.SelectedItem as string;

                    // Find the corresponding item in the List
                    var item = abilities.FirstOrDefault(x => x.Name == selectedItem);

                    // Display the item's information in the other ListBox
                    if (item != null)
                    {
                        bool isValid = true;

                        foreach (string feature in item.Features)
                        {
                            if (feature.ToLower().Equals(abilityFeatureMC.Text.ToLower()))
                            {
                                isValid = false;
                                MessageBox.Show("Ability Feature already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        if (isValid)
                        {
                            item.Features.Add(abilityFeatureMC.Text);

                            // so that the user doesn't have to change the selection to view all Features
                            // the Feature List gets updated as soon as a new Feature gets added
                            abilityFeatureLB.ItemsSource = null;
                            abilityFeatureLB.ItemsSource = item.Features;

                            abilityFeatureMC.Clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select an Ability first before adding a new Feature!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Cannot add an empty Ability Feature!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowErrorWindow (string message, MessageBoxImage boxImage)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, boxImage);
        }

        private void abilityNameLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected item from the ListBox
            string selectedItem = abilityNameLB.SelectedItem as string;

            // Find the corresponding item in the List
            var item = abilities.FirstOrDefault(x => x.Name == selectedItem);

            // Display the item's information in the other ListBox
            if (item != null)
            {
                abilityFeatureLB.ItemsSource = item.Features;
            }
        }

        private void removeAbility_Click(object sender, RoutedEventArgs e)
        {
            var item = abilities.FirstOrDefault(x => x.Name == (sender as Button).DataContext.ToString());
            if(item != null)
            {
                //var item = (sender as Button).DataContext;
                abilityNameLB.Items.Remove((sender as Button).DataContext);
                abilities.Remove(item);
                abilityFeatureLB.ItemsSource = null;    // so the Features of the deleted Ability are also gone (if not, then the Features remain in the list as long as the user doesn't change the "Ability Name"-Selection)
            }
        }

        private void removeFeature_Click(object sender, RoutedEventArgs e)
        {
            var feature = (sender as Button).DataContext;
            var item = abilities.FirstOrDefault(x => x.Features.Contains(feature.ToString()));

            if (item != null && feature != null)
            {
                // the object in the list gets edited directly | Remove the ItemsSource from the List and then add it again at the end so it works
                abilityFeatureLB.ItemsSource = null;
                //abilityFeatureLB.Items.Remove(feature);   // isn't allowed when using "ItemsSource"
                item.Features.Remove(feature.ToString());   
                abilityFeatureLB.ItemsSource = item.Features;
            }
        }

        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var itemId = button.Tag as string;
            Trace.WriteLine(itemId);

            await DeleteItem(checkCharacterType(), itemId);

            // Refresh the ListView data here if needed
        }

        public async Task DeleteItem(string path, string documentId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:6969");

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var request = new HttpRequestMessage(HttpMethod.Delete, $"/char/{path}/{documentId}");
                    Trace.WriteLine(documentId);
                    Trace.WriteLine(request.ToString());
                    
                    var response = await client.SendAsync(request);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Character successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<Error>(responseContent);
                        throw new Exception($"Error deleting document: {error.Message}");
                    }
                }

                // UPDATE THE LISTVIEW RIGHT AFTER THE CHARACTER GETS DELETED
                switch(path)
                {
                    case "mainChar": radioBtnMain_Click(null, null); break;
                    case "npc": radioBtnNpc_Click(null, null); break;
                    case "vendor": radioBtnVendor_Click(null, null); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void PostItem_Click(object sender, RoutedEventArgs e)
        {
            // Name, Role, Appearances, MaxHealth are required fields/Abilites don't have to be added right away
            switch(checkCharacterType())
            {
                case "mainChar":
                    {
                        if (!string.IsNullOrWhiteSpace(nameMC.Text) && AppearancesMC.SelectedItems.Count != 0 && !string.IsNullOrWhiteSpace(roleMC.Text) && !string.IsNullOrWhiteSpace(healthMC.Text))
                        {
                            MainChar mainChar = buildMainChar();

                            await PostItemAsync(mainChar);

                            abilities.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Please fill out the required fields which are marked with a star (<name>*)!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    }
                case "npc":
                    {
                        if(!string.IsNullOrWhiteSpace(nameNPC.Text) && AppearancesNPC.SelectedItems.Count != 0 && !string.IsNullOrWhiteSpace(roleNPC.Text))
                        {
                            Npc npc = buildNPC();

                            await PostItemAsync(npc);
                        }
                        else
                        {
                            MessageBox.Show("Please fill out the required fields which are marked with a star (<name>*)!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    }
            }
            


        }

        private MainChar buildMainChar()
        {
            // CONVERT APPEARANCES
            List<string> appearances = new List<string>();
            //Trace.WriteLine(AppearancesMC.SelectedItems.Count);
            foreach (string ap in AppearancesMC.SelectedItems)
            {
                appearances.Add(ap);
            }

            // CONVERT ABILITIES
            Dictionary<string, MainChar.Ability> abilitiesDic = new Dictionary<string, MainChar.Ability>();
            int abilityCount = 0;
            string abilityKey = "ability" + abilityCount;

            foreach (MainChar.Ability ab in abilities)
            {
                abilityCount++;
                abilityKey = "ability" + abilityCount;
                Trace.WriteLine(abilityKey);

                abilitiesDic.Add(abilityKey, ab);
            }

            foreach (MainChar.Ability ab in abilitiesDic.Values)
            {
                Trace.WriteLine(ab.Name);
                foreach (string fe in ab.Features)
                {
                    Trace.WriteLine(fe);
                }
            }

            MainChar mainChar = new MainChar(null, nameMC.Text, appearances, roleMC.Text, statusMC.Text, int.Parse(healthMC.Text), abilitiesDic);
            return mainChar;
        }

        private Npc buildNPC()
        {
            // CONVERT APPEARANCES
            List<string> appearances = new List<string>();
            //Trace.WriteLine(AppearancesMC.SelectedItems.Count);
            foreach (string ap in AppearancesNPC.SelectedItems)
            {
                appearances.Add(ap);
            }

            Npc npc = new Npc(null, nameNPC.Text, appearances, roleNPC.Text, statusNPC.Text);
            return npc;
        }

        public async Task PostItemAsync(object character)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:6969");

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string json = JsonConvert.SerializeObject(character);
                    Trace.WriteLine(json);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"/char/{checkCharacterType()}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Character successfully added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var error = JsonConvert.DeserializeObject<Error>(responseContent);
                        throw new Exception($"Error creating document: {error.Message}");
                    }
                }

                // UPDATE THE LISTVIEW RIGHT AFTER THE CHARACTER GETS POSTED
                switch(checkCharacterType())
                {
                    case "mainChar": radioBtnMain_Click(null, null); break;
                    case "npc": radioBtnNpc_Click(null, null); break;
                    case "vendor": radioBtnVendor_Click(null, null); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string checkCharacterType()
        {
            string path = "";

            if (radioBtnMain.IsChecked == true)
            {
                path = "mainChar";
            }
            else if (radioBtnNpc.IsChecked == true)
            {
                path = "npc";
            }
            else if (radioBtnVendor.IsChecked == true)
            {
                path = "vendor";
            }

            return path;
        }

        public class Error
        {
            public string Message { get; set; }
        }
    }
}