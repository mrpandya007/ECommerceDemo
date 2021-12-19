using ECommerceDemo.BusinessLayer;
using ECommerceDemo.Common;
using ECommerceDemo.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerceDemo.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private readonly EcommerceBAL objEcommerceBAL;

        public ProductController()
        {
            objEcommerceBAL = new EcommerceBAL();
        }

        [Route("ProductCategoryList")]
        [HttpGet]
        public IHttpActionResult GetAllProductCategoryDetails()
        {
            ApiResponse objApiResponse = objEcommerceBAL.GetAllProductCategoryDetails();
            return Json(objApiResponse);
        }

        [Route("ProductList")]
        [HttpGet]
        public IHttpActionResult GetAllProductDetails()
        {
            ApiResponse objApiResponse = objEcommerceBAL.GetAllProductDetails();
            var dataTable = new { data = objApiResponse.Data };
            return Json(dataTable);
        }

        [Route("ProductDetailById")]
        [HttpGet]
        public IHttpActionResult GetProductDetailById(int ProductID)
        {
            ApiResponse objApiResponse = objEcommerceBAL.GetProductDetailById(ProductID);
            return Json(objApiResponse);
        }

        [Route("DeleteProduct")]
        [HttpGet]
        public IHttpActionResult DeleteProductDetail(int ProductID)
        {
            ApiResponse objApiResponse = objEcommerceBAL.DeleteProductDetail(ProductID);
            return Json(objApiResponse);
        }

        [Route("AttributeByCategoryId")]
        [HttpGet]
        public IHttpActionResult GetAttributeFromCategoryDetails(int ProdCatID)
        {
            ApiResponse objApiResponse = objEcommerceBAL.GetAttributeFromCategoryDetails(ProdCatID);
            return Json(objApiResponse);
        }

        [Route("InsertUpdateProduct")]
        [HttpPost]
        public IHttpActionResult InsertUpdateProductDetail(ProductDTO objProductDTO)
        {
            ApiResponse objApiResponse = objEcommerceBAL.InsertUpdateProductDetail(objProductDTO);
            return Json(objApiResponse);
        }
    }
}
