using System;
using System.Collections.Generic;

namespace StoreManagement.Data.Model.StoreManagement;

public partial class ErrorLog
{
    public int Id { get; set; }

    public string? User { get; set; }

    public DateTime? Date { get; set; }

    public string? ErrorMessage { get; set; }

    public string? Module { get; set; }
}
