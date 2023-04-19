using System;
using System.Collections.Generic;

namespace MetaData_ScraperDashboardAPI.Models;

public partial class Run
{
    public string Id { get; set; } = null!;

    public DateTime StartTimeUtc { get; set; }

    public DateTime? EndTimeUtc { get; set; }

    public string Action { get; set; } = null!;

    public string Target { get; set; } = null!;

    public string Config { get; set; } = null!;

    public virtual ICollection<RunLog> RunLogs { get; set; } = new List<RunLog>();
}
