using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordIconReplacer.Services
{
    public interface IFileDialogService
    {
        void ShowFileDialog(TextBox targetTextBox, string fileType, string extension);

        void ShowFolderDialog(TextBox targetTextBox, string title);
    }
}
