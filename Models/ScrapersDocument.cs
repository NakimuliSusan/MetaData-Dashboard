using System;
using System.Collections.Generic;

namespace MetaData_ScraperDashboardAPI.Models;

public partial class ScrapersDocument
{
    public Guid Id { get; set; }

    public string Url { get; set; } = null!;

    public string Scraper { get; set; } = null!;

    public string Version { get; set; } = null!;

    public TimeOnly[] Timestamp { get; set; } = null!;

    public string Data { get; set; } = null!;

    public DateTime IngestedAt { get; set; }
}
