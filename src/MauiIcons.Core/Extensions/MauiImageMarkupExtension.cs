using MauiIcons.Core.Helpers;
using System.Runtime.CompilerServices;
using IImage = Microsoft.Maui.IImage;

namespace MauiIcons.Core;
public static class MauiImageMarkupExtension
{
    /// <summary>
    /// Gets or sets the icon.
    /// </summary>
    public static TImage Icon<TImage,TEnum>(this TImage bindable, TEnum icon) where TImage : BindableObject, IImageSourcePart where TEnum : struct,Enum
    {
        if(bindable is Button)
        {
            var imageSource = new FontImageSource()
            {
                Glyph = icon.GetDescription(),
                FontFamily = icon.GetFontFamily(),
                Size = 30.0,
                Color = Colors.Black,
            };
            bindable.SetValue(Button.ImageSourceProperty, imageSource);
            return bindable;
        }
        if(bindable is IImage)
        {
            ImageSource imageSource = new FontImageSource()
            {
                Glyph = icon.GetDescription(),
                FontFamily = icon.GetType().Name,
            };
            bindable.SetValue(Image.SourceProperty, imageSource);
            return bindable;
        }

        if(bindable is MenuItem)
        {
            var imageSource = new FontImageSource()
            {
                Glyph = icon.GetDescription(),
                FontFamily = icon.GetFontFamily(),
                Size = 50.0,
                Color = Colors.Black,
            };
            bindable.SetValue(MenuItem.IconImageSourceProperty, imageSource);
            return bindable;
        }

        return ThrowCustomExpection<TImage>();
    }

    /// <summary>
    /// Gets or sets the size of the icon.
    /// </summary>
    public static TSize IconSize<TSize>(this TSize bindable, double size) where TSize : BindableObject, IImage
    {
        if(bindable is Button)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.Size = size;

            bindable.SetValue(Button.ImageSourceProperty, imageSource);
            return bindable;
        }
        if(bindable is IImage)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.Size = size;

            bindable.SetValue(Image.SourceProperty, imageSource);
            return bindable;
        }

        if(bindable is MenuItem)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.Size = size;

            bindable.SetValue(MenuItem.IconImageSourceProperty, imageSource);
            return bindable;
        }

        return ThrowCustomExpection<TSize>();
    }

    /// <summary>
    /// Gets or sets the color of the icon.
    /// </summary>
    public static TColor IconColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IImage
    {
        if(bindable is Button)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.Color = color;

            bindable.SetValue(Button.ImageSourceProperty, imageSource);
            return bindable;
        }
        if(bindable is IImage)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.Color = color;

            bindable.SetValue(Image.SourceProperty, imageSource);
            return bindable;
        }

        if(bindable is MenuItem)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.Color = color;

            bindable.SetValue(MenuItem.IconImageSourceProperty, imageSource);
            return bindable;
        }

        return ThrowCustomExpection<TColor>();
    }

    /// <summary>
    /// Gets or sets the background color of the icon.
    /// </summary>
    public static TColor IconBackgroundColor<TColor>(this TColor bindable, Color color) where TColor : BindableObject, IImage
    {
        if(bindable is Button)
        {
            //bindable.SetValue(Button.BackgroundColorProperty, color);
            return bindable;
        }
        if(bindable is IImage)
        {
            bindable.SetValue(Image.BackgroundColorProperty, color);
            return bindable;
        }

        if(bindable is MenuItem)
        {
            return bindable;
        }
        return ThrowCustomExpection<TColor>();
    }

    /// <summary>
    /// Gets or sets a value indicating whether the icon should automatically scale.
    /// </summary>
    public static TBool IconAutoScaling<TBool>(this TBool bindable, bool value) where TBool : BindableObject, IImage
    {
        if(bindable is Button)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.FontAutoScalingEnabled = value;

            bindable.SetValue(Button.ImageSourceProperty, imageSource);
            return bindable;
        }
        if(bindable is IImage)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.FontAutoScalingEnabled = value;

            bindable.SetValue(Image.SourceProperty, imageSource);
            return bindable;
        }

        if(bindable is MenuItem)
        {
            var imageSource = GetExistingSource(bindable);
            imageSource.FontAutoScalingEnabled = value;

            bindable.SetValue(MenuItem.IconImageSourceProperty, imageSource);
            return bindable;
        }
        return ThrowCustomExpection<TBool>();
    }

    /// <summary>
    /// Sets a value for multiple platforms that this should render.
    /// </summary>
    public static TPlatform OnPlatforms<TPlatform>(this TPlatform bindable, IList<string> platforms) where TPlatform : BindableObject, IImage
    {
        if(bindable is Button && PlatformHelper.IsValidPlatform(platforms))
            return bindable;

        else if(bindable is Button)
        {
            bindable.SetValue(Button.TextProperty, null);
            bindable.SetValue(Button.FontFamilyProperty, null);
            bindable.SetValue(Button.FontSizeProperty, null);
            bindable.SetValue(Button.TextColorProperty, null);
            bindable.SetValue(Button.BackgroundColorProperty, null);
            bindable.SetValue(Button.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if(bindable is IImage && PlatformHelper.IsValidPlatform(platforms))
            return bindable;

        else if(bindable is IImage)
        {
            bindable.SetValue(Image.SourceProperty, null);
            bindable.SetValue(Image.BackgroundColorProperty, null);
            return bindable;
        }
        return ThrowCustomExpection<TPlatform>();
    }

    /// <summary>
    /// Sets a value for multiple Idioms that this should render.
    /// </summary>
    public static TIdiom OnIdioms<TIdiom>(this TIdiom bindable, IList<string> idioms) where TIdiom : BindableObject, IImage
    {
        if(bindable is Button && PlatformHelper.IsValidIdiom(idioms))
            return bindable;

        else if(bindable is Button)
        {
            bindable.SetValue(Button.TextProperty, null);
            bindable.SetValue(Button.FontFamilyProperty, null);
            bindable.SetValue(Button.FontSizeProperty, null);
            bindable.SetValue(Button.TextColorProperty, null);
            bindable.SetValue(Button.BackgroundColorProperty, null);
            bindable.SetValue(Button.FontAutoScalingEnabledProperty, false);
            return bindable;
        }
        if(bindable is IImage && PlatformHelper.IsValidIdiom(idioms))
            return bindable;

        else if(bindable is IImage)
        {
            bindable.SetValue(Image.SourceProperty, null);
            bindable.SetValue(Image.BackgroundColorProperty, null);
            return bindable;
        }
        return ThrowCustomExpection<TIdiom>();
    }

    static TType ThrowCustomExpection<TType>()
    {
        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new(17, 1);
        defaultInterpolatedStringHandler.AppendFormatted(typeof(TType));
        defaultInterpolatedStringHandler.AppendLiteral(" is not supported");
        throw new MauiIconsExpection(defaultInterpolatedStringHandler.ToStringAndClear());
    }

    internal static FontImageSource GetExistingSource<TType>(TType bindable) where TType : BindableObject
    {
        if(bindable is Image fontImage)
        {
            if(fontImage.Source is null)
                return new FontImageSource();

            return (FontImageSource)fontImage.Source;
        }

        if(bindable is Button button)
        {
            return button.ImageSource as FontImageSource ?? new FontImageSource();
        }

        if(bindable is ImageButton imageButton)
        {
            return imageButton.Source as FontImageSource ?? new FontImageSource();
        }

        if(bindable is MenuItem menuItem)
        {
            return menuItem.IconImageSource as FontImageSource ?? new FontImageSource();
        }
        throw new MauiIconsExpection("This Image Element Does Not Support Maui Icon Extensions.");
    }
}
