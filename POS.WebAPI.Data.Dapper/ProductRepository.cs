using POS.WebAPI.Entity;
using POS.WebAPI.Infraestructure;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class ProductRepository
    {
        private IConnectionFactory _connectionFactory;

        public ProductRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public ResponseMessage CreateProductItem(Product item)
        {
            var procedure = "dbproduct.Proc_CreateCompanyProductItem";
            ResponseMessage response = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                       procedure,
                                                       param: new
                                                       {
                                                           p_company_id = item.CompanyId,
                                                           p_cat_sub_product_id = item.SubProductId,
                                                           p_item_number = item.ItemNumber,
                                                           p_bar_code = item.BarCode,
                                                           p_name = item.Name,
                                                           p_detail = item.Detail,
                                                           p_price = item.Price,
                                                           p_tax = item.Tax,
                                                           p_stock = item.Stock,
                                                           p_weight = item.Weight,
                                                           p_width = item.Width,
                                                           p_height = item.Height,
                                                           p_img_url = item.ImgURL,
                                                           p_created_user = item.CreatedUser
                                                       },
                                                       commandType: CommandType.StoredProcedure
                                                     );
            }

            return response;
        }

        public IEnumerable<Product> GetProductItemByCompany(Company company)
        {
            var procedure = "dbproduct.Proc_GetCompanyProductItem";
            IEnumerable<Product> itemList = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                itemList = connection.Query<Product>(
                                                       procedure,
                                                       param: new
                                                       {
                                                           p_company_id = company.Id,
                                                           p_cat_subproduct = company.SubProductId,
                                                           p_created_user = company.CreatedUser
                                                       },
                                                       commandType: CommandType.StoredProcedure
                                                     );
            }

            return itemList;
        }

        public bool DeleteItemById(Product product)
        {
            var procedure = "dbproduct.Proc_DeleteItemById";
            bool response = false;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                response = connection.QuerySingle<bool>(
                                                       procedure,
                                                       param: new
                                                       {
                                                           p_item_id = product.Id,
                                                           p_created_user = product.CreatedUser
                                                       },
                                                       commandType: CommandType.StoredProcedure
                                                     );
            }

            return response;
        }

        public ResponseMessage UpdateItemById(Product product)
        {
            var procedure = "dbproduct.Proc_UpdateProductItem";
            ResponseMessage response = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                response = connection.QuerySingle<ResponseMessage>(
                                                       procedure,
                                                       param: new
                                                       {
                                                           p_item_id = product.Id,
                                                           p_name = product.Name,
                                                           p_price = product.Price,
                                                           p_created_user = product.CreatedUser
                                                       },
                                                       commandType: CommandType.StoredProcedure
                                                     );
            }

            return response;
        }
    }
}
