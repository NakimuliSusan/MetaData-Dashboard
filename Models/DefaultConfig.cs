using System;
using System.Collections.Generic;

namespace MetaData_ScraperDashboardAPI.Models;

public partial class DefaultConfig
{
    public string Id { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string Target { get; set; } = null!;

    public string Config { get; set; } = null!;
}
