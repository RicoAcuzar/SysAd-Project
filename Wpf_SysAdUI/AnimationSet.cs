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
    public static class AnimationSet
    {
        private static Storyboard sboard;

        static AnimationSet()
        {
            sboard = new Storyboard();
        }

        public static event EventHandler Completed
        {
            add { sboard.Completed += value; }
            remove { sboard.Completed -= value; }
        }

        public static void Add(DependencyObject element, AnimationKind type, AnimationTimeline animation)
        {
            switch(type)
            {
                case AnimationKind.BackgroundColor:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Background.Color"));
                    break;
                case AnimationKind.BorderColor:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("(Border.BorderBrush).(SolidColorBrush.Color)"));
                    break;
                case AnimationKind.BackgroundOpacity:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Background.Opacity"));
                    break;
                case AnimationKind.DropShadowOpacity:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Effect.Opacity"));
                    break;
                case AnimationKind.DropShadowBlur:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Effect.BlurRadius"));
                    break;
                case AnimationKind.Opacity:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
                    break;
                case AnimationKind.TranslateX:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
                    break;
                case AnimationKind.TranslateY:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.Y)"));
                    break;
                case AnimationKind.Margin:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
                    break;
                case AnimationKind.Width:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Width"));
                    break;
                case AnimationKind.Height:
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));
                    break;
                default:
                    break;
            }

            Storyboard.SetTarget(animation, element);
            sboard.Children.Add(animation);
        }

        public static void Run()
        {
            if (sboard.Children.Count > 0)
            {
                sboard.Begin();
                sboard = new Storyboard();
            }
        }
    }
}
