using Avalonia.Controls;
using Engine.Services;
using Engine.ViewModels;
using System.Text;
using System;
using System.Threading.Tasks;

namespace DotNetpadUI.FileDialogs
{
    public class OpenFileDialogWindow
    {
        public static async Task OpenFiles(Window parent, DataSession dataSession)
        {
            var dlg = new OpenFileDialog();
            dlg.Filters.Add(new FileDialogFilter() { Name = "Text Files", Extensions = { "txt" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "All Files", Extensions = { "*" } });
            dlg.AllowMultiple = true;

            var result = await dlg.ShowAsync(parent);
            if (result != null)
            {
                string[] fileNames = result;
                var sb = new StringBuilder();
                int indexTest = dataSession.OpenTabs.Count - 1;
                foreach (string fileName in fileNames)
                {
                    try
                    {
                        string header = CacheService.GetFileName(fileName);
                        dataSession.OpenTabs.Add(new(indexTest, header, CacheService.LoadTextBoxData(fileName), false));
                        indexTest++;
                    }
                    catch (Exception ex)
                    {
                        string text = string.Format("Error: {0}\n", ex.Message);
                        sb.Append(text);
                    }
                }
            }
        }
    }
}
