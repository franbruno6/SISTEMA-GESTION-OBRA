create database DB_SGO
go

use DB_SGO
go

create table Persona(
IdPersona int primary key identity,
NombreCompleto nvarchar(100),
Correo nvarchar(100),
Documento nvarchar(60)
)
go

/*--------MODULO DE SEGURIDAD--------*/
create table Usuario(
IdUsuario int primary key identity,
IdPersona int,
Clave nvarchar(400),
Estado bit,
foreign key (IdPersona) references Persona(IdPersona)
)
go

create table Componente(
IdComponente int primary key identity,
Nombre nvarchar(60),
TipoComponente nvarchar(20),
Estado bit
)
go

--TABLA PERMISO (HEREDA DE COMPONENTE)--
create table Permiso(
IdPermiso int primary key identity,
IdComponente int,
NombreMenu nvarchar(100) not null,
foreign key (IdComponente) references Componente(IdComponente)
)
go

--TABLA GRUPOPERMISO (HEREDA DE COMPONENTE)--
create table GrupoPermiso(
IdGrupoPermiso int primary key identity,
IdComponente int,
NombreGrupo nvarchar(60)
foreign key (IdComponente) references Componente(IdComponente)
)
go

--TABLA USUARIOCOMPONENTE (RELACION MUCHOS A MUCHOS ENTRE USUARIO Y COMPONENTE)--
create table UsuarioComponente(
IdUsuario int,
IdComponente int,
primary key (IdUsuario,IdComponente),
foreign key (IdUsuario) references Usuario(IdUsuario),
foreign key (IdComponente) references Componente(IdComponente),
)
go

--TABLA GRUPOPERMISOCOMPONENTE (RELACION MUCHOS A MUCHOS ENTRE GRUPOPERMISO Y COMPONENTE)--
create table GrupoPermisoComponente(
IdGrupoPermiso int,
IdComponente int,
primary key (IdGrupoPermiso,IdComponente),
foreign key (IdGrupoPermiso) references GrupoPermiso(IdGrupoPermiso),
foreign key (IdComponente) references Componente(IdComponente),
)
go
/*-------- CIERRE MODULO DE SEGURIDAD--------*/

create table Cliente(
IdCliente int primary key identity,
IdPersona int,
Telefono nvarchar(60),
Direccion nvarchar(100),
Estado bit,
foreign key (IdPersona) references Persona(IdPersona)
)
go

create table Producto(
IdProducto int primary key identity,
Codigo nvarchar(60),
Nombre nvarchar(60),
Descripcion nvarchar(100),
Categoria nvarchar(60),
Precio decimal(18,2) default 0,
Estado bit
)
go

create table Presupuesto(
IdPresupuesto int primary key identity,
IdUsuario int,
NumeroPresupuesto nvarchar(60),
NombreCliente nvarchar(100),
TelefonoCliente nvarchar(60),
Direccion nvarchar(100),
Localidad nvarchar(60),
MontoTotal decimal(18,2),
FechaRegistro datetime default getdate(),
foreign key (IdUsuario) references Usuario(IdUsuario)
)
go

create table DetallePresupuesto(
IdDetallePresupuesto int primary key identity,
IdPresupuesto int,
IdProducto int,
Precio decimal(18,2),
Cantidad int,
MontoTotal decimal(18,2),
foreign key (IdPresupuesto) references Presupuesto(IdPresupuesto),
foreign key (IdProducto) references Producto(IdProducto)
)
go

create table ComprobanteObra(
IdComprobanteObra int primary key identity,
IdPresupuesto int,
IdUsuario int,
NumeroComprobante nvarchar(60),
NombreCliente nvarchar(100),
DocumentoCliente nvarchar(60),
Direccion nvarchar(100),
MontoTotal decimal(18,2),
EstadoObra nvarchar(60),
FechaRegistro datetime default getdate(),
foreign key (IdPresupuesto) references Presupuesto(IdPresupuesto),
foreign key (IdUsuario) references Usuario(IdUsuario)
)
go

create table DetalleComprobanteObra(
IdDetalleComprobanteObra int primary key identity,
IdComprobanteObra int,
IdProducto int,
Precio decimal(18,2),
Cantidad int,
MontoTotal decimal(18,2),
foreign key (IdComprobanteObra) references ComprobanteObra(IdComprobanteObra),
foreign key (IdProducto) references Producto(IdProducto)
)
go