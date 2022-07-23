
using System.Collections.Generic;

namespace Warehouse_MS.Models
{
    public class StorageType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Storage> Storages { get; set; }
        public List<Product> Products { get; set; }

    }
}