using System;
using System.Collections.Generic;

namespace ARTF_ASISTENCIA_v2.Models;

public partial class Empleado
{
    public decimal Numemp { get; set; }

    public string? NombreEmp { get; set; }

    public byte[]? Huella { get; set; }

    public byte[]? Huella2 { get; set; }

    public byte[]? Huella3 { get; set; }

    public byte[]? Huella4 { get; set; }

    public byte[]? Huella5 { get; set; }

    public string? Area { get; set; }

    public string? Puesto { get; set; }

    public string? Curp { get; set; }

    public string? Rfc { get; set; }
}
