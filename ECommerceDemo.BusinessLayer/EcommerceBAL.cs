using ECommerceDemo.Common;
using ECommerceDemo.DataTransferObjects;
using ECommerceDemo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Net;

namespace ECommerceDemo.BusinessLayer
{
    public class EcommerceBAL
    {
        private IUnitOfWork objIUnitOfWork;
        public EcommerceBAL()
        {
            objIUnitOfWork = new UnitOfWork.UnitOfWork();
        }

        public ApiResponse GetProductDetailById(int ProductID)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                ProductDTO objProductDTO = objIUnitOfWork.EcommerceRepository.GetProductDetailById(ProductID);
                objApiResponse.IsSuccess = true;
                objApiResponse.Data = objProductDTO;
                objApiResponse.Message = "Found";
            }
            catch (Exception ex)
            {
                objApiResponse.IsSuccess = false;
                objApiResponse.Data = "";
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return objApiResponse;
        }

        public ApiResponse GetAllProductDetails()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                List<ProductCategoryViewModel> objProductCategoryViewModelList = objIUnitOfWork.EcommerceRepository.GetAllProductDetails();
                if (objProductCategoryViewModelList.Count > 0)
                {
                    objApiResponse.IsSuccess = true;
                    objApiResponse.Data = objProductCategoryViewModelList;
                    objApiResponse.Message = "Found";
                }
                else
                {
                    objApiResponse.IsSuccess = true;
                    objApiResponse.Data = null;
                    objApiResponse.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                objApiResponse.IsSuccess = false;
                objApiResponse.Data = "";
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return objApiResponse;
        }

        public ApiResponse InsertUpdateProductDetail(ProductDTO objProductDTO)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                DbResult dbResult = objIUnitOfWork.EcommerceRepository.InsertUpdateProductDetail(objProductDTO);
                objApiResponse.IsSuccess = true;
                if (dbResult.DbResultId.ToString() == "Inserted")
                {
                    objApiResponse.Message = "Record Created Successfully";
                }
                if (dbResult.DbResultId.ToString() == "Updated")
                {
                    objApiResponse.Message = "Record Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                objApiResponse.IsSuccess = false;
                objApiResponse.Data = "";
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return objApiResponse;
        }

        public ApiResponse DeleteProductDetail(int ProductID)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                DbResult dbResult = objIUnitOfWork.EcommerceRepository.DeleteProductDetail(ProductID);
                objApiResponse.IsSuccess = true;
                objApiResponse.Message = (int)DbResultType.Inserted == 1 ? "Record Created Successfully" : "Record Updated Successfully";
                objApiResponse.Message = "Record Deleted Successfully";
            }
            catch (Exception ex)
            {
                objApiResponse.IsSuccess = false;
                objApiResponse.Data = "";
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return objApiResponse;
        }

        public ApiResponse GetAttributeFromCategoryDetails(int ProdCatID)
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                List<ProductAttributeLookupDTO> objProductAttributeLookupDTOList = objIUnitOfWork.EcommerceRepository.GetAttributeFromCategoryDetails(ProdCatID);
                if (objProductAttributeLookupDTOList.Count > 0)
                {
                    objApiResponse.IsSuccess = true;
                    objApiResponse.Data = objProductAttributeLookupDTOList;
                    objApiResponse.Message = "Found";
                }
                else
                {
                    objApiResponse.IsSuccess = true;
                    objApiResponse.Data = null;
                    objApiResponse.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                objApiResponse.IsSuccess = false;
                objApiResponse.Data = "";
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return objApiResponse;
        }

        public ApiResponse GetAllProductCategoryDetails()
        {
            ApiResponse objApiResponse = new ApiResponse();
            try
            {
                List<ProductCategoryDTO> objProductCategoryDTOList = objIUnitOfWork.EcommerceRepository.GetAllProductCategoryDetails();
                if (objProductCategoryDTOList.Count > 0)
                {
                    objApiResponse.IsSuccess = true;
                    objApiResponse.Data = objProductCategoryDTOList;
                    objApiResponse.Message = "Found";
                }
                else
                {
                    objApiResponse.IsSuccess = true;
                    objApiResponse.Data = null;
                    objApiResponse.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                objApiResponse.IsSuccess = false;
                objApiResponse.Data = "";
                objApiResponse.Message = ex.Message;
                objApiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return objApiResponse;
        }
    }
}
