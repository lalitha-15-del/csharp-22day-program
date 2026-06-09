using System;
using System.Collections.Generic;

namespace CareBridge.PerformanceLab.Models;

public partial class VwClinical
{
    public int PatientId { get; set; }

    public string FullName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string EncounterType { get; set; } = null!;
}
