using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class UserPreferences
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
