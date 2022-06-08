use PlayStream;


Create table Pelicula(id int IDENTITY(1,1) PRIMARY KEY , titulo varchar(100), 
				Genero varchar(50), 
				descripcion varchar(1500),
				director varchar(50),  trailer varchar(2500), enlacePelicula varchar(2500))

/*
Create table Serie(id int PRIMARY KEY (id), titulo varchar(100), 
				Genero varchar(50) FOREIGN KEY REFERENCES Genero(nombre), 
				Temporadas int , descripcion varchar(2500), 
				director varchar(50))

Create table Capitulo(
				id int, serie int FOREIGN KEY REFERENCES Serie(id), 
				titulo varchar(100), 
				descripcion varchar(1500), 
				director varchar(50), PRIMARY KEY (id, serie))*/

INSERT INTO Pelicula(titulo , Genero, descripcion, director, trailer)
VALUES(
  'Blade Runner', 'Ciencia-ficción', 'Ridley Scott, Harrison Ford', 'Ridley Scott', 'https://www.youtube.com/watch?v=gCcx85zbxz4'
),

(
  'Gladiator', 'Aventuras', 'Ridley Scott, Russell Crowe', 'Russell Crowe', 'https://www.youtube.com/watch?v=uePBwv_s6gM'
),
('Pelicula 1', 'Aventuras', 'descrpcion peliciula 1', 'director de la pelicula 1', ''),
('Pelicula 2', 'Ciencia-ficción', 'descrpcion peliciula 2', 'director de la pelicula 2', ''),
('Pelicula 3', 'Aventuras', 'descrpcion peliciula 3', 'director de la pelicula 3', ''),
('Pelicula 4', 'Ciencia-ficción', 'descrpcion peliciula 4', 'director de la pelicula 4',''),
('Pelicula 5', 'Comedia', 'descrpcion peliciula 5', 'director de la pelicula 5', '');
/*
INSERT INTO Serie(titulo , Genero, descripcion, director)
VALUES(
  'The big bang Theory', 'Sitcom', 'Leonard y Sheldon son dos cerebros privilegiados que pueden ser capaces de decirle
  a todo el mundo más de lo que quiere saber sobre la física cuántica, pero que no tienen ni la menor idea de cómo 
  relacionarse socialmente, sobre todo cuando se trata de mujeres.', 'Mark Cendrowski'
),

('Serie 1', 'Aventuras', 'descrpcion Serie 1', 'director de la Serie 1'),
('Serie 2', 'Ciencia-ficción', 'descrpcion Serie 2', 'director de la Serie 2'),
('Serie 3', 'Aventuras', 'descrpcion Serie 3', 'director de la Serie 3'),
('Serie 4', 'Ciencia-ficción', 'descrpcion Serie 4', 'director de la Serie 4'),
('Serie 5', 'Comedia', 'descrpcion Serie 5', 'director de la Serie 5');*/

select * from pelicula;