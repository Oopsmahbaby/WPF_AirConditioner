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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string email = txtboxEmail.Text;
            string password = txtboxPassword.Password;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                System.Windows.Forms.MessageBox.Show("Pleae input both email & password", "Input plz.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StaffMemberService staffMemberService = new StaffMemberService();
            StaffMember? staffMember = staffMemberService.CheckLogin(email, password);
            if (staffMember == null)
            {
                System.Windows.Forms.MessageBox.Show("Login failed. Check the email and password again!", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AirConditionerManager airConditionerManager = new AirConditionerManager();
            airConditionerManager.ShowDialog();
            this.Close();
        }
    }
}
