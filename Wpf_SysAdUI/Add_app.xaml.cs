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
            //WrapPanel panel = (WrapPanel)FindName("App_stack");
            //WrapPanel panel2 = (WrapPanel)FindName("Stat_stack");
            Grid grid = new Grid();
            grid.Height = 140;
            grid.Width = 140;
            grid.Margin = new Thickness(5);
            grid.Background = new SolidColorBrush(Colors.SkyBlue);


            Grid grid2 = new Grid();
            grid2.Height = 140;
            grid2.Width = 140;
            grid2.Margin = new Thickness(5);
            grid2.Background = new SolidColorBrush(Colors.SkyBlue);


            TextBlock text = new TextBlock();
            text.Text = devname_tb.Text;
            text.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            text.FontSize = 15;
            text.TextAlignment = TextAlignment.Center;
            text.Margin = new Thickness(7, 64, 13, 47);
            
            TextBlock text2 = new TextBlock();
            text2.Text = devloc_tb.Text;
            text2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            text2.FontSize = 11;
            text2.TextAlignment = TextAlignment.Center;
            text2.Margin = new Thickness(10, 87, 10, 33);

            TextBlock text3= new TextBlock();
            text3.Text = ec_tb.Text;
            text3.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            text3.FontSize = 11;
            text3.TextAlignment = TextAlignment.Center;
            text3.Margin = new Thickness(10, 101, 10, 22);
            
            grid.Children.Add(text);
            grid.Children.Add(text2);
            grid.Children.Add(text3);
            //panel.Children.Insert(0, grid);
            //panel2.Children.Insert(0, grid2);
            this.Close();
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

        private void devname_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dev_name_prev.Text = devname_tb.Text;
        }

        private void devloc_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dev_loc_prev.Text = devloc_tb.Text;
        }

        private void ec_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ec_tb.Text == "")
                consump_prev.Text = "";
            else
                consump_prev.Text = ec_tb.Text + " Watts";
        }
    }
}
