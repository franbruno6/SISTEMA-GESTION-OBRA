use SistemaGestionObra
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
inner join Componente on Permiso.IdPermiso = Componente.IdComponente
where IdPermiso = @IdPermiso
go

--SELECT LISTA GRUPOPERMISOS-- 
select Componente.IdComponente, Nombre, TipoComponente, Estado
from Componente
inner join GrupoPermisoComponente on Componente.IdComponente = GrupoPermisoComponente.IdComponente 
where IdGrupoPermiso = @IdComponente
go
--------

select Componente.IdComponente, Nombre, TipoComponente, Estado,
Permiso.NombreMenu 
from UsuarioComponente
inner join Componente on UsuarioComponente.IdComponente = Componente.IdComponente
left join Permiso on UsuarioComponente.IdComponente = Permiso.IdPermiso
where UsuarioComponente.IdUsuario = 2 --@IdUsuario

select Componente.IdComponente, Nombre, TipoComponente, Estado,
Permiso.NombreMenu 
from GrupoPermisoComponente
inner join GrupoPermiso on GrupoPermisoComponente.IdGrupoPermiso = GrupoPermiso.IdGrupoPermiso
inner join Componente on GrupoPermisoComponente.IdComponente = Componente.IdComponente
left join Permiso on GrupoPermisoComponente.IdComponente = Permiso.IdPermiso
where GrupoPermiso.IdGrupoPermiso = 9 --@IdGrupoPermiso

select Componente.IdComponente, Nombre, TipoComponente, Estado
from UsuarioComponente
inner join Componente on UsuarioComponente.IdComponente = Componente.IdComponente
where UsuarioComponente.IdUsuario = 2 

select * from GrupoPermiso
inner join Componente on Componente.IdComponente = GrupoPermiso.IdGrupoPermiso

select * from UsuarioComponente
select * from Componente
select * from GrupoPermisoComponente

select IdPermiso, NombreMenu from Permiso
inner join Componente on Permiso.IdPermiso = Componente.IdComponente

select Componente.IdComponente, Nombre, TipoComponente, Estado
from Componente
inner join GrupoPermisoComponente on Componente.IdComponente = GrupoPermisoComponente.IdComponente
where IdGrupoPermiso = 9

select * from Usuario
inner join Persona on Usuario.IdPersona = Persona.IdPersona

select * from UsuarioComponente
inner join Componente on UsuarioComponente.IdComponente = Componente.IdComponente
where UsuarioComponente.IdUsuario = 2