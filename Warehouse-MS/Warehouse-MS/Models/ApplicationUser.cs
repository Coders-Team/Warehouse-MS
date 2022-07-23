using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Warehouse_MS.Models
{
    public class ApplicationUser : IdentityUser
    {




        public List<Warehouse> Warehouses { get; set; }

    }
}
