using System;
using System.Collections.Generic;

namespace ARTF_ASISTENCIA_v2.Models;

public partial class Asistencium
{
    public DateTime DiaReg { get; set; }

    public DateTime? HrfhIng { get; set; }

    public DateTime? HrfhSal { get; set; }

    public string? Observaciones { get; set; }

    public string? Justificaciones { get; set; }

    public decimal? Numemp { get; set; }
}
