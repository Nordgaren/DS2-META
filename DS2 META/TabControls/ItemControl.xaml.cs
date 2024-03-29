﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DS2_META
{
    /// <summary>
    /// Interaction logic for ItemControl.xaml
    /// </summary>
    public partial class ItemControl : METAControl
    {
        public ItemControl()
        {
            InitializeComponent();
        }

        public override void InitTab()
        {
            cmbCategory.ItemsSource = DS2ItemCategory.All;
            cmbCategory.SelectedIndex = 0;
            FilterItems();
            InventoryTimer.Interval = 100;
            InventoryTimer.Elapsed += InventoryTimer_Elapsed;
        }

        private void InventoryTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (Properties.Settings.Default.UpdateMaxLive)
                    HandleMaxAvailable();
            }));
        }

        private void HandleMaxAvailable()
        {
            if (cbxQuantityRestrict.IsChecked.Value)
            {
                DS2Item item = lbxItems.SelectedItem as DS2Item;
                if (item == null)
                    return;

                var max = Hook.GetMaxQuantity(item);
                var held = Hook.GetHeld(item);
                var diff = max - held;
                if (diff != nudQuantity.Maximum)
                {
                    nudQuantity.Maximum = diff;
                    if (cbxMax.IsChecked.Value)
                        nudQuantity.Value = nudQuantity.Maximum;

                    nudQuantity.IsEnabled = nudQuantity.Maximum > 1;
                    txtMaxHeld.Visibility = nudQuantity.Maximum > 0 ? Visibility.Hidden : Visibility.Visible;
                }
            }
        }

        internal override void ReloadCtrl()
        {
            lbxItems.SelectedIndex = -1;
            lbxItems.SelectedIndex = 0;
        }

        internal override void EnableCtrls(bool enable)
        {
            InventoryTimer.Enabled = enable;
            btnCreate.IsEnabled= enable;

            if (enable)
                UpdateCreateEnabled();
        }

        Timer InventoryTimer = new Timer();
        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterItems();
        }

        //Clear items and add the ones that match text in search box
        private void FilterItems()
        {
            lbxItems.Items.Clear();

            if (SearchAllCheckbox.IsChecked.Value && txtSearch.Text != "")
            {
                //search every item category
                foreach (DS2ItemCategory category in cmbCategory.Items)
                {
                    foreach (DS2Item item in category.Items)
                    {
                        if (item.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                            lbxItems.Items.Add(item);
                    }
                }
            }
            else
            {
                //only search selected item category
                DS2ItemCategory category = cmbCategory.SelectedItem as DS2ItemCategory;
                foreach (DS2Item item in category.Items)
                {
                    if (item.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                        lbxItems.Items.Add(item);
                }
            }

            if (lbxItems.Items.Count > 0)
                lbxItems.SelectedIndex = 0;

            HandleSearchLabel();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterItems();
        }

        //Handles the "Searching..." label on the text box
        private void HandleSearchLabel()
        {
            if (txtSearch.Text == "")
                lblSearch.Visibility = Visibility.Visible;
            else
                lblSearch.Visibility = Visibility.Hidden;

        }

        private void cbxQuantityRestrict_Checked(object sender, RoutedEventArgs e)
        {
            if (lbxItems == null)
                return;

            DS2Item item = lbxItems.SelectedItem as DS2Item;
            if (item == null)
                return;

            if (!cbxQuantityRestrict.IsChecked.Value)
            {
                var max = Hook.GetMaxQuantity(item);
                var held = Hook.GetHeld(item);
                nudQuantity.IsEnabled = true;
                nudQuantity.Maximum = 99;
                txtMaxHeld.Visibility = max - held > 0 ? Visibility.Hidden : Visibility.Visible;
            }
            else if (lbxItems.SelectedIndex != -1)
            {
                var max = Hook.GetMaxQuantity(item);
                var held = Hook.GetHeld(item);
                nudQuantity.Maximum = max - held;
                nudQuantity.IsEnabled = nudQuantity.Maximum > 1;
                txtMaxHeld.Visibility = nudQuantity.Maximum > 0 ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void cmbInfusion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var infusion = cmbInfusion.SelectedItem as DS2Infusion;
            //Checks if cbxMaxUpgrade is checked and sets the value to max value
            HandleMaxItemCheckbox();

        }

        private void lbxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!Hook.Hooked) return;

            DS2Item item = lbxItems.SelectedItem as DS2Item;
            if (item == null)
                return;

            if (cbxQuantityRestrict.IsChecked.Value)
            {
                txtMaxHeld.Visibility = nudQuantity.Maximum > 0 ? Visibility.Hidden : Visibility.Visible;

                var max = Hook.GetMaxQuantity(item);
                var held = Hook.GetHeld(item);
                nudQuantity.Maximum = 99;
                nudQuantity.IsEnabled = true;
                txtMaxHeld.Visibility = max - held > 0 ? Visibility.Hidden : Visibility.Visible;
            }

            cmbInfusion.Items.Clear();
            if (item.Type == DS2Item.ItemType.Weapon)
                foreach (var infusion in Hook.GetWeaponInfusions(item.ID))
                    cmbInfusion.Items.Add(infusion);
            else
                cmbInfusion.Items.Add(DS2Infusion.Infusions[0]);
            
            cmbInfusion.SelectedIndex = 0;
            cmbInfusion.IsEnabled = cmbInfusion.Items.Count > 1;

            nudUpgrade.Maximum = Hook.GetMaxUpgrade(item);
            nudUpgrade.IsEnabled = nudUpgrade.Maximum > 0;

            btnCreate.IsEnabled = Hook.GetIsDroppable(item.ID) || Properties.Settings.Default.SpawnUndroppable;
            if (!Properties.Settings.Default.UpdateMaxLive)
                HandleMaxAvailable();
            HandleMaxItemCheckbox();
        }

        public void UpdateCreateEnabled()
        {
            DS2Item item = lbxItems.SelectedItem as DS2Item;
            if (item == null)
                return;

            btnCreate.IsEnabled = Hook.GetIsDroppable(item.ID) || Properties.Settings.Default.SpawnUndroppable;
        }

        internal void EnableStats(bool enable)
        {
            btnCreate.IsEnabled = enable;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateItem();
        }

        //Apply hair to currently loaded character
        public void CreateItem()
        {
            if (!Properties.Settings.Default.UpdateMaxLive)
                HandleMaxAvailable();
            //Check if the button is enabled and the selected item isn't null
            if (btnCreate.IsEnabled && lbxItems.SelectedItem != null)
            {
                _ = ChangeColor(Brushes.DarkGray);
                DS2Item item = lbxItems.SelectedItem as DS2Item;
                if (item == null)
                    return;

                var id = item.ID;

                var infusion = cmbInfusion.SelectedItem as DS2Infusion;
                Hook.GetItem(id, (short)nudQuantity.Value, (byte)nudUpgrade.Value, (byte)infusion.ID);
                if (!Properties.Settings.Default.UpdateMaxLive)
                    HandleMaxAvailable();
            }
        }

        //handles up and down scrolling
        private void ScrollListbox(KeyEventArgs e)
        {
            //Scroll down through Items listbox and go back to bottom at end
            if (e.Key == Key.Up)
            {
                e.Handled = true;//Do not pass keypress along

                //One liner meme that does the exact same thing as the code above
                lbxItems.SelectedIndex = ((lbxItems.SelectedIndex - 1) + lbxItems.Items.Count) % lbxItems.Items.Count;
                lbxItems.ScrollIntoView(lbxItems.SelectedItem);
                return;
            }

            //Scroll down through Items listbox and go back to top at end
            if (e.Key == Key.Down)
            {
                e.Handled = true;//Do not pass keypress along

                //One liner meme that does the exact same thing as the code above
                lbxItems.SelectedIndex = (lbxItems.SelectedIndex + 1) % lbxItems.Items.Count;
                lbxItems.ScrollIntoView(lbxItems.SelectedItem);
                return;
            }
        }

        //Changes the color of the Apply button
        private async Task ChangeColor(Brush new_color)
        {
            btnCreate.Background = new_color;

            await Task.Delay(TimeSpan.FromSeconds(.25));

            btnCreate.Background = default(Brush);
        }

        //handles escape
        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                txtSearch.Clear();
                return;
            }

            //Create selected index as item
            if (e.Key == Key.Enter)
            {
                e.Handled = true; //Do not pass keypress along
                CreateItem();
                return;
            }

            //Return if sender is cmbInfusion so that arrow Key are handled correctly
            if (sender == cmbInfusion)
                return;
            //Prevents up and down Key from moving the cursor left and right when nothing in item box
            if (lbxItems.Items.Count == 0)
            {
                if (e.Key == Key.Up)
                    e.Handled = true; //Do not pass keypress along
                if (e.Key == Key.Down)
                    e.Handled = true; //Do not pass keypress along
                return;
            }

            ScrollListbox(e);
        }

        //Select number in nud
        private void nudUpgrade_Click(object sender, EventArgs e)
        {
            nudUpgrade.Focus();
        }

        private void SearchAllCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //checkbox changed, refresh search filter (if txtSearch is not empty)
            if (txtSearch.Text != "")
                FilterItems();
        }

        private void cbxMaxUpgrade_Checked(object sender, RoutedEventArgs e)
        {
            //HandleMaxItemCheckbox()
            if (cbxMax.IsChecked.Value)
            {
                nudUpgrade.Value = nudUpgrade.Maximum;
                nudQuantity.Value = nudQuantity.Maximum;
            }
            else
            {
                nudUpgrade.Value = nudUpgrade.Minimum;
                nudQuantity.Value = nudQuantity.Minimum;
            }
        }

        private void HandleMaxItemCheckbox()
        {
            //Set upgrade nud to max if max checkbox is ticked
            if (cbxMax.IsChecked.Value)
            {
                nudUpgrade.Value = nudUpgrade.Maximum;
                nudQuantity.Value = nudQuantity.Maximum;
            }
        }

        private void cmbInfusion_KeyDown(object sender, KeyEventArgs e)
        {
            //Create selected index as item
            if (e.Key == Key.Enter)
            {
                e.Handled = true; //Do not pass keypress along
                CreateItem();
                return;
            }
        }
        //Select all text in search box
        private void txtSearch_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txtSearch.SelectAll();
            txtSearch.Focus();
            e.Handled = true;
        }

        private void SearchAllCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text != "")
                FilterItems();
        }
    }
}
