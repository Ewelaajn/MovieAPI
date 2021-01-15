DROP SCHEMA IF EXISTS film CASCADE;
CREATE SCHEMA film;

CREATE TABLE film.user
(
    id SERIAL PRIMARY KEY,
    nickname TEXT UNIQUE NOT NULL,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    mail TEXT UNIQUE NOT NULL
);

CREATE TABLE film.movie
(
	id SERIAL PRIMARY KEY,
	title TEXT NOT NULL,
	release_date DATE,
	runtime INTEGER,
    imdb_rating NUMERIC,
    UNIQUE(title, release_date)
);

CREATE TABLE film.director
(
	id SERIAL PRIMARY KEY,
	first_name TEXT NOT NULL,
	last_name TEXT NOT NULL,
	UNIQUE (first_name, last_name)
);

CREATE TABLE film.genre
(
	id SERIAL PRIMARY KEY,
	type TEXT UNIQUE NOT NULL
);

CREATE TABLE film.top50
(
	id SERIAL PRIMARY KEY,
	movie_id INTEGER NOT NULL
);

CREATE TABLE film.watched
(
    user_id INTEGER NOT NULL,
	movie_id INTEGER NOT NULL,
    rating NUMERIC,
    UNIQUE(user_id, movie_id)
);

CREATE TABLE film.to_watch
(
    user_id INTEGER NOT NULL,
	movie_id INTEGER NOT NULL,
	UNIQUE (user_id, movie_id)
);

CREATE TABLE film.favourites_directors
(
    user_id INTEGER NOT NULL,
	director_id INTEGER NOT NULL,
	UNIQUE(user_id, director_id)
);

CREATE TABLE film.movie_director
(
	movie_id INTEGER NOT NULL,
	director_id INTEGER NOT NULL,
	UNIQUE(movie_id, director_id)
);

CREATE TABLE film.movie_genre
(
	movie_id INTEGER NOT NULL,
	genre_id INTEGER NOT NULL,
	UNIQUE(movie_id, genre_id)
);


