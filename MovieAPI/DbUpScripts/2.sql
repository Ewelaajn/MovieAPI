DROP TABLE IF EXISTS
    film.genre,
    film.top50
Cascade;

ALTER TABLE film.movie_genre ADD UNIQUE (movie_id);

