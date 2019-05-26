CREATE TRIGGER [dbo].[trigger_customer_audit] ON [dbo].[tbl_customer] FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_customer_audit(customer_id,customer_code,type,fullname,emailid,phone,description
							,photo,password,status,datecreated,dateupdated,login_attempt
							,is_mail_verified,mode)
SELECT
   I.customer_id,
   I.customer_code,
   I.type,
   I.fullname,
   I.emailid,
   I.phone,
   I.description,
   I.photo,
   I.password,
   I.status,
   I.datecreated,
   I.dateupdated,
   I.login_attempt,
   I.is_mail_verified,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.customer_id,
   D.customer_code,
   D.type,
   D.fullname,
   D.emailid,
   D.phone,
   D.description,
   D.photo,
   D.password,
   D.status,
   D.datecreated,
   D.dateupdated,
   D.login_attempt,
   D.is_mail_verified,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);
GO


