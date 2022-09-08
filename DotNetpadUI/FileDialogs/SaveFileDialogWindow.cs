using Avalonia.Controls;
using Engine.Services;
using System.Threading.Tasks;

namespace DotNetpadUI.FileDialogs
{
    public class SaveFileDialogWindow
    {
        public static async Task ExportFile(Window parent, string content)
        {
            var dlg = new SaveFileDialog();
            dlg.Filters.Add(new FileDialogFilter() { Name = "Text Files", Extensions = { "txt" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "Json Files", Extensions = { "json" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "XML Files", Extensions = { "xml" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "All Files", Extensions = { "*" } });

            var result = await dlg.ShowAsync(parent);
            if (result != null)
            {
                TabDataIOService.SaveTextBoxData(result, content);
            }
        }
    }
}
