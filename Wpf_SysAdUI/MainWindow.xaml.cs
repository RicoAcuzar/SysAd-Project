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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Threading;
using BusinessLogic;

namespace Wpf_SysAdUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        //
        // Animation Codes
        //
        #region Animation Codes
        public MainWindow()
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Date = new DateTime(2005,8,20),Time=new DateTime(1,1,1,11,00,00), userName = "dsadsa", Event = "dsasfgjdsfjdsakfsafdk" });
            items.Add(new User() { Date = new DateTime(2012,8,23), Time = new DateTime(1,1,1,11,30,00), userName = "dsadsadsadsadsa", Event = "dsasfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2013,8,10), Time = new DateTime(1,1,1,11,02,00), userName = "dsadsaddsdssadsadsa", Event = "dsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2015, 8, 30), Time = new DateTime(1, 1, 1, 11, 50, 00), userName = "aaaaaaaadsadsaddsdssadsadsa", Event = "aaaaaaadsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            lvUsers.ItemsSource = items;
            reports.ItemsSource = items;
            
        }


        private void SlideBar_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.Width(SlideBar, 245.0, TimeSpan.FromMilliseconds(200));
        }

        private void SlideBar_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.Width(SlideBar, 90.0, TimeSpan.FromMilliseconds(200));
        }

        
        private void signin_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(signin_btn, 0.0, TimeSpan.FromSeconds(0));
            signin_btn.BorderBrush = new SolidColorBrush(Color.FromRgb(82, 127, 222))/*"#FF527FDE"*/;
        }

        private void signin_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(signin_btn, 0.4, TimeSpan.FromSeconds(0));
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatch = new DispatcherTimer();
            dispatch.Interval = new TimeSpan(0,0,0,0,100);
            dispatch.Tick += dispatch_Tick;
            dispatch.Start();
            //////
            double kwh;
            if (System.IO.File.Exists("kwh.txt") && double.TryParse(System.IO.File.ReadAllText("kwh.txt"), out kwh))
                set_kwh_tb.Text = (Globals.KWH = kwh).ToString();
            else set_kwh_tb.Text = (Globals.KWH = 0d).ToString();
        }

        void dispatch_Tick(object sender, EventArgs e)
        {
            Dtime.Content = DateTime.Now.ToString();
        }

        private void home_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(home_pan, "#FF2E9CDA", TimeSpan.FromMilliseconds(0));
        }

        private void home_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            if(HomeUI_inner.Visibility==Visibility.Collapsed)
            Animation.BackgroundColor(home_pan, "Transparent", TimeSpan.FromMilliseconds(0));
        }

        private void stat_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            
            Animation.BackgroundColor(stat_pan, "#FF2E9CDA", TimeSpan.FromMilliseconds(0));
        }

        private void stat_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            if(StatUI_inner.Visibility==Visibility.Collapsed)
            Animation.BackgroundColor(stat_pan, "Transparent", TimeSpan.FromMilliseconds(0));
        }

        private void rep_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(rep_pan, "#FF2E9CDA", TimeSpan.FromMilliseconds(0));
        }

        private void rep_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            if(RepUI_inner.Visibility==Visibility.Collapsed)
            Animation.BackgroundColor(rep_pan, "Transparent", TimeSpan.FromMilliseconds(0));
        }

        private void sched_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(sched_pan, "#FF2E9CDA", TimeSpan.FromMilliseconds(0));
        }

        private void sched_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            if(SchedUI_inner.Visibility==Visibility.Collapsed)
            Animation.BackgroundColor(sched_pan, "Transparent", TimeSpan.FromMilliseconds(0));
        }

        private void app_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(app_pan, "#FF2E9CDA", TimeSpan.FromMilliseconds(0));
        }

        private void app_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            if(AppdUI_inner.Visibility==Visibility.Collapsed)
            Animation.BackgroundColor(app_pan, "Transparent", TimeSpan.FromMilliseconds(0));
        }

        private void set_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(set_pan, "#FF2E9CDA", TimeSpan.FromMilliseconds(0));
        }

        private void set_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            if(SetdUI_inner.Visibility==Visibility.Collapsed)
            Animation.BackgroundColor(set_pan, "Transparent", TimeSpan.FromMilliseconds(0));
        }

        private void AccExpander_CNA_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(AccExpander_CNA_pan, "#FF91BFF7", TimeSpan.FromMilliseconds(0));
        }

        private void AccExpander_CP_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(AccExpander_CP_pan, "#FF91BFF7", TimeSpan.FromMilliseconds(0));
        }

        private void AccExpander_LO_pan_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(AccExpander_LO_pan, "#FF91BFF7", TimeSpan.FromMilliseconds(0));
        }

        private void AccExpander_CNA_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(AccExpander_CNA_pan, "#FFBBD4F3", TimeSpan.FromMilliseconds(0));
        }

        private void AccExpander_CP_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(AccExpander_CP_pan, "#FFBBD4F3", TimeSpan.FromMilliseconds(0));
        }

        private void AccExpander_LO_pan_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(AccExpander_LO_pan, "#FFBBD4F3", TimeSpan.FromMilliseconds(0));
        }

        private void AccExpander_LO_pan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes)
            {
                AnimationSet.Completed += (object s, EventArgs ex) =>
                {
                    AnimationSet.Add(SlideBar, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(0)));
                    AnimationSet.Add(LogIn, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(500)));
                    AnimationSet.Run();

                };
                AnimationSet.Add(Inner_UIMain, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Run();
                Account_name.Visibility = Visibility.Collapsed;
                Expander.IsExpanded = false;
                HomeUI_inner.Visibility = Visibility.Collapsed;
                StatUI_inner.Visibility = Visibility.Collapsed;
                RepUI_inner.Visibility = Visibility.Collapsed;
                SchedUI_inner.Visibility = Visibility.Collapsed;
                AppdUI_inner.Visibility = Visibility.Collapsed;
                SetdUI_inner.Visibility = Visibility.Collapsed;
                Inner_UIMain.Visibility = Visibility.Collapsed;
                home_pan.Background = new SolidColorBrush(Color.FromRgb(46, 156, 218));
                stat_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                rep_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                sched_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                app_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                set_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                pass_login.Clear();
            
            }
            //////
            Globals.Logout();
        }

        private void RepUI_D_tile_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_D_tile, "#CC368EB4", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_D_tile_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_D_tile, "#CC43B2E2", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_W_tile_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_W_tile, "#CC368EB4", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_W_tile_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_W_tile, "#CC43B2E2", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_M_tile_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_M_tile, "#CC368EB4", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_M_tile_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_M_tile, "#CC43B2E2", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_Y_tile_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_Y_tile, "#CC368EB4", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_Y_tile_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_Y_tile, "#CC43B2E2", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_C_tile_MouseEnter(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_C_tile, "#CC368EB4", TimeSpan.FromMilliseconds(0));
        }

        private void RepUI_C_tile_MouseLeave(object sender, MouseEventArgs e)
        {
            Animation.BackgroundColor(RepUI_C_tile, "#CC43B2E2", TimeSpan.FromMilliseconds(0));
        }

        private void home_pan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomeUI_inner.Visibility = Visibility.Visible;
            StatUI_inner.Visibility = Visibility.Collapsed;
            RepUI_inner.Visibility = Visibility.Collapsed;
            SchedUI_inner.Visibility = Visibility.Collapsed;
            AppdUI_inner.Visibility = Visibility.Collapsed;
            SetdUI_inner.Visibility = Visibility.Collapsed;
            home_pan.Background = new SolidColorBrush(Color.FromRgb(46, 156, 218));
            stat_pan.Background = new SolidColorBrush(Color.FromArgb(0,255,255,255));
            rep_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            sched_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            app_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            set_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        private void stat_pan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomeUI_inner.Visibility = Visibility.Collapsed;
            StatUI_inner.Visibility = Visibility.Visible;
            RepUI_inner.Visibility = Visibility.Collapsed;
            SchedUI_inner.Visibility = Visibility.Collapsed;
            AppdUI_inner.Visibility = Visibility.Collapsed;
            SetdUI_inner.Visibility = Visibility.Collapsed;
            stat_pan.Background = new SolidColorBrush(Color.FromRgb(46, 156, 218));
            home_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            rep_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            sched_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            app_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            set_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        private void rep_pan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Please Fix Functionalities esp. Sorting by weekly.Thank you!", "WAIT", MessageBoxButton.OK, MessageBoxImage.Information);
            HomeUI_inner.Visibility = Visibility.Collapsed;
            StatUI_inner.Visibility = Visibility.Collapsed;
            RepUI_inner.Visibility = Visibility.Visible;
            SchedUI_inner.Visibility = Visibility.Collapsed;
            AppdUI_inner.Visibility = Visibility.Collapsed;
            SetdUI_inner.Visibility = Visibility.Collapsed;
            rep_pan.Background = new SolidColorBrush(Color.FromRgb(46, 156, 218));
            stat_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            home_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            sched_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            app_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            set_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        private void sched_pan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomeUI_inner.Visibility = Visibility.Collapsed;
            StatUI_inner.Visibility = Visibility.Collapsed;
            RepUI_inner.Visibility = Visibility.Collapsed;
            SchedUI_inner.Visibility = Visibility.Visible;
            AppdUI_inner.Visibility = Visibility.Collapsed;
            SetdUI_inner.Visibility = Visibility.Collapsed;
            sched_pan.Background = new SolidColorBrush(Color.FromRgb(46, 156, 218));
            stat_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            rep_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            home_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            app_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            set_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        private void app_pan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HomeUI_inner.Visibility = Visibility.Collapsed;
            StatUI_inner.Visibility = Visibility.Collapsed;
            RepUI_inner.Visibility = Visibility.Collapsed;
            SchedUI_inner.Visibility = Visibility.Collapsed;
            AppdUI_inner.Visibility = Visibility.Visible;
            SetdUI_inner.Visibility = Visibility.Collapsed;
            app_pan.Background = new SolidColorBrush(Color.FromRgb(46, 156, 218));
            stat_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            rep_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            sched_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            home_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            set_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        private void set_pan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string check="NO";
            if (SetdUI_inner.Visibility != Visibility.Visible)
            {
                Authentication a = new Authentication(this);
                a.ShowDialog();
                check=a.check;
            }
            if (check == "GO")
            {
                HomeUI_inner.Visibility = Visibility.Collapsed;
                StatUI_inner.Visibility = Visibility.Collapsed;
                RepUI_inner.Visibility = Visibility.Collapsed;
                SchedUI_inner.Visibility = Visibility.Collapsed;
                AppdUI_inner.Visibility = Visibility.Collapsed;
                SetdUI_inner.Visibility = Visibility.Visible;
                set_pan.Background = new SolidColorBrush(Color.FromRgb(46, 156, 218));
                stat_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                rep_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                sched_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                app_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                home_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            }

        }
        

        private void viewSched_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(viewSched_btn, 0.0, TimeSpan.FromSeconds(0));
            
        }

        private void createSched_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(createSched_btn, 0.0, TimeSpan.FromSeconds(0));
            
        }

        private void editSched_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(editSched_btn, 0.0, TimeSpan.FromSeconds(0));
            
        }

        private void delSched_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(delSched_btn, 0.0, TimeSpan.FromSeconds(0));
            
        }

        private void viewSched_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {

            Animation.DropShadowOpacity(viewSched_btn, 0.5, TimeSpan.FromSeconds(0));
            if (SchedUI_Calendar.SelectedDate == null)
            {
                MessageBox.Show("Please select a date.", "No Date Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ManageSched m = new ManageSched();
                m.Date_lbl.Content = SchedUI_Calendar.SelectedDate.Value.ToLongDateString();
                m.create_btn.Visibility = Visibility.Collapsed;
                m.delete_btn.Visibility = Visibility.Collapsed;
                m.edit_btn.Visibility = Visibility.Collapsed;
                m.save_btn.Visibility = Visibility.Collapsed;
                m.ShowDialog();
            }
        }

        private void createSched_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(createSched_btn, 0.5, TimeSpan.FromSeconds(0));
            if (SchedUI_Calendar.SelectedDate == null)
            {
                MessageBox.Show("Please select a date.", "No Date Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ManageSched m = new ManageSched();
                m.Date_lbl.Content = SchedUI_Calendar.SelectedDate.Value.ToLongDateString();
                m.list_sched.IsEnabled = false;
                m.time_off_tb.IsEnabled = true;
                m.time_on_tb.IsEnabled = true;
                m.device_tb.IsEnabled = true;
                m.desc_tb.IsEnabled = true;
                m.delete_btn.Visibility = Visibility.Collapsed;
                m.edit_btn.Visibility = Visibility.Collapsed;
                m.save_btn.Visibility = Visibility.Collapsed;
                m.ShowDialog();
            }
        }

        private void editSched_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(editSched_btn, 0.5, TimeSpan.FromSeconds(0));
            if (SchedUI_Calendar.SelectedDate == null)
            {
                MessageBox.Show("Please select a date.", "No Date Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ManageSched m = new ManageSched();
                m.Date_lbl.Content = SchedUI_Calendar.SelectedDate.Value.ToLongDateString();
                m.delete_btn.Visibility = Visibility.Collapsed;
                m.create_btn.Visibility = Visibility.Collapsed;
                m.ShowDialog();
            }
        }

        private void delSched_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(delSched_btn, 0.5, TimeSpan.FromSeconds(0));
            if (SchedUI_Calendar.SelectedDate == null)
            {
                MessageBox.Show("Please select a date.", "No Date Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ManageSched m = new ManageSched();
                m.Date_lbl.Content = SchedUI_Calendar.SelectedDate.Value.ToLongDateString();
                m.create_btn.Visibility = Visibility.Collapsed;
                m.edit_btn.Visibility = Visibility.Collapsed;
                m.save_btn.Visibility = Visibility.Collapsed;
                m.ShowDialog();
            }
        }

        private void RepUI_D_tile_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            reports.IsEnabled = true;
            reports.Visibility = Visibility.Visible;
            //sample adding data on tables
            List<User> items = new List<User>();
            items.Add(new User() { Date = new DateTime(2005, 8, 20), Time = new DateTime(1, 1, 1, 11, 00, 00), userName = "dsadsa", Event = "dsasfgjdsfjdsakfsafdk" });
            items.Add(new User() { Date = new DateTime(2012, 8, 23), Time = new DateTime(1, 1, 1, 11, 30, 00), userName = "dsadsadsadsadsa", Event = "dsasfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2013, 8, 10), Time = new DateTime(1, 1, 1, 11, 02, 00), userName = "dsadsaddsdssadsadsa", Event = "dsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2015, 8, 30), Time = new DateTime(1, 1, 1, 11, 50, 00), userName = "aaaaaaaadsadsaddsdssadsadsa", Event = "aaaaaaadsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            //reports.ItemsSource = items;
            reports.ItemsSource = items.OrderBy(item => item.Date).ToArray();
            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(tiles_grid, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -150.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(close_btn, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Add(reports, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Run();

            };
            AnimationSet.Add(property_lbl, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -50.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            close_btn.IsEnabled = true;
            reports.IsEnabled = true;
            RepUI_D_tile.Background = new SolidColorBrush(Color.FromArgb(80, 54, 102, 180));
            RepUI_W_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_C_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_M_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_Y_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
        }

        private void RepUI_W_tile_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            reports.IsEnabled = true;
            reports.Visibility = Visibility.Visible;
            //sample adding data on tables
            List<User> items = new List<User>();
            items.Add(new User() { Date = new DateTime(2005, 8, 20), Time = new DateTime(1, 1, 1, 11, 00, 00), userName = "dsadsa", Event = "dsasfgjdsfjdsakfsafdk" });
            items.Add(new User() { Date = new DateTime(2012, 8, 23), Time = new DateTime(1, 1, 1, 11, 30, 00), userName = "dsadsadsadsadsa", Event = "dsasfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2013, 8, 10), Time = new DateTime(1, 1, 1, 11, 02, 00), userName = "dsadsaddsdssadsadsa", Event = "dsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2015, 8, 30), Time = new DateTime(1, 1, 1, 11, 50, 00), userName = "aaaaaaaadsadsaddsdssadsadsa", Event = "aaaaaaadsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            reports.ItemsSource = items;
            reports.ItemsSource = items.OrderBy(item => item.Date).ToArray();
            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(tiles_grid, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -150.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(close_btn, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Add(reports, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Run();

            };
            AnimationSet.Add(property_lbl, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -50.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            close_btn.IsEnabled = true;
            RepUI_W_tile.Background = new SolidColorBrush(Color.FromArgb(80, 54, 102, 180));
            RepUI_C_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_M_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_Y_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_D_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
        }

        private void RepUI_M_tile_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            reports.IsEnabled = true;
            reports.Visibility = Visibility.Visible;
            //sample adding data on tables
            List<User> items = new List<User>();
            items.Add(new User() { Date = new DateTime(2005, 8, 20), Time = new DateTime(1, 1, 1, 11, 00, 00), userName = "dsadsa", Event = "dsasfgjdsfjdsakfsafdk" });
            items.Add(new User() { Date = new DateTime(2012, 8, 23), Time = new DateTime(1, 1, 1, 11, 30, 00), userName = "dsadsadsadsadsa", Event = "dsasfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2013, 8, 10), Time = new DateTime(1, 1, 1, 11, 02, 00), userName = "dsadsaddsdssadsadsa", Event = "dsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2015, 8, 30), Time = new DateTime(1, 1, 1, 11, 50, 00), userName = "aaaaaaaadsadsaddsdssadsadsa", Event = "aaaaaaadsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            //reports.ItemsSource = items;
            reports.ItemsSource = items.OrderBy(item => item.Date.Month).ToArray();            
            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(tiles_grid, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -150.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(close_btn, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Add(reports, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Run();

            };
            AnimationSet.Add(property_lbl, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -50.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            close_btn.IsEnabled = true;
            RepUI_M_tile.Background = new SolidColorBrush(Color.FromArgb(80, 54, 102, 180));
            RepUI_W_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_C_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_Y_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_D_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
        }

        private void RepUI_Y_tile_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            reports.IsEnabled = true;
            reports.Visibility = Visibility.Visible;
            //sample adding data on tables
            List<User> items = new List<User>();
            items.Add(new User() { Date = new DateTime(2005, 8, 20), Time = new DateTime(1, 1, 1, 11, 00, 00), userName = "dsadsa", Event = "dsasfgjdsfjdsakfsafdk" });
            items.Add(new User() { Date = new DateTime(2012, 8, 23), Time = new DateTime(1, 1, 1, 11, 30, 00), userName = "dsadsadsadsadsa", Event = "dsasfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2013, 8, 10), Time = new DateTime(1, 1, 1, 11, 02, 00), userName = "dsadsaddsdssadsadsa", Event = "dsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2015, 8, 30), Time = new DateTime(1, 1, 1, 11, 50, 00), userName = "aaaaaaaadsadsaddsdssadsadsa", Event = "aaaaaaadsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            //reports.ItemsSource = items;
            reports.ItemsSource = items.OrderBy(item => item.Date.Year).ToArray();                        
            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(tiles_grid, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -150.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(close_btn, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Add(reports, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Run();

            };
            AnimationSet.Add(property_lbl, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -50.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            close_btn.IsEnabled = true;
            RepUI_Y_tile.Background = new SolidColorBrush(Color.FromArgb(80, 54, 102, 180));
            RepUI_W_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_M_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_C_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_D_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
        }

        private void RepUI_C_tile_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            reports.IsEnabled = true;
            reports.Visibility = Visibility.Visible;
            //sample adding data on tables
            List<User> items = new List<User>();
            items.Add(new User() { Date = new DateTime(2005, 8, 20), Time = new DateTime(1, 1, 1, 11, 00, 00), userName = "dsadsa", Event = "dsasfgjdsfjdsakfsafdk" });
            items.Add(new User() { Date = new DateTime(2012, 8, 23), Time = new DateTime(1, 1, 1, 11, 30, 00), userName = "dsadsadsadsadsa", Event = "dsasfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2013, 8, 10), Time = new DateTime(1, 1, 1, 11, 02, 00), userName = "dsadsaddsdssadsadsa", Event = "dsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            items.Add(new User() { Date = new DateTime(2015, 8, 30), Time = new DateTime(1, 1, 1, 11, 50, 00), userName = "aaaaaaaadsadsaddsdssadsadsa", Event = "aaaaaaadsasdsadsadsadfgjdsfjdsakfsafdsaddk" });
            //reports.ItemsSource = items;
            reports.ItemsSource = items.OrderBy(item => item.Date).ToArray();                        
            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(tiles_grid, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -150.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(close_btn, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(reports, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Run();

            };
            AnimationSet.Add(property_lbl, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, -50.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            RepUI_C_tile.Background= new SolidColorBrush(Color.FromArgb(80,54,102,180));
            RepUI_W_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_M_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_Y_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            RepUI_D_tile.Background = new SolidColorBrush(Color.FromArgb(80, 67, 178, 226));
            close_btn.IsEnabled = true;
            MessageBox.Show("I dont know what to put here.", "No Idea", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void close_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(property_lbl, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(close_btn, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(reports, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Run();

            };
            AnimationSet.Add(tiles_grid, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            close_btn.IsEnabled = false;
            reports.IsEnabled = false;
            reports.Visibility = Visibility.Collapsed;
        }

        //sample adding data on tables
        public class User
        {
            public DateTime Date { get; set; }
            public string DateString { get { return Date.ToShortDateString(); } }
            public DateTime Time  { get; set; }
            public string TimeString { get { return Time.ToLongTimeString(); } }
            public string userName { get; set; }
            public string Event { get; set; }
        }


        private void AppUI_add_tile_Click(object sender, RoutedEventArgs e)
        {
            Add_app add = new Add_app(this);
            add.ShowDialog();
           
        }

        private void AccExpander_CNA_pan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Expander.IsExpanded = false;
            new ManageAccount().ShowDialog();
        }

        private void AccExpander_CP_pan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string check="NO";
            if (SetdUI_inner.Visibility != Visibility.Visible)
            {
                Authentication a = new Authentication(this);
                a.ShowDialog();
                check=a.check;
            }
            if (check == "GO")
            {
                HomeUI_inner.Visibility = Visibility.Collapsed;
                StatUI_inner.Visibility = Visibility.Collapsed;
                RepUI_inner.Visibility = Visibility.Collapsed;
                SchedUI_inner.Visibility = Visibility.Collapsed;
                AppdUI_inner.Visibility = Visibility.Collapsed;
                SetdUI_inner.Visibility = Visibility.Visible;
                set_pan.Background = new SolidColorBrush(Color.FromRgb(46, 156, 218));
                stat_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                rep_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                sched_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                app_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                home_pan.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                Expander.IsExpanded = false;
            }
        }

        private void set_pass_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (set_pass_tb.Text != pass_login.Password.ToString())
                save_btn.IsEnabled = true;
            else
                save_btn.IsEnabled = false;
        }

        private void set_userN_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (set_userN_tb.Text != User_tb_login.Text)
                save_btn.IsEnabled = true;
            else
                save_btn.IsEnabled = false;
        }

        private void set_kwh_tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            save_btn.IsEnabled = true;
        }

        private async void save_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(save_btn, 0.0, TimeSpan.FromSeconds(0));

            //////
            //Check username
            if (set_userN_tb.Text.Trim() == Globals.Account.Username) { }
            else if (await Globals.UsernameExists(set_userN_tb.Text.Trim()))
            {
                MessageBox.Show("Username already taken.");
                return;
            }

            //Check password
            if (set_pass_tb.Text.Contains(' '))
            {
                MessageBox.Show("Passwords must not contain spaces.");
                return;
            }

            //Php/KWh
            double kwh;
            if (!double.TryParse(set_kwh_tb.Text, out kwh))
            {
                MessageBox.Show("Please enter a valid price per kiloWatt-hour.");
                return;
            }

            await Globals.ChangeUsername(set_userN_tb.Text.Trim());
            await Globals.ChangePassword(set_pass_tb.Text);
            System.IO.File.WriteAllText("kwh.txt", (Globals.KWH = kwh).ToString());
            MessageBox.Show("Settings Saved!");
        }

        private void cancel_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(cancel_btn, 0.0, TimeSpan.FromSeconds(0));
        }

        private void save_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(save_btn, 0.5, TimeSpan.FromSeconds(0));
        }

        private void cancel_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(cancel_btn, 0.5, TimeSpan.FromSeconds(0));
            set_userN_tb.Text = User_tb_login.Text;
            set_pass_tb.Text = pass_login.Password.ToString();
            save_btn.IsEnabled = false;
        }

        public void Add_Appliances(string devName, string devLoc, string watts, Image sa)
        {
            WrapPanel panel = (WrapPanel)FindName("App_stack");
            WrapPanel panel2 = (WrapPanel)FindName("Stat_stack");
            Image i = new Image();
            i.Margin = new Thickness(10, 10, 10, 81);
            i.Source = sa.Source;

            Image i2 = new Image();
            i2.Margin = new Thickness(10, 10, 10, 81);
            i2.Source = sa.Source;

            Path info = new Path();
            info.Margin = new Thickness(115, 5, 5, 115);
            info.Style = FindResource("InfoIcon") as Style;
            info.Fill = new SolidColorBrush(Colors.White);
            info.ToolTip = "Turns your appliances On or Off.";

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

            TextBlock name = new TextBlock();
            name.Text = devName;
            name.FontSize = 16;
            name.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            name.TextAlignment = TextAlignment.Center;
            name.Margin = new Thickness(5, 64, 5, 47);
            
            TextBlock name2 = new TextBlock();
            name2.Text = devName;
            name2.FontSize = 16;
            name2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            name2.TextAlignment = TextAlignment.Center;
            name2.Margin = new Thickness(5, 64, 5, 47);

            TextBlock loc = new TextBlock();
            loc.Text = devLoc;
            loc.FontSize = 11;
            loc.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            loc.TextAlignment = TextAlignment.Center;
            loc.Margin = new Thickness(10, 87, 10, 33);
            
            TextBlock loc2 = new TextBlock();
            loc2.Text = devLoc;
            loc2.FontSize = 11;
            loc2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            loc2.TextAlignment = TextAlignment.Center;
            loc2.Margin = new Thickness(10, 87, 10, 33);
            
            TextBlock w = new TextBlock();
            w.Text = watts + " Watts";
            w.FontSize = 11;
            w.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            w.TextAlignment = TextAlignment.Center;
            w.Margin = new Thickness(10, 101, 10, 22);

            ToggleSwitch toggle = new ToggleSwitch();
            toggle.Margin = new Thickness(0, 110, 25, 0);
            toggle.OffSwitchBrush = new SolidColorBrush(Color.FromRgb(17, 158, 218));
            toggle.OnSwitchBrush = new SolidColorBrush(Color.FromRgb(160, 222, 72));
            toggle.Foreground = new SolidColorBrush(Colors.Transparent);
            toggle.HorizontalAlignment = HorizontalAlignment.Center;
            ScaleTransform size = new ScaleTransform(1, 0.5);
            toggle.RenderTransform = size;

            grid.Children.Add(name);
            grid.Children.Add(loc);
            grid.Children.Add(w);
            grid.Children.Add(i);
            
            grid2.Children.Add(name2);
            grid2.Children.Add(loc2);
            grid2.Children.Add(i2);
            grid2.Children.Add(toggle);
            grid2.Children.Add(info);

            grid.MouseEnter += grid_MouseEnter;
            grid.MouseLeave += grid_MouseLeave;
            grid.MouseDown += grid_MouseDown;
            panel.Children.Insert(0, grid);
            panel2.Children.Insert(0, grid2);
        }


        void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Add_app add = new Add_app(this);
            //add.ShowDialog();
            //data from selected device will go to textboxes in Add_app form 
            //to edit and delete
            //paki lagyan nalang ng delete button sa Add_app form
            MessageBox.Show("Please read the comments in the code. Thanks.", "No function yet", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        void grid_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Grid)sender).Background = new SolidColorBrush(Colors.SkyBlue);
        }

        void grid_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Grid)sender).Background = new SolidColorBrush(Color.FromRgb(147,147,255));
        }
        #endregion


        //
        // Functionality Codes
        //
        #region Functionality Codes

        //Sign in button
        private async void signin_btn_Click(object sender, RoutedEventArgs e)
        {
            string pw = "";
            foreach (char c in pass_login.Password)
                pw += c;
            if (pw.Length == 0)
            {
                MessageBox.Show("Please enter your password.");
                return;
            }
            if (!(await Globals.Login(User_tb_login.Text, pw)))
            {
                MessageBox.Show("Error login! :(");
                return;
            }
            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(SlideBar, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Add(Inner_UIMain, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Run();
            };
            SlideBar.Visibility = Visibility.Visible;
            Inner_UIMain.Visibility = Visibility.Visible;
            HomeUI_inner.Visibility = Visibility.Visible;
            AnimationSet.Add(LogIn, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 970.0, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            Account_name.Text = User_tb_login.Text;
            Account_name.Visibility = Visibility.Visible;
            set_userN_tb.Text = User_tb_login.Text;
            set_pass_tb.Text = pass_login.Password.ToString();
        }
        #endregion
    }
}
