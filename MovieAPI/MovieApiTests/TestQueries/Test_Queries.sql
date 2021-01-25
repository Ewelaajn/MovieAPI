INSERT INTO film.movie(id, title, release_date, runtime, imdb_rating)
VALUES
(1, 'The Lord of the Rings: The Return of the King', 2003-12-17, 201, 8.9),
(2, 'American Beauty', 1999-10-01, 122, 8.3),
(3, 'The Green Mile', 1999-12-10, 189, 8.6),
(4, 'Dragon', 2011-07-04, 98, 7.1),
(5, 'Hannibal', 2001-02-09, 131, 6.8);

INSERT INTO film.director (id, first_name, last_name)
VALUES
(1, 'Peter', 'Jackson'),
(2, 'Sam', 'Mendes'),
(3, 'Frank', 'Darabont'),
(4, 'Peter', 'Chan'),
(5, 'Ridley', 'Scott');

INSERT INTO film.genre (id, type)
VALUES
       (1, 'Action'),
       (2, 'Adventure'),
       (3, 'Drama'),
       (4, 'Fantasy'),
       (5, 'Crime'),
       (6, 'Mystery'),
       (7, 'Thriller');

INSERT INTO film.movie_genre(movie_id, genre_id)
VALUES
(1, 1),(1, 2),(1, 3),(1,4),
(2, 1),
(3, 3),(3, 4),(3,5),(3,6),
(4, 1),(4, 3),(4, 5),(4, 7),
(5, 3),(5, 5),(5, 7);

INSERT INTO film.movie_director (movie_id, director_id)
VALUES (1, 1),(2, 2)(3, 3)(4, 4),(5, 5);
