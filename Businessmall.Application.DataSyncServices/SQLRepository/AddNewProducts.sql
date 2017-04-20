SELECT   bmall_prod.id as id
		,bmall_prod.name as name
		,bmall_prod.price as price
		,bmall_prod.qty_at_hand as qty_at_hand
FROM [esb.businessmall].dbo.Product  as bmall_prod 
LEFT OUTER JOIN [esb.shop].dbo.Product  new_product ON new_product.product_id = bmall_prod.id
where new_product.product_id is null