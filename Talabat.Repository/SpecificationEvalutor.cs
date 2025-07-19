using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    internal static class SpecificationEvalutor<T> where T:BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery,ISpecification<T> Spec)
        {
            //_dbContext.Products.Where(P => P.Id == id).Include(P => P.ProductType).Include(P => P.ProductBrand);

            //_dbContext.Products
            var Query = InputQuery;
            if(Spec.Critirea is not null)
            {
                //Spec.Critera => P => P.Id ==id
                //_dbContext.Products.Where(P => P.Id == id)
                Query = Query.Where(Spec.Critirea);

            }

            if(Spec.OrderBy is not null)
            {
                Query = Query.OrderBy(Spec.OrderBy);
            }
            if (Spec.OrderByDesc is not null)
            {
                Query = Query.OrderByDescending(Spec.OrderByDesc);
            }
            if (Spec.IsPaginationEnabled)
            {
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            }
            if (Spec.Includes is not null)
            {
                //_dbContext.Products.Where(P => P.Id == id).Include(P => P.ProductType).Include(P => P.ProductBrand);
                // P=>P.ProductType, P=> P.ProductBrand
                Query = Spec.Includes.Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));       
                  
            }
            return Query;
        }
    }
}
