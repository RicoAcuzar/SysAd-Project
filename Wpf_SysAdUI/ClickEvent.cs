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
    public class ClickEvent : EventClass
    {
        private bool buttonDown;
        private FrameworkElement[] exclusions;
        private FrameworkElement referencePoint;

        public ClickEvent(Action action, FrameworkElement referencePoint)
        {
            this.action = action;
            this.referencePoint = referencePoint;
        }

        public ClickEvent(Action action, FrameworkElement referencePoint, FrameworkElement[] exclusions)
            : this(action, referencePoint)
        {
            this.exclusions = exclusions;
        }

        public void OnButtonDown(object sender, EventArgs e)
        {
            buttonDown = true;
        }

        public void OnButtonUp(object sender, EventArgs e)
        {
            if (buttonDown && !CheckExclusions())
                action.Invoke();

            buttonDown = false;
        }

        private bool CheckExclusions()
        {
            if (exclusions != null)
            {
                Point p = Mouse.GetPosition(referencePoint);
                foreach (FrameworkElement e in exclusions)
                {
                    Point p2 = e.TranslatePoint(new Point(0.0, 0.0), referencePoint);
                    if (new Rect(p2, new Size(e.ActualWidth, e.ActualHeight)).IntersectsWith(new Rect(p, p)))
                        return true;
                }
            }
            return false;
        }
    }
}
