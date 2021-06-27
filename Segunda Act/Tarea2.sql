--Create database

create database Tarea2;

use Tarea2
go

-- Create tables

--Tabla Rol
Create table Rol(
Idrol int identity primary key,
Nombre varchar(100) not null ,
Descripcion varchar(100) not null,
Estado bit not null,
);

--Tabla pelicula
Create table Pelicula(
Nombre varchar(100) not null primary key,
Fecha date not null,
Duracion int not null,
Clasificacion varchar(100) not null,
Estudio varchar(100) not null,
Director varchar(100) not null,
Genero varchar(100) not null
);


--Rellenando con algunos datos para que no exista error con las otras tablas
-- Inserting data into Rol

insert into Rol values('Jefe', 'Manda a todos', 1);
insert into Rol values('Empleado', 'Hace lo que pida el jefe', 1);
insert into Rol values('Recursos humanos', 'Manda a todos', 1);
insert into Rol values('Repartidor', 'Trae equipo', 0);
insert into Rol values('Conserje', 'Limpia la zona', 1);

--Inserting data into Pelicula

insert into Pelicula values('Duro de matar', '05-21-2000',120,'Adultos', 'Universal', 'Tarantino', 'Acción');
insert into Pelicula values('Jonh Wick', '03-12-2014',114,'R', 'DefyNite Films', 'Chad Stahelski', 'Acción');
insert into Pelicula values('Cars 2', '6-18-2011',107,'G', 'Pixar Animation Studios', 'John Lasseter', 'Comedia');
insert into Pelicula values('La naranja mecánica', '12-19-1971',136,'R', 'Universal', 'Stanley Kubrick', 'Drama');
insert into Pelicula values('Toy Story', '04-18-1995',81,'G', '	Pixar Animation Studios', 'John Lasseter', 'Comedia');


--Tabla persona 
create table Persona(
Idpersona int identity primary key,
Nombre varchar(30) not null,
Apellido varchar(30) not null,
Edad int not null,
Telefono varchar(8) not null,
Idrol int not null,
CONSTRAINT fk_Asignatura FOREIGN KEY (Idrol) REFERENCES Rol (Idrol)
);

--Rellenando algunos datos de la tabla persona para que no exista conflicto en la tabla acceso_premier
insert into Persona values('Rodrigo', 'Valle',21,'77317840',1);
insert into Persona values('Juan', 'Perez',35,'76402431',2);
insert into Persona values('Pepe', 'Campos',18,'77665878',3);
insert into Persona values('Ronaldo', 'Cabrera',28,'77242560',4);
insert into Persona values('Kevin', 'Galdamez',25,'72459947',5);

--Tabla Acceso_Premier 
create table Acceso_Premier (
Idapremier int identity primary key,
Nombre_pelicula varchar(100) not null,
idPersona int not null,
CONSTRAINT fk_Peli FOREIGN KEY (Nombre_pelicula) REFERENCES Pelicula (Nombre),
CONSTRAINT fk_Persona FOREIGN KEY (idPersona) REFERENCES Persona (Idpersona)
);

select*from Pelicula
select*from Persona
select*from Rol
select*from Acceso_Premier