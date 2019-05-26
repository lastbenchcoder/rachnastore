CREATE TRIGGER [dbo].[trigger_customer_address_audit] ON [dbo].[tbl_customer_address] FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_customer_address_audit(customer_address_id,customer_id,customer_address_code,address_line1,address_line2,land_mark,
									city,state,country,zipcode,datecreated,dateupdated,status,mode)
SELECT
   I.customer_address_id,
   I.customer_id,
   I.customer_address_code,
   I.address_line1,
   I.address_line2,
   I.land_mark,
   I.city,
   I.state,
   I.country,
   I.zipcode,
   I.datecreated,
   I.dateupdated,
   I.status,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.customer_address_id,
   D.customer_id,
   D.customer_address_code,
   D.address_line1,
   D.address_line2,
   D.land_mark,
   D.city,
   D.state,
   D.country,
   D.zipcode,
   D.datecreated,
   D.dateupdated,
   D.status,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);
GO


