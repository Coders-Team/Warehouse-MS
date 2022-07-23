using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse_MS.Models.DTO
{
    public class TransactionDto
    {

        //  This is the Transaction DTO for get request 
        public string Type { get; set; }
        public string NewLocation { get; set; }

        public string OldLocation { get; set; }
        public DateTime UpdateDate { get; set; }

        public int ProductId { get; set; }

        public string UpdatedBy { get; set; }


    }
}
