using System;
using System.Collections.Generic;

namespace Infraestructure.data.Models;

public partial class Compra
{
    public int CodigoCompra { get; set; }

    public string NombreCompra { get; set; } = null!;
}
