using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ProductsWithAuthorSpecification : Specification<Product>
    {
        public ProductsWithAuthorSpecification()
        {
            Query.Include(x => x.Author);
        }

        //ctor'dan ctor'cagırma
        public ProductsWithAuthorSpecification(int? categoryId, int? AuthorId) : this()
        {
            if (categoryId.HasValue)
            {
                Query.Where(x => x.CategoryId == categoryId);
            }
            if (AuthorId.HasValue)
            {
                Query.Where(x => x.AuthorId == AuthorId);
            }

        }
        public ProductsWithAuthorSpecification(int? categoryId, int? AuthorId, int skip, int take) : this(categoryId, AuthorId)
        {
            Query.Skip(skip).Take(take);
        }
    }
}
