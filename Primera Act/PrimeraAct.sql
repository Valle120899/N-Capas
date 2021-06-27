--Create database

create database PrimeraAct;


use PrimeraAct;

-- Create tables

Create table Rol(
Idrol int identity primary key,
Nombre varchar(100) not null ,
Descripcion varchar(100) not null,
Estado bit not null 
);

create table Persona(
Idpersona int identity primary key,
Nombre varchar(30) not null,
Apellido varchar(30) not null,
Edad int not null,
Telefono varchar(8) not null,
Idrol int not null,
CONSTRAINT fk_Asignatura FOREIGN KEY (Idrol) REFERENCES Rol (Idrol)
);


-- Inserting data into Rol

insert into Rol values('Jefe', 'Manda a todos', 1);
insert into Rol values('Empleado', 'Hace lo que pida el jefe', 1);
insert into Rol values('Recursos humanos', 'Manda a todos', 1);
insert into Rol values('Repartidor', 'Trae equipo', 0);
insert into Rol values('Conserje', 'Limpia la zona', 1);

--Procedimiento insertar Persona

create proc Insertar_Persona
@Nombre varchar(30),
@Apellido varchar(30),
@edad int,
@Telefono varchar(8),
@Idrol int
as
insert into Persona (Nombre, Apellido, Edad, Telefono, Idrol) values(@Nombre, @Apellido, @edad, @Telefono, @Idrol)
go


-- Procedimiento listar datos

create Proc Listar_Persona
as
Select* from Persona 
order by Idpersona desc
go

