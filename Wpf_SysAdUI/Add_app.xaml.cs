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
    /// Interaction logic for Add_app.xaml
    /// </summary>
    public partial class Add_app : MetroWindow
    {
        public Add_app()
        {
            InitializeComponent();
        }
        private void create_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(create_btn, 0.0, TimeSpan.FromMilliseconds(0));
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
    }
}
