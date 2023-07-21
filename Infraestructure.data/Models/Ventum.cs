using System;
using System.Collections.Generic;

namespace Infraestructure.data.Models;

public partial class Ventum
{
    public int CodigoVenta { get; set; }

    public int CodigoProd { get; set; }

    public int Cantidad { get; set; }

    public double? Precio { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Producto CodigoProdNavigation { get; set; } = null!;
}
