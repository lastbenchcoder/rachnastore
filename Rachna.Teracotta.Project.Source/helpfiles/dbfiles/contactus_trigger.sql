CREATE TRIGGER [dbo].[trigger_contactus_audit] ON [dbo].[tbl_contactus] FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_contactus_audit(contact_owner_id,contact_owner_code,title,description,address,city,state
						   ,zipcode,emailid,phone,fax,website,googlemapurl,admin_id,datecreated,dateupdated,
						   status,can_submit_query,mode)
SELECT
   I.contact_owner_id,
   I.contact_owner_code,
   I.title,
   I.description,
   I.address,
   I.city,
   I.state,
   I.zipcode,
   I.emailid,
   I.phone,
   I.fax,
   I.website,
   I.googlemapurl,
   I.admin_id,
   I.datecreated,
   I.dateupdated,
   I.status,
   I.can_submit_query,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.contact_owner_id,
   D.contact_owner_code,
   D.title,
   D.description,
   D.address,
   D.city,
   D.state,
   D.zipcode,
   D.emailid,
   D.phone,
   D.fax,
   D.website,
   D.googlemapurl,
   D.admin_id,
   D.datecreated,
   D.dateupdated,
   D.status,
   D.can_submit_query,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);
GO


