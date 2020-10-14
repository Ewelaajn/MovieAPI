using Newtonsoft.Json.Converters;

namespace MovieApi.Services.Models
{
    public class JustDateNoTimeConverter : IsoDateTimeConverter
    {
        public JustDateNoTimeConverter()
        {
            DateTimeFormat = "dd-MM-yyyy";
        }
    }
}
