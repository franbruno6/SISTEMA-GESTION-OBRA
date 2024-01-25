﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Observer
{
    public interface ISujetoComprobante
    {
        void AgregarObservador(IObservadorCliente observador);
        void EliminarObservador(IObservadorCliente observador);
        void NotificarObservadores();
    }
}
