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
    }
}
