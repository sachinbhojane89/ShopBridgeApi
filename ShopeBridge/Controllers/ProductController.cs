using ShopBridge.Contracts;
using ShopeBridgeBusiness;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopeBridge.Controllers
{
    /// <summary>
    /// Product controller handles all incoming requests
    /// </summary>
    public class ProductController : ApiController
    {
        private IProductService _service = null;
        public ProductController()
        {
            //Due to some issues I have to make this adjustment to run the application, in normal world this should get automatically created by contructor
            var container = WebApiApplication.container;
            _service = container.GetInstance<IProductService>();
        }
        public ProductController(IProductService service)
        {
            _service = service;
        }

        /// <summary>
        /// Method return all records page wise, we need to specify current page number and page size
        /// </summary>
        /// <param name="pageNo">current page number</param>
        /// <param name="countOfRecords">page size</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(int pageNo, int pageSize)
        {
            try
            {
                if (pageSize <= 0)
                {
                    return BadRequest("Please provide required input - pageSize");
                }
                var products = await _service.GetAll(pageNo, pageSize);
                if (products != null)
                    return Ok(products);
                else
                    throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                var response = GenerateErrorResponse(ex, "Error occured while fetching record");
                throw new HttpResponseException(response);
            }

        }

        private static HttpResponseMessage GenerateErrorResponse(Exception ex, string message)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(message + "Stack Trace: " + ex.InnerException)
            };
            return response;
        }

        /// <summary>
        /// Method to fetch product using id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>Product</returns>
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var product = await _service.GetById(id);
                if (product != null)
                    return Ok(product);
                else
                    throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                var response = GenerateErrorResponse(ex, "Error occured while fetching record");
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Method to save new product entry to database
        /// </summary>
        /// <param name="product">New product</param>
        /// <returns>IHttpActionResult</returns>
        public async Task<IHttpActionResult> Post(ProductDto product)
        {
            try
            {
                if (product != null)
                    return Ok(await _service.Save(product));
                else
                    throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                var response = GenerateErrorResponse(ex, "Error occured while saving record");
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Method to update records from database
        /// </summary>
        /// <param name="value">Product with updated values</param>
        /// <returns>IHttpActionResult</returns>
        public async Task<IHttpActionResult> Put(ProductDto value)
        {
            try
            {
                if (value != null)
                    return Ok(await _service.Update(value));
                else
                    throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                var response = GenerateErrorResponse(ex, "Error occured while updating record");
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Method to delete records from database
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>IHttpActionResult</returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (Exception ex)
            {
                var response = GenerateErrorResponse(ex, "Error occured while deleting record");
                throw new HttpResponseException(response);
            }
        }
    }
}
