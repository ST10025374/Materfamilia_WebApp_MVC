using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleApp.Models;

public partial class MediaContent
{
    public int MediaId { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }

    // New properties for storing the image in the database
    public byte[] ImageData { get; set; }
    public string ImageFileName { get; set; }

    // Property for the uploaded file in the form
    [NotMapped]
    public IFormFile ImageFile { get; set; }
}
