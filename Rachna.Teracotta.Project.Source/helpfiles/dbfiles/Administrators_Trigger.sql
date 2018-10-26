CREATE TRIGGER [dbo].[Administrators_Trigger]
       ON [dbo].[Administrators]
AFTER INSERT,UPDATE,DELETE
AS
BEGIN
       SET NOCOUNT ON; 
       
	   DECLARE @Admin_Id int
       DECLARE @Invitation_Id int
       DECLARE @Store_Id int
       DECLARE @AdminCode nvarchar(50)
       DECLARE @FullName nvarchar(100)
       DECLARE @EmailId nvarchar(300)
       DECLARE @Phone nvarchar(50)
       DECLARE @Description nvarchar(max)
       DECLARE @Photo nvarchar(50)
       DECLARE @Password nvarchar(50)
       DECLARE @Admin_Status nvarchar(50)
       DECLARE @Admin_Role nvarchar(50)
       DECLARE @Admin_CreatedDate datetime
       DECLARE @Admin_UpdatedDate datetime
       DECLARE @Admin_Login_Attempt int
	   DECLARE @user varchar(20)
	   DECLARE @activity varchar(20)

	   SELECT @Admin_Id = INSERTED.Admin_Id      
       FROM INSERTED
 
		if exists(SELECT * from inserted) and exists (SELECT * from deleted)
		begin
			SET @activity = 'UPDATE';
			SET @user = SYSTEM_USER;
			SELECT	 @Admin_Id = Admin_Id
					 ,@Invitation_Id = Invitation_Id 
					 ,@Store_Id = Store_Id
					 ,@AdminCode = AdminCode
					 ,@FullName = FullName
					 ,@EmailId = EmailId
					 ,@Phone = Phone
					 ,@Description = Description
					 ,@Photo = Photo
					 ,@Password = Password
					 ,@Admin_Status = Admin_Status
					 ,@Admin_Role = Admin_Role
					 ,@Admin_CreatedDate = Admin_CreatedDate
					 ,@Admin_UpdatedDate = Admin_UpdatedDate
					 ,@Admin_Login_Attempt = Admin_Login_Attempt
			FROM   inserted i;
			INSERT into Administrators_Audit
			(Admin_Id,Invitation_Id,Store_Id,AdminCode,FullName,EmailId,Phone,Description,Photo,Password,Admin_Status,Admin_Role,Admin_CreatedDate,Admin_UpdatedDate,Admin_Login_Attempt,Action,DataUser)
			values 
			(@Admin_Id,@Invitation_Id,@Store_Id,@AdminCode,@FullName,@EmailId,@Phone,@Description,@Photo,@Password,@Admin_Status,@Admin_Role,@Admin_CreatedDate,@Admin_UpdatedDate,@Admin_Login_Attempt,@activity,@user);
		end

		If exists (Select * from inserted) and not exists(Select * from deleted)
		begin
			SET @activity = 'INSERT';
			SET @user = SYSTEM_USER;
			SELECT	 @Admin_Id = Admin_Id
					 ,@Invitation_Id = Invitation_Id 
					 ,@Store_Id = Store_Id
					 ,@AdminCode = AdminCode
					 ,@FullName = FullName
					 ,@EmailId = EmailId
					 ,@Phone = Phone
					 ,@Description = Description
					 ,@Photo = Photo
					 ,@Password = Password
					 ,@Admin_Status = Admin_Status
					 ,@Admin_Role = Admin_Role
					 ,@Admin_CreatedDate = Admin_CreatedDate
					 ,@Admin_UpdatedDate = Admin_UpdatedDate
					 ,@Admin_Login_Attempt = Admin_Login_Attempt
			FROM   inserted i;
			INSERT into Administrators_Audit
			(Admin_Id,Invitation_Id,Store_Id,AdminCode,FullName,EmailId,Phone,Description,Photo,Password,Admin_Status,Admin_Role,Admin_CreatedDate,Admin_UpdatedDate,Admin_Login_Attempt,Action,DataUser)
			values 
			(@Admin_Id,@Invitation_Id,@Store_Id,@AdminCode,@FullName,@EmailId,@Phone,@Description,@Photo,@Password,@Admin_Status,@Admin_Role,@Admin_CreatedDate,@Admin_UpdatedDate,@Admin_Login_Attempt,@activity,@user);
		end

		If exists(select * from deleted) and not exists(Select * from inserted)
		begin 
			SET @activity = 'DELETE';
			SET @user = SYSTEM_USER;
			SELECT	 @Admin_Id = Admin_Id
					 ,@Invitation_Id = Invitation_Id 
					 ,@Store_Id = Store_Id
					 ,@AdminCode = AdminCode
					 ,@FullName = FullName
					 ,@EmailId = EmailId
					 ,@Phone = Phone
					 ,@Description = Description
					 ,@Photo = Photo
					 ,@Password = Password
					 ,@Admin_Status = Admin_Status
					 ,@Admin_Role = Admin_Role
					 ,@Admin_CreatedDate = Admin_CreatedDate
					 ,@Admin_UpdatedDate = Admin_UpdatedDate
					 ,@Admin_Login_Attempt = Admin_Login_Attempt
			FROM   inserted i;
			INSERT into Administrators_Audit
			(Admin_Id,Invitation_Id,Store_Id,AdminCode,FullName,EmailId,Phone,Description,Photo,Password,Admin_Status,Admin_Role,Admin_CreatedDate,Admin_UpdatedDate,Admin_Login_Attempt,Action,DataUser)
			values 
			(@Admin_Id,@Invitation_Id,@Store_Id,@AdminCode,@FullName,@EmailId,@Phone,@Description,@Photo,@Password,@Admin_Status,@Admin_Role,@Admin_CreatedDate,@Admin_UpdatedDate,@Admin_Login_Attempt,@activity,@user);
		end
END