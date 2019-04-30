using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ControlExplorer
{
    public class ButtonGradientEffect : RoutingEffect
    {
        public static readonly BindableProperty GradientColorProperty = BindableProperty.CreateAttached("GradientColor", typeof(Color), typeof(ButtonGradientEffect), Color.Black);

        public ButtonGradientEffect() : base("Xamarin.ButtonGradientEffect")
        { }

        public static void SetGradientColor(VisualElement view, Color color)
        {
            view.SetValue(GradientColorProperty, color);
        }

        public static Color GetGradientColor(VisualElement view)
        {
            return (Color)view.GetValue(GradientColorProperty);
        }
    }
}
