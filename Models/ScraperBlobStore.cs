using System;
using System.Collections.Generic;

namespace MetaData_ScraperDashboardAPI.Models;

public partial class ScraperBlobStore
{
    public Guid Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string FileContentType { get; set; } = null!;

    public byte[] SourceFile { get; set; } = null!;

    public Guid DocumentId { get; set; }

    public virtual Document Document { get; set; } = null!;
}
