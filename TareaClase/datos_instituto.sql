INSERT INTO `alumnos` (`nombre`, `apellidos`, `fechaNacimiento`, `provincia`, `municipio`, `media`)
VALUES 
	('Juan', 'Pérez', '2000-01-01', 1, 1, 8.5),
   ('Ana', 'Gómez', '1999-05-20', 2, 2, 9.0),
   ('Carlos', 'Martínez', '2001-07-30', 3, 3, 7.5);

-- Insertando datos en la tabla Notas
INSERT INTO `notas` (`descripcion`, `nota`, `codigo_alumno`) VALUES
	/*Notas Juan*/
	('Acceso a Datos', 5, 1),
   ('Programacion de servicios', 6, 1),
   ('Desarrollo de interfaces', 5 , 1),
   /*Notas Ana*/
   ('Acceso a Datos', 7, 2),
   ('Programacion de servicios', 5, 2),
   ('Desarrollo de interfaces', 7 , 2),
   /*Notas Carlos*/
   ('Acceso a Datos', 7, 3),
   ('Programacion de servicios', 7, 3),
   ('Desarrollo de interfaces', 7, 3);