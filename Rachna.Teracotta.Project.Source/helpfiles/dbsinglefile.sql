DECLARE @DBCompatibilityLevel INT
DECLARE @DBCompatibilityLevelMajor INT
DECLARE @DBCompatibilityLevelMinor INT

SELECT 
    @DBCompatibilityLevel = cmptlevel 
FROM 
    master.dbo.sysdatabases 
WHERE 
    name = DB_NAME()

IF @DBCompatibilityLevel <> 90
BEGIN

    SELECT @DBCompatibilityLevelMajor = @DBCompatibilityLevel / 10, 
           @DBCompatibilityLevelMinor = @DBCompatibilityLevel % 10
           
    PRINT N'
    ===========================================================================
    WARNING! 
    ---------------------------------------------------------------------------
    
    This script is designed for Microsoft SQL Server 2005 (9.0) but your 
    database is set up for compatibility with version ' 
    + CAST(@DBCompatibilityLevelMajor AS NVARCHAR(80)) 
    + N'.' 
    + CAST(@DBCompatibilityLevelMinor AS NVARCHAR(80)) 
    + N'. Although 
    the script should work with later versions of Microsoft SQL Server, 
    you can ensure compatibility by executing the following statement:
    
    ALTER DATABASE [' 
    + DB_NAME() 
    + N'] 
    SET COMPATIBILITY_LEVEL = 90

    If you are hosting ELMAH in the same database as your application 
    database and do not wish to change the compatibility option then you 
    should create a separate database to host ELMAH where you can set the 
    compatibility level more freely.
    
    If you continue with the current setup, please report any compatibility 
    issues you encounter over at:
    
    http://code.google.com/p/elmah/issues/list

    ===========================================================================
'
END
GO

/* ------------------------------------------------------------------------ 
        TABLES
   ------------------------------------------------------------------------ */

CREATE TABLE [dbo].[ELMAH_Error]
(
    [ErrorId]     UNIQUEIDENTIFIER NOT NULL,
    [Application] NVARCHAR(60)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Host]        NVARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Type]        NVARCHAR(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Source]      NVARCHAR(60)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Message]     NVARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [User]        NVARCHAR(50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [StatusCode]  INT NOT NULL,
    [TimeUtc]     DATETIME NOT NULL,
    [Sequence]    INT IDENTITY (1, 1) NOT NULL,
    [AllXml]      NVARCHAR(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) 
ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[ELMAH_Error] WITH NOCHECK ADD 
    CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED ([ErrorId]) ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ELMAH_Error] ADD 
    CONSTRAINT [DF_ELMAH_Error_ErrorId] DEFAULT (NEWID()) FOR [ErrorId]
GO

CREATE NONCLUSTERED INDEX [IX_ELMAH_Error_App_Time_Seq] ON [dbo].[ELMAH_Error] 
(
    [Application]   ASC,
    [TimeUtc]       DESC,
    [Sequence]      DESC
) 
ON [PRIMARY]
GO

/* ------------------------------------------------------------------------ 
        STORED PROCEDURES                                                      
   ------------------------------------------------------------------------ */

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorXml]
(
    @Application NVARCHAR(60),
    @ErrorId UNIQUEIDENTIFIER
)
AS

    SET NOCOUNT ON

    SELECT 
        [AllXml]
    FROM 
        [ELMAH_Error]
    WHERE
        [ErrorId] = @ErrorId
    AND
        [Application] = @Application

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(
    @Application NVARCHAR(60),
    @PageIndex INT = 0,
    @PageSize INT = 15,
    @TotalCount INT OUTPUT
)
AS 

    SET NOCOUNT ON

    DECLARE @FirstTimeUTC DATETIME
    DECLARE @FirstSequence INT
    DECLARE @StartRow INT
    DECLARE @StartRowIndex INT

    SELECT 
        @TotalCount = COUNT(1) 
    FROM 
        [ELMAH_Error]
    WHERE 
        [Application] = @Application

    -- Get the ID of the first error for the requested page

    SET @StartRowIndex = @PageIndex * @PageSize + 1

    IF @StartRowIndex <= @TotalCount
    BEGIN

        SET ROWCOUNT @StartRowIndex

        SELECT  
            @FirstTimeUTC = [TimeUtc],
            @FirstSequence = [Sequence]
        FROM 
            [ELMAH_Error]
        WHERE   
            [Application] = @Application
        ORDER BY 
            [TimeUtc] DESC, 
            [Sequence] DESC

    END
    ELSE
    BEGIN

        SET @PageSize = 0

    END

    -- Now set the row count to the requested page size and get
    -- all records below it for the pertaining application.

    SET ROWCOUNT @PageSize

    SELECT 
        errorId     = [ErrorId], 
        application = [Application],
        host        = [Host], 
        type        = [Type],
        source      = [Source],
        message     = [Message],
        [user]      = [User],
        statusCode  = [StatusCode], 
        time        = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
    FROM 
        [ELMAH_Error] error
    WHERE
        [Application] = @Application
    AND
        [TimeUtc] <= @FirstTimeUTC
    AND 
        [Sequence] <= @FirstSequence
    ORDER BY
        [TimeUtc] DESC, 
        [Sequence] DESC
    FOR
        XML AUTO

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[ELMAH_LogError]
(
    @ErrorId UNIQUEIDENTIFIER,
    @Application NVARCHAR(60),
    @Host NVARCHAR(30),
    @Type NVARCHAR(100),
    @Source NVARCHAR(60),
    @Message NVARCHAR(500),
    @User NVARCHAR(50),
    @AllXml NVARCHAR(MAX),
    @StatusCode INT,
    @TimeUtc DATETIME
)
AS

    SET NOCOUNT ON

    INSERT
    INTO
        [ELMAH_Error]
        (
            [ErrorId],
            [Application],
            [Host],
            [Type],
            [Source],
            [Message],
            [User],
            [AllXml],
            [StatusCode],
            [TimeUtc]
        )
    VALUES
        (
            @ErrorId,
            @Application,
            @Host,
            @Type,
            @Source,
            @Message,
            @User,
            @AllXml,
            @StatusCode,
            @TimeUtc
        )

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

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

CREATE TRIGGER trigger_cart_audit ON tbl_cart FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_cart_audit(Cart_Id,cart_code,Store_Id,Customer_Id,Customer_Name,customer_ip_address,Product_Id,Product_Title,Product_Price,
					  Product_Banner,cart_qty,Cart_Price,Shipping_Charge,Cart_Total_Price,Cart_Size,status,DateCreated,DateUpdated,mode)
SELECT
   I.Cart_Id,
   I.cart_code,
   I.Store_Id,
   I.Customer_Id,
   I.Customer_Name,
   I.customer_ip_address,
   I.Product_Id,
   I.Product_Title,
   I.Product_Price,
   I.Product_Banner,
   I.cart_qty,
   I.Cart_Price,
   I.Shipping_Charge,
   I.Cart_Total_Price,
   I.Cart_Size,
   I.status,
   I.datecreated,
   I.dateupdated,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.Cart_Id,
   D.cart_code,
   D.Store_Id,
   D.Customer_Id,
   D.Customer_Name,
   D.customer_ip_address,
   D.Product_Id,
   D.Product_Title,
   D.Product_Price,
   D.Product_Banner,
   D.cart_qty,
   D.Cart_Price,
   D.Shipping_Charge,
   D.Cart_Total_Price,
   D.Cart_Size,
   D.status,
   D.datecreated,
   D.dateupdated,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);

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


CREATE TRIGGER [dbo].[trigger_customer_address_audit] ON [dbo].[tbl_customer_address] FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_customer_address_audit(customer_address_id,customer_id,customer_address_code,address_line1,address_line2,land_mark,
									city,state,country,zipcode,datecreated,dateupdated,status,mode)
SELECT
   I.customer_address_id,
   I.customer_id,
   I.customer_address_code,
   I.address_line1,
   I.address_line2,
   I.land_mark,
   I.city,
   I.state,
   I.country,
   I.zipcode,
   I.datecreated,
   I.dateupdated,
   I.status,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.customer_address_id,
   D.customer_id,
   D.customer_address_code,
   D.address_line1,
   D.address_line2,
   D.land_mark,
   D.city,
   D.state,
   D.country,
   D.zipcode,
   D.datecreated,
   D.dateupdated,
   D.status,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);
GO


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


CREATE TRIGGER [dbo].[trigger_customer_audit] ON [dbo].[tbl_customer] FOR INSERT, UPDATE, DELETE
AS
SET NOCOUNT ON;
INSERT tbl_customer_audit(customer_id,customer_code,type,fullname,emailid,phone,description
							,photo,password,status,datecreated,dateupdated,login_attempt
							,is_mail_verified,mode)
SELECT
   I.customer_id,
   I.customer_code,
   I.type,
   I.fullname,
   I.emailid,
   I.phone,
   I.description,
   I.photo,
   I.password,
   I.status,
   I.datecreated,
   I.dateupdated,
   I.login_attempt,
   I.is_mail_verified,
   CASE WHEN EXISTS (SELECT * FROM Deleted) THEN 'UPDATED' ELSE 'INSERTED' END
FROM
   Inserted I
UNION ALL
SELECT
   D.customer_id,
   D.customer_code,
   D.type,
   D.fullname,
   D.emailid,
   D.phone,
   D.description,
   D.photo,
   D.password,
   D.status,
   D.datecreated,
   D.dateupdated,
   D.login_attempt,
   D.is_mail_verified,
   'DELETED'
FROM Deleted D
WHERE NOT EXISTS (
   SELECT * FROM Inserted
);
GO
