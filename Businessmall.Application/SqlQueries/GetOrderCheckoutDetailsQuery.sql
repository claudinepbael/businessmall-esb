SELECT product_id as productId
		,name as productName
		,price as price
		,available_qty as availableQty 
FROM [esb.shop].[dbo].[Product]
WHERE product_id = @productId
