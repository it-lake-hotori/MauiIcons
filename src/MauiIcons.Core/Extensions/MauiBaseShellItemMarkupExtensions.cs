using MauiIcons.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiIcons.Core;
public static class MauiBaseShellItemMarkupExtensions
{
    public static T HamburgerIcon<T,TEnum>(this T shellItem, TEnum icon,double size = 30d, Color color = default(Color) ,bool autoScaling = false) where T : BaseShellItem where TEnum : struct, Enum
    {
        var imageSource = new FontImageSource()
        {
            Glyph = icon.GetDescription(),
            FontFamily = icon.GetType().Name,
            Size = size,
            Color = color,
            FontAutoScalingEnabled = autoScaling,
        };

        shellItem.Icon = imageSource;
        return shellItem;
    }

    public static T Icon<T, TEnum>(this T shellItem, TEnum icon, double size = 30d, Color color = default(Color), bool autoScaling = false) where T : BaseShellItem where TEnum : struct, Enum
    {
        var imageSource = new FontImageSource()
        {
            Glyph = icon.GetDescription(),
            FontFamily = icon.GetType().Name,
            Size = size,
            Color = color,
            FontAutoScalingEnabled = autoScaling,
        };

        shellItem.Icon = imageSource;
        return shellItem;
    }
}
