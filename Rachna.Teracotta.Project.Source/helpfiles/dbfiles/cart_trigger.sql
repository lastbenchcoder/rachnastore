CREATE TRIGGER trigger_cart_audit ON tbl_cart FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_cart_audit(Cart_Id,cart_code,Store_Id,Customer_Id,Customer_Name,customer_ip_address,Product_Id,Product_Title,Product_Price,
					  Product_Banner,cart_qty,Cart_Price,Shipping_Charge,Cart_Total_Price,Cart_Size,status,DateCreated,DateUpdated,mode)
SELECT
   I.Cart_Id,
   I.cart_code,
   I.Store_Id,
   I.Customer_Id,
   I.Customer_Name,
   I.customer_ip_address,
   I.Product_Id,
   I.Product_Title,
   I.Product_Price,
   I.Product_Banner,
   I.cart_qty,
   I.Cart_Price,
   I.Shipping_Charge,
   I.Cart_Total_Price,
   I.Cart_Size,
   I.status,
   I.datecreated,
   I.dateupdated,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.Cart_Id,
   D.cart_code,
   D.Store_Id,
   D.Customer_Id,
   D.Customer_Name,
   D.customer_ip_address,
   D.Product_Id,
   D.Product_Title,
   D.Product_Price,
   D.Product_Banner,
   D.cart_qty,
   D.Cart_Price,
   D.Shipping_Charge,
   D.Cart_Total_Price,
   D.Cart_Size,
   D.status,
   D.datecreated,
   D.dateupdated,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);