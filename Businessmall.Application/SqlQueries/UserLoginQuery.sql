SELECT	 id as userID
		,username as userName
		,CONCAT(first_name,' ',last_name) as fullName 
FROM	[User]
WHERE username = @_userName and password = @_password