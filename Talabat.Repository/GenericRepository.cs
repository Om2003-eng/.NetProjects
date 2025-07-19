using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:BaseEntity
    {
        private readonly StoreContext _dbContext;

       
        //Without Specfications
        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
                return   (IReadOnlyList<T>) await _dbContext.Products.Include(P=>P.ProductBrand).Include(P=>P.ProductType).ToListAsync();
                return await _dbContext.Set<T>().ToListAsync();
            
        }
        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        } 
        //With Specfication         
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> Spec)
        {
            return await ApplySpecification(Spec).ToListAsync();
        }

     

        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> Spec)
        {
            return await ApplySpecification(Spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> Spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), Spec);
        }

        public async Task<int> GetCountWithSpecAsync(ISpecification<T> Spec)
        {
          return await ApplySpecification(Spec).CountAsync();
        }
    }
}
