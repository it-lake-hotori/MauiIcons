using MauiIcons.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiIcons.Core;
public static class MauiSliderMarkupExtensions
{
    public static T ThumbIcon<T,TEnum>(this T slider,TEnum icon,double size = 30d, Color color = default(Color) ,bool autoScaling = false) where T : Slider where TEnum : struct,Enum
    {
        var imageSource = new FontImageSource()
        {
            Glyph = icon.GetDescription(),
            FontFamily = icon.GetType().Name,
            Size = size,
            Color = color,
            FontAutoScalingEnabled = autoScaling,
        };

        slider.ThumbImageSource = imageSource;
        return slider;
    }
}
