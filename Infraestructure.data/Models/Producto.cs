using System;
using System.Collections.Generic;

namespace Infraestructure.data.Models;

public partial class Producto
{
    public int CodigoProd { get; set; }

    public string NombreProd { get; set; } = null!;

    public string? Cantidad { get; set; }

    public double? PrecioCompra { get; set; }

    public double PrecioVenta { get; set; }

    public int CodigoCat { get; set; }

    public DateTime Fecha { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
