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
)

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
) 

/*
idCategoria
categoriaLibro
*/

Create table Categoria(
idCategoria int primary key identity,
categoriaLibro varchar(20) not null
)

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
)


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
)

/*añadir fecha de entrega y fecha limite, en formulario hacer notar si ya se vencio el plazo
  (seria interesante enviar correos pero dependera de que tanto tiempo quede)*/

alter table PrestamoLibros add fechaPrestamo date default Cast(GETDATE() as date);
alter table PrestamoLibros add fechaDevolucion date 


create table Roles(
idRol int primary key identity,
RolUsuario varchar(10) not null
)

alter table Usuarios add idRol int 

alter table Usuarios add foreign key (idRol) references Roles(idRol)





/*Other scripting*/

select Cast(GETDATE() as date) 

insert into Roles (RolUsuario) values 
('Root'),
('Admin'),
('Staff')

insert into Roles (RolUsuario) values 
('External')

insert into TipoUsuarios (TipoUsuario) values
('Interno'),
('Externo')



insert into Usuarios (nombreUsuario,apellidoUsuario,correoUsuario,claveUsuario,bloqueado,idTipoUsuario,idRol)
values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')

insert into Usuarios (nombreUsuario,apellidoUsuario,correoUsuario,claveUsuario,bloqueado,idTipoUsuario,idRol)
values (@param1, @param2, @param3, @param4, @param5, @param6, @param7)


select * from Usuarios u;
select * from Usuarios where /*idUsuarios = 3 ? AND*/ bloqueado = 0;
select count(idUsuarios) from Usuarios ;

delete from Usuarios

select us.idUsuarios, us.nombreUsuario, us.apellidoUsuario, us.correoUsuario, CASE when us.bloqueado = 0 then 'No' When us.bloqueado = 1 then 'Si' else 'Indeterminado' end as bloqueo from Usuarios us Inner join TipoUsuarios tu on idTipoUsuarios = us.idTipoUsuario  inner join Roles r  on r.idRol = us.idRol 

DBCC CHECKIDENT ('Usuarios', RESEED, 1)

select * from Roles r;
select * from TipoUsuarios tu 

select * from Libros l 

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


select TOP 5  idLibro ,nombreLibro, cantidadLibros  from Libros lbr order by idLibro DESC 

select us.idUsuarios, us.nombreUsuario, us.apellidoUsuario , us.correoUsuario, us.idTipoUsuario, us.idRol  from Usuarios us Where us.idUsuarios = @param1

/* 
 user: john@protonmail.com
 Pass: 123er
*/


