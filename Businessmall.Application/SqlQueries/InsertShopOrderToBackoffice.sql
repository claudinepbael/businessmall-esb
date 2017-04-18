﻿INSERT INTO [esb.businessmall].[dbo].Order
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

INSERT INTO [esb.businessmall].[dbo].Order
	SELECT
		'8A158BC5-DDB8-4F1D-8844-F2FC7EE2315F' as order_id,
		6 as product_id,
		2 as user_id,
		4 as quantity
	FROM [esb.businessmall].[dbo].Product
	WHERE 
		product_id = 6 and
		qty_at_hand >= 4;
