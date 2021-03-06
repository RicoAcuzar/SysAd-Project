﻿using System;
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
    /// Interaction logic for Add_app.xaml
    /// </summary>
    public partial class Add_app : MetroWindow
    {
        int selectedIndex;
        MainWindow main = null;

        public Add_app(MainWindow m)
        {
            InitializeComponent();
            InitializeStackWrapPanel();
            main = m;
        }

        public void InitializeStackWrapPanel()
        {
            selectedIndex = -1;

            List<Element> elementList = new List<Element>();
            for (int i = 0; i <= 40; i++)
                elementList.Add(new Element("pic" + i.ToString()));

            int index = 0;
            WrapPanel stack = (WrapPanel)FindName("stack");

            foreach (Element element in elementList)
            {
                Image image = new Image()
                {
                    Source = (BitmapImage)FindResource(element.ImageSourceString),
                    Height = 50,
                    Width = 50,
                    Margin = new Thickness(5)
                };

                Grid grid = new Grid();
                grid.Background = new SolidColorBrush(Colors.Transparent);

                element.Index = index++;
                grid.Tag = element;
                grid.Children.Add(image);

                grid.MouseDown += grid_MouseDown;
                grid.MouseEnter += grid_MouseEnter;
                grid.MouseLeave += grid_MouseLeave;

                stack.Children.Add(grid);
            }
        }

        void grid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (selectedIndex != ((Element)((Grid)sender).Tag).Index)
            {
                ((Grid)sender).Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        void grid_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Grid)sender).Background = new SolidColorBrush(Color.FromArgb(40, 0, 0, 0));
        }

        void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WrapPanel wrapPanel = ((WrapPanel)FindName("stack"));
            Element element = (Element)((Grid)sender).Tag;

            if (selectedIndex != element.Index)
            {
                selectedIndex = element.Index;

                foreach (Grid grid in wrapPanel.Children.OfType<Grid>().ToList().Where(g => ((Element)g.Tag).Index != selectedIndex))
                    grid.Background = new SolidColorBrush(Colors.Transparent);

                ((Grid)sender).Background = new SolidColorBrush(Color.FromArgb(40, 0, 0, 0));
            }

            OnSelectionChanged(element);
        }

        private void OnSelectionChanged(Element element)
        {
            // DO YOUR THING HERE
            logo.Source = (BitmapImage)FindResource(element.ImageSourceString);
        }

        class Element
        {
            public Element(string imagesource)
            {
                Index = 0;
                ImageSourceString = imagesource;
            }

            public Element(int index, string imagesource)
            {
                Index = index;
                ImageSourceString = imagesource;
            }

            public int Index { get; set; }
            public string ImageSourceString { get; set; }
        }

        private void create_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(create_btn, 0.0, TimeSpan.FromMilliseconds(0));
        }

        private async void create_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(create_btn, 0.5, TimeSpan.FromMilliseconds(0));
            // TODO: save image with filename as ApplianceID then retrieve it when load
            double watt;
            byte pin;
            if (!double.TryParse(ec_tb.Text, out watt))
            {
                MessageBox.Show("Please enter a valid wattage.");
                return;
            }
            if (!byte.TryParse(pin_tb.Text, out pin))
            {
                MessageBox.Show("Please enter a valid pin.");
                return;
            }
            else
            {
                if (pin < 1 || pin > 2)
                {
                    MessageBox.Show("The only available pins for this device are 1 and 2.");
                    return;
                }
                else
                {
                    if (await Globals.PinExists(pin))
                    {
                        MessageBox.Show("Pin is already in use.");
                        return;
                    }
                }
            }
            await Globals.AddAppliance(devname_tb.Text, devloc_tb.Text, devtype_tb.Text, watt, pin);
            var appID = await Globals.GetLastAppliance();
            main.Add_Appliances(appID.Rows[0][0].ToString(), devname_tb.Text, devloc_tb.Text, watt.ToString(), logo);
            this.Close();
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

        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            //event does not fire
        }

    }
}
