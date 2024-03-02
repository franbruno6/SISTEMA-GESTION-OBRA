use DB_SGO
go

--PROCEDURE REGISTRAR USUARIO--
create procedure SP_RegistrarUsuario(
@NombreCompleto nvarchar(100),
@Correo nvarchar(100),
@Documento nvarchar(100),
@Clave nvarchar(400),
@Estado bit,
@Mensaje nvarchar(400) output,
@IdUsuarioRegistrado int output
)
as
begin
	begin try
		set @IdUsuarioRegistrado = 0
		set @Mensaje = ''
		declare @IdPersona int = 0

		begin transaction registro
		
			if exists(
				select * 
				from Persona
				where Documento = @Documento
			)
			begin
				select @IdPersona = IdPersona
				from Persona
				where Documento = @Documento

				if not exists(
					select *
					from Usuario
					where IdPersona = @IdPersona
				)
				begin
					update Persona
					set NombreCompleto = @NombreCompleto,
						Correo = @Correo
					where Documento = @Documento
				
					insert into Usuario(IdPersona,Clave,Estado) values
					(@IdPersona,@Clave,@Estado)				

					set @IdUsuarioRegistrado = SCOPE_IDENTITY()
				end
				else
				begin
					set @Mensaje = 'Ya existe un usuario con ese número de documento'
				end
			end
			else
			begin
				insert into Persona(NombreCompleto,Correo,Documento) values
				(@NombreCompleto,@Correo,@Documento)

				set @IdPersona = SCOPE_IDENTITY()

				if (@IdPersona != 0)
				begin
					insert into Usuario(IdPersona,Clave,Estado) values
					(@IdPersona,@Clave,@Estado)

					set @IdUsuarioRegistrado = SCOPE_IDENTITY()
				end
			end
		commit transaction registro
	end try
	begin catch
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end
go

--PROCEDURE EDITAR USUARIO--
create procedure SP_EditarUsuario(
@IdUsuario int,
@IdPersona int,
@NombreCompleto nvarchar(100),
@Correo nvarchar(100),
@Documento nvarchar(100),
@Estado bit,
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
    begin try
        set @Resultado = 0;
        set @Mensaje = '';

        begin transaction editar;

        if not exists (
                select *
                from Usuario
                inner join Persona on Usuario.IdPersona = Persona.IdPersona
                where Persona.Documento = @Documento and IdUsuario != @IdUsuario
        )
        begin
            update Persona set
                NombreCompleto = @NombreCompleto,
                Correo = @Correo,
                Documento = @Documento
            where IdPersona = @IdPersona;

            update Usuario set
                Estado = @Estado
            where IdUsuario = @IdUsuario;

            set @Resultado = 1;
        end
		else
		begin
			set @Mensaje = 'Ya existe un usuario con ese numero de documento'
		end

        commit transaction editar;
    end try
    begin catch
        set @Mensaje = 'Error: ' + ERROR_MESSAGE() + ' (' + CAST(ERROR_NUMBER() AS NVARCHAR) + ')';
        rollback transaction editar;
    end catch
end;
go

--PROCEDURE RESTABLECER CLAVE--
create procedure SP_RestablecerClave(
@IdUsuario int,
@Clave nvarchar(400),
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
    begin try
        set @Resultado = 0;
        set @Mensaje = '';

        begin transaction restablecerclave;

        begin
            update Usuario set
                Clave = @Clave
            where IdUsuario = @IdUsuario;

            set @Resultado = 1;
        end
        commit transaction restablecerclave;
    end try
    begin catch
        set @Mensaje = 'Error: ' + ERROR_MESSAGE() + ' (' + CAST(ERROR_NUMBER() AS NVARCHAR) + ')';
        rollback transaction restablecerclave;
    end catch
end;
go

--PROCEDURE ELIMINAR USUARIO--
create procedure SP_EliminarUsuario(
@IdUsuario int,
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
	set @Resultado = 0;
    set @Mensaje = '';
	declare @pasoreglas bit = 1

	if exists (
		select * from Presupuesto
		inner join Usuario on Presupuesto.IdUsuario = Usuario.IdUsuario
		where Presupuesto.IdUsuario = @IdUsuario
	)
	begin
		set @Resultado = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar. El usuario se encuentra ligado a un presupuesto.\n'
		set @pasoreglas = 0
	end

	if exists (
		select * from ComprobanteObra
		inner join Usuario on ComprobanteObra.IdUsuario = Usuario.IdUsuario
		where ComprobanteObra.IdUsuario = @IdUsuario
	)
	begin
		set @Resultado = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar. El usuario se encuentra ligado a un comprobante de obra.\n'
		set @pasoreglas = 0
	end

	if exists (
		select * from UsuarioComponente
		where IdUsuario = @IdUsuario
	)
	begin
		delete from UsuarioComponente
		where IdUsuario = @IdUsuario
	end

	if (@pasoreglas = 1)
	begin
		delete from Usuario where IdUsuario = @IdUsuario
		set @Resultado = 1
	end
end;
go

--PROCEDURE REGISTRAR CLIENTE--
create procedure SP_RegistrarCliente(
@NombreCompleto nvarchar(100),
@Correo nvarchar(100),
@Documento nvarchar(100),
@Telefono nvarchar(60),
@Direccion nvarchar(100),
@Localidad nvarchar(60),
@Provincia nvarchar(60),
@Estado bit,
@Mensaje nvarchar(400) output,
@IdClienteRegistrado int output
)
as
begin
	begin try
		set @IdClienteRegistrado = 0
		set @Mensaje = ''
		declare @IdPersona int = 0

		begin transaction registro
			if exists(
				select * 
				from Persona
				where Documento = @Documento
			)
			begin
				select @IdPersona = IdPersona
				from Persona
				where Documento = @Documento

				if not exists(
					select *
					from Cliente
					where IdPersona = @IdPersona
				)
				begin
					update Persona
					set NombreCompleto = @NombreCompleto,
						Correo = @Correo
					where Documento = @Documento

					insert into Cliente(Direccion,Localidad,Telefono,Estado,Provincia) values
					(@Direccion,@Localidad,@Telefono,@Estado,@Provincia)

					set @IdClienteRegistrado = SCOPE_IDENTITY()
				end
				else
				begin
					set @Mensaje = 'Ya existe un cliente con ese numero de documento'
				end
			end
			else
			begin
				insert into Persona(NombreCompleto,Correo,Documento) values
				(@NombreCompleto,@Correo,@Documento)

				set @IdPersona = SCOPE_IDENTITY()

				if (@IdPersona != 0)
				begin
					insert into Cliente(IdPersona,Telefono,Direccion,Estado,Localidad,Provincia) values
					(@IdPersona,@Telefono,@Direccion,@Estado,@Localidad,@Provincia)

					set @IdClienteRegistrado = SCOPE_IDENTITY()
				end
			end
		commit transaction registro
	end try
	begin catch
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end
go

--PROCEDURE EDITAR CLIENTE--
create procedure SP_EditarCliente(
@IdCliente int,
@IdPersona int,
@NombreCompleto nvarchar(100),
@Correo nvarchar(100),
@Documento nvarchar(100),
@Telefono nvarchar(60),
@Direccion nvarchar(100),
@Localidad nvarchar(60),
@Provincia nvarchar(60),
@Estado bit,
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
    begin try
        set @Resultado = 0;
        set @Mensaje = '';

        begin transaction editar;

        if not exists (
                select *
                from Cliente
                inner join Persona on Cliente.IdPersona = Persona.IdPersona
                where Persona.Documento = @Documento and IdCliente != @IdCliente
        )
        begin
            update Persona set
                NombreCompleto = @NombreCompleto,
                Correo = @Correo,
                Documento = @Documento
            where IdPersona = @IdPersona;

            update Cliente set
				Direccion = @Direccion,
				Localidad = @Localidad,
				Provincia = @Provincia,
				Telefono = @Telefono,
                Estado = @Estado
            where IdCliente = @IdCliente;

            set @Resultado = 1;
        end
		else
		begin
			set @Mensaje = 'Ya existe un cliente con ese numero de documento'
		end

        commit transaction editar;
    end try
    begin catch
        set @Mensaje = 'Error: ' + ERROR_MESSAGE() + ' (' + CAST(ERROR_NUMBER() AS NVARCHAR) + ')';
        rollback transaction editar;
    end catch
end
go

--PROCEDURE ELIMINAR CLIENTE--
create procedure SP_EliminarCliente(
@IdCliente int,
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
	set @Resultado = 0;
    set @Mensaje = '';
	declare @pasoreglas bit = 1

	if exists(
		select *
		from Presupuesto
		where IdCliente = @IdCliente
	)
	begin
		set @Resultado = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar. El cliente se encuentra ligado a un presupuesto.\n'
		set @pasoreglas = 0
	end

	if exists(
		select *
		from ComprobanteObra
		where IdCliente = @IdCliente
	)
	begin
		set @Resultado = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar. El cliente se encuentra ligado a un comprobante de obra.\n'
		set @pasoreglas = 0
	end

	if (@pasoreglas = 1)
	begin
		delete from Cliente where IdCliente = @IdCliente
		set @Resultado = 1
	end
end;
go

--PROCEDURE CREAR PERMISO (USO SOLO EN BASE DE DATOS NO LO USO EN EL CODIGO)--
create procedure SP_RegistrarPermiso(
@Nombre nvarchar(100),
@NombreMenu nvarchar(100),
@Mensaje nvarchar(400) output,
@IdPermisoRegistrado int output
)
as
begin
	begin try
		set @IdPermisoRegistrado = 0
		set @Mensaje = ''
		declare @IdComponente int = 0
		declare @TipoComponente nvarchar(60) = 'Permiso'
		declare @Estado bit = 1

		begin transaction registro
		
			insert into Componente(Nombre,TipoComponente,Estado) values
			(@Nombre,@TipoComponente,@Estado)

			set @IdComponente = SCOPE_IDENTITY()

			if (@IdComponente != 0)
			begin
				insert into Permiso(IdComponente,NombreMenu) values
				(@IdComponente,@NombreMenu)

				set @IdPermisoRegistrado = SCOPE_IDENTITY()
			end
		commit transaction registro
	end try
	begin catch
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end
go

--EXEC DEL PROCEDURE AGREGAR PERMISO--
declare @IdPermisoRegistrado int
declare @Mensaje nvarchar(500)

--exec SP_RegistrarPermiso 'Agregar Usuario','menuagregarusuario',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Modificar Usuario','menumodificarusuario',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Restablecer Clave','menurestablecerclave',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Eliminar Usuario','menueliminarusuario',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Ver Menu Permiso','menupermiso',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Ver Menu Permiso Simple','menupermisosimple',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Ver Menu Permiso Usuario','menupermisousuario',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Agregar Grupo','menuagregargrupo',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Modificar Grupo','menumodificargrupo',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Eliminar Grupo','menueliminargrupo',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Modificar Estado de Permiso','menumodificarestadopermiso',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Modificar Permisos del Usuario','menueditarpermisousuario',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Agregar Cliente','menuagregarcliente',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Modificar Cliente','menumodificarcliente',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Eliminar Cliente','menueliminarcliente',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Agregar Producto','menuagregarproducto',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Modificar Producto','menumodificarproducto',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Eliminar Producto','menueliminarproducto',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Agregar Presupuesto','menuagregarpresupuesto',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Modificar Presupuesto','menumodificarpresupuesto',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Eliminar Presupuesto','menueliminarpresupuesto',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Agregar Comprobante','menuagregarcomprobante',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Modificar Comprobante','menumodificarcomprobante',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Cancelar Comprobante','menucancelarcomprobante',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Ver Menu Reporte','menureporte',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Ver Menu Reporte Presupuesto','menureportepresupuesto',@IdPermisoRegistrado output,@Mensaje output
--exec SP_RegistrarPermiso 'Ver Menu Reporte Comprobante','menureportecomprobante',@IdPermisoRegistrado output,@Mensaje output
exec SP_RegistrarPermiso 'Ver Menu Auditoria', 'menuauditoria', @IdPermisoRegistrado output,@Mensaje output

select @IdPermisoRegistrado

select @Mensaje

select * from Permiso
inner join Componente on Permiso.IdComponente = Componente.IdComponente
go

--PROCEDURE REGISTRAR GRUPO PERMISO--
--USO ESTO COMO UN PARAMETRO PARA CREAR UN GRUPO PERMISO-- PARTE 15 MINTUO 44
create type [dbo].[EListaComponentes] as table(
	[IdComponente] int null
)
go
create procedure SP_RegistrarGrupoPermiso(
@NombreGrupo nvarchar(60),
@Estado bit,
@Componentes [EListaComponentes] readonly,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
	begin try
		declare @IdGrupoPermiso int = 0
		declare @IdComponente int = 0
		set @Resultado = 1
		set @Mensaje = ''
		declare @TipoComponente nvarchar(20) = 'GrupoPermiso'

		begin transaction registro
			
			insert into Componente(Nombre,TipoComponente,Estado)
			values (@NombreGrupo,@TipoComponente,@Estado)

			set @IdComponente = SCOPE_IDENTITY()

			insert into GrupoPermiso(NombreGrupo,IdComponente)
			values (@NombreGrupo,@IdComponente)

			set @IdGrupoPermiso = SCOPE_IDENTITY()

			insert into GrupoPermisoComponente(IdGrupoPermiso,IdComponente)
			select @IdGrupoPermiso,IdComponente from @Componentes

		commit transaction registro
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end
go

--PROCEDURE EDITAR GRUPO PERMISO--
create procedure SP_EditarGrupoPermiso(
    @IdGrupoPermiso int,
	@IdComponente int,
    @NombreGrupo nvarchar(60),
    @Estado bit,
    @Componentes [EListaComponentes] readonly,
    @Resultado bit output,
    @Mensaje nvarchar(500) output
)
as
begin
    begin try
        set @Resultado = 1
        set @Mensaje = ''
        declare @TipoComponente nvarchar(20) = 'GrupoPermiso'

        begin transaction edicion

            -- Actualizar el nombre y estado del componente asociado al grupo
            update Componente
            set Nombre = @NombreGrupo, Estado = @Estado
            where IdComponente = @IdComponente

            -- Actualizar el nombre del grupo en la tabla GrupoPermiso
            update GrupoPermiso
            set NombreGrupo = @NombreGrupo
            where IdGrupoPermiso = @IdGrupoPermiso

            -- Eliminar las asociaciones existentes de componentes con el grupo
            delete from GrupoPermisoComponente
            where IdGrupoPermiso = @IdGrupoPermiso

            -- Insertar las nuevas asociaciones de componentes con el grupo
            insert into GrupoPermisoComponente(IdGrupoPermiso, IdComponente)
            select @IdGrupoPermiso, IdComponente
            from @Componentes

        commit transaction edicion
    end try
    begin catch
        set @Resultado = 0
        set @Mensaje = ERROR_MESSAGE()
        rollback transaction edicion
    end catch
end
go

--PROCEDURE ELIMINAR GRUPO PERMISO--
create procedure SP_EliminarGrupoPermiso(
    @IdGrupoPermiso int,
	@IdComponente int,
    @Resultado bit output,
    @Mensaje nvarchar(500) output
)
as
begin
    begin try
        set @Resultado = 1
        set @Mensaje = ''

        begin transaction eliminacion
			-- Eliminar las relaciones del grupo con usuarios
			delete from UsuarioComponente
			where IdComponente = @IdComponente

            -- Eliminar las relaciones del grupo con componentes
            delete from GrupoPermisoComponente
            where IdGrupoPermiso = @IdGrupoPermiso

            -- Eliminar el grupo de permisos
            delete from GrupoPermiso
            where IdGrupoPermiso = @IdGrupoPermiso

            -- Eliminar el componente asociado al grupo
            delete from Componente
            where IdComponente = @IdComponente

        commit transaction eliminacion
    end try
    begin catch
        set @Resultado = 0
        set @Mensaje = ERROR_MESSAGE()
        rollback transaction eliminacion
    end catch
end
go

--PROCEDURE EDITAR ESTADO DE PERMISO--
create procedure SP_EditarEstadoPermiso(
	@IdComponente int,
    @Estado bit,
    @Resultado bit output,
    @Mensaje nvarchar(500) output
)
as
begin
    begin try
        set @Resultado = 1
        set @Mensaje = ''

        begin transaction edicion

            -- Actualizar el estado del componente asociado al grupo
            update Componente
            set Estado = @Estado
            where IdComponente = @IdComponente

        commit transaction edicion
    end try
    begin catch
        set @Resultado = 0
        set @Mensaje = ERROR_MESSAGE()
        rollback transaction edicion
    end catch
end
go

--PROCEDURE EDITAR PERMISOS DEL USUARIO--
create procedure SP_EditarUsuarioPermiso(
    @IdUsuario int,
    @Componentes [EListaComponentes] readonly,
    @Resultado bit output,
    @Mensaje nvarchar(500) output
)
as
begin
    begin try
        set @Resultado = 1
        set @Mensaje = ''

        begin transaction edicion

            if exists(
				select *
				from UsuarioComponente
				where IdUsuario = @IdUsuario
			)
			begin
				-- Eliminar las asociaciones existentes de componentes con el grupo
				delete from UsuarioComponente
				where IdUsuario = @IdUsuario
			end

            -- Insertar las nuevas asociaciones de componentes con el grupo
            insert into UsuarioComponente(IdUsuario, IdComponente)
            select @IdUsuario, IdComponente
            from @Componentes

        commit transaction edicion
    end try
    begin catch
        set @Resultado = 0
        set @Mensaje = ERROR_MESSAGE()
        rollback transaction edicion
    end catch
end
go

--PROCEDURE REGISTRAR PRODUCTO--
create procedure SP_RegistrarProducto(
@Nombre nvarchar(60),
@Codigo nvarchar(60),
@Descripcion nvarchar(100),
@Categoria nvarchar(60),
@Precio decimal(18,2),
@Estado bit,
@Mensaje nvarchar(400) output,
@IdProductoRegistrado int output
)
as
begin
	begin try
		set @IdProductoRegistrado = 0
		set @Mensaje = ''

		begin transaction registro
		
			if not exists (select * from Producto where Codigo = @Codigo)
			begin
			insert into Producto(Nombre,Codigo,Descripcion,Categoria,Precio,Estado) values
			(@Nombre,@Codigo,@Descripcion,@Categoria,@Precio,@Estado)

			set @IdProductoRegistrado = SCOPE_IDENTITY()
			end
			else
			begin
			set @Mensaje = 'Numero de codigo ya registrado'
			end
		commit transaction registro
	end try
	begin catch
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end
go

--PROCEDURE EDITAR PRODUCTO--
create procedure SP_EditarProducto(
@IdProducto int,
@Nombre nvarchar(60),
@Codigo nvarchar(60),
@Descripcion nvarchar(100),
@Categoria nvarchar(60),
@Precio decimal(18,2),
@Estado bit,
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
    begin try
        set @Resultado = 0;
        set @Mensaje = '';

        begin transaction editar;

        if not exists (
                select *
                from Producto
                where Codigo = @Codigo and IdProducto != @IdProducto
        )
        begin
            update Producto set
                Nombre = @Nombre,
				Codigo = @Codigo,
				Descripcion = @Descripcion,
				Categoria = @Categoria,
				Precio = @Precio,
				Estado = @Estado
            where IdProducto = @IdProducto;

            set @Resultado = 1;
        end
		else
		begin
			set @Mensaje = 'Ya existe un producto con ese numero de codigo'
		end

        commit transaction editar;
    end try
    begin catch
        set @Mensaje = 'Error: ' + ERROR_MESSAGE() + ' (' + CAST(ERROR_NUMBER() AS NVARCHAR) + ')';
        rollback transaction editar;
    end catch
end;
go

--PROCEDURE ELIMINAR PRODUCTO--
create procedure SP_EliminarProducto(
@IdProducto int,
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
	set @Resultado = 0;
    set @Mensaje = '';
	declare @pasoreglas bit = 1

	if exists (
		select * from Producto
		inner join DetallePresupuesto on Producto.IdProducto = DetallePresupuesto.IdProducto
		where DetallePresupuesto.IdProducto = @IdProducto
	)
	begin
		set @Resultado = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar. El producto se encuentra ligado a un presupuesto.\n'
		set @pasoreglas = 0
	end

	if exists (
		select * from Producto
		inner join DetalleComprobanteObra on Producto.IdProducto = DetalleComprobanteObra.IdProducto
		where DetalleComprobanteObra.IdProducto = @IdProducto
	)
	begin
		set @Resultado = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar. El producto se encuentra ligado a un comprobante de obra.\n'
		set @pasoreglas = 0
	end

	if (@pasoreglas = 1)
	begin
		delete from Producto where IdProducto = @IdProducto
		set @Resultado = 1
	end
end;
go

--PROCEDURE REGISTRAR PRESUPUESTO--
--USO ESTO COMO UN PARAMETRO PARA CREAR UN PRESUPUESTO-- PARTE 15 MINTUO 44
create type [dbo].[EDetallePresupuesto] as table(
	[IdProducto] int null,
	[Precio] decimal(18,2) null,
	[Cantidad] int null,
	[MontoTotal] decimal(18,2) null
)
go

create procedure SP_RegistrarPresupuesto(
@IdUsuario int,
@IdCliente int,
@NumeroPresupuesto nvarchar(60),
@Direccion nvarchar(100),
@Localidad nvarchar(60),
@Provincia nvarchar(60),
@MontoTotal decimal(18,2),
@FechaRegistro date,
@Descripcion nvarchar(100),
@DetallePresupuesto [EDetallePresupuesto] readonly,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
	begin try
		declare @IdPresupuesto int = 0
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro
			
			insert into Presupuesto(IdUsuario,IdCliente,NumeroPresupuesto,Direccion,Localidad,Provincia,MontoTotal,FechaRegistro,Descripcion)
			values(@IdUsuario,@IdCliente,@NumeroPresupuesto,@Direccion,@Localidad,@Provincia,@MontoTotal,@FechaRegistro,@Descripcion)

			set @IdPresupuesto = SCOPE_IDENTITY()

			insert into DetallePresupuesto(IdPresupuesto,IdProducto,Precio,Cantidad,MontoTotal)
			select @IdPresupuesto,IdProducto,Precio,Cantidad,MontoTotal from @DetallePresupuesto

		commit transaction registro
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end
go

--PROCEDURE EDITAR PRESUPUESTO--
create procedure SP_EditarPresupuesto(
@IdPresupuesto int,
@IdUsuario int,
@IdCliente int,
@Direccion nvarchar(100),
@Localidad nvarchar(60),
@Provincia nvarchar(60),
@MontoTotal decimal(18,2),
@Descripcion nvarchar(100),
@DetallePresupuesto [EDetallePresupuesto] readonly,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
    begin try
        set @Resultado = 1
        set @Mensaje = ''

        begin transaction edicion
			if not exists(
				select * 
				from ComprobanteObra
				where IdPresupuesto = @IdPresupuesto
			)
			begin
				update Presupuesto
				set IdUsuario = @IdUsuario, IdCliente = @IdCliente, Direccion = @Direccion, Localidad = @Localidad, Provincia = @Provincia, MontoTotal = @MontoTotal, Descripcion = @Descripcion
				where IdPresupuesto = @IdPresupuesto

				-- Eliminar las asociaciones existentes de componentes con el grupo
				delete from DetallePresupuesto
				where IdPresupuesto = @IdPresupuesto

				-- Insertar las nuevas asociaciones de componentes con el grupo
				insert into DetallePresupuesto(IdPresupuesto, IdProducto, Precio, Cantidad, MontoTotal)
				select @IdPresupuesto, IdProducto, Precio, Cantidad, MontoTotal
				from @DetallePresupuesto
			end
			else
			begin
				declare @NumeroComprobante nvarchar(60)
				select @NumeroComprobante = NumeroComprobante
				from ComprobanteObra
				where IdPresupuesto = @IdPresupuesto
				set @Mensaje = 'No se puede modificar, el presupuesto está relacionado al comprobante numero ' + @NumeroComprobante
			end
        commit transaction edicion
    end try
    begin catch
        set @Resultado = 0
        set @Mensaje = ERROR_MESSAGE()
        rollback transaction edicion
    end catch
end
go

--PROCEDURE ELIMINAR PRESUPUESTO--
create procedure SP_EliminarPresupuesto
(
@IdPresupuesto int,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
    begin try
        set @Resultado = 1
        set @Mensaje = ''
		declare @NumeroComprobante nvarchar(20) = ''

        begin transaction eliminar
			if not exists(
				select *
				from ComprobanteObra
				where IdPresupuesto = @IdPresupuesto
			)
			begin
				-- Eliminar las asociaciones existentes de componentes con el grupo
				delete from DetallePresupuesto
				where IdPresupuesto = @IdPresupuesto

				delete from Presupuesto
				where IdPresupuesto = @IdPresupuesto
			end
			else
			begin
				select @NumeroComprobante = NumeroComprobante
				from ComprobanteObra
				where IdPresupuesto = @IdPresupuesto
				set @Resultado = 0
				set @Mensaje = 'No es posible eliminar el presupuesto, ya que esta ligado al comprobante numero ' + @NumeroComprobante
			end
        commit transaction eliminar
    end try
    begin catch
        set @Resultado = 0
        set @Mensaje = ERROR_MESSAGE()
        rollback transaction eliminar
    end catch
end
go

--PROCEDURE REGISTRAR COMPROBANTE--
--USO ESTO COMO UN PARAMETRO PARA CREAR UN PRESUPUESTO-- PARTE 15 MINTUO 44
create type [dbo].[EDetalleComprobante] as table(
	[IdProducto] int null,
	[Precio] decimal(18,2) null,
	[Cantidad] int null,
	[MontoTotal] decimal(18,2) null
)
go

create procedure SP_RegistrarComprobanteObra(
@IdUsuario int,
@IdCliente int,
@IdPresupuesto int,
@NumeroComprobante nvarchar(60),
@Direccion nvarchar(100),
@Localidad nvarchar(50),
@Provincia nvarchar(60),
@MontoTotal decimal(18,2),
@FechaRegistro date,
@Descripcion nvarchar(100),
@Adelanto decimal(18,2),
@Saldo decimal(18,2),
@DetalleComprobanteObra [EDetalleComprobante] readonly,
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
	begin try
		declare @IdComprobanteObra int = 0
		declare @EstadoObra nvarchar(60) = 'Pendiente'
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro
			insert into ComprobanteObra(IdUsuario,IdCliente,IdPresupuesto,NumeroComprobante,Direccion,Localidad,Provincia,MontoTotal,Adelanto,Saldo,EstadoObra,FechaRegistro,Descripcion)
			values (@IdUsuario,@IdCliente,@IdPresupuesto,@NumeroComprobante,@Direccion,@Localidad,@Provincia,@MontoTotal,@Adelanto,@Saldo,@EstadoObra,@FechaRegistro,@Descripcion)

			set @IdComprobanteObra = SCOPE_IDENTITY()

			insert into DetalleComprobanteObra(IdComprobanteObra,IdProducto,Precio,Cantidad,MontoTotal)
			select @IdComprobanteObra,IdProducto,Precio,Cantidad,MontoTotal from @DetalleComprobanteObra

		commit transaction registro
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end
go

--PROCEDURE EDITAR ESTADO COMPROBANTE--
create procedure SP_EditarEstadoComprobante(
@IdUsuario int,
@IdComprobanteObra int,
@EstadoObra nvarchar(60),
@Resultado bit output,
@Mensaje nvarchar(500) output
)
as
begin
	begin try
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction edicion
			update ComprobanteObra
			set IdUsuario = @IdUsuario, EstadoObra = @EstadoObra
			where IdComprobanteObra = @IdComprobanteObra

			if (@EstadoObra = 'Cuenta saldada')
			begin
				update ComprobanteObra
				set Adelanto = 0, Saldo = 0
				where IdComprobanteObra = @IdComprobanteObra
			end
		commit transaction edicion
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction edicion
	end catch
end
go

--PROCEDURE REPORTE PRESUPUESTO--
create procedure SP_ReportePresupuesto(
@FechaInicio varchar(20),
@FechaFin varchar(20)
)
as
begin
	set dateformat dmy
	select
		convert(char(10),FechaRegistro,103)[FechaRegistro],NumeroPresupuesto,Presupuesto.Direccion,Presupuesto.Localidad,Presupuesto.Provincia,MontoTotal,Descripcion,
		NombreCompleto, Correo
		from Presupuesto
		inner join Cliente on Presupuesto.IdCliente = Cliente.IdCliente
		inner join Persona on Cliente.IdPersona = Persona.IdPersona
		where CONVERT(date,FechaRegistro) between @FechaInicio and @FechaFin
end
go

--PROCEDURE REPORTE COMPROBANTE--
create procedure SP_ReporteComprobante(
@FechaInicio varchar(20),
@FechaFin varchar(20)
)
as
begin
	set dateformat dmy
	select
		convert(char(10),FechaRegistro,103)[FechaRegistro],NumeroComprobante,ComprobanteObra.Direccion,ComprobanteObra.Localidad,ComprobanteObra.Provincia,MontoTotal,Descripcion,EstadoObra,
		NombreCompleto, Correo
		from ComprobanteObra
		inner join Cliente on ComprobanteObra.IdCliente = Cliente.IdCliente
		inner join Persona on Cliente.IdPersona = Persona.IdPersona
		where CONVERT(date,FechaRegistro) between @FechaInicio and @FechaFin
end