using Avalonia.Controls;
using Engine.Services;
using Engine.ViewModels;
using System;
using System.Threading.Tasks;

namespace DotNetpadUI.FileDialogs
{
    public class OpenFileDialogWindow
    {
        public static async Task OpenFiles(Window parent, DataSession dataSession)//TODO: Dependency injection
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
                string[] fileNames = result;
                int tabIndex = dataSession.OpenTabs.Count - 1;
                foreach (string fileName in fileNames)
                {
                    try
                    {
                        string header = CacheService.GetFileName(fileName);
                        dataSession.OpenTabs.Add(new(tabIndex, header, CacheService.LoadTextBoxData(fileName), false));
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
