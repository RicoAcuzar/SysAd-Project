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
    /// Interaction logic for ManageSched.xaml
    /// </summary>
    public partial class ManageSched : MetroWindow
    {
        public ManageSched()
        {
            InitializeComponent();
            List<Sched> scheds=new List<Sched>();
            scheds.Add(new Sched() { Time1 = new DateTime(1, 1, 1, 3, 23, 0), Time2 = new DateTime(1, 1, 1, 11, 21, 0), Device = "Lights", Description = "living room light" });
            list_sched.ItemsSource = scheds;
        }
        public class Sched
        {
            public DateTime Time1 { get; set; }
            public string Time1String { get { return Time1.ToLongTimeString(); } }
            public DateTime Time2 { get; set; }
            public string Time2String { get { return Time2.ToLongTimeString(); } }
            public string Device { get; set; }
            public string Description { get; set; }
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

        private void delete_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(delete_btn, 0.0, TimeSpan.FromMilliseconds(0));
        }

        private void delete_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(delete_btn, 0.5, TimeSpan.FromMilliseconds(0));
        }

        private void edit_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(edit_btn, 0.0, TimeSpan.FromMilliseconds(0));
        }

        private void edit_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(edit_btn, 0.5, TimeSpan.FromMilliseconds(0));
        }

        private void save_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(save_btn, 0.0, TimeSpan.FromMilliseconds(0));
        }

        private void save_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(save_btn, 0.5, TimeSpan.FromMilliseconds(0));
        }

        private void list_sched_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //something here
        }
    }
}
