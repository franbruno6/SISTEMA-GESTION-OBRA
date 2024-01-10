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