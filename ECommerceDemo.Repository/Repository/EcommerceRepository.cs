using Dapper;
using ECommerceDemo.Common;
using ECommerceDemo.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ECommerceDemo.Repository
{
    public class EcommerceRepository : IEcommerceRepository
    {
        private DBDataProvider objDBDataProvider;
        public EcommerceRepository()
        {
            objDBDataProvider = new DBDataProvider();
        }
        public ProductDTO GetProductDetailById(int ProductID)
        {
            using (objDBDataProvider = new DBDataProvider())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", (int)Mode.Get);
                parameters.Add("ProductId", ProductID);
                ProductDTO _objProductDTO = objDBDataProvider.GetEntity<ProductDTO>(StoredProcedure.MstProductDetails, parameters, CommandType.StoredProcedure);
                return _objProductDTO;
            }
        }
        public List<ProductCategoryViewModel> GetAllProductDetails()
        {
            using (objDBDataProvider = new DBDataProvider())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", (int)Mode.GetAll);
                List<ProductCategoryViewModel> _objProductCategoryViewModel = objDBDataProvider.GetEntityList<ProductCategoryViewModel>(StoredProcedure.MstProductDetails, parameters, CommandType.StoredProcedure);
                return _objProductCategoryViewModel;
            }
        }
        public DbResult InsertUpdateProductDetail(ProductDTO objProductDTO)
        {
            using (objDBDataProvider = new DBDataProvider())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", (int)Mode.Insert);
                parameters.Add("ProductId", objProductDTO.ProductId);
                parameters.Add("ProdCatId", objProductDTO.ProdCatId);
                parameters.Add("AttributeId", objProductDTO.AttributeId);
                parameters.Add("ProdName", objProductDTO.ProdName);
                parameters.Add("ProdDescription", objProductDTO.ProdDescription);
                DbResult objDbResult = objDBDataProvider.GetEntity<DbResult>(StoredProcedure.MstProductDetails, parameters, CommandType.StoredProcedure);
                return objDbResult;
            }
        }
        public DbResult DeleteProductDetail(int ProductID)
        {
            using (objDBDataProvider = new DBDataProvider())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", (int)Mode.Delete);
                parameters.Add("ProductId", ProductID);
                DbResult objDbResult = objDBDataProvider.GetEntity<DbResult>(StoredProcedure.MstProductDetails, parameters, CommandType.StoredProcedure);
                return objDbResult;
            }
        }
        public List<ProductAttributeLookupDTO> GetAttributeFromCategoryDetails(int ProdCatID)
        {
            using (objDBDataProvider = new DBDataProvider())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", 6);
                parameters.Add("ProdCatId", ProdCatID);
                List<ProductAttributeLookupDTO> _objProductAttributeLookupDTO = objDBDataProvider.GetEntityList<ProductAttributeLookupDTO>(StoredProcedure.MstProductDetails, parameters, CommandType.StoredProcedure);
                return _objProductAttributeLookupDTO;
            }
        }
        public List<ProductCategoryDTO> GetAllProductCategoryDetails()
        {
            using (objDBDataProvider = new DBDataProvider())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Mode", 7);
                List<ProductCategoryDTO> _objProductCategoryDTO = objDBDataProvider.GetEntityList<ProductCategoryDTO>(StoredProcedure.MstProductDetails, parameters, CommandType.StoredProcedure);
                return _objProductCategoryDTO;
            }
        }
    }
}
