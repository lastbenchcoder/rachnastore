CREATE TRIGGER trigger_admin_audit ON tbl_admin FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_admin_audit(invitation_id,store_id,role,
					   admin_id,admin_code,fullname,emailid,
					   phone,description,photo,password,
					   login_attempt,status,datecreated,dateupdated,mode)
SELECT
   I.invitation_id,
   I.store_id,
   I.role,
   I.admin_id,
   I.admin_code,
   I.fullname,
   I.emailid,
   I.phone,
   I.description,
   I.photo,
   I.password,
   I.login_attempt,
   I.status,
   I.datecreated,
   I.dateupdated,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.invitation_id,
   D.store_id,
   D.role,
   D.admin_id,
   D.admin_code,
   D.fullname,
   D.emailid,
   D.phone,
   D.description,
   D.photo,
   D.password,
   D.login_attempt,
   D.status,
   D.datecreated,
   D.dateupdated,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);