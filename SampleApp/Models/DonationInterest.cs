using System;
using System.Collections.Generic;

namespace SampleApp.Models;

public partial class DonationInterest
{
    public int DonationId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public decimal? AmountPledged { get; set; }

    public DateTime? DateSubmitted { get; set; }
}
