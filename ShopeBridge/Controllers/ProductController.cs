using ShopBridge.Contracts;
using ShopeBridgeBusiness;
using System;
using System.Collections.Generic;
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
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await Task.Run(() => _service.GetAll()));
            }
            catch (Exception ex)
            {
                //logs can be added here
                return InternalServerError(ex);
            }
            
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            try {
                return Ok(await Task.Run(() => _service.GetById(id)));
            }
            catch (Exception ex)
            {
                //logs can be added here
                return InternalServerError(ex);
            }
            
        }

        public async Task<IHttpActionResult> Post(ProductDto product)
        {
            try {
                return Ok(await Task.Run(() => _service.Save(product)));
            }
            catch (Exception ex)
            {
                //logs can be added here
                return InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> Put(ProductDto value)
        {
            try {
                return Ok(await Task.Run(() => _service.Update(value)));
            }catch (Exception ex)
            {
                //logs can be added here
                return InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                return Ok(await Task.Run(() => _service.Delete(id)));
            }
            catch (Exception ex)
            {
                //logs can be added here
                return InternalServerError(ex);
            }
        }
    }
}
