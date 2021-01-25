namespace MovieApi.Repositories.Queries
{
    public static class GenreQueries
    {
        public const string InsertIntoGenre = @"
                                    INSERT INTO film.genre (type)
                                    VALUES (@type)
                                    RETURNING id AS Id, type AS Type";

        public const string InsertIntoMovieGenre = @"
                                   INSERT INTO film.movie_genre (movie_id, genre_id)
                                   VALUES (@movieId, @genreId)
                                   RETURNING movie_id AS MovieId, genre_id AS GenreId";

        public const string GetGenreByType = @"SELECT
                            id AS Id,
                            type AS Type
                            FROM film.genre
                            WHERE type = @type";
    }
}