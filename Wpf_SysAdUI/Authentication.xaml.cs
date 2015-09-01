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

namespace Wpf_SysAdUI
{
    /// <summary>
    /// Interaction logic for Authentication.xaml
    /// </summary>
    
    public partial class Authentication : MetroWindow
    {
        string checker;    
        MainWindow Main = null;
        public Authentication(MainWindow m)
        {
            InitializeComponent();
            Main = m;
        }

        
        private void Ok_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(Ok_btn, 0.0, TimeSpan.FromMilliseconds(0));
            
        }

        private void Cancel_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(Cancel_btn, 0.5, TimeSpan.FromMilliseconds(0));
            this.Close();
        }

        private void Cancel_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(Cancel_btn, 0.0, TimeSpan.FromMilliseconds(0));
        }

        private void Ok_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(Ok_btn, 0.5, TimeSpan.FromMilliseconds(0));
            if (pass.Password == Main.pass_login.Password)
            {
                checker = "GO";
                this.Close();
            }
            else
            {
                checker = "NO";
                MessageBox.Show("Incorrect Password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            }
        }
        public string check
        { get { return checker; } }
     
    }
}
