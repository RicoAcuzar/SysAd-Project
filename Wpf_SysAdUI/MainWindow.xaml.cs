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
namespace Wpf_SysAdUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
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

            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(SlideBar, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Add(Inner_UIMain, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(100000), TimeSpan.FromMilliseconds(500)));
                AnimationSet.Run();

            };
            SlideBar.Visibility = Visibility.Visible;
            Inner_UIMain.Visibility = Visibility.Visible;
            AnimationSet.Add(LogIn, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 970.0, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            Account_name.Text = User_tb_login.Text;
            Account_name.Visibility = Visibility.Visible; 
            Animation.DropShadowOpacity(signin_btn, 0.4, TimeSpan.FromSeconds(0));
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatch = new DispatcherTimer();
            dispatch.Interval = new TimeSpan(0,0,0,0,100);
            dispatch.Tick += dispatch_Tick;
            dispatch.Start();

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
                pass_login.Clear();
            
            }
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
        }

        private void createSched_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(createSched_btn, 0.5, TimeSpan.FromSeconds(0));
        }

        private void editSched_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(editSched_btn, 0.5, TimeSpan.FromSeconds(0));
        }

        private void delSched_btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Animation.DropShadowOpacity(delSched_btn, 0.5, TimeSpan.FromSeconds(0));
        }

        private void RepUI_D_tile_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            reports.IsEnabled = true;
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
        }

        private void close_btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AnimationSet.Completed += (object s, EventArgs ex) =>
            {
                AnimationSet.Add(tiles_grid, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(close_btn, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(reports, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Run();

            };
            AnimationSet.Add(property_lbl, AnimationKind.TranslateY, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(300), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Run();
            close_btn.IsEnabled = false;
        }

        public class User
        {
            public DateTime Date { get; set; }
            public string DateString { get { return Date.ToShortDateString(); } }
            public DateTime Time  { get; set; }
            public string TimeString { get { return Time.ToLongTimeString(); } }
            public string userName { get; set; }
            public string Event { get; set; }
        }
 

    }
}
