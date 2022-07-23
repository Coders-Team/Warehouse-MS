using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse_MS.Models.DTO
{
    public class ProductDto
    {

        public string Name { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int SizeInUnit { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }
        public string BarcodeNum { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }


        public int StorageId { get; set; }
        public int StorageTypeId { get; set; }
        public int ProductTypeId { get; set; }

    }
}
