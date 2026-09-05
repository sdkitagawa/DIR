using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using DiscordIconReplacer.Skins;

namespace DiscordIconReplacer.Controls;

public partial class TitleBar : UserControl
{
    public TitleBar()
    {
        InitializeComponent();

        foreach (var skin in SkinManager.GetAvailableSkins())
            SkinSelector.Items.Add(SkinManager.GetDisplayName(skin));

        string current = Properties.Settings.Default.SelectedSkin;
        if (string.IsNullOrWhiteSpace(current)) current = "Main";
        int index = System.Array.IndexOf(SkinManager.GetAvailableSkins(), current);
        SkinSelector.SelectedIndex = index < 0 ? 0 : index;
    }

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (IsOverInteractiveElement(e.OriginalSource))
            return;

        var window = Window.GetWindow(this);
        if (window == null)
            return;

        if (e.ClickCount == 2)
        {
            window.WindowState = window.WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }
        else
        {
            if (window.WindowState != WindowState.Maximized)
                window.DragMove();
        }
    }

    private static bool IsOverInteractiveElement(object source)
    {
        for (var current = source as DependencyObject; current != null; current = VisualTreeHelper.GetParent(current))
        {
            if (current is ButtonBase || current is ComboBox || current is TextBoxBase)
                return true;
        }

        return false;
    }

    private void SkinSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (SkinSelector.SelectedIndex < 0) return;
        var skins = SkinManager.GetAvailableSkins();
        if (SkinSelector.SelectedIndex >= skins.Length) return;
        SkinManager.ApplySkin(skins[SkinSelector.SelectedIndex]);
    }

    private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);
        if (window != null)
            window.WindowState = WindowState.Minimized;
    }

    private void ButtonClose_Click(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);
        if (window != null)
            window.Close();
    }
}