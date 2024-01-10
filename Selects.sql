use SistemaGestionObra
go

--SELECT LISTAR PERMISOS--
select Componente.IdComponente, Nombre, TipoComponente, Estado,
Permiso.IdPermiso, NombreMenu
from UsuarioComponente
inner join Componente on UsuarioComponente.IdComponente = Componente.IdComponente
left join Permiso on Permiso.IdPermiso = Componente.IdComponente
where IdUsuario = @IdUsuario
go

--SELECT LISTAR GRUPOPERMISOS-- SIN RESOLVER TERMINAR MAÑANA
select Componente.IdComponente, Nombre, TipoComponente, Estado,
GrupoPermiso.IdGrupoPermiso, GrupoPermiso.NombreGrupo,
Permiso.IdPermiso, Permiso.NombreMenu
from UsuarioComponente
inner join Componente on Componente.IdComponente = UsuarioComponente.IdComponente
inner join GrupoPermiso on Componente.IdComponente = GrupoPermiso.IdGrupoPermiso
inner join GrupoPermisoComponente on UsuarioComponente.IdComponente = GrupoPermisoComponente.IdGrupoPermiso
inner join Permiso on GrupoPermisoComponente.IdComponente = 
where IdUsuario = @IdUsuario
go

select * from GrupoPermiso
inner join Componente on Componente.IdComponente = GrupoPermiso.IdGrupoPermiso

select * from UsuarioComponente
select * from Componente
select * from GrupoPermisoComponente