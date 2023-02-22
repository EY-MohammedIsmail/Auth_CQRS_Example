using System;
using System.Collections.Generic;

namespace Auth_CQRS_Example.Models;

public partial class UserInfo
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
}
