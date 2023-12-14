using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrycleanProject
{
    internal class ResultForm
    {
        public int orderId { get; set; }

        public int ItemId { get; set; }

        public string TypeC { get; set; } = null!;

        public string TypeF { get; set; } = null!;  

        public string Color { get; set; } = null!;

        public string Passport { get; set; } = null!;   

        public string Employee { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Status { get; set; } = null!;

        public int Cost { get; set; }
    }
}
