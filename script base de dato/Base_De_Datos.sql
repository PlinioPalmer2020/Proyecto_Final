CREATE DATABASE proyecto_final;
go

use  proyecto_final;

go

 CREATE TABLE usuario(
id_user int identity(1,1) primary key,
username nvarchar(50) not null,
pass nvarchar(50) not null,
empleado_id int not null,
estado int default 1
);

go

CREATE TABLE empleados(
id_empleado int identity(1,1) primary key,
nombre nvarchar(50) not null,
apellido nvarchar(50) not null,
cedula nvarchar(50) not null,
estado bit default 1
);

go

CREATE TABLE registro_entradas(
id_registro int identity(1,1) primary key,
empleado_id int not null,
fecha_entrada  smalldatetime not null,
fecha_salida  smalldatetime
)
go

go

INSERT INTO usuario (username,pass,empleado_id) Values('user','user',1)
go

INSERT INTO empleados(nombre,apellido,cedula) Values('Plinio','Palmer','40238830059');

