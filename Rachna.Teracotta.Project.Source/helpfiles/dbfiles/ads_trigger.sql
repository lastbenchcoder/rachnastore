CREATE TRIGGER [dbo].[trigger_ads_audit] ON [dbo].[tbl_ads] FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_ads_audit(admin_id,ads_id,ads_code,type,banner_source,redirect_url,datecreated,dateupdated,mode)
SELECT
   I.admin_id,
   I.ads_id,
   I.ads_code,
   I.type,
   I.banner_source,
   I.redirect_url,
   I.datecreated,
   I.dateupdated,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.admin_id,
   D.ads_id,
   D.ads_code,
   D.type,
   D.banner_source,
   D.redirect_url,
   D.datecreated,
   D.dateupdated,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);
GO


