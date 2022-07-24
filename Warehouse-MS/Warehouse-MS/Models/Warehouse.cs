using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Warehouse_MS.Auth.Models;

namespace Warehouse_MS.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SizeInUnit { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        //ForeignKey
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        //Navigation properties
        public List<Storage> Storages { get; set; }
    }
}
