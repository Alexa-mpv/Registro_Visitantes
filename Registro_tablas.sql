Use Registro

create table visitante(
	cVisitante int primary key,
	nombre varchar(50) not null)

create table trabajador(
	cTrabajador int primary key,
	nombre varchar(50) not null)

create table historial(
	cHistorial int primary key,
	fIngreso datetime,
	fEgreso datetime,
	cVisitante int references visitante,
	cTrabajador int references trabajador)