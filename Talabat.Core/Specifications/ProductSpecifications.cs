using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class ProductSpecifications:BaseSpecifications<Product>
    {
        public ProductSpecifications()
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
            ApplyOrderBy(P => P.Name);
        }
        //GetAllProducts
        //_dbContext.Products.Where(P=>P.ProductBrand.id==BrandId && P=>P.ProductType.id==TypeId).Include(P => P.ProductType).Include(P => P.ProductBrand);
        public ProductSpecifications(ProductSpecParams Params):base
            (
              p=>(!Params.BrandId.HasValue || p.ProductBrandId== Params.BrandId)
              &&
              (!Params.TypeId.HasValue ||p.ProductTypeId==Params.TypeId)
            )
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
            if (!string.IsNullOrEmpty(Params.Sort))
            {
                switch (Params.Sort)
                {
                    case "PriceAsc":
                        ApplyOrderBy(P => P.Price);
                        break;

                    case "PriceDesc":
                        ApplyOrderByDesc(P => P.Price);
                        break;
                    default:
                        ApplyOrderBy(P => P.Name);
                        break;



                }

            }

            ApplyPagination(Params.PageSize,Params.PageSize*(Params.PageIndex-1));

        }

        //Get By Id

        public ProductSpecifications(int Id):base(P => P.Id == Id)
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);

        }


    }
}
