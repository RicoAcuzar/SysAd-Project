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
    /// Interaction logic for ManageSched.xaml
    /// </summary>
    public partial class ManageSched : MetroWindow
    {
        private List<Sched> scheds;
        private List<Schedule> schedules;
        private List<Appliance> appliances;

        public ManageSched()
        {
            InitializeComponent();
            /*List<Sched> scheds=new List<Sched>();
            scheds.Add(new Sched() { Time1 = new DateTime(1, 1, 1, 3, 23, 0), Time2 = new DateTime(1, 1, 1, 11, 21, 0), Device = "Lights", Description = "living room light" });*/
            //list_sched.ItemsSource = scheds;
            //////
            scheds = new List<Sched>();
            schedules = new List<Schedule>();
            appliances = new List<Appliance>();
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            /*var apps = await Globals.GetAppliances();
            for (int i = 0; i < apps.Rows.Count; i++)
                appliances.Add(new Appliance() {
                    ApplianceID = (int)apps.Rows[i][0],
                    Name = apps.Rows[i][1].ToString(),
                    ApplianceType = apps.Rows[i][2].ToString(),
                    Wattage = (double)apps.Rows[i][3],
                    PinID = (short)apps.Rows[i][4],
                    IsDigital = (bool)apps.Rows[i][5],
                    Active = (bool)apps.Rows[i][6],
                    Restricted = (bool)apps.Rows[i][7],
                    AddedBy = (int)apps.Rows[i][8]
                });*/
            var table = await Globals.GetSchedules();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //
                // TODO: parse error
                //
                schedules.Add(new Schedule()
                {
                    ScheduleID = (int)table.Rows[i][0],
                    ApplianceID = (int)table.Rows[i][1],
                    SetValue = (short)table.Rows[i][2],
                    ScheduleType = table.Rows[i][3].ToString(),
                    Repetition = table.Rows[i][4].ToString(),
                    LowerLimit = DateTime.Parse(table.Rows[i][5].ToString()),
                    UpperLimit = DateTime.Parse(table.Rows[i][6].ToString())
                });
                scheds.Add(new Sched() {
                    DateAndTime = schedules[schedules.Count - 1].LowerLimit,
                    State = (schedules[schedules.Count - 1].SetValue == 0) ? "Off" : "On",
                    Device = appliances.Find(x => x.ApplianceID == schedules[schedules.Count - 1].ApplianceID).Name,
                    Description = string.Format("Appliance Type: {0}\nWattage: {1}", appliances.Find(x => x.ApplianceID == schedules[schedules.Count - 1].ApplianceID).ApplianceType, appliances.Find(x => x.ApplianceID == schedules[schedules.Count - 1].ApplianceID).Wattage)
                });
            }
            list_sched.ItemsSource = schedules;
        }

        public class Sched
        {
            public DateTime DateAndTime { get; set; }
            public string State { get; set; }
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
            time_off_tb.IsEnabled = true;
            time_on_tb.IsEnabled = true;
            device_tb.IsEnabled = true;
            desc_tb.IsEnabled = true;
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
            //Sched sched = (Sched)list_sched.SelectedItem;
            /*time_on_tb.Text = sched.Time1String;
            time_off_tb.Text = sched.Time2String;
            desc_tb.Text = sched.Description;
            device_tb.Text = sched.Device;*/
        }

        //////
        
        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            //validate fields
            //if (time_on_tb.Text)
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            //get details on selected log index
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
