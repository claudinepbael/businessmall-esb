SELECT 
	o.order_id as orderId,
	o.product_id as productId,
	p.name as productName,
	o.user_id as userId,
	o.date_ordered as dateOrdered,
	quantity as quantity,
	p.price as price,
	quantity * p.price as totalPrice,
	status as status

FROM [esb.shop].[dbo].[Order] o
FULL OUTER JOIN [esb.shop].[dbo].[Product] p ON o.product_id = p.product_id
FULL OUTER JOIN [esb.shop].[dbo].[Users] u ON o.user_id = u.user_id
WHERE o.user_id = @userId