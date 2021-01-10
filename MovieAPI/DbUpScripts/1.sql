DROP SCHEMA IF EXISTS film CASCADE;
CREATE SCHEMA film;

/*TABLE FOR ALL USERS OF SITE*/

CREATE TABLE film.user
(
    id SERIAL PRIMARY KEY,
    nickname TEXT UNIQUE NOT NULL,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    mail TEXT UNIQUE NOT NULL
);

/*MOVIE PARAMETERS*/

CREATE TABLE film.movie
(
	id SERIAL PRIMARY KEY,
	title TEXT NOT NULL,
	release_date DATE,
	runtime INTEGER,
    imdb_rating NUMERIC
);


/*DIRECTOR PARAMETERS TO CHECK ALL DIRECTORS, ALSO TO FIND MOVIES
DIRECTED BY CHOSEN FULL_NAME, BEST MOVIES FROM ONE DIRECTOR ETC.*/

CREATE TABLE film.director
(
	id SERIAL PRIMARY KEY,
	full_name TEXT NOT NULL UNIQUE
);

/*TO SEE ALL GENRES OF MOVIES, FIND THE BEST MOVIES IN CHOSEN GENRE,
ALL MOVIES BY ONE TYPE ETC.*/

CREATE TABLE film.genre
(
	id SERIAL PRIMARY KEY,
	type TEXT UNIQUE NOT NULL
);

/*TOP 50 MOVIES BY IMDB RATING WITH PARAMETERS*/

CREATE TABLE film.top50
(
	id SERIAL PRIMARY KEY,
	movie_id INTEGER NOT NULL
);

/*CLIENT CAN OPERATE WITH FILMS THAT ALREADY WATCHED*/

CREATE TABLE film.watched
(
    user_id INTEGER NOT NULL,
	movie_id INTEGER NOT NULL,
    rating NUMERIC,
    UNIQUE(user_id, movie_id)
);

/*CLIENT CAN CHOOSE MOVIES THAT HE WANT TO SEE IN FUTURE*/

CREATE TABLE film.to_watch
(
    user_id INTEGER NOT NULL,
	movie_id INTEGER NOT NULL,
	UNIQUE (user_id, movie_id)
);

/*CLIENT CAN ADD FAVOURITES DIRECTORS, AND THEN ON THE OTHER TABLES
CHECK HIS MOVIES THAT HE HAVENT SEEN*/

CREATE TABLE film.favourites_directors
(
    user_id INTEGER NOT NULL,
	director_id INTEGER NOT NULL,
	UNIQUE(user_id, director_id)
);

/*THIS IS TABLE WHERE WE CAN CHECK ALL MOVIE FROM ONE DIRECTOR, OR
WHO DIRECTED CHOSEN MOVIE*/

CREATE TABLE film.movie_director
(
	movie_id INTEGER NOT NULL,
	director_id INTEGER NOT NULL,
	UNIQUE(movie_id, director_id)
);

/*TABLE TO SORT AND FIND MOVIES BY GENRE*/

CREATE TABLE film.movie_genre
(
	movie_id INTEGER NOT NULL,
	genre_id INTEGER NOT NULL,
	UNIQUE(movie_id, genre_id)
);


