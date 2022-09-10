namespace Engine.DTOs
{
    public class UserPreferencesDTO //TODO: Create a model and instantiate

    {
        public int SaveIntervalInMinutes { get; set; }
        public int SaveIntervalInSeconds { get; set; }
        public int SaveIntervalInMilliseconds
        {
            get
            {
                return (SaveIntervalInMinutes * 60 + SaveIntervalInSeconds) * 1000;
            }
        }
        public string? CachePath { get; set; }
        public string Font { get; set; }
        public int FontSize { get; set; }

    }
}
