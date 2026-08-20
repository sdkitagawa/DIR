using System.Windows.Forms;

namespace DiscordIconReplacer.Services;

public class FileDialogService : IFileDialogService
{
    public string ShowFileDialog(string fileType, string extension)
    {
        using (var dialog = new OpenFileDialog
        {
            Filter = $"{fileType} (*.{extension})| *.{extension}",
            Title = $"Select {fileType}"
        })
        {
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
        }
    }

    public string ShowFolderDialog(string title, string currentPath)
    {
        using (var folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = title;
            folderDialog.SelectedPath = currentPath;
            return folderDialog.ShowDialog() == DialogResult.OK ? folderDialog.SelectedPath : null;
        }
    }
}
