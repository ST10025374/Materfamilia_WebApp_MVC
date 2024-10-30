using System;
using System.Collections.Generic;

namespace SampleApp.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public string? ServiceType { get; set; }

    public DateTime? Date { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }
}
