CREATE TRIGGER [dbo].[trigger_customer_request_audit] ON [dbo].[tbl_customer_request] FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_customer_request_audit(cus_req_id,fullname,emailid,subject,description,ipaddress,datecreated,dateupdated,mode)
SELECT
   I.cus_req_id,
   I.fullname,
   I.emailid,
   I.subject,
   I.description,
   I.ipaddress,
   I.datecreated,
   I.dateupdated,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.cus_req_id,
   D.fullname,
   D.emailid,
   D.subject,
   D.description,
   D.ipaddress,
   D.datecreated,
   D.dateupdated,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);
GO


