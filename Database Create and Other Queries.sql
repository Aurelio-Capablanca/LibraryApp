Create Database dbBibliotecas;

drop table TipoUsuarios

-- #!954feae8$$$ Pass for SQL SErver

/* 

rootapp
#!954feae8sss

*/

Create table TipoUsuarios(
idTipoUsuarios int identity Primary key,
TipoUsuario varchar(12) not null
);

/*idusuarios 
nombreUsuario
apellidoUsuario
correoUsuario
claveUsuario
bloqueado
idTipoUsuario*/

Create table Usuarios(
idUsuarios int primary key identity,
nombreUsuario varchar(25) not null,
apellidoUsuario varchar(25) not null,
correoUsuario varchar(30) not null,
claveUsuario varchar(100) not null,
bloqueado bit,
idTipoUsuario int foreign key references TipoUsuarios(idTipoUsuarios)
);

/*
idCategoria
categoriaLibro
*/

Create table Categoria(
idCategoria int primary key identity,
categoriaLibro varchar(20) not null
);

/*
idLibro
nombreLibro
ISBN
idCategoria
cantidadLibros
*/

Create table Libros(
idLibro int primary key identity,
nombreLibro varchar(100) not null,
ISBN varchar(20) not null,
cantidadLibros int default 0,
idCategoria int foreign key references Categoria(idCategoria)
);


/*
idPrestamo
idLibro
idUsuario
devolucion
 */

create table PrestamoLibros(
idPrestamo int primary key identity,
idLibro int foreign key references Libros(idLibro),
idUsuario int foreign key references Usuarios(idUsuarios),
devolucion bit default 0
);

/*añadir fecha de entrega y fecha limite, en formulario hacer notar si ya se vencio el plazo
  (seria interesante enviar correos pero dependera de que tanto tiempo quede)*/

alter table PrestamoLibros add fechaPrestamo date default Cast(GETDATE() as date);
alter table PrestamoLibros add fechaDevolucion date; 
alter table PrestamoLibros add cantidadLibros int;

create table Roles(
idRol int primary key identity,
RolUsuario varchar(10) not null
);

alter table Usuarios add idRol int;
alter table Usuarios add foreign key (idRol) references Roles(idRol);


insert into Roles (RolUsuario) values 
('Root'),
('Admin'),
('Staff');

insert into Roles (RolUsuario) values 
('External');

insert into TipoUsuarios (TipoUsuario) values
('Interno'),
('Externo');

INSERT INTO Libros (nombreLibro, ISBN, cantidadLibros)
VALUES
('The Great Gatsby', '9780743273565', 20),
('To Kill a Mockingbird', '9780061120084', 15),
('1984', '9780451524935', 25),
('Pride and Prejudice', '9780141439518', 30),
('The Catcher in the Rye', '9780316769488', 18),
('The Hobbit', '9780547928227', 22),
('The Lord of the Rings', '9780261103252', 12),
('Animal Farm', '9780451526342', 17),
('Brave New World', '9780060850524', 21),
('To the Lighthouse', '9780156907392', 28);


Alter table libros add foto VARBINARY(MAX);

/*Other scripting*/

select Cast(GETDATE() as date) 
select * from roles



insert into Usuarios (nombreUsuario,apellidoUsuario,correoUsuario,claveUsuario,bloqueado,idTipoUsuario,idRol)
values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')


select * from Usuarios u;
select * from Usuarios where /*idUsuarios = 3 ? AND*/ bloqueado = 0;
select count(idUsuarios) from Usuarios ;

delete from Usuarios

select us.idUsuarios, us.nombreUsuario, us.apellidoUsuario, us.correoUsuario, CASE when us.bloqueado = 0 then 'No' When us.bloqueado = 1 then 'Si' else 'Indeterminado' end as bloqueo from Usuarios us Inner join TipoUsuarios tu on idTipoUsuarios = us.idTipoUsuario  inner join Roles r  on r.idRol = us.idRol 

DBCC CHECKIDENT ('Usuarios', RESEED, 1)

select * from Roles r;
select * from TipoUsuarios tu 

select * from Libros l


select TOP 5  idLibro ,nombreLibro, cantidadLibros  from Libros lbr order by idLibro DESC 

select us.idUsuarios, us.nombreUsuario, us.apellidoUsuario , us.correoUsuario, us.idTipoUsuario, us.idRol  from Usuarios us Where us.idUsuarios = @param1

insert into Usuarios (nombreUsuario,apellidoUsuario,correoUsuario,claveUsuario,bloqueado,idTipoUsuario,idRol)
values (@param1, @param2, @param3, @param4, @param5, @param6, @param7)

/* 
 user: john@protonmail.com
 Pass: 123er
*/

update Usuarios set 
nombreUsuario = @param2, 
apellidoUsuario = @param3, 
correoUsuario = @param4, 
idTipoUsuario = @param5, 
idRol = @param6 
where idUsuarios = @param1


select * from usuarios 

select * from Libros

select idLibro, nombreLibro, cantidadLibros from Libros where idLibro = @param1

select * from PrestamoLibros 

Insert into PrestamoLibros (idLibro, idUsuario, devolucion, fechaprestamo, fechadevolucion)
values (@param1, @param2, false, CONVERT(date, @param3, 105), CONVERT(date, @param4, 105))


 

Insert into Libros (nombreLibro, ISBN, cantidadLibros, foto) values (@param1, @param2, @param3, @param4)

select idLibro, nombreLibro, ISBN, cantidadLibros

delete from libros Where idlibro = 11


select idLibro as id, nombreLibro as nombre, ISBN as isbn, cantidadLibros as cantidad, foto as foto from Libros Order by idLibro DESC

select 
idLibro as id, /*0*/
nombreLibro as nombre, /*1*/
ISBN as isbn, /*2*/
cantidadLibros as cantidad, /*3*/
foto as foto, /*4*/
from Libros Where idLibro = @Param1

INSERT INTO Libros (nombreLibro,ISBN,cantidadLibros,idCategoria,foto) VALUES
	 ('TEST book','321424324',12,NULL,0x)
	 
Update Libros set nombreLibro = @param1, ISBN = @param2, cantidadLibros = @param3, foto = @param4 Where idLibro = @param5

Delete from Libros Where idLibro = @param1

select idLibro ,nombreLibro, cantidadLibros, foto  
from Libros lbr 
Where nombreLibro Like '%boo%'
order by idLibro DESC 




CREATE FULLTEXT CATALOG BookCatalogue;

CREATE FULLTEXT INDEX ON Libros(nombreLibro)
KEY INDEX PK__Libros__5BC0F02646DC1DFE ON BookCatalogue;

select * from Libros order by idLibro DESC 

select * from PrestamoLibros pl order by pl.idPrestamo DESC 
   
select idLibro ,nombreLibro, cantidadLibros, foto from Libros lbr  Where CONTAINS(nombreLibro, @param1) order by idLibro DESC



Insert into PrestamoLibros (idLibro, idUsuario, devolucion, fechaprestamo, fechadevolucion, cantidadLibros) values (@param1, @param2, @param3, CONVERT(date, @param4, 105), CONVERT(date, @param5, 105), @param6)

Update Libros set cantidadLibros = cantidadLibros - @param1 Where idLibro = @param2

select * from Roles r;
select * from TipoUsuarios tu; 



SELECT * FROM Roles r Where r.idRol < 4

Delete From Usuarios Where idUsuarios = @param1


INSERT INTO Libros (nombreLibro, ISBN, cantidadLibros) VALUES
('Dune', '9780441013593', 10),
('The Hound of the Baskervilles', '9780747536220', 5),
('The Shining', '9780307743657', 8),
('Sapiens: A Brief History of Humankind', '9780062316097', 12),
('Steve Jobs', '9781451648539', 7),
('A People’s History of the United States', '9780062397348', 10),
('Harry Potter and the Sorcerer´s Stone', '9780590353427', 25),
('Neuromancer', '9780441569595', 9),
('The Name of the Wind', '9780756404741', 14),
('Gone Girl', '9780307588364', 11),
('The Notebook', '9781455582877', 13),
('It', '9781501142970', 6),
('Educated', '9780399590504', 17),
('The Wright Brothers', '9781476728742', 4),
('Guns, Germs, and Steel', '9780393354324', 9),
('Charlotte´s Web', '9780064400558', 22);

select idLibro from Libros l 

INSERT INTO PrestamoLibros (idLibro, idUsuario, devolucion, fechaPrestamo, fechaDevolucion, cantidadLibros) VALUES
(1, 1, 0, '2023-05-01', NULL, 2),
(2, 2, 0, '2023-05-02', NULL, 1),
(3, 3, 1, '2023-04-20', '2023-05-10', 1),
(4, 1, 1, '2023-03-15', '2023-04-01', 3),
(5, 2, 0, '2023-05-05', NULL, 1),
(6, 3, 1, '2023-02-25', '2023-03-10', 2),
(7, 1, 0, '2023-04-10', NULL, 1),
(8, 2, 1, '2023-01-10', '2023-01-20', 1),
(9, 3, 0, '2023-04-15', NULL, 2),
(10, 1, 1, '2023-02-05', '2023-02-15', 1),
(12, 2, 0, '2023-05-07', NULL, 1),
(14, 3, 0, '2023-04-22', NULL, 1),
(15, 1, 1, '2023-01-25', '2023-02-05', 1),
(16, 2, 1, '2023-03-10', '2023-03-20', 1),
(17, 3, 0, '2023-05-03', NULL, 2),
(18, 1, 0, '2023-04-12', NULL, 1),
(19, 2, 1, '2023-02-22', '2023-03-02', 1),
(20, 3, 0, '2023-05-08', NULL, 1),
(21, 1, 0, '2023-05-09', NULL, 1),
(22, 2, 1, '2023-03-12', '2023-03-22', 1),
(23, 3, 0, '2023-04-25', NULL, 1),
(24, 1, 1, '2023-01-12', '2023-01-22', 2),
(25, 2, 0, '2023-04-27', NULL, 1),
(26, 3, 0, '2023-05-01', NULL, 1),
(27, 1, 1, '2023-02-07', '2023-02-17', 1),
(28, 2, 0, '2023-04-30', NULL, 1),
(29, 3, 1, '2023-03-05', '2023-03-15', 2),
(30, 1, 0, '2023-05-10', NULL, 1);

UPDATE PrestamoLibros
SET fechaDevolucion = DATEADD(DAY, 15, fechaPrestamo)
WHERE fechaDevolucion IS NULL;

select * from PrestamoLibros pl 


Update PrestamoLibros SET cantidadLibros = 1 Where cantidadLibros is null;



Select pl.idPrestamo, ls.idLibro, ls.nombreLibro, pl.cantidadLibros, ls.foto from PrestamoLibros pl Inner join Libros ls on ls.idLibro = pl.idLibro  Where idUsuario = 3 and devolucion = 0


Select nombreLibro, ISBN, ls.cantidadLibros, CONCAT(us.nombreUsuario,' ',us.apellidoUsuario) as NombreCompletoUsuario from PrestamoLibros pl Inner join Libros ls on ls.idLibro = pl.idLibro Inner join Usuarios us on us.idUsuarios = pl.idUsuario Where devolucion = 0 /*All Dues*/

Select nombreLibro, ISBN, ls.cantidadLibros, CONCAT(us.nombreUsuario,' ',us.apellidoUsuario) as NombreCompletoUsuario from PrestamoLibros pl Inner join Libros ls on ls.idLibro = pl.idLibro  Inner join Usuarios us on us.idUsuarios = pl.idUsuario  Where devolucion = 0 And CAST(fechaDevolucion AS DATE) > CAST(GETDATE() AS DATE) /*OverDues*/
	 


select * from Usuarios u


Update PrestamoLibros set devolucion = 1 Where idPrestamo = @param1


