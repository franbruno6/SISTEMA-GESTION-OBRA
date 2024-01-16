use DB_SGO
go

--SELECT LISTA COMPONENTES--
select Componente.IdComponente, Nombre, TipoComponente, Estado 
from UsuarioComponente 
inner join Componente on UsuarioComponente.IdComponente = Componente.IdComponente
where UsuarioComponente.IdUsuario = @IdUsuario
go

--SELECT LISTA PERMISOS--
select IdPermiso, NombreMenu
from Permiso
inner join Componente on Permiso.IdComponente = Componente.IdComponente
where Permiso.IdComponente = @IdComponente
go

--SELECT LISTA GRUPOPERMISOS-- 
select IdGrupoPermiso
from GrupoPermiso
inner join Componente on GrupoPermiso.IdComponente = Componente.IdComponente
where GrupoPermiso.IdComponente = 9

select Componente.IdComponente, Nombre, TipoComponente, Estado
from Componente
inner join GrupoPermisoComponente on GrupoPermisoComponente.IdComponente = Componente.IdComponente
where GrupoPermisoComponente.IdGrupoPermiso = 2


select Componente.IdComponente, Nombre, TipoComponente, Estado 
from Componente
inner join GrupoPermiso on Componente.IdComponente = GrupoPermiso.IdComponente
inner join GrupoPermisoComponente on GrupoPermiso.IdGrupoPermiso = GrupoPermiso.IdGrupoPermiso
where GrupoPermisoComponente.IdGrupoPermiso = 2


select Componente.IdComponente, Nombre, TipoComponente, Estado,
GrupoPermisoComponente.IdGrupoPermiso
from Componente
inner join GrupoPermisoComponente on Componente.IdComponente = GrupoPermisoComponente.IdComponente 
where IdGrupoPermiso = @IdGrupoPermiso
go

--SELECT LISTA CLIENTES--
select Persona.IdPersona, NombreCompleto, Correo, Documento,
IdCliente, Telefono, Direccion, Estado
from Persona
inner join Cliente on Persona.IdPersona = Cliente.IdPersona

