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
select GrupoPermiso.IdGrupoPermiso, Nombre
from GrupoPermiso
inner join Componente on GrupoPermiso.IdComponente = Componente.IdComponente
where GrupoPermiso.IdComponente = @IdComponente

--SELECT LISTA CLIENTES--
select Persona.IdPersona, NombreCompleto, Correo, Documento,
IdCliente, Telefono, Direccion, Estado
from Persona
inner join Cliente on Persona.IdPersona = Cliente.IdPersona

--SELECT LISTA GRUPO PERMISOS COMPLETA--
select Componente.IdComponente, Nombre, Estado,
GrupoPermiso.IdGrupoPermiso
from Componente
inner join GrupoPermiso on Componente.IdComponente = GrupoPermiso.IdComponente
