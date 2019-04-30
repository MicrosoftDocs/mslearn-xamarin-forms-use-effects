using Android.Graphics.Drawables;
using Android.Graphics;

namespace ControlExplorer.Droid
{
    public static class Gradient
    {
        public static GradientDrawable GetGradientDrawable (Color colorTop, Color colorBottom)
        {
            return new GradientDrawable(GradientDrawable.Orientation.TopBottom, new int[] { colorTop, colorBottom });
        }
    }
}