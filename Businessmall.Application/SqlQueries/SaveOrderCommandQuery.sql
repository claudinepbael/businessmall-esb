INSERT INTO [esb.businessmall].[dbo].Order
	(order_id,product_id, user_id, quantity)
	SELECT
		@orderId as order_id,
		@productId as product_id,
		@userId as user_id,
		@quantity as quantity
	FROM [esb.businessmall].[dbo].Product
	WHERE 
		product_id = @product_id and
		qty_at_hand >= @quantity
;
