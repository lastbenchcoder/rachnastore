CREATE TRIGGER [dbo].[Category_Trigger]
       ON [dbo].[Categories]
AFTER INSERT,UPDATE,DELETE
AS
BEGIN
       SET NOCOUNT ON;
 
       DECLARE @Category_Id INT
	   DECLARE @CategoryCode nvarchar(50)
	   DECLARE @Category_Title nvarchar(200)
	   DECLARE @Administrators_Id Int
	   DECLARE @Category_CreatedDate datetime
	   DECLARE @Category_UpdatedDate datetime
	   DECLARE @Category_Status nvarchar(15)
	   DECLARE @user varchar(20)
	   DECLARE @activity varchar(20)
 
       SELECT @Category_Id = INSERTED.Category_Id      
       FROM INSERTED
 
		if exists(SELECT * from inserted) and exists (SELECT * from deleted)
		begin
			SET @activity = 'INSERT/UPDATE';
			SET @user = SYSTEM_USER;
			SELECT	@Category_Id = Category_Id,
					@CategoryCode = CategoryCode,
					@Category_Title = Category_Title,
					@Administrators_Id = Administrators_Id,
					@Category_CreatedDate=Category_CreatedDate,
					@Category_UpdatedDate=GETDATE(),
					@Category_Status=Category_Status

			FROM   inserted i;
			INSERT into Categories_Audit
			(Category_Id,CategoryCode, Category_Title,Administrators_Id,Category_CreatedDate,Category_UpdatedDate,Category_Status,Action) 
			values 
			(@Category_Id,@CategoryCode, @Category_Title,@Administrators_Id,@Category_CreatedDate,getdate(),@Category_Status,@activity);
		end

		If exists (Select * from inserted) and not exists(Select * from deleted)
		begin
			SET @activity = 'INSERT';
			SET @user = SYSTEM_USER;
			SELECT	@Category_Id = Category_Id,
					@CategoryCode = CategoryCode,
					@Category_Title = Category_Title,
					@Administrators_Id = Administrators_Id,
					@Category_CreatedDate=Category_CreatedDate,
					@Category_UpdatedDate=GETDATE(),
					@Category_Status=Category_Status

			FROM   inserted i;
			INSERT into Categories_Audit
			(Category_Id,CategoryCode, Category_Title,Administrators_Id,Category_CreatedDate,Category_UpdatedDate,Category_Status,Action) 
			values 
			(@Category_Id,@CategoryCode, @Category_Title,@Administrators_Id,@Category_CreatedDate,getdate(),@Category_Status,@activity);
		end

		If exists(select * from deleted) and not exists(Select * from inserted)
		begin 
			SET @activity = 'DELETE';
			SET @user = SYSTEM_USER;
			SELECT	@Category_Id = Category_Id,
					@CategoryCode = CategoryCode,
					@Category_Title = Category_Title,
					@Administrators_Id = Administrators_Id,
					@Category_CreatedDate=Category_CreatedDate,
					@Category_UpdatedDate=GETDATE(),
					@Category_Status=Category_Status

			FROM   inserted i;
			INSERT into Categories_Audit
			(Category_Id,CategoryCode, Category_Title,Administrators_Id,Category_CreatedDate,Category_UpdatedDate,Category_Status,Action) 
			values 
			(@Category_Id,@CategoryCode, @Category_Title,@Administrators_Id,@Category_CreatedDate,getdate(),@Category_Status,@activity);
		end
END