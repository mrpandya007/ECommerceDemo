using ECommerceDemo.Common;
using ECommerceDemo.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDemo.Repository
{
    public interface IEcommerceRepository
    {
        ProductDTO GetProductDetailById(int ProductID);
        List<ProductCategoryViewModel> GetAllProductDetails();
        DbResult InsertUpdateProductDetail(ProductDTO objProductDTO);
        DbResult DeleteProductDetail(int ProductID);
        List<ProductAttributeLookupDTO> GetAttributeFromCategoryDetails(int ProdCatID);
        List<ProductCategoryDTO> GetAllProductCategoryDetails();
    }
}
