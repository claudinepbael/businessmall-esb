INSERT INTO [esb.shop].[dbo].[Order](product_id, user_id, quantity)
	OUTPUT INSERTED.order_id
	VALUES(
		@productId,
		@userId,
		@quantity
	);
SELECT SCOPE_IDENTITY();