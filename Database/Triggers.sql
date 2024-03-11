use DB_SGO
go

create trigger TRG_ComprobanteObra_AfterInsertUpdate
on ComprobanteObra
after insert, update
as
begin
    declare @IdComprobanteObra int,
            @EstadoObraPrevio nvarchar(60),
            @EstadoObraNuevo nvarchar(60),
			@Operacion nvarchar(10);

    -- Insertar registros cuando se actualiza el estado de la obra
    if exists(select * from inserted i inner join deleted d on i.IdComprobanteObra = d.IdComprobanteObra)
    begin
        -- Obtener los valores actualizados y anteriores
        select @IdComprobanteObra = i.IdComprobanteObra,
               @EstadoObraPrevio = d.EstadoObra,
               @EstadoObraNuevo = i.EstadoObra
        from inserted i
        left join deleted d on i.IdComprobanteObra = d.IdComprobanteObra;

		set @Operacion = 'Update'
        -- Insertar el registro en la tabla histórica
        insert into Hist_ComprobanteObra (IdComprobanteObra, IdPresupuesto, IdCliente, IdUsuario, Adelanto, Saldo, MontoTotal, EstadoObraActual, EstadoObraPrevio, Operacion, FechaRegistro)
        select IdComprobanteObra, IdPresupuesto, IdCliente, IdUsuario, Adelanto, Saldo, MontoTotal, @EstadoObraNuevo, @EstadoObraPrevio, @Operacion, getdate()
        from ComprobanteObra
        where IdComprobanteObra = @IdComprobanteObra;
    end

    -- Insertar registros cuando se inserta un nuevo comprobante obra
	else if exists(select * from inserted i left join deleted d on i.IdComprobanteObra = d.IdComprobanteObra where d.IdComprobanteObra is null)
    begin
        -- Obtener el nuevo estado de la obra
        select @IdComprobanteObra = IdComprobanteObra,
               @EstadoObraNuevo = i.EstadoObra
        from inserted i;

		set @Operacion = 'Insert'
        -- Insertar el registro en la tabla de historial con estado previo NULL
        insert into Hist_ComprobanteObra (IdComprobanteObra, IdPresupuesto, IdCliente, IdUsuario, Adelanto, Saldo, MontoTotal, EstadoObraActual, EstadoObraPrevio, Operacion, FechaRegistro)
        select IdComprobanteObra, IdPresupuesto, IdCliente, IdUsuario, Adelanto, Saldo, MontoTotal, @EstadoObraNuevo, null, @Operacion, getdate()
        from ComprobanteObra
        where IdComprobanteObra = @IdComprobanteObra;
    end
end
go