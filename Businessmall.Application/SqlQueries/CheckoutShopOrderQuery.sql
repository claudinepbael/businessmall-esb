INSERT INTO [esb.shop].[dbo].[Order](product_id, user_id, quantity, total_price)
	OUTPUT INSERTED.order_id
	SELECT 
		@productId as product_id,
		@userId as user_id,
		@quantity as quantity,
		price * @quantity as total_price
	FROM [esb.shop].[dbo].[Product]
	WHERE product_id = @productId;
;
SELECT SCOPE_IDENTITY();