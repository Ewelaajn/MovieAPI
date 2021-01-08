namespace MovieApi.Repositories.Models
{
    public class Watched
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
    }
}