using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApp.Models;

public partial class MediaContent
{
    public int MediaId { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    public string Description { get; set; } 

    // Add this property if you want to bind the uploaded file
    [NotMapped] // Ensure this is not mapped to the database
    public IFormFile ImageFile { get; set; }
}
