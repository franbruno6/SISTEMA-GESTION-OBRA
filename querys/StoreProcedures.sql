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



