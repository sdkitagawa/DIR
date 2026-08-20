namespace DiscordIconReplacer.Services;

public interface IFileDialogService
{
    string ShowFileDialog(string fileType, string extension);
    string ShowFolderDialog(string title, string currentPath);
}
