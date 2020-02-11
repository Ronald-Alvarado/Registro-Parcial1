CREATE DATABASE ArticulosDb
GO
USE ArticulosDb
GO
CREATE TABLE Articulos(
	ProductoId int primary key identity,
	Descripcion varchar(max),
	Existencia int,
	Costo int,
	ValorInventario int,
);
DROP TABLE Articulos