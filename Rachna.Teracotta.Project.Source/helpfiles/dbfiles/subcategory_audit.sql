CREATE TRIGGER [dbo].[SubCategory_Trigger]
       ON [dbo].[SubCategories]
AFTER INSERT,UPDATE,DELETE
AS
BEGIN
       SET NOCOUNT ON;
 
       DECLARE @SubCategory_Id INT
	   DECLARE @Category_Id INT
	   DECLARE @SubCategoryCode nvarchar(50)
	   DECLARE @SubCategory_Title nvarchar(200)
	   DECLARE @Administrators_Id Int
	   DECLARE @SubCategory_CreatedDate datetime
	   DECLARE @SubCategory_UpdatedDate datetime
	   DECLARE @SubCategory_Status nvarchar(15)
	   DECLARE @user varchar(20)
	   DECLARE @activity varchar(20)
 
       SELECT @SubCategory_Id = INSERTED.SubCategory_Id      
       FROM INSERTED
 
		if exists(SELECT * from inserted) and exists (SELECT * from deleted)
		begin
			SET @activity = 'INSERT/UPDATE';
			SET @user = SYSTEM_USER;
			SELECT	@SubCategory_Id = SubCategory_Id,
					@Category_Id = Category_Id,
					@SubCategoryCode = SubCategoryCode,
					@SubCategory_Title = SubCategory_Title,
					@Administrators_Id = Administrators_Id,
					@SubCategory_CreatedDate=SubCategory_CreatedDate,
					@SubCategory_UpdatedDate=GETDATE(),
					@SubCategory_Status=SubCategory_Status

			FROM   inserted i;
			INSERT into SubCategories_Audit
			(SubCategory_Id,Category_Id,SubCategoryCode, SubCategory_Title,Administrators_Id,SubCategory_CreatedDate,SubCategory_UpdatedDate,SubCategory_Status,Action) 
			values 
			(@SubCategory_Id,@Category_Id,@SubCategoryCode, @SubCategory_Title,@Administrators_Id,@SubCategory_CreatedDate,getdate(),@SubCategory_Status,@activity);
		end

		If exists (Select * from inserted) and not exists(Select * from deleted)
		begin
			SET @activity = 'INSERT';
			SET @user = SYSTEM_USER;
			SELECT	@SubCategory_Id = SubCategory_Id,
					@Category_Id = Category_Id,
					@SubCategoryCode = SubCategoryCode,
					@SubCategory_Title = SubCategory_Title,
					@Administrators_Id = Administrators_Id,
					@SubCategory_CreatedDate=SubCategory_CreatedDate,
					@SubCategory_UpdatedDate=GETDATE(),
					@SubCategory_Status=SubCategory_Status

			FROM   inserted i;
			INSERT into SubCategories_Audit
			(SubCategory_Id,Category_Id,SubCategoryCode, SubCategory_Title,Administrators_Id,SubCategory_CreatedDate,SubCategory_UpdatedDate,SubCategory_Status,Action) 
			values 
			(@SubCategory_Id,@Category_Id,@SubCategoryCode, @SubCategory_Title,@Administrators_Id,@SubCategory_CreatedDate,getdate(),@SubCategory_Status,@activity);
		end

		If exists(select * from deleted) and not exists(Select * from inserted)
		begin 
			SET @activity = 'DELETE';
			SET @user = SYSTEM_USER;
			SELECT	@SubCategory_Id = SubCategory_Id,
					@Category_Id = Category_Id,
					@SubCategoryCode = SubCategoryCode,
					@SubCategory_Title = SubCategory_Title,
					@Administrators_Id = Administrators_Id,
					@SubCategory_CreatedDate=SubCategory_CreatedDate,
					@SubCategory_UpdatedDate=GETDATE(),
					@SubCategory_Status=SubCategory_Status

			FROM   inserted i;
			INSERT into SubCategories_Audit
			(SubCategory_Id,Category_Id,SubCategoryCode, SubCategory_Title,Administrators_Id,SubCategory_CreatedDate,SubCategory_UpdatedDate,SubCategory_Status,Action) 
			values 
			(@SubCategory_Id,@Category_Id,@SubCategoryCode, @SubCategory_Title,@Administrators_Id,@SubCategory_CreatedDate,getdate(),@SubCategory_Status,@activity);
		end
END