using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Warehouse_MS.Models;

namespace Warehouse_MS.Auth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Warehouse> Warehouses { get; set; }
    }
}
