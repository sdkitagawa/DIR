using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DiscordIconReplacer.Services;

namespace DiscordIconReplacer.Controls;

public partial class DirectoryRow : UserControl
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(DirectoryRow),
            new PropertyMetadata(string.Empty, OnTitleChanged));

    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register(nameof(Description), typeof(string), typeof(DirectoryRow),
            new PropertyMetadata(string.Empty, OnDescriptionChanged));

    public static readonly DependencyProperty IconKindProperty =
        DependencyProperty.Register(nameof(IconKind), typeof(IconKind), typeof(DirectoryRow),
            new PropertyMetadata(IconKind.Tag, OnIconKindChanged));

    public static readonly DependencyProperty PathValueProperty =
        DependencyProperty.Register(nameof(PathValue), typeof(string), typeof(DirectoryRow),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnPathValueChanged));

    public static readonly DependencyProperty IsFolderProperty =
        DependencyProperty.Register(nameof(IsFolder), typeof(bool), typeof(DirectoryRow),
            new PropertyMetadata(false));

    public static readonly DependencyProperty DividerVisibilityProperty =
        DependencyProperty.Register(nameof(DividerVisibility), typeof(Visibility), typeof(DirectoryRow),
            new PropertyMetadata(Visibility.Visible));

    public static readonly DependencyProperty IconImagePathProperty =
        DependencyProperty.Register(nameof(IconImagePath), typeof(string), typeof(DirectoryRow),
            new PropertyMetadata(string.Empty, OnIconImagePathChanged));

    public string IconImagePath
    {
        get => (string)GetValue(IconImagePathProperty);
        set => SetValue(IconImagePathProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public IconKind IconKind
    {
        get => (IconKind)GetValue(IconKindProperty);
        set => SetValue(IconKindProperty, value);
    }

    public string PathValue
    {
        get => (string)GetValue(PathValueProperty);
        set => SetValue(PathValueProperty, value);
    }

    public bool IsFolder
    {
        get => (bool)GetValue(IsFolderProperty);
        set => SetValue(IsFolderProperty, value);
    }

    public Visibility DividerVisibility
    {
        get => (Visibility)GetValue(DividerVisibilityProperty);
        set => SetValue(DividerVisibilityProperty, value);
    }

    public IFileDialogService DialogService { get; set; }

    public DirectoryRow()
    {
        InitializeComponent();
        BrowseButton.Click += BrowseButton_Click;
    }

    private void PathTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        PathValue = PathTextBox.Text;
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        var service = DialogService;
        if (service == null) return;

        if (IsFolder)
        {
            var result = service.ShowFolderDialog(Title, PathValue);
            if (result != null)
                PathValue = result;
        }
        else
        {
            var result = service.ShowFileDialog("Icon", "ico");
            if (result != null)
                PathValue = result;
        }
    }

    private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((DirectoryRow)d).TitleTextBlock.Text = (string)e.NewValue;
    }

    private static void OnDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((DirectoryRow)d).DescriptionTextBlock.Text = (string)e.NewValue;
    }

    private static void OnIconKindChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((DirectoryRow)d).ApplyIcon((IconKind)e.NewValue);
    }

    private static void OnPathValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var row = (DirectoryRow)d;
        var value = (string)e.NewValue ?? string.Empty;
        row.PathTextBox.Text = value;
        row.PlaceholderText.Visibility = string.IsNullOrEmpty(value) ? Visibility.Visible : Visibility.Collapsed;
    }

    private static void OnIconImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((DirectoryRow)d).ApplyIconImage((string)e.NewValue);
    }

    private void ApplyIconImage(string path)
    {
        if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
        {
            try
            {
                using (var stream = File.OpenRead(path))
                {
                    var frame = BitmapFrame.Create(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                    IconImage.Source = frame;
                }

                var clipRect = new System.Windows.Rect(0, 0, 28, 28);
                IconImage.Clip = new System.Windows.Media.RectangleGeometry(clipRect) { RadiusX = 6, RadiusY = 6 };
                IconImage.Visibility = Visibility.Visible;
                RenderOptions.SetBitmapScalingMode(IconImage, BitmapScalingMode.Fant);
                IconTextBlock.Visibility = Visibility.Collapsed;
                IconFolderPath.Visibility = Visibility.Collapsed;
                return;
            }
            catch
            {
            }
        }

        ApplyIcon(IconKind);
    }

    private void ApplyIcon(IconKind kind)
    {
        IconImage.Visibility = Visibility.Collapsed;
        IconTextBlock.Visibility = Visibility.Collapsed;
        IconFolderPath.Visibility = Visibility.Collapsed;

        switch (kind)
        {
            case IconKind.Folder:
                IconFolderPath.Visibility = Visibility.Visible;
                break;
            case IconKind.Tag:
                IconTextBlock.Text = "\u25C6";
                IconTextBlock.FontSize = 14;
                IconTextBlock.SetResourceReference(TextBlock.ForegroundProperty, "TagIconColor");
                IconTextBlock.Visibility = Visibility.Visible;
                break;
        }
    }
}

public enum IconKind
{
    Folder,
    Tag
}