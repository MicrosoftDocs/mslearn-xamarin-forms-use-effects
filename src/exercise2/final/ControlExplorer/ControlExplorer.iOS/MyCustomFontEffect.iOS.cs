using CustomFont.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(MyCustomFontEffect), "CustomFontEffect")]
namespace CustomFont.iOS
{
    class MyCustomFontEffect : PlatformEffect
    {
        UIFont oldFont;

        protected override void OnAttached()
        {
            if (Element is Label == false)
                return;

            var label = Control as UILabel;

            oldFont = label.Font;

            label.Font = UIFont.FromName("Pacifico", label.Font.PointSize);
        }

        protected override void OnDetached()
        {
            if(oldFont != null)
            {
                var label = Control as UILabel;
                label.Font = oldFont;
            }
        }
    }
}