using Avalonia.Controls;
using Engine.Services;
using Engine.ViewModels;
using System.Text;
using System;
using System.Threading.Tasks;

namespace DotNetpadUI.FileDialogs
{
    public class SaveFileDialogWindow
    {
        public static async Task ExportFile(Window parent, string content)
        {
            var dlg = new SaveFileDialog();
            dlg.Filters.Add(new FileDialogFilter() { Name = "Text Files", Extensions = { "txt" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "All Files", Extensions = { "*" } });

            var result = await dlg.ShowAsync(parent);
            if (result != null)
            {
                CacheService.SaveTextBoxData(result, content);
            }
        }
    }
}
