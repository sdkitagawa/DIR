using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordIconReplacer.Services
{
    public class FileDialogService : IFileDialogService
    {
        public void ShowFileDialog(TextBox targetTextBox, string fileType, string extension)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = $"{fileType} (*.{extension})| *.{extension}",
                Title = $"Select {fileType}"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    targetTextBox.Text = dialog.FileName;
            }
        }

        public void ShowFolderDialog(TextBox targetTextBox, string title)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = title;
                folderDialog.SelectedPath = targetTextBox.Text;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                    targetTextBox.Text = folderDialog.SelectedPath;
            }
        }
    }
}
