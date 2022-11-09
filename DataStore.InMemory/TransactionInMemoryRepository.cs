using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStoreInterfaces;
using MainBusiness;

namespace DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            transactions = new List<Transaction>();
        }
        public IEnumerable<Transaction> Get(string sellerName)
        {
            if(string.IsNullOrWhiteSpace(sellerName))
            return transactions;
            else
                return transactions.Where(x=>string.Equals(x.SellerName,sellerName,StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Transaction> GetByDay(string sellerName,DateTime date)
        {
            if (string.IsNullOrWhiteSpace(sellerName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return transactions.Where(x => string.Equals(x.SellerName, sellerName, StringComparison.OrdinalIgnoreCase) && x.TimeStamp.Date == date.Date);
        }
        public IEnumerable<Transaction> SearchByDate(string sellerName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(sellerName))
                return transactions.Where(x => x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
            else
                return transactions.Where(x => string.Equals(x.SellerName, sellerName, StringComparison.OrdinalIgnoreCase) && x.TimeStamp.Date >= startDate.Date && x.TimeStamp.Date <= endDate.Date.AddDays(1).Date);
        }
        public void Save(string sellerName, int productId, string productName, int preQuantity,int soldQuantity, double price)
        {
            int transactionId = 0;
            if (transactions != null && transactions.Count > 0)
            {
                int maxId = transactions.Max(x => x.TransactionId);
                transactionId = maxId + 1;
            }
            transactions.Add(new Transaction
            {
                TransactionId = transactionId,
                ProductId = productId,
                ProductName = productName,
                Price = price,
                PreQuantity = preQuantity,
                SoldQuantity = soldQuantity,
                TimeStamp = DateTime.Now,
                SellerName = sellerName

            });
        }

        
    }
}
