/****** Object:  Database [SuperShopMVC5_db]    Script Date: 22/05/2024 19:59:58 ******/

-- SuperShopMVC5_db (global-serverdb/SuperShopMVC5_db)
-- DROP DATABASE [SuperShopMVC5_db]
-- GO


SELECT TOP (1000) [Id]
      ,[Name]
      ,[Price]
      ,[LastPurchase]
      ,[LastSale]
      ,[IsAvailable]
      ,[Stock]
      ,[UserId]
      ,[ImageId]
  FROM [dbo].[Products]