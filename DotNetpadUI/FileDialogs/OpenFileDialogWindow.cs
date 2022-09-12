using Avalonia.Controls;
using Engine.Services;
using Engine.ViewModels;
using System;
using System.Threading.Tasks;

namespace DotNetpadUI.FileDialogs
{
    public class OpenFileDialogWindow
    {
        public static async Task OpenFiles(Window parent, IDataSessionVM dataSession)//TODO: Dependency injection
        {
            var dlg = new OpenFileDialog();
            dlg.Filters.Add(new FileDialogFilter() { Name = "Text Files", Extensions = { "txt" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "Json Files", Extensions = { "json" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "XML Files", Extensions = { "xml" } });
            dlg.Filters.Add(new FileDialogFilter() { Name = "All Files", Extensions = { "*" } });
            dlg.AllowMultiple = true;

            var result = await dlg.ShowAsync(parent);
            if (result != null)
            {
                string[] filePaths = result;
                int tabIndex = dataSession.OpenTabs.Count - 1;
                foreach (string filePath in filePaths)
                {
                    try
                    {
                        string header = DiskIOService.GetFileName(filePath); //Consider calling it from the dataSession
                        dataSession.OpenTabs.Add(new(tabIndex, header, TabDataIOService.LoadTextBoxData(filePath), false));
                        tabIndex++;
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}
