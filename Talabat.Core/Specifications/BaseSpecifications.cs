using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Critirea { get ; set; }
        public List<Expression<Func<T, object>>> Includes { get ; set; }= new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Take { get ; set ; }
        public int Skip { get; set; }
        public bool IsPaginationEnabled { get ; set ; }

        //Get All Product
        public BaseSpecifications()
        {
           
        }

        //Get Product By Id
        public BaseSpecifications(Expression<Func<T, bool>> expression)
        {
            Critirea = expression;
           
        }
        public void ApplyOrderBy(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }
        public void ApplyOrderByDesc(Expression<Func<T, object>> OrderByDescExpression)
        {
            OrderByDesc = OrderByDescExpression;
        }
        public void ApplyPagination(int take, int skip) {
            Take = take;
            Skip = skip;
            IsPaginationEnabled = true;  ;
               
        
        }
    }
}
