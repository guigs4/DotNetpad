using System.Text.Json.Serialization;

namespace Engine.Models
{
    public class TabModel
    {
        public int Id { get; set; }
        public string? Header { get; set; }
        public string? Content { get; set; }
        public bool IsInternal { get; set; }

        public TabModel(int index, string header, string content = "", bool isInternal = true)
        {
            Id = index;
            Header = header;
            Content = content;
            IsInternal = isInternal;
        }

        public TabModel(int index)
        {
            Id = index;
            Header = $"New Tab";
            Content = "";
            IsInternal = true;
        }

        [JsonConstructor]
        public TabModel(int id, string header, string content)
        {
            Id = id;
            Header = header;
            Content = content;
        }
    }
}
