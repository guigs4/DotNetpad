using System.Text.Json.Serialization;

namespace Engine.Models
{
    public class UserPreferencesModel : ICloneable
    {
        public int SaveIntervalInMinutes { get; set; }
        public int SaveIntervalInSeconds { get; set; }
        [JsonIgnore]
        public int SaveIntervalInMilliseconds
        {
            get
            {
                return (SaveIntervalInMinutes * 60 + SaveIntervalInSeconds) * 1000;
            }
        }
        public string? DataPath { get; set; }
        public string? Font { get; set; }
        public int FontSize { get; set; }
        public string? ForegroundColor { get; set; }
        public string? BackgroundColor { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

    }
}
