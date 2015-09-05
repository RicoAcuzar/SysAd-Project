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
using MahApps.Metro.Controls;
using BusinessLogic;

namespace Wpf_SysAdUI
{
    /// <summary>
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : MetroWindow
    {
        public ManageAccount()
        {
            InitializeComponent();
        }
       

        private async void create_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(create_btn, 0.0, TimeSpan.FromMilliseconds(0));
            //////
            //Check username
            if (create_username.Text.Trim() == "") { }
            else if (await Globals.UsernameExists(create_username.Text.Trim()))
            {
                MessageBox.Show("Username already taken.");
                return;
            }

            //Check password
            string pw1 = "", pw2 = "";
            foreach (char c in create_password.Password)
                pw1 += c;
            foreach (char c in retype_password.Password)
                pw2 += c;
            if (pw1.Contains(' ') || pw2.Contains(' '))
            {
                MessageBox.Show("Passwords must not contain spaces.");
                return;
            }
            if (pw1 != pw2)
            {
                MessageBox.Show("Passwords does not match.");
                return;
            }

            await Globals.Register(create_username.Text, pw1);
            MessageBox.Show("Account successfully created!");
        }

        private void create_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(create_btn, 0.5, TimeSpan.FromMilliseconds(0));
        }

        private void cancel_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(cancel_btn, 0.0, TimeSpan.FromMilliseconds(0));
        }

        private void cancel_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(cancel_btn, 0.5, TimeSpan.FromMilliseconds(0));
            this.Close();
        }

        private void retype_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(create_password.Password==retype_password.Password||retype_password.Password=="")
            {
                error.Visibility = Visibility.Collapsed;
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }
        
    }
}
