using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity //Class that is in database Table
    {
        //without specification
         public Task<IReadOnlyList<T>> GetAllAsync();
         public Task<T> GetByIdAsync(int id);

        //with specification
        public Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec);
         public Task<T> GetByIdWithSpecAsync(ISpecification<T> Spec);

        public Task<int> GetCountWithSpecAsync(ISpecification<T> Spec);
        
            //This method is used to get the count of entities that match the specification
            
        


    }
}
