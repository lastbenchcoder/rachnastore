CREATE TRIGGER [dbo].[Store_Trigger]
       ON [dbo].[Stores]
AFTER INSERT,UPDATE,DELETE
AS
BEGIN
       SET NOCOUNT ON;
 
       DECLARE @Store_Id INT
	   DECLARE @StoreCode nvarchar(50)
	   DECLARE @Store_Name nvarchar(200)
	   DECLARE @Store_Url nvarchar(450)
	   DECLARE @Store_Logo nvarchar(450)
	   DECLARE @Store_CreatedDate datetime
	   DECLARE @Store_Status nvarchar(15)
	   DECLARE @user varchar(20)
	   DECLARE @activity varchar(20)
 
       SELECT @Store_Id = INSERTED.Store_Id      
       FROM INSERTED
 
		if exists(SELECT * from inserted) and exists (SELECT * from deleted)
		begin
			SET @activity = 'INSERT/UPDATE';
			SET @user = SYSTEM_USER;
			SELECT	@Store_Id = Store_Id,
					@StoreCode = StoreCode,
					@Store_Name = Store_Name,
					@Store_Url = Store_Url,
					@Store_Logo = Store_Logo,
					@Store_CreatedDate=Store_CreatedDate,
					@Store_Status=Store_Status

			FROM   inserted i;
			INSERT into Stores_Audit
			(Store_Id,StoreCode, Store_Name,Store_Url,Store_Logo,Store_CreatedDate,Store_UpdatedDate,Store_Status,Action,DataUser) 
			values 
			(@Store_Id,@StoreCode, @Store_Name,@Store_Url,@Store_Logo,@Store_CreatedDate,getdate(),@Store_Status,@activity,@user);
		end

		If exists (Select * from inserted) and not exists(Select * from deleted)
		begin
			SET @activity = 'INSERT';
			SET @user = SYSTEM_USER;
			SELECT	@Store_Id = Store_Id,
					@StoreCode = StoreCode,
					@Store_Name = Store_Name,
					@Store_Url = Store_Url,
					@Store_Logo = Store_Logo,
					@Store_CreatedDate=Store_CreatedDate,
					@Store_Status=Store_Status

			FROM   inserted i;
			INSERT into Stores_Audit
			(Store_Id,StoreCode, Store_Name,Store_Url,Store_Logo,Store_CreatedDate,Store_UpdatedDate,Store_Status,Action,DataUser) 
			values 
			(@Store_Id,@StoreCode, @Store_Name,@Store_Url,@Store_Logo,@Store_CreatedDate,getdate(),@Store_Status,@activity,@user);
		end

		If exists(select * from deleted) and not exists(Select * from inserted)
		begin 
			SET @activity = 'DELETE';
			SET @user = SYSTEM_USER;
			SELECT	@Store_Id = Store_Id,
					@StoreCode = StoreCode,
					@Store_Name = Store_Name,
					@Store_Url = Store_Url,
					@Store_Logo = Store_Logo,
					@Store_CreatedDate=Store_CreatedDate,
					@Store_Status=Store_Status

			FROM   deleted i;
			INSERT into Stores_Audit
			(Store_Id,StoreCode, Store_Name,Store_Url,Store_Logo,Store_CreatedDate,Store_UpdatedDate,Store_Status,Action,DataUser) 
			values 
			(@Store_Id,@StoreCode, @Store_Name,@Store_Url,@Store_Logo,@Store_CreatedDate,getdate(),@Store_Status,@activity,@user);
		end
END