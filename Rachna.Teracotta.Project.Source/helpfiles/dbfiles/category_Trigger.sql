ALTER TRIGGER [dbo].[trigger_category_audit] ON [dbo].[tbl_category] FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_category_audit(category_id,category_code,title,banner,admin_id,datecreated,dateupdated,status,mode)
SELECT
   I.category_id,
   I.category_code,
   I.title,
   I.banner,
   I.admin_id,
   I.datecreated,
   I.dateupdated,
   I.status,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.category_id,
   D.category_code,
   D.title,
   D.banner,
   D.admin_id,
   D.datecreated,
   D.dateupdated,
   D.status,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);
GO


