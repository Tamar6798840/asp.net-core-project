﻿using System;
using System.Collections.Generic;

namespace Entities;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; } = null!;

    public int UserId { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
