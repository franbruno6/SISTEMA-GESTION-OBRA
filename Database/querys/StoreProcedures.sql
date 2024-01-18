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
		
			if not exists(
				select * 
				from Usuario
				inner join Persona on Usuario.IdPersona = Persona.IdPersona
				where Persona.Documento = @Documento
			)
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
@IdPersona int,
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

	if (@pasoreglas = 1)
	begin
		delete from Usuario where IdUsuario = @IdUsuario
		delete from Persona where IdPersona = @IdPersona
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
		
			if not exists(
				select * 
				from Cliente
				inner join Persona on Cliente.IdPersona = Persona.IdPersona
				where Persona.Documento = @Documento
			)
			begin
				insert into Persona(NombreCompleto,Correo,Documento) values
				(@NombreCompleto,@Correo,@Documento)

				set @IdPersona = SCOPE_IDENTITY()

				if (@IdPersona != 0)
				begin
					insert into Cliente(IdPersona,Telefono,Direccion,Estado) values
					(@IdPersona,@Telefono,@Direccion,@Estado)

					set @IdClienteRegistrado = SCOPE_IDENTITY()
				end
			end
			else
			begin
				set @Mensaje = 'Ya existe un cliente con este documento'
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
end;
go

--PROCEDURE ELIMINAR CLIENTE--
create procedure SP_EliminarCliente(
@IdCliente int,
@IdPersona int,
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
	set @Resultado = 0;
    set @Mensaje = '';

	begin try
		begin transaction editar
			delete from Cliente where IdCliente = @IdCliente;
			delete from Persona where IdPersona = @IdPersona;
		commit transaction editar
			set @Resultado = 1
	end try
	begin catch
		rollback transaction editar
        set @Mensaje = 'Error: ' + ERROR_MESSAGE() + ' (' + CAST(ERROR_NUMBER() AS NVARCHAR) + ')';
	end catch
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

exec SP_RegistrarPermiso 'Agregar Usuario','menuagregarusuario',@IdPermisoRegistrado output,@Mensaje output
exec SP_RegistrarPermiso 'Modificar Usuario','menumodificarusuario',@IdPermisoRegistrado output,@Mensaje output
exec SP_RegistrarPermiso 'Restablecer Clave','menurestablecerclave',@IdPermisoRegistrado output,@Mensaje output
exec SP_RegistrarPermiso 'Eliminar Usuario','menueliminarusuario',@IdPermisoRegistrado output,@Mensaje output

select @IdPermisoRegistrado

select @Mensaje

select * from Permiso
go

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
