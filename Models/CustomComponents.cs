using System;
namespace Maui_PagoJa.Controls
{
    public class CustomComponents
    {
        public static View GetCustomTitle(string title)
        {
            var lblTitle = new Label()
            {
                Text = title,
                FontSize = 16,
                FontFamily = "OpenSansRegular",
                TextColor = Color.FromArgb("FBFBFB"),
                FontAttributes = FontAttributes.None,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TranslationX = -16,
            };

            return lblTitle;
        }

        public static Image GetCustomIcon(string iconPath)
        {
            var icon = new Image()
            {
                Source = iconPath,
                HeightRequest = 10, 
                WidthRequest = 10, 
                Aspect = Aspect.Center, 
                
            };

            return icon;
        }
    }
}
