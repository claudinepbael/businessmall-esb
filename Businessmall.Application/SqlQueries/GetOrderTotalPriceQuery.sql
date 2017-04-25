SELECT total_price as totalPrice
FROM [esb.shop].[dbo].[Order]
WHERE order_id = @orderId