namespace MovieApi.Repositories.Queries
{
    public static class DirectorQueries
    {
        public const string InsertIntoDirector = @"
                            INSERT INTO film.director (first_name, last_name)
                            VALUES (@firstName, @lastName)
                            RETURNING id";

        public const string InsertIntoFavouriteDirector = @"
                            INSERT INTO film.favourite_director (user_id, director_id)
                            VALUES (@userId, @directorId)
                            RETURNING user_id AS UserId, director_id AS DirectorId";

        public const string InsertIntoMovieDirector = @"
                            INSERT INTO film.movie_director (movie_id, director_id)
                            VALUES (@movieId, @directorId)
                            RETURNING movie_id As MovieId, director_id AS DirectorId";

        public const string GetDirectorByFullName = @"SELECT
                            id AS Id,
                            first_name AS FirstName,
                            last_name AS LastName
                            FROM film.director
                            WHERE first_name = @firstName
                            AND last_name = @lastName";
    }
}