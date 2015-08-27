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
    public static class AnimationFactory
    {
        public static AnimationTimeline Create(AnimationType type, object newValue, TimeSpan duration, TimeSpan beginTime)
        {
            return Create(type, null, newValue, duration, beginTime, 0, 0);
        }

        public static AnimationTimeline Create(AnimationType type, object newValue, TimeSpan duration, TimeSpan beginTime, double acceleration, double deceleration)
        {
            return Create(type, null, newValue, duration, beginTime, acceleration, deceleration);
        }

        public static AnimationTimeline Create(AnimationType type, object oldValue, object newValue, TimeSpan duration, TimeSpan beginTime)
        {
            return Create(type, oldValue, newValue, duration, beginTime, 0, 0);
        }

        public static AnimationTimeline Create(AnimationType type, object oldValue, object newValue, TimeSpan duration, TimeSpan beginTime, double acceleration, double deceleration)
        {
            switch (type)
            {
                case AnimationType.DoubleAnimation:
                    if (oldValue != null)
                        return new DoubleAnimation((double)oldValue, (double)newValue, duration) { BeginTime = beginTime, AccelerationRatio = acceleration, DecelerationRatio = deceleration };
                    else
                        return new DoubleAnimation((double)newValue, duration) { BeginTime = beginTime, AccelerationRatio = acceleration, DecelerationRatio = deceleration };
                case AnimationType.ColorAnimation:
                    if (newValue is Color)
                    {
                        if (oldValue != null)
                            return new ColorAnimation((Color)oldValue, (Color)newValue, duration) { BeginTime = beginTime, AccelerationRatio = acceleration, DecelerationRatio = deceleration };
                        else
                            return new ColorAnimation((Color)newValue, duration) { BeginTime = beginTime, AccelerationRatio = acceleration, DecelerationRatio = deceleration };
                    }
                    else
                    {
                        if (oldValue != null)
                            return new ColorAnimation((Color)oldValue, (Color)ColorConverter.ConvertFromString(newValue as string), duration) { BeginTime = beginTime, AccelerationRatio = acceleration, DecelerationRatio = deceleration };
                        else
                            return new ColorAnimation((Color)ColorConverter.ConvertFromString(newValue as string), duration) { BeginTime = beginTime, AccelerationRatio = acceleration, DecelerationRatio = deceleration };
                    }
                case AnimationType.ThicknessAnimation:
                    if (oldValue != null)
                        return new ThicknessAnimation((Thickness)oldValue, (Thickness)newValue, duration) { BeginTime = beginTime, AccelerationRatio = acceleration, DecelerationRatio = deceleration };
                    else
                        return new ThicknessAnimation((Thickness)newValue, duration) { BeginTime = beginTime, AccelerationRatio = acceleration, DecelerationRatio = deceleration };
                default:
                    return null;
            }
        }
    }
}
