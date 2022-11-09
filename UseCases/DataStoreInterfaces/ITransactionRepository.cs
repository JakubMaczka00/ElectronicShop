using MainBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStoreInterfaces
{
    public interface ITransactionRepository
    {
        public IEnumerable<Transaction> Get(string sellerName);
        public IEnumerable<Transaction> GetByDay(string sellerName, DateTime date);
        public void Save(string sellerName, int productId, string productName,int soldQuantity,int preQuantity, double price);
        public IEnumerable<Transaction> SearchByDate(string sellerName, DateTime startDate, DateTime endDate);
    }
}
