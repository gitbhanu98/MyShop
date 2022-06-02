//This interface is generated from InMemoryRepository as IInMemoryRepository in MyShop.DataAcess project and then it is moved to MyShop.Core.COntracts and has been renamed as IRepository

using MyShop.Core.Models;
using System.Linq;

namespace MyShop.Core.Contracts

{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}