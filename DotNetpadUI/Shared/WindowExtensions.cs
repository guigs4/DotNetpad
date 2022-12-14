using Avalonia.Controls;
using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media;
using Engine.Models;

namespace DotNetpadUI.Shared
{
    public static class WindowExtensions
    {
        public static void UpdateInterface(this Window window, UserPreferencesModel preferencesModel)
        {
            window.FontFamily = preferencesModel.Font;
            window.FontSize = preferencesModel.FontSize;
            window.Background = (IBrush)ColorToBrushConverter.Convert(Color.Parse(preferencesModel.BackgroundColor), typeof(IBrush));
            window.Foreground = (IBrush)ColorToBrushConverter.Convert(Color.Parse(preferencesModel.ForegroundColor), typeof(IBrush));
        }
    }
}
