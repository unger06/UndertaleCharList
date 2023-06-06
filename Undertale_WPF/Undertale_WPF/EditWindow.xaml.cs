using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MongoDB.Bson.IO;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using System.Diagnostics;
using System.Collections;
using System.Xml.Linq;

namespace Undertale_WPF
{
    /// <summary>
    /// Interaktionslogik für EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public ItemsCB ItemsCBAppearance { get; set; }
        MainChar mainChar = new MainChar();
        MainChar originalMainChar = new MainChar();
        List<MainChar.Ability> abilities = new List<MainChar.Ability>();
        List<MainChar.Ability> originalAbilities = new List<MainChar.Ability>();

        public EditWindow(object selectedItem)
        {
            InitializeComponent();

            mainChar = (MainChar)selectedItem;

            BuildOriginalChar(mainChar);
            //originalMainChar = mainChar;

            List<string> itemsAppearance = new List<string> { "Ruins", "Snowdin", "Waterfall", "Hotland", "The Core", "New Home" };
            ItemsCBAppearance = new ItemsCB(itemsAppearance);

            ItemsCBAppearance.Items = itemsAppearance;
            ItemsCBAppearance.Appearances = mainChar.Appearances;

            abilities.Clear();
            foreach (MainChar.Ability ab in mainChar.Abilities.Values)
            {
                abilities.Add(ab);
            }

            foreach (MainChar.Ability ab in abilities)
            {
                originalAbilities.Add(ab);
            }

            // Set DataContext to this so it works
            DataContext = this;
            SetExistingData(mainChar);

            Closing += Window_Closing;

            //List<string> itemsAppearance = new List<string> { "Ruins", "Snowdin", "Waterfall", "Hotland", "The Core", "New Home" };
            //ItemsCBAppearance = new ItemsCB(itemsAppearance);
            // Set the DataContext of the window to the selected item
            //DataContext = selectedItem;
        }

        private void BuildOriginalChar(MainChar newMainChar)
        {
            originalMainChar.Id = newMainChar.Id;
            originalMainChar.Name = newMainChar.Name;
            originalMainChar.Appearances = newMainChar.Appearances;
            originalMainChar.Role = newMainChar.Role;
            originalMainChar.Status = newMainChar.Status;
            originalMainChar.MaxHealth = newMainChar.MaxHealth;
            originalMainChar.Abilities = newMainChar.Abilities;
        }

        private void IsNumerical(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SetExistingData(MainChar mainChar)
        {
            // IF ANY ITEM GETS CHANGED IN THE ABILITY LIST OR THE FEATURE LIST AND THE WINDOW GETS CLOSED. AFTER IT GETS OPENED AGAIN ON THE SAME ITEM THE CHANGED VALUES ARE STILL IN THE LIST AND NOT THE ORIGINAL ITEMS
            nameEdit.Text = mainChar.Name;
            appearancesEditCB.SelectedItems = mainChar.Appearances;
            roleEdit.Text = mainChar.Role;
            statusEdit.Text = mainChar.Status;
            healthEdit.Text = mainChar.MaxHealth.ToString();

            //originalAbilityName = abilityName.Text;

            abilityNameLB.Items.Clear();
            foreach (MainChar.Ability ab in mainChar.Abilities.Values)
            {
                abilityNameLB.Items.Add(ab.Name);   
            }
        }

        private void ResetData()
        {
            mainChar = originalMainChar;
            /*
            //abilities = originalAbilities;
            abilities.Clear();
            foreach (MainChar.Ability ab in originalAbilities) 
            {
                abilities.Add(ab);
            }
            */
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ResetData();
        }

        private void addAbilityName_KeyDown(object sender, KeyEventArgs e)
        {
            // The difference between edit and add doesn't really work (SelectedItem)
            if (e.Key == Key.Return)
            {
                if (abilityNameLB.SelectedItem == null)
                {
                    addAbilityName();
                }
                else if (abilityNameLB.SelectedItem != null && !string.IsNullOrWhiteSpace(abilityName.Text))
                {
                    editAbilityName();
                }
            }
        }

        private void addAbilityFeature_KeyDown(object sender, KeyEventArgs e)
        {
            // The difference between edit and add doesn't really work (SelectedItem)
            if (e.Key == Key.Return)
            {
                if (abilityFeatureLB.SelectedItem == null)
                {
                    addAbilityFeature();
                    
                }
                else if (abilityFeatureLB.SelectedItem != null && !string.IsNullOrWhiteSpace(abilityFeature.Text))
                {
                    editAbilityFeature();
         
                }
            }
        }

        private void addAbilityFeature_OnClick(object sender, RoutedEventArgs e)
        {
            if (abilityFeatureLB.SelectedItem == null)
            {
                addAbilityFeature();

            }
            else if (abilityFeatureLB.SelectedItem != null && !string.IsNullOrWhiteSpace(abilityFeature.Text))
            {
                editAbilityFeature();

            }
        }

        private void addAbilityName_OnClick(object sender, RoutedEventArgs e)
        {
            if (abilityNameLB.SelectedItem == null)
            {
                addAbilityName();
            }
            else if (abilityNameLB.SelectedItem != null && !string.IsNullOrWhiteSpace(abilityName.Text))
            {
                editAbilityName();
            }
        }

        private void addAbilityName()
        {
            if (!string.IsNullOrWhiteSpace(abilityName.Text))
            {
                if (abilities.Count == 0)
                {
                    MainChar.Ability newAbility = new MainChar.Ability(abilityName.Text, new List<string>());
                    abilities.Add(newAbility);
                    abilityNameLB.Items.Add(newAbility.Name);
                    abilityName.Clear();
                }
                else if (abilities.Count > 0)
                {
                    bool isValid = true;

                    foreach (MainChar.Ability ab in abilities)
                    {
                        if (ab.Name.ToLower().Equals(abilityName.Text.ToLower()))
                        {
                            isValid = false;
                            MessageBox.Show("Ability Name already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }
                    }
                    if (isValid)
                    {
                        MainChar.Ability newAbility = new MainChar.Ability(abilityName.Text, new List<string>());
                        abilities.Add(newAbility);
                        abilityNameLB.Items.Add(newAbility.Name);
                        abilityName.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Cannot add an empty Abillity Name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void editAbilityName()
        {
            foreach (MainChar.Ability ab in abilities)
            {
                if (abilityNameLB.SelectedItem.ToString() == ab.Name)
                {
                    //ab.Name = abList.Name;
                    //ab.Features = abList.Features;

                    int itemIndex = abilityNameLB.Items.IndexOf(ab.Name);

                    abilityNameLB.Items.Remove(ab.Name);
                    // ALTERNATIVELY CHANGE THE ABILITY DIRECTLY BUT IF I CLOSE THE WINDOW THEN THE ABILITY DOESN'T RESET PROPERLY
                    ab.Name = abilityName.Text;
                    abilityNameLB.Items.Insert(itemIndex, abilityName.Text);
                    abilityNameLB.Items.Refresh();
                    abilityNameLB.SelectedIndex = itemIndex;
                    
                    break;
                }
            }            
        }

        private void addAbilityFeature()
        {
            if (!string.IsNullOrWhiteSpace(abilityFeature.Text))
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
                            if (feature.ToLower().Equals(abilityFeature.Text.ToLower()))
                            {
                                isValid = false;
                                MessageBox.Show("Ability Feature already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        if (isValid)
                        {
                            item.Features.Add(abilityFeature.Text);

                            // so that the user doesn't have to change the selection to view all Features
                            // the Feature List gets updated as soon as a new Feature gets added
                            //abilityFeatureLB.ItemsSource = null;
                            //abilityFeatureLB.ItemsSource = item.Features;
                            abilityFeatureLB.Items.Refresh();

                            abilityFeature.Clear();
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

        private void editAbilityFeature()
        {
            MainChar.Ability ab = new MainChar.Ability("", new List<string>());
            foreach (MainChar.Ability abList in abilities)
            {
                if (abilityNameLB.SelectedItem.ToString() == abList.Name)
                {
                    ab.Name = abList.Name;
                    ab.Features = abList.Features;
                }
            }
            
            foreach (string fe in ab.Features.ToList())
            {
                if (abilityFeatureLB.SelectedItem.ToString() == fe)
                {
                    int itemIndex = ab.Features.IndexOf(fe);
                    string feature = ab.Features.ElementAt(itemIndex);

                    ab.Features.RemoveAt(itemIndex);
                    ab.Features.Insert(itemIndex, abilityFeature.Text);
                    abilityFeatureLB.Items.Refresh();
                    abilityFeatureLB.SelectedIndex = itemIndex;
                    break;
                }
            }
            Trace.WriteLine(originalMainChar.Name);
            foreach (MainChar.Ability ability in originalMainChar.Abilities.Values)
            {
                foreach (string feature in ability.Features)
                {
                    Trace.WriteLine(feature);
                }

            }
        }

        private void ShowErrorWindow(string message, MessageBoxImage boxImage)
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

                abilityName.Text = selectedItem;
            }
        }

        private void abilityFeatureLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected item from the ListBox
            string selectedItem = abilityFeatureLB.SelectedItem as string;

            abilityFeature.Text = selectedItem;
        }

        private void removeAbility_Click(object sender, RoutedEventArgs e)
        {
            var item = abilities.FirstOrDefault(x => x.Name == (sender as Button).DataContext.ToString());
            if (item != null)
            {
                //var item = (sender as Button).DataContext;
                abilityNameLB.Items.Remove((sender as Button).DataContext);
                abilities.Remove(item);

                if (abilityNameLB.SelectedItem != null)
                {
                    if (item.Name == abilityNameLB.SelectedItem.ToString())
                    {
                        abilityFeatureLB.ItemsSource = null;    // so the Features of the deleted Ability are also gone (if not, then the Features remain in the list as long as the user doesn't change the "Ability Name"-Selection)
                        abilityName.Clear();
                    }
                }

                abilityFeatureLB.Items.Refresh();
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

        private void clearListSelection(object sender, RoutedEventArgs e)
        {
            abilityNameLB.SelectedItem = null;
            abilityFeatureLB.ItemsSource = null;
            abilityName.Clear();
            abilityFeature.Clear();
        }

        private void UpdateItem_Click(object sender, RoutedEventArgs e)
        {
            _ = UpdateItemAsync(BuildFinalChar());
        }

        private async Task UpdateItemAsync(MainChar mainChar)
        {

            using (var httpClient = new HttpClient())
            {
                // Set the base URL of your API
                httpClient.BaseAddress = new Uri("http://localhost:6969/char/mainChar");

                // Set the Accept header to JSON
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Serialize the Item object to JSON

                var json = JsonConvert.SerializeObject(mainChar);

                // Send the PUT request to the API
                var response = await httpClient.PutAsync($"/{mainChar.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                // Throw an exception if the response is not successful
                response.EnsureSuccessStatusCode();
            }
        }

        private MainChar BuildFinalChar()
        {
            
            List<string> appearances = new List<string>();

            foreach (string appearance in appearancesEditCB.SelectedItems)
            {
                appearances.Add(appearance);
            }

            // MAKE A NEW DICTIONARY FOR THE MODIFIED ITEMS IN THE ABILITY LIST
            MainChar finalChar = new MainChar(
                originalMainChar.Id,
                nameEdit.Text,
                appearances,
                roleEdit.Text,
                statusEdit.Text,
                int.Parse(healthEdit.Text),
                new Dictionary<string, MainChar.Ability>()
            );

            foreach (string abilityName in abilityNameLB.Items)
            {
                MainChar.Ability ability = new MainChar.Ability("", new List<string>());
            }
            return mainChar;   
        }
    }
}