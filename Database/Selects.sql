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
go

--SELECT LISTA CLIENTES--
select Persona.IdPersona, NombreCompleto, Correo, Documento,
IdCliente, Telefono, Direccion, Estado
from Persona
inner join Cliente on Persona.IdPersona = Cliente.IdPersona
go

--SELECT LISTA GRUPO PERMISOS COMPLETA--
select Componente.IdComponente, Nombre, Estado,
GrupoPermiso.IdGrupoPermiso
from Componente
inner join GrupoPermiso on Componente.IdComponente = GrupoPermiso.IdComponente
go

--SELECT LISTA GRUPO COMPONENTES MEDIANTE IDGRUPOPERMISO--
select Nombre, TipoComponente, Estado, Componente.IdComponente
from GrupoPermisoComponente
inner join GrupoPermiso on GrupoPermisoComponente.IdGrupoPermiso = GrupoPermiso.IdGrupoPermiso
inner join Componente on GrupoPermisoComponente.IdComponente = Componente.IdComponente
where GrupoPermisoComponente.IdGrupoPermiso = @IdGrupoPermiso
go

--SELECT LISTA PRESUPUESTOS--
select IdPresupuesto, Presupuesto.IdUsuario, Presupuesto.IdCliente, NumeroPresupuesto, Presupuesto.Direccion, MontoTotal, FechaRegistro, Presupuesto.Localidad,
NombreCompleto, Telefono, Documento, Correo
from Presupuesto
inner join Cliente on Presupuesto.IdCliente = Cliente.IdCliente
inner join Persona on Cliente.IdPersona = Persona.IdPersona
go

--SELECT LISTA PRESUPUESTOS SIN COMPROBANTES--
select IdPresupuesto, Presupuesto.IdUsuario, Presupuesto.IdCliente, NumeroPresupuesto, Presupuesto.Direccion, MontoTotal, FechaRegistro, Presupuesto.Localidad,
NombreCompleto, Telefono, Documento, Correo
from Presupuesto
inner join Cliente on Presupuesto.IdCliente = Cliente.IdCliente
inner join Persona on Cliente.IdPersona = Persona.IdPersona
where not exists(
	select 1
	from ComprobanteObra
	where ComprobanteObra.IdPresupuesto = Presupuesto.IdPresupuesto
)
go

--SELECT LISTA DETALLE PRESUPUESTO MEDIANTE IDPRESUPUESTO--
select DetallePresupuesto.IdProducto,DetallePresupuesto.Precio,Cantidad,MontoTotal,
Nombre,Codigo
from DetallePresupuesto
inner join Producto on DetallePresupuesto.IdProducto = Producto.IdProducto
where IdPresupuesto = @IdPresupuesto
go

--SELECT LISTA COMPROBANTES--
select NumeroComprobante, ComprobanteObra.Direccion, MontoTotal, EstadoObra, ComprobanteObra.Localidad, FechaRegistro, Saldo, Adelanto, IdUsuario, ComprobanteObra.IdCliente, IdPresupuesto, IdComprobanteObra
NombreCompleto, Telefono, Correo
from ComprobanteObra
inner join Cliente on ComprobanteObra.IdCliente = Cliente.IdCliente
inner join Persona on Cliente.IdPersona = Persona.IdPersona
go

--SELECT LISTA DETALLE COMPROBANTE MEDIANTE IDCOMPROBANTE--
select DetalleComprobanteObra.IdProducto,DetalleComprobanteObra.Precio,Cantidad,MontoTotal,
Nombre,Codigo
from DetalleComprobanteObra
inner join Producto on DetalleComprobanteObra.IdProducto = Producto.IdProducto
where IdComprobanteObra = @IdComprobanteObra
go