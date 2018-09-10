using POS.WebAPI.Entity;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public interface IProductService
    {
        ResponseMessage CreateProductItem(Product item);
        IEnumerable<Product> GetProductItemByCompany(Company company);
        bool DeleteItemById(Product product);
        ResponseMessage UpdateItemById(Product product);
    }
}
