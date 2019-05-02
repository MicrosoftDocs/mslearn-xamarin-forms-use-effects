using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ControlExplorer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]
namespace ControlExplorer.Droid
{
    class MyButtonGradientEffect : PlatformEffect
    {
        Drawable oldDrawable;

        protected override void OnAttached()
        {
            if (Element is Xamarin.Forms.Button == false)
                return;

            oldDrawable = Control.Background;

            SetGradient();
        }

        protected override void OnDetached()
        {
            if (oldDrawable != null)
                Control.Background = oldDrawable;
        }
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(e);

            if (Element is Xamarin.Forms.Button == false)
                return;

            if (e.PropertyName == ButtonGradientEffect.GradientColorProperty.PropertyName
            || e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName
            || e.PropertyName == VisualElement.WidthProperty.PropertyName
            || e.PropertyName == VisualElement.HeightProperty.PropertyName)
            {
                SetGradient();
            }
        }

        void SetGradient()
        {
            var xfButton = Element as Xamarin.Forms.Button;

            var colorTop = xfButton.BackgroundColor;
            var colorBottom = ButtonGradientEffect.GetGradientColor(xfButton);

            var drawable = Gradient.GetGradientDrawable(colorTop.ToAndroid(), colorBottom.ToAndroid());

            Control.SetBackground(drawable);
        }
    }
}