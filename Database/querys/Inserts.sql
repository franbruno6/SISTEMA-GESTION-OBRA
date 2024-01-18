use DB_SGO
go

insert into Persona(NombreCompleto,Correo,Documento)
values ('Francisco Bruno','francisco@gmail.com','10'),('Jimena','jimena"gmail.com','12')
go

insert into Usuario(IdPersona,Clave,Estado)
values (1,'10',1),(2,'12',1)
go

insert into Componente(Nombre,TipoComponente,Estado)
values ('VerUsuario','Permiso',1),('VerPermiso','Permiso',1),('VerCliente','Permiso',1),('VerProducto','Permiso',1),('VerPresupuesto','Permiso',1),('VerComprobante','Permiso',1),('AgregarUsuario','Permiso',1),('GestionarUsuario','GrupoPermiso',1),('VerUsuarioPermiso','GrupoPermiso',1),('VerPresupuestoComprobante','GrupoPermiso',1)
go

insert into Permiso(IdComponente,NombreMenu)
values (1,'menuusuario'),(2,'menugrupo'),(3,'menucliente'),(4,'menuproducto'),(5,'menupresupuesto'),(6,'menucomprobante')
go

insert into GrupoPermiso(IdComponente,NombreGrupo)
values (8,'GestionarUsuario'),(9,'GrupoPrueba'),(10,'GrupoPrueba2')
go

insert into GrupoPermisoComponente(IdGrupoPermiso,IdComponente)
values (1,1),(1,7),(2,1),(2,2),(2,10),(3,5),(3,6)
go

insert into UsuarioComponente(IdUsuario,IdComponente)
values (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(2,9)
go

insert into Persona(NombreCompleto,Correo,Documento)
values ('Cliente prueba','cliente@gmail.com',88)
select * from Persona

insert into Cliente(IdPersona,Telefono,Direccion,Estado)
values (7,'341cliente','direccion cliente',1)
select * from Cliente

