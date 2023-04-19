using System;
using System.Collections.Generic;

namespace MetaData_ScraperDashboardAPI.Models;

public partial class RunLog
{
    public string LogId { get; set; } = null!;

    public string RunId { get; set; } = null!;

    public string LogLevel { get; set; } = null!;

    public DateTime TimestampUtc { get; set; }

    public string Message { get; set; } = null!;

    public string? Data { get; set; }

    public virtual Run Run { get; set; } = null!;
}
