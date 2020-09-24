namespace MovieApi.Omdb.Client
{
    public class OmdbApiSettings
    {
        public string BaseUrl { get; set; }
        public string BaseUrlImg { get; set; }
        public string ApiKey { get; set; }
        public int ConnectionTimeout { get; set; }
        public QueryParamsSettings QueryParams { get; set; }
    }

    public class QueryParamsSettings
    {
        public string ApiKey { get; set; }
        public string SearchByTitle { get; set; }
        public string SearchByType { get; set; }
        public string PageNumber { get; set; }
        public string DataTypeToReturn { get; set; }
    }
}