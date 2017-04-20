SELECT  o.order_id as orderID,
		p.name as productName,
		o.quantity as quantity,
		p.price as price 
From	[esb.shop].dbo.Orders o 
		INNER JOIN [esb.shop].dbo.Products p ON p.product_id = o.product_id
		
WHERE o.order_id = @order_id
