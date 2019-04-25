using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ControlExplorer.iOS;
using CoreAnimation;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]

namespace ControlExplorer.iOS
{
    class MyButtonGradientEffect : PlatformEffect
    {
        CAGradientLayer gradLayer;

        protected override void OnAttached()
        {
            if (Element is Button == false)
                return;

            SetGradient();
        }

        protected override void OnDetached()
        {
            if (gradLayer != null)
                gradLayer.RemoveFromSuperLayer();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(e);

            if (Element is Button == false)
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
            gradLayer?.RemoveFromSuperLayer();

            var xfButton = Element as Button;
            var colorTop = xfButton.BackgroundColor;
            var colorBottom = ButtonGradientEffect.GetGradientColor(xfButton); ;

            gradLayer = Gradient.GetGradientLayer(colorTop.ToCGColor(), colorBottom.ToCGColor(), (float)xfButton.Width, (float)xfButton.Height);

            Control.Layer.InsertSublayer(gradLayer, 0);
        }

    }
}