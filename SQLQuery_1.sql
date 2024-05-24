SELECT *
  FROM [SuperShopWEB].[dbo].[Products] Products, [SuperShopWEB].[dbo].[AspNetUsers] Users
  WHERE
    Products.UserId = Users.Id