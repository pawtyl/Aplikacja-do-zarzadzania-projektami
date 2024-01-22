using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace aspnet.Areas.Identity.Data;

public class SampleUser : IdentityUser
{
    public string Username { get; set; }
    public string Password { get; set; }
}