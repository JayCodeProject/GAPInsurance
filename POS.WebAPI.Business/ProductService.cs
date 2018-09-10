using POS.WebAPI.Data.Dapper;
using POS.WebAPI.Entity;
using POS.WebAPI.Extender;
using System;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public class ProductService : IProductService
    {
        private LogRepository _LogRepository;
        private ProductRepository _ProductRepository;

        public ProductService(LogRepository logRepository, ProductRepository productRepository)
        {
            _LogRepository = logRepository;
            _ProductRepository = productRepository;
        }

        public ResponseMessage CreateProductItem(Product item)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
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
            };

            try
            {
                process.company = item.CompanyId.ToString();
                process.procName = "Proc_CreateCompanyProductItem";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = item.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _ProductRepository.CreateProductItem(item);

                process.result = response.ToString().SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return response;
        }

        public IEnumerable<Product> GetProductItemByCompany(Company company)
        {
            IEnumerable<Product> itemList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_company_id = company.Id,
                p_created_user = company.CreatedUser
            };

            try
            {
                process.company = company.Id.ToString();
                process.procName = "Proc_GetCompanyProductItem";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = company.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                itemList = _ProductRepository.GetProductItemByCompany(company);

                process.result = itemList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return itemList;
        }

        public bool DeleteItemById(Product product)
        {
            bool response = false;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_item_id = product.Id,
                p_created_user = product.CreatedUser
            };

            try
            {
                process.company = product.CompanyId.ToString();
                process.procName = "Proc_DeleteItemById";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = product.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _ProductRepository.DeleteItemById(product);

                process.result = response.ToString().SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return response;
        }

        public ResponseMessage UpdateItemById(Product product)
        {
            ResponseMessage response = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_item_id = product.Id,
                p_name = product.Name,
                p_price = product.Price,
                p_created_user = product.CreatedUser
            };

            try
            {
                process.company = product.CompanyId.ToString();
                process.procName = "Proc_UpdateProductItem";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = product.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                response = _ProductRepository.UpdateItemById(product);

                process.result = response.ToString().SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return response;
        }
    }
}
