using System;
using System.ComponentModel.DataAnnotations.Schema;
using Warehouse_MS.Auth.Models;

namespace Warehouse_MS.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string newLocation { get; set; }
        public string OldLocation { get; set; }
        public DateTime UpdateDate { get; set; }
        
        //ForeignKey
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UpdatedBy { get; set; }
    }
}
