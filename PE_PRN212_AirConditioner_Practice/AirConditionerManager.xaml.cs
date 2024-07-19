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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PE_PRN212_AirConditioner_Practice
{
    /// <summary>
    /// Interaction logic for AirConditionerManager.xaml
    /// </summary>
    public partial class AirConditionerManager : Window
    {
        public AirConditionerManager()
        {
            InitializeComponent();
            LoadAllTable();
        }

        public void LoadAllTable()
        {
            AirConditionerService airConditionerService = new AirConditionerService();
            ListACDataGrid.ItemsSource = airConditionerService.LoadAllTable();
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            InputForm inputForm = new InputForm(LoadAllTable);
            inputForm.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListACDataGrid.SelectedItem is AirConditioner selectedAir)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete the book '{selectedAir.AirConditionerName}'?",
                    "Delete Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    AirConditionerService airConditionerService = new();
                    airConditionerService.Delete(selectedAir);
                    LoadAllTable();
                }
            }
            else
            {
                MessageBox.Show("Please select an Airconditioner to delete.");
            }
        }
    }
}
