use SistemaGestionObra
go

insert into Persona(NombreCompleto,Correo,Documento)
values ('Francisco Bruno','francisco@gmail.com','10'),('Jimena','jimena"gmail.com','12')
go

insert into Usuario(IdPersona,Clave,Estado)
values (1,'10',1),(2,'12',1)
go

insert into Componente(Nombre,TipoComponente,Estado)
values ('VerUsuario','Permiso',1),('AgregarUsuario','Permiso',1),('GestionarUsuario','GrupoPermiso',1),('VerCliente','Permiso',1),('VerPermiso','Permiso',1),('VerProducto','Permiso',1),('VerPresupuesto','Permiso',1),('VerComprobante','Permiso',1),('VerUsuarioPermiso','GrupoPermiso',1)
go

insert into Permiso(IdPermiso,NombreMenu)
values (1,'menuusuario'),(2,'btnagregarusuario'),(4,'menucliente'),(5,'menupermiso'),(6,'menuproducto'),(7,'menupresupuesto'),(8,'menucomprobante')
go

insert into UsuarioComponente(IdUsuario,IdComponente)
values (1,1),(1,4),(1,5),(1,6),(1,7),(1,8),(2,9)
go

insert into GrupoPermiso(IdGrupoPermiso,NombreGrupo)
values (3,'GestionarUsuario'),(9,'GrupoPrueba')
go

insert into GrupoPermisoComponente(IdGrupoPermiso,IdComponente)
values (3,1),(3,2),(9,1),(9,5)
go

select * from Componente
