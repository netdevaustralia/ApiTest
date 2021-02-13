namespace Application.Core.Utils
{
    using System.Text.Json;

    public static class JsonSerializerExtensions
    {
        private static readonly JsonSerializerOptions DefaultSerializerSettings = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringConverter(), new JsonInt32Converter() },
            IgnoreNullValues = true
        };

        public static JsonSerializerOptions GetDefaultJsonSerializerOptions()
        {
            return DefaultSerializerSettings;
        }
    }
}