using Android.Graphics;
using Android.Widget;
using CustomFont.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(MyCustomFontEffect), "CustomFontEffect")]
namespace CustomFont.Droid
{
    class MyCustomFontEffect : PlatformEffect
    {
        Typeface oldFont;

        protected override void OnAttached()
        {
            if (Element is Label == false)
                return;

            var label = Control as TextView; 

            oldFont = label.Typeface;

            var font = Typeface.CreateFromAsset(Android.App.Application.Context.Assets, "Pacifico.ttf"); 
            label.Typeface = font;
        }

        protected override void OnDetached()
        {
            if (oldFont != null)
            {
                var label = Control as TextView;

                label.Typeface = oldFont;
            }
        }
    }
}