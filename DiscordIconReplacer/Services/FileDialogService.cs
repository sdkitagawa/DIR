using System.Windows.Forms;
using Microsoft.Win32;

namespace DiscordIconReplacer.Services;

public class FileDialogService : IFileDialogService
{
    public string ShowFileDialog(string fileType, string extension)
    {
        var dialog = new Microsoft.Win32.OpenFileDialog
        {
            Filter = DialogFilter.Build(fileType, extension),
            Title = $"Select {fileType}",
            CheckFileExists = true
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }

    public string ShowFolderDialog(string title, string currentPath)
    {
        using (var folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = title;
            if (!string.IsNullOrEmpty(currentPath))
                folderDialog.SelectedPath = currentPath;
            return folderDialog.ShowDialog() == DialogResult.OK ? folderDialog.SelectedPath : null;
        }
    }
}
