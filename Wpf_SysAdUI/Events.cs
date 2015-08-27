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
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_SysAdUI
{
    
    public static class Events
    {
        private static List<EventClass> list;
        private static FrameworkElement mainGrid;

        static Events()
        {
            list = new List<EventClass>();
        }

        public static void Load(FrameworkElement element)
        {
            mainGrid = element;
        }

        public static void OnClick(FrameworkElement element, Action action)
        {
            ClickEvent c = new ClickEvent(action, mainGrid);
            element.MouseLeftButtonDown += c.OnButtonDown;
            element.MouseLeftButtonUp += c.OnButtonUp;
            list.Add(c);
        }

        public static void OnClick(FrameworkElement element, Action action, params FrameworkElement[] exclusions)
        {
            ClickEvent c = new ClickEvent(action, mainGrid, exclusions);
            element.MouseLeftButtonDown += c.OnButtonDown;
            element.MouseLeftButtonUp += c.OnButtonUp;
            list.Add(c);
        }

        
    }
}
