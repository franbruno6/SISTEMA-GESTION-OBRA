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
@Clave nvarchar(400),
@Estado bit,
@Mensaje nvarchar(400) output,
@Resultado bit output
)
as
begin
    begin TRY
        set @Resultado = 0;
        set @Mensaje = '';

        begin TRANSACTION editar;

        IF NOT EXISTS (
                SELECT *
                FROM Usuario
                         INNER JOIN Persona ON Usuario.IdPersona = Persona.IdPersona
                WHERE Persona.Documento = @Documento AND IdUsuario != @IdUsuario
        )
        begin
            UPDATE Persona set
                NombreCompleto = @NombreCompleto,
                Correo = @Correo,
                Documento = @Documento
            WHERE IdPersona = @IdPersona;

            UPDATE Usuario set
                Clave = @Clave,
                Estado = @Estado
            WHERE IdUsuario = @IdUsuario;

            set @Resultado = 1;
        end
		else
		begin
			set @Mensaje = 'Ya existe un usuario con ese numero de documento'
		end

        COMMIT TRANSACTION editar;
    end TRY
    begin catch
        set @Mensaje = 'Error: ' + ERROR_MESSAGE() + ' (' + CAST(ERROR_NUMBER() AS NVARCHAR) + ')';
        ROLLBACK TRANSACTION editar;
    end catch
end;
go