﻿using WEB.Entitites;

namespace WEB.Interfaces
{
    public interface IPrincipalModel
    {
        Respuesta ConsultarProductos();
        Respuesta ConsultarProducto(int codigoCompra);
    }
}
