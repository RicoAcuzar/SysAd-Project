/*

Table Definition

*/
DROP TABLE ApplicationLog;
DROP TABLE StateChanges;
DROP TABLE Schedules;
DROP TABLE Appliances;
DROP TABLE Accounts;
DROP PROCEDURE Schedules_EditSchedule;
DROP PROCEDURE Schedules_AddSchedule;
DROP PROCEDURE Logs_Log;
DROP PROCEDURE Proc_StateChanges;
DROP PROCEDURE Appliances_EditAppliance;
DROP PROCEDURE Appliances_AddAppliance;
DROP PROCEDURE Accounts_Login;
DROP PROCEDURE Accounts_GetSalt;
DROP PROCEDURE Accounts_ChangePassword;
DROP PROCEDURE Accounts_Register;
DROP PROCEDURE General_Error;

CREATE TABLE Accounts
(
AccountID INT PRIMARY KEY IDENTITY(0,1),
Username CHAR(16) UNIQUE NOT NULL,
[Password] CHAR(96) NOT NULL, /* base-64 encoding: 88(data) + 8(salt) */
Salt CHAR(8) NOT NULL,
AccountType CHAR(6) NOT NULL, /* DEVICE, ROOT, ADMIN, NORMAL */
Active BIT NOT NULL
);

CREATE TABLE Appliances
(
ApplianceID INT PRIMARY KEY IDENTITY(0,1),
Name CHAR(16) NOT NULL,
ApplianceType CHAR(16) NOT NULL,
Wattage REAL NOT NULL,
PinID TINYINT NOT NULL,
IsDigital BIT NOT NULL,
Active BIT NOT NULL, /* root visibility */
Restricted BIT NOT NULL, /* admin visibility */
AddedBy INT FOREIGN KEY REFERENCES Accounts(AccountID)
);

CREATE TABLE Schedules
(
ScheduleID INT PRIMARY KEY IDENTITY(0,1),
ApplianceID INT FOREIGN KEY REFERENCES Appliances(ApplianceID) NOT NULL,
SetValue SMALLINT NOT NULL,
ScheduleType CHAR(16) NOT NULL, /* OneTime, Repitition, Periodic, RepitionPeriodic */
Repitition CHAR(7) NOT NULL, /* ONCE, DAILY, WEEKLY, MONTHLY, YEARLY */
LowerLimit DATETIME NOT NULL,
UpperLimit DATETIME
);

CREATE TABLE StateChanges
(
AccountID INT FOREIGN KEY REFERENCES Accounts(AccountID),
ApplianceID INT FOREIGN KEY REFERENCES Appliances(ApplianceID) NOT NULL,
Value SMALLINT NOT NULL,
DateAndTime DATETIME NOT NULL
);

CREATE TABLE ApplicationLog
(
AccountID INT FOREIGN KEY REFERENCES Accounts(AccountID) NOT NULL,
Importance CHAR(8) NOT NULL, /* LOW, NORMAL, HIGH, CRITICAL */
[Message] VARCHAR(100) NOT NULL
);


/*

Stored Procedures

*/
/* General_Error */
CREATE PROCEDURE General_Error @ErrorNumber INT = NULL, @ErrorSeverity INT = NULL, @ErrorState INT = NULL, @ErrorProcedure NVARCHAR(128) = NULL, @ErrorLine INT = NULL, @ErrorMessage NVARCHAR(4000) = NULL
AS
BEGIN
SELECT 
	COALESCE(@ErrorNumber, ERROR_NUMBER()) AS ErrorNumber,
	COALESCE(@ErrorSeverity, ERROR_SEVERITY()) AS ErrorSeverity,
	COALESCE(@ErrorState, ERROR_STATE()) AS ErrorState,
	COALESCE(@ErrorProcedure, ERROR_PROCEDURE()) AS ErrorProcedure,
	COALESCE(@ErrorLine, ERROR_LINE()) AS ErrorLine,
	COALESCE(@ErrorMessage, ERROR_MESSAGE()) AS ErrorMessage;
END
RETURN

/* Accounts_Register */
CREATE PROCEDURE Accounts_Register @Username CHAR(16), @Password CHAR(96), @Salt CHAR(8), @AccountType CHAR(6), @Active BIT
AS
BEGIN
	BEGIN TRY
		INSERT INTO Accounts(Username, [Password], Salt, AccountType, Active) VALUES(@Username, @Password, @Salt, @AccountType, @Active);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Accounts_ChangePassword */
CREATE PROCEDURE Accounts_ChangePassword @Username CHAR(16), @Password CHAR(96), @Salt CHAR(8)
AS
BEGIN
	BEGIN TRY
		UPDATE Accounts SET [Password]=@Password,Salt=@Salt WHERE Username=@Username;
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Accounts_GetSalt */
CREATE PROCEDURE Accounts_GetSalt @Username CHAR(16), @Salt CHAR(8) OUTPUT
AS
BEGIN
	BEGIN TRY
		SELECT @Salt=RTRIM(Salt) FROM Accounts WHERE Username=@Username;
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Accounts_Login */
CREATE PROCEDURE Accounts_Login @Username CHAR(16), @Password CHAR(96)
AS
BEGIN
	BEGIN TRY
		SELECT * FROM Accounts WHERE Username=@Username AND [Password]=@Password;
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END	
RETURN

/* Appliances_AddAppliance */
CREATE PROCEDURE Appliances_AddAppliance @Name CHAR(16), @ApplianceType CHAR(16), @Wattage REAL, @PinID TINYINT, @IsDigital BIT, @Active BIT, @Restricted BIT, @AddedBy INT
AS
BEGIN
	BEGIN TRY
		DECLARE @ResultCount INT;
		SELECT @ResultCount=COUNT(*) FROM Appliances WHERE IsDigital=@IsDigital AND PinID=@PinID;
		IF @ResultCount>0
			EXECUTE General_Error @ErrorNumber=1, @ErrorSeverity=1, @ErrorState=1, @ErrorProcedure='Appliances_AddAppliance', @ErrorLine=1, @ErrorMessage='The digital or analog pin overlap detected.';
		ELSE
			BEGIN
				INSERT INTO Appliances(Name, ApplianceType, Wattage, PinID, IsDigital, Active, Restricted, AddedBy) VALUES (@Name, @ApplianceType, @Wattage, @PinID, @IsDigital, @Active, @Restricted, @AddedBy);
			END
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Appliances_EditAppliance */
CREATE PROCEDURE Appliances_EditAppliance @ApplianceID INT, @Name CHAR(16) = NULL, @ApplianceType CHAR(16) = NULL, @Wattage REAL = NULL, @PinID TINYINT = NULL, @IsDigital BIT = NULL, @Active BIT = NULL, @Restricted BIT = NULL, @AddedBy INT = NULL
AS
BEGIN
	BEGIN TRY
		UPDATE Appliances SET
		Name=COALESCE(@Name, Name),
		ApplianceType=COALESCE(@ApplianceType, ApplianceType),
		Wattage=COALESCE(@Wattage, Wattage),
		PinID=COALESCE(@PinID, PinID),
		IsDigital=COALESCE(@IsDigital, IsDigital),
		Active=COALESCE(@Active, Active),
		Restricted=COALESCE(@Restricted, Restricted),
		AddedBy=COALESCE(@AddedBy, AddedBy)
		WHERE ApplianceID=@ApplianceID;
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Proc_StateChanges */
CREATE PROCEDURE States_ChangeState @AccountID INT, @ApplianceID INT, @Value SMALLINT, @DateAndTime DATETIME = NULL
AS
BEGIN
	BEGIN TRY
		SET @DateAndTime = COALESCE(@DateAndTime, GETDATE());
		INSERT INTO StateChanges(AccountID, ApplianceID, Value, DateAndTime) VALUES(@AccountID, @ApplianceID, @Value, @DateAndTime);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Logs_Log */
CREATE PROCEDURE Logs_Log @AccountID INT = NULL, @Importance CHAR(8), @Message VARCHAR(100)
AS
BEGIN
	BEGIN TRY
		INSERT INTO ApplicationLog(AccountID, Importance, [Message]) VALUES(@AccountID, @Importance, @Message);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Schedules_AddSchedule */
CREATE PROCEDURE Schedules_AddSchedule @ApplianceID INT, @SetValue BIT, @ScheduleType CHAR(16), @Repitition CHAR(7), @LowerLimit DATETIME, @UpperLimit DATETIME = NULL
AS
BEGIN
	BEGIN TRY
		INSERT INTO Schedules(ApplianceID, SetValue, ScheduleType, Repitition, LowerLimit, UpperLimit) VALUES(@ApplianceID, @SetValue, @ScheduleType, @Repitition, @LowerLimit, @UpperLimit);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Schedules_EditSchedule */
CREATE PROCEDURE Schedules_EditSchedule @ScheduleID INT, @ApplianceID INT = NULL, @SetValue BIT = NULL, @ScheduleType CHAR(16) = NULL, @Repitition CHAR(7) = NULL, @LowerLimit DATETIME = NULL, @UpperLimit DATETIME = NULL
AS
BEGIN
	BEGIN TRY
		UPDATE Schedules SET
		ApplianceID=COALESCE(@ApplianceID, ApplianceID),
		SetValue=COALESCE(@SetValue, ApplianceID),
		ScheduleType=COALESCE(@ScheduleType, ApplianceID),
		Repitition=COALESCE(@Repitition, ApplianceID),
		LowerLimit=COALESCE(@LowerLimit, ApplianceID),
		UpperLimit=@UpperLimit
		WHERE ScheduleID=@ScheduleID;
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Select_Accounts */
CREATE PROCEDURE Select_Accounts @AccountID INT = NULL, @Username CHAR(16) = NULL, @Password CHAR(96) = NULL, @Salt CHAR(8) = NULL, @AccountType CHAR(6) = NULL, @Active BIT = NULL
AS
BEGIN
	BEGIN TRY
		SELECT * FROM Accounts WHERE
		AccountID=COALESCE(@AccountID, AccountID) AND
		Username=COALESCE(@Username, Username) AND
		[Password]=COALESCE(@Password, [Password]) AND
		Salt=COALESCE(@Salt, Salt) AND
		AccountType=COALESCE(@AccountType, AccountType) AND
		Active=COALESCE(@Active, Active);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Select_Appliances */
CREATE PROCEDURE Select_Appliances @ApplianceID INT = NULL, @Name CHAR(16) = NULL, @ApplianceType CHAR(16) = NULL, @Wattage REAL = NULL, @PinID TINYINT = NULL, @IsDigital BIT = NULL, @Active BIT = NULL, @Restricted BIT = NULL, @AddedBy INT = NULL
AS
BEGIN
	BEGIN TRY
		SELECT * FROM Appliances WHERE
		ApplianceID=COALESCE(@ApplianceID, ApplianceID) AND
		Name=COALESCE(@Name, Name) AND
		ApplianceType=COALESCE(@ApplianceType, ApplianceType) AND
		Wattage=COALESCE(@Wattage, Wattage) AND
		PinID=COALESCE(@PinID, PinID) AND
		IsDigital=COALESCE(@IsDigital, IsDigital) AND
		Active=COALESCE(@Active, Active) AND
		Restricted=COALESCE(@Restricted, Restricted) AND
		AddedBy=COALESCE(@AddedBy, AddedBy);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Select_Schedule */
CREATE PROCEDURE Select_Schedule @ScheduleID INT = NULL, @ApplianceID INT = NULL, @SetValue INT = NULL, @ScheduleType CHAR(16) = NULL, @Repitition CHAR(7) = NULL, @LowerLimit DATETIME = NULL, @UpperLimit DATETIME = NULL
AS
BEGIN
	BEGIN TRY
		SELECT * FROM Schedules WHERE
		ScheduleID=COALESCE(@ScheduleID, ScheduleID) AND
		ApplianceID=COALESCE(@ApplianceID, ApplianceID) AND
		SetValue=COALESCE(@SetValue, SetValue) AND
		ScheduleType=COALESCE(@ScheduleType, ScheduleType) AND
		Repitition=COALESCE(@Repitition, Repitition) AND
		LowerLimit=COALESCE(@LowerLimit, LowerLimit) AND
		UpperLimit=COALESCE(@UpperLimit, UpperLimit);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Select_StateChanges */
CREATE PROCEDURE Select_StateChanges @AccountID INT = NULL, @ApplianceID INT = NULL, @Value SMALLINT = NULL, @DateAndTime DATETIME 
AS
BEGIN
	BEGIN TRY
		SELECT * FROM StateChanges WHERE
		AccountID=COALESCE(@AccountID, AccountID) AND
		ApplianceID=COALESCE(@ApplianceID, ApplianceID) AND
		Value=COALESCE(@Value, Value) AND
		DateAndTime=COALESCE(@DateAndTime, DateAndTime);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/* Select_ApplicationLog */
CREATE PROCEDURE Select_ApplicationLog @AccountID INT = NULL, @Importance CHAR(8) = NULL, @Message VARCHAR(100) = NULL
AS
BEGIN
	BEGIN TRY
		SELECT * FROM ApplicationLog WHERE
		AccountID=COALESCE(@AccountID, AccountID) AND
		Importance=COALESCE(@Importance, Importance) AND
		[Message]=COALESCE(@Message, [Message]);
	END TRY
	BEGIN CATCH
		EXECUTE General_Error;
	END CATCH
END
RETURN

/*

Data

*/
/* Accounts */
EXECUTE Accounts_Register @Username='device', @Password='eY2JfQw6eXWbD1zrokOtrqQeiJj/3dZ6VRBLvgUAzb33DdmnAdcziBP8Rt0zsuVvXQBmRy/Ov2RwRpRUxamT+2RldmljZQ==', @Salt='device', @AccountType='DEVICE', @Active=1;
EXECUTE Accounts_Register @Username='root', @Password='ma3CMbBFMx5RSlFrS3aA9YjjgjITq+kBc4vDrWey9vyzxk77k9GAAliNPMwaSe+64c4gy0PfNrOGUfEfp1Z46HJvb3Q=', @Salt='root', @AccountType='ROOT', @Active=1;
EXECUTE Accounts_Register @Username='admin', @Password='x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY036xxzTTrw10Wq3+4qQyB+XURPWx1ONxp3Y3pB37GFkbWlu', @Salt='admin', @AccountType='ADMIN', @Active=1;
EXECUTE Accounts_Register @Username='user', @Password='sUNhQEwHj/1UnAPbRDw/7eLz5TTXP3j3cwHtl9SkNqn9nbBe6LMlwK02Q4tD/shRDCBPwcHtsh0JQcAOniwc4nVzZXI=', @Salt='user', @AccountType='NORMAL', @Active=1;
SELECT * FROM Accounts;

/* Appliances */
EXECUTE	Appliances_AddAppliance @Name='LED', @ApplianceType='Light', @Wattage=40, @PinID=2, @IsDigital=1, @Active=1, @Restricted=0, @AddedBy=1;
EXECUTE	Appliances_AddAppliance @Name='Garage Light', @ApplianceType='Light', @Wattage=40, @PinID=3, @IsDigital=1, @Active=0, @Restricted=0, @AddedBy=1;
EXECUTE	Appliances_AddAppliance @Name='Sony TV', @ApplianceType='TV', @Wattage=400, @PinID=4, @IsDigital=1, @Active=1, @Restricted=0, @AddedBy=2;
EXECUTE	Appliances_AddAppliance @Name='Asus', @ApplianceType='Computer', @Wattage=300, @PinID=5, @IsDigital=1, @Active=1, @Restricted=1, @AddedBy=2;
SELECT * FROM Appliances;

/* StateChanges */
EXECUTE States_ChangeState @AccountID=0, @ApplianceID=0, @Value=0;
EXECUTE States_ChangeState @AccountID=0, @ApplianceID=1, @Value=0;
EXECUTE States_ChangeState @AccountID=0, @ApplianceID=2, @Value=0;
EXECUTE States_ChangeState @AccountID=0, @ApplianceID=3, @Value=0;
SELECT * FROM Appliances;