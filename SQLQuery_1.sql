SELECT *
  FROM [SuperShopWEB].[dbo].[Products] Products, [SuperShopWEB].[dbo].[AspNetUsers] Users
  --FROM [SuperShopMVC5_db].[dbo].[Products] Products, [SuperShopMVC5_db].[dbo].[AspNetUsers] Users
  WHERE
    Products.UserId = Users.Id


SELECT UserRoles.*, Roles.*
  --FROM [SuperShopWEB].[dbo].[AspNetUsers] Users
  FROM [SuperShopWEB].[dbo].[AspNetUsers] UserRoles, [SuperShopWEB].[dbo].[AspNetRoles] Roles
  RIGHT JOIN [SuperShopWEB].[dbo].[AspNetUsers] ON Id = Roles.Id

[dbo].[__EFMigrationsHistory]
SELECT * FROM [SuperShopWEB].[dbo].[AspNetUsers]
SELECT * FROM [SuperShopWEB].[dbo].[AspNetRoles]
SELECT * FROM [SuperShopWEB].[dbo].[AspNetUserRoles]

