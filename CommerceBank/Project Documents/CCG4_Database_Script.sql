USE [CCG4]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/2/2019 9:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[ClientID] [int] NOT NULL,
	[AccountID] [int] NOT NULL,
	[Balance] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alerts]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alerts](
	[AlertsID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[AlertName] [nvarchar](1000) NOT NULL,
	[TransactionType] [nvarchar](3) NULL,
	[State] [char](2) NULL,
	[Dispute] [bit] NULL,
	[TransactionDetails] [nvarchar](2000) NULL,
	[GreaterThanAmount] [decimal](18, 0) NULL,
	[LessThanAmount] [decimal](18, 0) NULL,
	[EqualAmount] [decimal](18, 0) NULL,
	[AfterThisDate] [date] NULL,
	[BeforeThisDate] [date] NULL,
	[ExactDate] [date] NULL,
	[AlertLogic] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AlertsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[AlertName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[HomeState] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientsLogin]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientsLogin](
	[UserName] [nvarchar](255) NOT NULL,
	[PasswordHash] [binary](64) NOT NULL,
	[ClientID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FiltersAndIDS]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiltersAndIDS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AlertFilter] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[TransactionDetails] [nvarchar](2000) NULL,
	[TransactionAmount] [decimal](18, 0) NOT NULL,
	[TransactionType] [nvarchar](3) NOT NULL,
	[State] [char](2) NOT NULL,
	[Dispute] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] NOT NULL,
	[FirstName] [nchar](50) NULL,
	[LastName] [nchar](50) NULL,
	[UserRights] [nchar](4) NULL,
	[UserName] [nchar](10) NULL,
	[UserPass] [nchar](20) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Alerts]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
ALTER TABLE [dbo].[ClientsLogin]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
/****** Object:  StoredProcedure [dbo].[spDELETE_Account_Alert_NamesAndID]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDELETE_Account_Alert_NamesAndID]
@AccountID nvarchar(250),
@ID INT
AS
BEGIN
	DELETE FROM [dbo].[Alerts] WHERE [AlertsID] = @ID
	SELECT [AlertsID],[AlertName] 
	FROM [dbo].[Alerts]
	WHERE AccountID = @AccountID
END
GO
/****** Object:  StoredProcedure [dbo].[spGET_Account_Alert_NamesAndID]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGET_Account_Alert_NamesAndID]
@AccountID nvarchar(250)
AS
BEGIN
	SELECT [AlertsID],[AlertName] 
	FROM [dbo].[Alerts]
	WHERE AccountID = @AccountID
END
GO
/****** Object:  StoredProcedure [dbo].[spGET_AlertFilters]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGET_AlertFilters]
AS
BEGIN
	SELECT * FROM [dbo].[FiltersAndIDS]
END
GO
/****** Object:  StoredProcedure [dbo].[spGet_AlertTransactions]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGet_AlertTransactions]
@ID int
AS 
BEGIN
	DECLARE @SQL NVARCHAR(MAX) = (SELECT AlertLogic FROM [dbo].[Alerts]
	WHERE AlertsID = @ID)
	EXEC sp_executesql @SQL
END;
GO
/****** Object:  StoredProcedure [dbo].[spGet_AlertTransactions_ForExporting]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGet_AlertTransactions_ForExporting]
@ID int
AS 
BEGIN
	DECLARE @SQL NVARCHAR(MAX) = (SELECT AlertLogic FROM [dbo].[Alerts]
	WHERE AlertsID = @ID)
	DECLARE @TempAlertTable TABLE(
									TransactionID INT NOT NULL,
									[Date] date NOT NULL,
									[TransactionDetails] NVARCHAR(2000) NULL, 
									[TransactionAmount] decimal(18,0) NOT NULL,
									[TransactionType] NVARCHAR(3) NOT NULL,
									[State] CHAR(2) NOT NULL,
									Dispute BIT NULL)
	INSERT INTO @TempAlertTable EXEC sp_executesql @SQL

	SELECT   [TransactionDetails] AS [Transaction Details]
			,[TransactionAmount] AS [Transaction Amount]
			,[TransactionType] AS [Transaction Type]
			,[State] AS [State]
			,[Dispute] AS [Disputing?]
	FROM @TempAlertTable
END;
GO
/****** Object:  StoredProcedure [dbo].[spGET_ALL_TransactionTable_Data_BasedOnAccountID]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGET_ALL_TransactionTable_Data_BasedOnAccountID]
@AccountID INT
AS
BEGIN
	SELECT * FROM [dbo].[Transactions]
	WHERE [AccountID] = @AccountID
END
GO
/****** Object:  StoredProcedure [dbo].[spGET_Count_Number_Of_Triggered_Alerts]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGET_Count_Number_Of_Triggered_Alerts]
@AccountID INT 
AS
BEGIN
	-- Will hold the number of alerts that an account has setup
	DECLARE @NumberOfAlerts INT
	-- Will Hold the number of transactions that triggered an alert
	DECLARE @NumberOfTransactionsThatTriggeredAnAlert INT = 0
	-- Will be our counter in the while loop 
	DECLARE @Counter INT = 0
	-- Will hold the data form the alerts table temporarly
	DECLARE @HoldAlertsDataTempTable table (
											RowNumber INT NOT NULL,
											[AccountID] INT NOT NULL,
											[AlertLogic] NVARCHAR(MAX) NOT NULL)

----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------

	-- Count the number of alerts and set it to @NumberOfAlerts
	SET @NumberOfAlerts = (SELECT COUNT(AlertsID) FROM [dbo].[Alerts])


	-- Get all the alerts from a single account
	INSERT INTO @HoldAlertsDataTempTable 
	SELECT ROW_NUMBER() OVER (ORDER BY AlertsID) AS RowNumber
					,[AccountID]
					,[AlertLogic]
	FROM [dbo].[Alerts] WHERE [AccountID] = @AccountID

	-- This variable is the main form of data retrieval
	DECLARE @SQL NVARCHAR(MAX)
	-- This While loop will be used to retrieve a lot of data
	WHILE(@Counter <= @NumberOfAlerts)
		BEGIN
		SET @SQL = (SELECT [AlertLogic] FROM @HoldAlertsDataTempTable WHERE RowNumber = @Counter)
		SET @SQL = N'SET @NumberOfTransactionsThatTriggeredAnAlert = @NumberOfTransactionsThatTriggeredAnAlert + (SELECT COUNT(*) FROM (' +@SQL+'))'
		EXEC sp_executesql @SQL, N'DECLARE @NumberOfTransactionsThatTriggeredAnAlert INT out', @NumberOfTransactionsThatTriggeredAnAlert out;
			SET @Counter = @Counter +1
		END
END
GO
/****** Object:  StoredProcedure [dbo].[spGet_TransactionData]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGet_TransactionData]
@ID int
AS 
BEGIN
	SELECT AMOUNT FROM [dbo].[TRANSACTIONS]
	WHERE ID = @ID
END;
GO
/****** Object:  StoredProcedure [dbo].[spInsert_Alert]    Script Date: 12/2/2019 9:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsert_Alert]
@AccountID nvarchar(250),
@AlertName nvarchar(250),
@TransactionType nvarchar(3) =  NULL,
@State char(2) = NULL,
@Dispute char(1) = NULL,
@TransactionDetails nvarchar(2000) = NULL,
@GreaterThanAmount nvarchar(250) = NULL,
@LessThanAmount nvarchar(250) = NULL,
@EqualAmount nvarchar(250) = NULL,
@AfterThisDate nvarchar(200) = NULL,
@BeforeThisDate nvarchar(200) = NULL,
@ExactDate nvarchar(200) = NULL
AS
BEGIN
DECLARE @SQL NVARCHAR(MAX)
SET @SQL = N'
			SELECT [TransactionID]
			,[Date]
			,[TransactionDetails]
			,[TransactionAmount]
			,[TransactionType]
			,[State]
			,[Dispute]
			FROM [dbo].[Transactions]
			WHERE [AccountID] = '+@AccountID+''

IF @TransactionType IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [TransactionType] = '''+@TransactionType+''''
	END
IF @State IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [State] = '''+@State+''''
	END
IF @Dispute IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [Dispute] = '+@Dispute+''
	END
IF @TransactionDetails IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [TransactionDetails] = '''+@TransactionDetails+''''
	END
IF @GreaterThanAmount IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [TransactionAmount] >= '+@GreaterThanAmount+''
	END
IF @LessThanAmount IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [TransactionAmount] <= '+@LessThanAmount+''
	END
IF @EqualAmount IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [TransactionAmount] = '+@EqualAmount+''
	END
IF @AfterThisDate IS NOT NULL AND @BeforeThisDate IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [Date] BETWEEN '''+@AfterThisDate+''' AND '''+@BeforeThisDate+''''
	END
IF @ExactDate IS NOT NULL
	BEGIN
		SET @SQL = @SQL + N' AND [Date] = '''+@ExactDate+''''
	END
INSERT INTO [dbo].[Alerts]
	([AlertName]
	,[AlertLogic]
	,[AccountID]
	,[TransactionType]
	,[State]
	,[Dispute]
	,[TransactionDetails]
	,[GreaterThanAmount]
	,[LessThanAmount]
	,[EqualAmount]
	,[AfterThisDate]
	,[BeforeThisDate]
	,[ExactDate]
	) 
	VALUES
	(@AlertName
	,@SQL
	,@AccountID
	,@TransactionType
	,@State
	,@Dispute
	,@TransactionDetails
	,@GreaterThanAmount
	,@LessThanAmount
	,@EqualAmount
	,@AfterThisDate
	,@BeforeThisDate
	,@ExactDate
	)
END
GO
