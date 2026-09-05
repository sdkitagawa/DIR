using System;
using System.Windows;

namespace DiscordIconReplacer.Skins;

public static class SkinManager
{
    private static readonly string[] AvailableSkins = { "Main", "Logic12", "LogicPro9" };

    public static string[] GetAvailableSkins() => AvailableSkins;

    public static string GetDisplayName(string skinKey)
    {
        return skinKey switch
        {
            "Main" => "Discord Blurple",
            "Logic12" => "Logic 12.3.1",
            "LogicPro9" => "Logic Pro 9",
            _ => skinKey
        };
    }

    public static void ApplySkin(string skinName)
    {
        var app = Application.Current;
        if (app == null) return;

        app.Resources.MergedDictionaries.Clear();

        var dict = new ResourceDictionary
        {
            Source = new Uri($"pack://application:,,,/Themes/{skinName}.xaml", UriKind.Absolute)
        };
        app.Resources.MergedDictionaries.Add(dict);

        Properties.Settings.Default.SelectedSkin = skinName;
        Properties.Settings.Default.Save();
    }
}
