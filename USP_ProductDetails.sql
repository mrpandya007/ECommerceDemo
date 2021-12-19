USE [ECommerceDemo]
GO
/****** Object:  StoredProcedure [dbo].[USP_ProductDetails]    Script Date: 06/14/2020 7:15:45 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[USP_ProductDetails]
GO
/****** Object:  StoredProcedure [dbo].[USP_ProductDetails]    Script Date: 06/14/2020 7:15:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ProductDetails]
	-- Add the parameters for the stored procedure here
	@ProductId INT = 0,
	@ProdCatId INT = 0,
	@ProdName NVARCHAR(250) = NULL,
	@ProdDescription NVARCHAR(max) = NULL,
	@ReportingPeriod NVARCHAR(max) = NULL,
	@AttributeId INT = 0,
	@AttributeName NVARCHAR(250) = NULL,
	@Mode INT = 0

AS
BEGIN
	IF(@mode = 1) --insert /update product
	BEGIN
		IF(@ProductId=0)
		BEGIN
			INSERT INTO dbo.Product(ProdCatId,ProdName,ProdDescription) VALUES (@ProdCatId,@ProdName,@ProdDescription)
				
			SET @ProductId = SCOPE_IDENTITY()
			SELECT @AttributeName = AttributeName FROM ProductAttributeLookup WHERE AttributeId =@AttributeId
			--insert ProductAttribute
			INSERT INTO ProductAttribute(ProductId,AttributeId,AttributeValue) VALUES (@ProductId,@AttributeId,@AttributeName)

			SELECT 1 AS DbResultId, @ProductId as TableId
		END
		ELSE
		BEGIN
			UPDATE Product SET ProdCatId=@ProdCatId,ProdName=@ProdName,ProdDescription=@ProdDescription WHERE ProductId = @ProductId

			--DELETE OLD VALUE
			DELETE FROM ProductAttribute WHERE ProductId =@ProductId

			--INSERT NEW VALUE
			SELECT @AttributeName = AttributeName FROM ProductAttributeLookup WHERE AttributeId =@AttributeId
			INSERT INTO ProductAttribute(ProductId,AttributeId,AttributeValue) VALUES (@ProductId,@AttributeId,@AttributeName)

			SELECT 2 AS DbResultId, @ProductId as TableId
		END
	END 
	ELSE IF(@mode = 3) --delete product
	BEGIN

		DELETE FROM ProductAttribute WHERE ProductId =@ProductId
		DELETE FROM Product WHERE ProductId =@ProductId
		
		SELECT 3 AS DbResultId, @ProductId as TableId
	END
	ELSE IF(@mode = 4) --product list
	BEGIN
		SELECT  DISTINCT P.ProductId,P.ProdName,P.ProdDescription,pc.CategoryName,PAL.AttributeValue AS AttributeName FROM ProductAttribute PA
		INNER JOIN Product P ON P.ProductId = PA.ProductId
		INNER JOIN ProductAttribute PAL ON PAL.AttributeId = PA.AttributeId 
		INNER JOIN ProductCategory PC ON PC.ProdCatId = P.ProdCatId
	END
	ELSE IF(@mode = 5)	--product detail by product id
	BEGIN
		SELECT P.ProductId,PC.ProdCatId,PAL.AttributeId,P.ProdName,P.ProdDescription FROM ProductAttribute PA
		INNER JOIN Product P ON P.ProductId = PA.ProductId
		INNER JOIN ProductAttribute PAL ON PAL.AttributeId = PA.AttributeId 
		INNER JOIN ProductCategory PC ON PC.ProdCatId = P.ProdCatId WHERE P.ProductId = @ProductId
	END
	ELSE IF(@mode = 6) --attribute from category
	BEGIN
		SELECT AttributeId,AttributeName FROM ProductAttributeLookup WHERE ProdCatId = @ProdCatId
	END
	ELSE IF(@mode = 7)	--category list
	BEGIN
		SELECT ProdCatId,CategoryName FROM ProductCategory
	END
	
END

GO
