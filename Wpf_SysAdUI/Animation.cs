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
    public static class Animation
    {
        private static ColorAnimation ca;
        private static DoubleAnimation da;
        private static ThicknessAnimation ta;
        private static Storyboard sb;
        private static Storyboard sbOnce;
        private static Storyboard sbForever;
        private static double accel;
        private static double decel;

        public static double Acceleration
        {
            get { return accel; }
            set 
            {
                if (value <= 1 && value >= 0)
                    accel = value; 
            }
        }

        public static double Deceleration
        {
            get { return decel; }
            set
            {
                if (value + accel <= 1)
                    decel = value;
            }
        }

        static Animation()
        {
            ca = new ColorAnimation();
            ta = new ThicknessAnimation();
            da = new DoubleAnimation();
            sbOnce = new Storyboard();
            sbForever = new Storyboard();
            sbForever.RepeatBehavior = RepeatBehavior.Forever;
            sbForever.Children.Add(new DoubleAnimation());
            sb = sbOnce;
            sb.Children.Add(new DoubleAnimation());
        }

        public static void BorderColor(Border border, Color newColor, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            CA_Setter(border, newColor, duration, "(Border.BorderBrush).(SolidColorBrush.Color)", autoReverse, repeatForever);
        }

        public static void BorderColor(Border border, string newColor, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            CA_Setter(border, (Color)ColorConverter.ConvertFromString(newColor), duration, "(Border.BorderBrush).(SolidColorBrush.Color)", autoReverse, repeatForever);
        }

        public static void BackgroundColor(DependencyObject element, string newColor, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            CA_Setter(element, (Color)ColorConverter.ConvertFromString(newColor), duration, "Background.Color", autoReverse, repeatForever);
        }

        public static void BackgroundColor(DependencyObject element, Color newColor, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            CA_Setter(element, newColor, duration, "Background.Color", autoReverse, repeatForever);
        }

        public static void Opacity(DependencyObject element, double newOpacity, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            DA_Setter(element, newOpacity, duration, "Opacity", autoReverse, repeatForever);
        }

        public static void BackgroundOpacity(DependencyObject element, double newOpacity, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            DA_Setter(element, newOpacity, duration, "Background.Opacity", autoReverse, repeatForever);
        }

        public static void DropShadowOpacity(DependencyObject element, double newOpacity, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            if (((UIElement)element).Effect is DropShadowEffect)
                DA_Setter(element, newOpacity, duration, "Effect.Opacity", autoReverse, repeatForever);
        }

        public static void DropShadowBlur(DependencyObject element, double blurRadius, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            if (((UIElement)element).Effect is DropShadowEffect)
                DA_Setter(element, blurRadius, duration, "Effect.BlurRadius", autoReverse, repeatForever);
        }

        public static void TranslateX(DependencyObject element, double newX, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            try
            {
                if (((UIElement)element).RenderTransform is TranslateTransform)
                    DA_Setter(element, newX, duration, "(UIElement.RenderTransform).(TranslateTransform.X)", autoReverse, repeatForever);
                else
                    throw new InvalidCastException();
            }
            catch(InvalidCastException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void TranslateY(DependencyObject element, double newY, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            try
            {
                if (((UIElement)element).RenderTransform is TranslateTransform)
                    DA_Setter(element, newY, duration, "(UIElement.RenderTransform).(TranslateTransform.Y)", autoReverse, repeatForever);
                else
                    throw new InvalidCastException();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Margin(DependencyObject element, Thickness newMargin, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            TA_Setter(element, newMargin, duration, "Margin", autoReverse, repeatForever);
        }

        public static void MarginLeft(DependencyObject element, double newLeft, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            FrameworkElement fe = (FrameworkElement)element;
            TA_Setter(element, new Thickness(newLeft, fe.Margin.Top, fe.Margin.Right, fe.Margin.Bottom), duration, "Margin", autoReverse, repeatForever);
        }

        public static void MarginRight(DependencyObject element, double newRight, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            FrameworkElement fe = (FrameworkElement)element;
            TA_Setter(element, new Thickness(fe.Margin.Left, fe.Margin.Top, newRight, fe.Margin.Bottom), duration, "Margin", autoReverse, repeatForever);
        }

        public static void MarginTop(DependencyObject element, double newTop, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            FrameworkElement fe = (FrameworkElement)element;
            TA_Setter(element, new Thickness(fe.Margin.Left, newTop, fe.Margin.Right, fe.Margin.Bottom), duration, "Margin", autoReverse, repeatForever);
        }

        public static void MarginBottom(DependencyObject element, double newBottom, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            FrameworkElement fe = (FrameworkElement)element;
            TA_Setter(element, new Thickness(fe.Margin.Left, fe.Margin.Top, fe.Margin.Right, newBottom), duration, "Margin", autoReverse, repeatForever);
        }

        public static void Width(DependencyObject element, double newWidth, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            DA_Setter(element, newWidth, duration, "Width", autoReverse, repeatForever);
        }

        public static void Height(DependencyObject element, double newHeight, TimeSpan duration, bool autoReverse = false, bool repeatForever = false)
        {
            DA_Setter(element, newHeight, duration, "Height", autoReverse, repeatForever);
        }

        private static void TA_Setter(DependencyObject element, Thickness value, TimeSpan duration, string propertyPath, bool autoReverse, bool repeatForever)
        {
            SB_Setter(autoReverse, repeatForever);

            ta.To = value;
            ta.Duration = duration;
            sb.Children[0] = ta;
            Storyboard.SetTarget(ta, element);
            Storyboard.SetTargetProperty(ta, new PropertyPath(propertyPath));
            sb.Begin();
        }

        private static void CA_Setter(DependencyObject element, Color value, TimeSpan duration, string propertyPath, bool autoReverse, bool repeatForever)
        {
            SB_Setter(autoReverse, repeatForever);

            ca.To = value;
            ca.Duration = duration;
            sb.Children[0] = ca;
            Storyboard.SetTarget(ca, element);
            Storyboard.SetTargetProperty(ca, new PropertyPath(propertyPath));
            sb.Begin();
        }

        private static void DA_Setter(DependencyObject element, double value, TimeSpan duration, string propertyPath, bool autoReverse, bool repeatForever)
        {
            SB_Setter(autoReverse, repeatForever);

            da.To = value;
            da.Duration = duration;
            sb.Children[0] = da;
            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, new PropertyPath(propertyPath));
            sb.Begin();
        }

        private static void SB_Setter(bool autoReverse, bool repeatForever)
        {
            if (repeatForever)
                sb = sbForever;
            else
                sb = sbOnce;

            sb.AutoReverse = autoReverse;
            sb.AccelerationRatio = accel;
            sb.DecelerationRatio = decel;
        }
    }
}
