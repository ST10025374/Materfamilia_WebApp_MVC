using System;
using System.Collections.Generic;

namespace SampleApp.Models;

public partial class MediaContent
{
    public int MediaId { get; set; }

    public string? Type { get; set; }

    public string? Url { get; set; }

    public string? Description { get; set; }
}
