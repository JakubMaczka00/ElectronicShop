using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusiness
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int PreQuantity  { get; set; }   
        public int SoldQuantity { get; set; }
        public string SellerName { get; set; }
        public string ProductName { get; set; }
    }
}
