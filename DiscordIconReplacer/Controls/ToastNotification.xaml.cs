using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DiscordIconReplacer.Controls;

public partial class ToastNotification : UserControl
{
    private static readonly TimeSpan DisplayDuration = TimeSpan.FromSeconds(1.8);

    public ToastNotification()
    {
        InitializeComponent();
    }

    public void Show(string message)
    {
        MessageText.Text = message;
        Opacity = 0;

        var storyboard = new Storyboard();

        var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(180))
        {
            EasingFunction = new QuadraticEase()
        };
        Storyboard.SetTarget(fadeIn, this);
        Storyboard.SetTargetProperty(fadeIn, new PropertyPath(OpacityProperty));
        storyboard.Children.Add(fadeIn);

        var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(180))
        {
            EasingFunction = new QuadraticEase(),
            BeginTime = DisplayDuration
        };
        Storyboard.SetTarget(fadeOut, this);
        Storyboard.SetTargetProperty(fadeOut, new PropertyPath(OpacityProperty));
        storyboard.Children.Add(fadeOut);

        storyboard.Begin();
    }
}