using System;
using System.Collections.Generic;

namespace MetaData_ScraperDashboardAPI.Models;

public partial class Document
{
    public Guid Id { get; set; }

    public string Url { get; set; } = null!;

    public string Scraper { get; set; } = null!;

    public string Version { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string Data { get; set; } = null!;

    public DateTime? IngestedAt { get; set; }

    public virtual ICollection<ScraperBlobStore> ScraperBlobStores { get; set; } = new List<ScraperBlobStore>();
}
