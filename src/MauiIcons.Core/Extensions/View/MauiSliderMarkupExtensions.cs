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
    /// <summary>
    /// Gets or sets the icon.
    /// </summary>
    public static T Icon<T>(this T slider, Enum icon) where T : Slider
    {
        ImageSource imageSource = new FontImageSource()
        {
            Glyph = icon.GetDescription(),
            FontFamily = icon.GetType().Name,
        };
        slider.ThumbImageSource = imageSource;
        return slider;
    }

    /// <summary>
    /// Gets or sets the size of the icon.
    /// </summary>
    public static T IconSize<T>(this T slider, double size) where T : Slider
    {
        var imageSource = slider.ThumbImageSource as FontImageSource ?? new FontImageSource();
        imageSource.Size = size;
        slider.ThumbImageSource = imageSource;
        return slider;
    }

    /// <summary>
    /// Gets or sets the color of the icon.
    /// </summary>
    public static T IconColor<T>(this T slider, Color color) where T : Slider
    {
        var imageSource = slider.ThumbImageSource as FontImageSource ?? new FontImageSource();
        imageSource.Color = color;
        slider.ThumbImageSource = imageSource;
        return slider;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the icon should automatically scale.
    /// </summary>
    public static T IconAutoScaling<T>(this T slider, bool value) where T : Slider
    {
        var imageSource = slider.ThumbImageSource as FontImageSource ?? new FontImageSource();
        imageSource.FontAutoScalingEnabled = value;
        slider.ThumbImageSource = imageSource;
        return slider;
    }

    /// <summary>
    /// Sets a value for multiple platforms that this should render.
    /// </summary>
    public static T OnPlatforms<T>(this T slider, IList<string> platforms) where T : Slider
    {
        if(!PlatformHelper.IsValidPlatform(platforms))
            RemoveIcon(slider);

        return slider;
    }

    /// <summary>
    /// Sets a value for multiple Idioms that this should render.
    /// </summary>
    public static T OnIdioms<T>(this T slider, IList<string> idioms) where T : Slider
    {
        if(!PlatformHelper.IsValidIdiom(idioms))
            RemoveIcon(slider);

        return slider;
    }

    static T RemoveIcon<T>(this T slider)where T : Slider
    {
        slider.ThumbImageSource = null;
        slider.BackgroundColor = null;
        return slider;
    }
}
