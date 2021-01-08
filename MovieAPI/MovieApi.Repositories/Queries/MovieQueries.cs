namespace MovieApi.Repositories.Queries
{
    public static class MovieQueries
    {
        public const string InsertIntoMovie = @"
                            INSERT INTO film.movie (title, release_date, runtime, imdb_rating)
                            VALUES (@Title, @ReleaseDate, @Runtime, @ImdbRating)
                            RETURNING id AS Id, release_date As ReleaseDate, 
                            runtime AS Runtime, imdb_rating AS ImdbRating";

        public const string InsertIntoDirector = @"
                            INSERT INTO film.director (full_name)
                            VALUES (@fullName)
                            RETURNING id AS Id, full_name AS FullName";

        public const string InsertIntoGenre = @"
                            INSERT INTO film.genre (type)
                            VALUES (@type)
                            RETURNING id AS Id, type AS Type";

        public const string InsertIntoWatched = @"
                            INSERT INTO film.watched (user_id, movie_id, rating)
                            VALUES (@userId, @movieId, @rating)
                            ReTURNING user_id AS UserId, movie_id AS MovieId, rating AS Rating";

        public const string InsertIntoToWatch = @"
                            INSERT INTO film.to_watch (user_id, movie_id)
                            VALUES (@userId, @movieId)
                            RETURNING user_id AS UserId, movie_id AS MovieId";

        public const string InsertIntoFavouriteDirector = @"
                            INSERT INTO film.favourite_director (user_id, director_id)
                            VALUES (userId, directorId)
                            RETURNING user_id AS UserId, director_id AS DirectorId";

        public const string InsertIntoMovieDirector = @"
                            INSERT INTO film.movie_director (movie_id, director_id)
                            VALUES (@movieId, @directorId)
                            RETURNING movie_id As MovieId, director_id AS DirectorId";

        public const string InsertIntoMovieGenre = @"
                            INSERT INTO film.movie_genre (movie_id, genre_id),
                            VALUES (@movieId, genreId)";

        public const string GetMovieIdByTitle = @"
                            SELECT id AS Id FROM film.movie WHERE title = @title";

        public const string GetMovieByTitle = @"SELECT
                            id AS Id,
                            title AS Title,
                            release_date AS ReleaseDate,
                            runtime AS Runtime,
                            imdb_rating AS ImdbRating,
                            poster AS Poster
                            FROM film.movie
                            WHERE title = @title";

        public const string GetMoviesByIds = @"SELECT
                            id AS Id,
                            title AS Title,
                            release_date AS ReleaseDate,
                            runtime AS Runtime,
                            imdb_rating AS ImdbRating,
                            poster AS Poster
                            FROM film.movie
                            WHERE id = ANY(@ids)";

        public const string ChangeRating = @"
                            UPDATE film.watched
                            SET rating = @rating
                            WHERE title = @title";

        public const string CheckIfMovieIsInWatchedTable = @"
                            SELECT EXISTS(SELECT 1 FROM film.watched WHERE title=@title)";

        public const string GetTop50WithTies = @"
                            SELECT * FROM film.watched
                            ORDER BY rating DESC
                            FETCH FIRST 50 ROWS WITH TIES";
    }
}