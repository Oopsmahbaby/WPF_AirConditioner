using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PE_PRN212_AirConditioner_Practice
{
    /// <summary>
    /// Interaction logic for InputForm.xaml
    /// </summary>
    public partial class InputForm : Window
    {
        private readonly Action _refreshACList;

        public InputForm(Action refreshACList)
        {
            InitializeComponent();
            LoadSupplier();
            _refreshACList = refreshACList;
        }

        public void LoadSupplier()
        {
            AirConditionerService airConditionerService = new AirConditionerService();
            SupplierIdComboBox.ItemsSource = airConditionerService.GetAllCompany();
            SupplierIdComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(AirConditionerIdTextBox.Text);
            string acName = AirConditionerNameTextBox.Text;
            string warranty = WarrantyTextBox.Text;
            string soundLv = SoundPressureLevelTextBox.Text;
            string feature = FeatureFunctionTextBox.Text;
            string supplierId = (string)SupplierIdComboBox.SelectedValue;

            AirConditionerService airConditionerService = new();
            AirConditioner? airConditioner = airConditionerService.CheckIdExist(id);
            if (airConditioner != null)
            {
                System.Windows.MessageBox.Show("Id cannot be duplicated", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(acName))
            {
                System.Windows.MessageBox.Show("Airconditioner Name must be filled", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                System.Windows.MessageBox.Show("Quantity must be a valid number greater than 0.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(DollarPriceTextBox.Text, out double dollarPrice) || dollarPrice <= 0)
            {
                System.Windows.MessageBox.Show("Price must be a valid number greater than 0.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            airConditioner = new AirConditioner
            {
                AirConditionerId = id,
                AirConditionerName = acName,
                Warranty = warranty,
                SoundPressureLevel = soundLv,
                FeatureFunction = feature,
                Quantity = quantity,
                DollarPrice = dollarPrice,
                SupplierId = supplierId,
            };
            airConditionerService.AddAC(airConditioner);
            System.Windows.MessageBox.Show("Airconditioner added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            _refreshACList.Invoke();
            ClearFields();
        }

        public void ClearFields()
        {
            AirConditionerIdTextBox.Clear();
            AirConditionerNameTextBox.Clear();
            WarrantyTextBox.Clear();
            SoundPressureLevelTextBox.Clear();
            FeatureFunctionTextBox.Clear();
            QuantityTextBox.Clear();
            DollarPriceTextBox.Clear();
            SupplierIdComboBox.SelectedIndex = 0;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
