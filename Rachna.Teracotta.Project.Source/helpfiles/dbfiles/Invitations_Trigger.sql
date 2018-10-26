CREATE TRIGGER [dbo].[Invitation_Trigger]
       ON [dbo].[Invitations]
AFTER INSERT,UPDATE,DELETE
AS
BEGIN
       SET NOCOUNT ON;
 
       DECLARE @Invitation_Id INT
	   DECLARE @Role nvarchar(15)
	   DECLARE @Store_Id int
	   DECLARE @Invitation_Code nvarchar(50)
	   DECLARE @Invitation_EmailId nvarchar(300)
	   DECLARE @Invitation_Status nvarchar(15)
	   DECLARE @Invitation_CreatedDate datetime
	   DECLARE @Invitation_UpdatedDate datetime
	   DECLARE @user varchar(20)
	   DECLARE @activity varchar(20)
 
       SELECT @Invitation_Id = INSERTED.Invitation_Id      
       FROM INSERTED
 
		if exists(SELECT * from inserted) and exists (SELECT * from deleted)
		begin
			SET @activity = 'UPDATE';
			SET @user = SYSTEM_USER;
			SELECT	@Invitation_Id = Invitation_Id,
					@Role = Role,
					@Store_Id = Store_Id,
					@Invitation_Code = Invitation_Code,
					@Invitation_EmailId = Invitation_EmailId,
					@Invitation_Status=Invitation_Status,
					@Invitation_CreatedDate=Invitation_CreatedDate,
					@Invitation_UpdatedDate=Invitation_UpdatedDate
					

			FROM   inserted i;
			INSERT into Invitations_Audit
			(Invitation_Id, Role, Store_Id, Invitation_Code, Invitation_EmailId, Invitation_Status, Invitation_CreatedDate, Invitation_UpdatedDate, Action, DataUser) 
			values 
			(@Invitation_Id, @Role, @Store_Id, @Invitation_Code, @Invitation_EmailId, @Invitation_Status, @Invitation_CreatedDate, @Invitation_UpdatedDate, @activity, @user);
		end

		If exists (Select * from inserted) and not exists(Select * from deleted)
		begin
			SET @activity = 'INSERT';
			SET @user = SYSTEM_USER;
			SELECT	@Invitation_Id = Invitation_Id,
					@Role = Role,
					@Store_Id = Store_Id,
					@Invitation_Code = Invitation_Code,
					@Invitation_EmailId = Invitation_EmailId,
					@Invitation_Status=Invitation_Status,
					@Invitation_CreatedDate=Invitation_CreatedDate,
					@Invitation_UpdatedDate=Invitation_UpdatedDate

			FROM   inserted i;
			INSERT into Invitations_Audit
			(Invitation_Id, Role, Store_Id, Invitation_Code, Invitation_EmailId, Invitation_Status, Invitation_CreatedDate, Invitation_UpdatedDate, Action, DataUser) 
			values 
			(@Invitation_Id, @Role, @Store_Id, @Invitation_Code, @Invitation_EmailId, @Invitation_Status, @Invitation_CreatedDate, @Invitation_UpdatedDate, @activity, @user);
		end

		If exists(select * from deleted) and not exists(Select * from inserted)
		begin 
			SET @activity = 'DELETE';
			SET @user = SYSTEM_USER;
			SELECT	@Invitation_Id = Invitation_Id,
					@Role = Role,
					@Store_Id = Store_Id,
					@Invitation_Code = Invitation_Code,
					@Invitation_EmailId = Invitation_EmailId,
					@Invitation_Status=Invitation_Status,
					@Invitation_CreatedDate=Invitation_CreatedDate,
					@Invitation_UpdatedDate=Invitation_UpdatedDate

			FROM   deleted i;
			INSERT into Invitations_Audit
			(Invitation_Id, Role, Store_Id, Invitation_Code, Invitation_EmailId, Invitation_Status, Invitation_CreatedDate, Invitation_UpdatedDate, Action, DataUser) 
			values 
			(@Invitation_Id, @Role, @Store_Id, @Invitation_Code, @Invitation_EmailId, @Invitation_Status, @Invitation_CreatedDate, @Invitation_UpdatedDate, @activity, @user);
		end
END