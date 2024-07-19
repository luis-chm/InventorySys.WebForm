CREATE DATABASE InventorySYS
GO
USE InventorySYS
GO

-- Tabla tbl_Roles
CREATE TABLE tbl_Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL,
    RoleActive BIT NOT NULL
);

-- Tabla tbl_Users
CREATE TABLE tbl_Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    UserEmail VARCHAR(100) NOT NULL,
    UserEncryptedPassword VARCHAR(100) NOT NULL,
    RoleID INT,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleID) REFERENCES tbl_Roles(RoleID)
);

-- Tabla tbl_Collections
CREATE TABLE tbl_Collections (
    CollectionID INT IDENTITY(1,1) PRIMARY KEY,
    CollectionName VARCHAR(100) NOT NULL,
    CollectionEffect VARCHAR(200) NOT NULL,
    CollectionActive BIT NOT NULL
);

-- Tabla tbl_Formats
CREATE TABLE tbl_Formats (
    FormatID INT IDENTITY(1,1) PRIMARY KEY,
    FormatName VARCHAR(100) NOT NULL,
    FormatSizeCM DECIMAL(8, 2),
    FormatActive BIT NOT NULL
);

-- Tabla tbl_Sites
CREATE TABLE tbl_Sites (
    SiteID INT IDENTITY(1,1) PRIMARY KEY,
    SiteName VARCHAR(100) NOT NULL,
    SiteLocation VARCHAR(200) NOT NULL,
    SiteActive BIT NOT NULL
);

-- Tabla tbl_Finitures
CREATE TABLE tbl_Finitures (
    FinitureID INT IDENTITY(1,1) PRIMARY KEY,
    FinitureCode VARCHAR(50) NOT NULL,
    FinitureName VARCHAR(100) NOT NULL,
    FinitureActive BIT NOT NULL
);

-- Tabla tbl_Materials
CREATE TABLE tbl_Materials (
    MaterialID INT IDENTITY(1,1) PRIMARY KEY,
    MaterialCode VARCHAR(50) NOT NULL,
    MaterialDescription VARCHAR(200) NOT NULL,
    CollectionID INT,
    FinitureID INT,
    FormatID INT,
    SiteID INT,
    MaterialIMG VARCHAR(MAX) NULL,
    MaterialReceivedDate DATE NOT NULL,
    MaterialStock DECIMAL(18, 2) NOT NULL,
    UserID INT,
    CONSTRAINT FK_Materials_Collections FOREIGN KEY (CollectionID) REFERENCES tbl_Collections(CollectionID),
    CONSTRAINT FK_Materials_Finitures FOREIGN KEY (FinitureID) REFERENCES tbl_Finitures(FinitureID),
    CONSTRAINT FK_Materials_Formats FOREIGN KEY (FormatID) REFERENCES tbl_Formats(FormatID),
    CONSTRAINT FK_Materials_Sites FOREIGN KEY (SiteID) REFERENCES tbl_Sites(SiteID),
    CONSTRAINT FK_Materials_Users FOREIGN KEY (UserID) REFERENCES tbl_Users(UserID)
);

-- Tabla tbl_MaterialTransactions (actualizada)
CREATE TABLE tbl_MaterialTransactions (
    MaterialTransactionID INT IDENTITY(1,1) PRIMARY KEY,
    MaterialTransactionType VARCHAR(50) NOT NULL,
    MaterialTransactionQuantity DECIMAL(18, 2) NOT NULL,
    MaterialTransactionDate DATETIME NOT NULL,
    UserID INT,
    CONSTRAINT FK_MaterialTransactions_Users FOREIGN KEY (UserID) REFERENCES tbl_Users(UserID)
);

-- Tabla tbl_DetallesMovimientos
CREATE TABLE tbl_DetailMovements (
    DetailMovID INT PRIMARY KEY IDENTITY(1,1),
    MaterialID INT,
    MaterialTransactionID INT,
    DetInitBalance DECIMAL(18, 2),
    DetCantEntry DECIMAL(18, 2),
    DetCantExit DECIMAL(18, 2),
    DetCurrentBalance DECIMAL(18, 2),
    CONSTRAINT FK_DetailMovements_Materials FOREIGN KEY (MaterialID) REFERENCES tbl_Materials(MaterialID),
    CONSTRAINT FK_DetailMovements_MaterialTransactions FOREIGN KEY (MaterialTransactionID) REFERENCES tbl_MaterialTransactions(MaterialTransactionID)
);

-- Procedimientos almacenados tabla usuarios

CREATE PROCEDURE GestionarUsuarios
    @accion NVARCHAR(10),
    @UserID INT = NULL,
    @UserName VARCHAR(50) = NULL,
    @UserEmail VARCHAR(100) = NULL,
    @UserEncryptedPassword VARCHAR(100) = NULL,
    @RoleID INT = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO tbl_Users (UserName, UserEmail, UserEncryptedPassword, RoleID) 
        VALUES (@UserName, @UserEmail, @UserEncryptedPassword, @RoleID);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM tbl_Users WHERE UserID = @UserID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE tbl_Users SET 
            UserName = @UserName,
            UserEmail = @UserEmail,
            UserEncryptedPassword = @UserEncryptedPassword,
            RoleID = @RoleID
        WHERE UserID = @UserID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT UserID, UserName, UserEmail, UserEncryptedPassword, RoleID 
        FROM tbl_Users
        WHERE UserID = @UserID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;

-- Procedimientos almacenados tabla roles

CREATE PROCEDURE GestionarRoles
    @accion NVARCHAR(10),
    @RoleID INT = NULL,
    @RoleName VARCHAR(50) = NULL,
    @RoleActive BIT = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO tbl_Roles (RoleName, RoleActive) 
        VALUES (@RoleName, @RoleActive);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM tbl_Roles WHERE RoleID = @RoleID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE tbl_Roles SET 
            RoleName = @RoleName,
            RoleActive = @RoleActive
        WHERE RoleID = @RoleID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT RoleID, RoleName, RoleActive
        FROM tbl_Roles
        WHERE RoleID = @RoleID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;

-- Procedimientos almacenados tabla Collections

CREATE PROCEDURE GestionarCollections
    @accion NVARCHAR(10),
    @CollectionID INT = NULL,
    @CollectionName VARCHAR(100) = NULL,
    @CollectionEffect VARCHAR(200) = NULL,
    @CollectionActive BIT = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO tbl_Collections (CollectionName, CollectionEffect, CollectionActive) 
        VALUES (@CollectionName, @CollectionEffect, @CollectionActive);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM tbl_Collections WHERE CollectionID = @CollectionID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE tbl_Collections SET 
            CollectionName = @CollectionName,
            CollectionEffect = @CollectionEffect,
            CollectionActive = @CollectionActive
        WHERE CollectionID = @CollectionID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT CollectionID, CollectionName, CollectionEffect, CollectionActive
        FROM tbl_Collections
        WHERE CollectionID = @CollectionID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;

-- Procedimientos almacenados tabla Finitures

CREATE PROCEDURE GestionarFinitures
    @accion NVARCHAR(10),
    @FinitureID INT = NULL,
    @FinitureCode VARCHAR(50) = NULL,
    @FinitureName VARCHAR(100) = NULL,
    @FinitureActive BIT = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO tbl_Finitures (FinitureCode, FinitureName, FinitureActive) 
        VALUES (@FinitureCode, @FinitureName, @FinitureActive);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM tbl_Finitures WHERE FinitureID = @FinitureID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE tbl_Finitures SET 
            FinitureCode = @FinitureCode,
            FinitureName = @FinitureName,
            FinitureActive = @FinitureActive
        WHERE FinitureID = @FinitureID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT FinitureID, FinitureCode, FinitureName, FinitureActive
        FROM tbl_Finitures
        WHERE FinitureID = @FinitureID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;

-- Procedimientos almacenados tabla Sites

CREATE PROCEDURE GestionarSites
    @accion NVARCHAR(10),
    @SiteID INT = NULL,
    @SiteName VARCHAR(100) = NULL,
    @SiteLocation VARCHAR(200) = NULL,
    @SiteActive BIT = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO tbl_Sites (SiteName, SiteLocation, SiteActive) 
        VALUES (@SiteName, @SiteLocation, @SiteActive);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM tbl_Sites WHERE SiteID = @SiteID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE tbl_Sites SET 
            SiteName = @SiteName,
            SiteLocation = @SiteLocation,
            SiteActive = @SiteActive
        WHERE SiteID = @SiteID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT SiteID, SiteName, SiteLocation, SiteActive
        FROM tbl_Sites
        WHERE SiteID = @SiteID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;


-- Procedimientos almacenados tabla Formats

CREATE PROCEDURE [dbo].[GestionarFormats]
    @accion NVARCHAR(10),
    @FormatID INT = NULL,
    @FormatName VARCHAR(100) = NULL,
    @FormatSizeCM DECIMAL(8,2) = NULL,
    @FormatActive BIT = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
	INSERT INTO [dbo].[tbl_Formats]
           ([FormatName]
           ,[FormatSizeCM]
           ,[FormatActive])
     VALUES
           (@FormatName,@FormatSizeCM,@FormatActive);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM [dbo].[tbl_Formats] WHERE [FormatID] = @FormatID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE [dbo].[tbl_Formats] SET 
            FormatName = @FormatName,
            FormatSizeCM = @FormatSizeCM,
            FormatActive = @FormatActive
        WHERE FormatID = @FormatID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
       SELECT [FormatID],[FormatName],[FormatSizeCM],[FormatActive]
       FROM [dbo].[tbl_Formats]
        WHERE FormatID = @FormatID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;
GO


--------------------Nueva columna en la tabla de transacciones para asociar una transaccion a un material-------------------------------------
ALTER TABLE [dbo].[tbl_MaterialTransactions]
ADD MaterialID INT NULL

ALTER TABLE [dbo].[tbl_MaterialTransactions]
ADD CONSTRAINT FK_MaterialID
FOREIGN KEY (MaterialID) REFERENCES [dbo].[tbl_Materials](MaterialID);
------------------------------------------------------
USE [InventorySYS]
GO

/****** Object:  StoredProcedure [dbo].[GestionarMaterialTransactions]    Script Date: 19/7/2024 17:09:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- Procedimientos almacenados tabla MaterialTransactions

CREATE PROCEDURE [dbo].[GestionarMaterialTransactions]
    @accion NVARCHAR(10),
    @MaterialTransactionID INT = NULL,
    @MaterialTransactionType VARCHAR(50) = NULL,
    @MaterialTransactionQuantity DECIMAL(18,2) = NULL,
	@MaterialTransactionDate DATETIME = NULL,
    @UserID INT = NULL,
	@MaterialID INT = NULL

AS
BEGIN

    DECLARE @Last_MaterialTransactionID INT = NULL,
    @DetInitBalance DECIMAL(18,2) = 0.00,
    @DetCantEntry DECIMAL(18,2)  = 0.00,
	@DetCantExit DECIMAL(18,2)  = 0.00,
    @DetCurrentBalance DECIMAL(18,2)  = 0.00;

	SELECT TOP 1 @DetInitBalance = MaterialStock FROM [dbo].[tbl_Materials] WHERE [MaterialID] = @MaterialID;

	IF @MaterialTransactionType = 'Ingreso'
	BEGIN
	  SELECT @DetCantEntry = @MaterialTransactionQuantity;
	  SELECT @DetCurrentBalance = @DetInitBalance + @DetCantEntry;
	END
	ELSE IF @MaterialTransactionType = 'Retiro'
	BEGIN
	  SELECT @DetCantExit = @MaterialTransactionQuantity;
	  SELECT @DetCurrentBalance = @DetInitBalance - @DetCantExit;
	END

    IF @accion = 'agregar'
    BEGIN
       INSERT INTO [dbo].[tbl_MaterialTransactions]
           ([MaterialTransactionType]
           ,[MaterialTransactionQuantity]
           ,[MaterialTransactionDate]
           ,[UserID]
		   ,[MaterialID])
     VALUES
           (@MaterialTransactionType
           ,@MaterialTransactionQuantity
           ,@MaterialTransactionDate
           ,@UserID
		   ,@MaterialID)

	-------Inserta los detalles de los movimientos calculados-----------------------------------
	SELECT TOP 1 @Last_MaterialTransactionID = MaterialTransactionID FROM [dbo].[tbl_MaterialTransactions] ORDER BY MaterialTransactionID DESC;
	INSERT INTO [dbo].[tbl_DetailMovements]
           ([MaterialTransactionID]
           ,[DetInitBalance]
           ,[DetCantEntry]
           ,[DetCantExit]
           ,[DetCurrentBalance])
     VALUES
           (@Last_MaterialTransactionID
           ,@DetInitBalance
           ,@DetCantEntry
           ,@DetCantExit
           ,@DetCurrentBalance)	
	-----------------Actualiza el stock en la tabla de Materiales---------------------------------------------------------
	UPDATE [dbo].[tbl_Materials]
	SET MaterialStock = @DetCurrentBalance
	WHERE [MaterialID] = @MaterialID;
    END
	-------------------------------------------------------------------------------
    ELSE IF @accion = 'borrar'
    BEGIN
		DELETE FROM  [dbo].[tbl_DetailMovements] WHERE MaterialTransactionID = @MaterialTransactionID;
        DELETE FROM  [dbo].[tbl_MaterialTransactions] WHERE MaterialTransactionID = @MaterialTransactionID;

    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE [dbo].[tbl_MaterialTransactions] SET 
            MaterialTransactionType = @MaterialTransactionType,
            MaterialTransactionQuantity = @MaterialTransactionQuantity,
            MaterialTransactionDate = @MaterialTransactionDate,
			UserID = @UserID,
			MaterialID = @MaterialID
        WHERE MaterialTransactionID = @MaterialTransactionID;
	-------Actualiza los detalles de los movimientos calculados-----------------------------------
	UPDATE [dbo].[tbl_DetailMovements]
	SET [DetInitBalance] = @DetInitBalance
      ,[DetCantEntry] = @DetCantEntry
      ,[DetCantExit] = @DetCantExit
      ,[DetCurrentBalance] = @DetCurrentBalance
	WHERE MaterialTransactionID = @MaterialTransactionID;
	-----------------Actualiza el stock en la tabla de Materiales---------------------------------------------------------
	UPDATE [dbo].[tbl_Materials]
	SET MaterialStock = @DetCurrentBalance
	WHERE [MaterialID] = @MaterialID;
	  -----------------------------------------------
    END
    ELSE IF @accion = 'consultar'
    BEGIN
       SELECT [MaterialTransactionID]
      ,[MaterialTransactionType]
      ,[MaterialTransactionQuantity]
      ,[MaterialTransactionDate]
      ,[UserID]
	  ,[MaterialID]
  FROM [dbo].[tbl_MaterialTransactions]
        WHERE MaterialTransactionID = @MaterialTransactionID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;
GO






-- Procedimientos almacenados tabla Materials

CREATE PROCEDURE [dbo].[GestionarMaterials]
    @accion NVARCHAR(10),
    @MaterialID INT = NULL,
    @MaterialCode VARCHAR(50) = NULL,
    @MaterialDescription VARCHAR(200) = NULL,
	@CollectionID INT = NULL,
    @FinitureID INT = NULL,
    @FormatID INT = NULL,
    @SiteID INT = NULL,
    @MaterialIMG VARCHAR(MAX) = NULL,
	@MaterialReceivedDate DATETIME = NULL,
	@MaterialStock DECIMAL(18,2) = NULL,
    @UserID INT = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
      INSERT INTO [dbo].[tbl_Materials]
           ([MaterialCode]
           ,[MaterialDescription]
           ,[CollectionID]
           ,[FinitureID]
           ,[FormatID]
           ,[SiteID]
           ,[MaterialIMG]
           ,[MaterialReceivedDate]
           ,[MaterialStock]
           ,[UserID])
     VALUES
           (@MaterialCode
           ,@MaterialDescription
           ,@CollectionID
           ,@FinitureID
           ,@FormatID
           ,@SiteID
           ,@MaterialIMG
           ,@MaterialReceivedDate
           ,@MaterialStock
           ,@UserID)
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM  [dbo].[tbl_Materials] WHERE MaterialID = @MaterialID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
       UPDATE [dbo].[tbl_Materials]
   SET [MaterialCode] = @MaterialCode
      ,[MaterialDescription] = @MaterialDescription
      ,[CollectionID] = @CollectionID
      ,[FinitureID] = @FinitureID
      ,[FormatID] = @FormatID
      ,[SiteID] = @SiteID
      ,[MaterialIMG] = @MaterialIMG
      ,[MaterialReceivedDate] = @MaterialReceivedDate
      ,[MaterialStock] = @MaterialStock
      ,[UserID] = @UserID
      WHERE MaterialID = @MaterialID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
      SELECT [MaterialID]
      ,[MaterialCode]
      ,[MaterialDescription]
      ,[CollectionID]
      ,[FinitureID]
      ,[FormatID]
      ,[SiteID]
      ,[MaterialIMG]
      ,[MaterialReceivedDate]
      ,[MaterialStock]
      ,[UserID]
  FROM [dbo].[tbl_Materials]
  WHERE MaterialID = @MaterialID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;
GO
------------------------------------Remover columna inecesaria----------------------------------------------------------------
-- Eliminar la clave foránea
ALTER TABLE [dbo].[tbl_DetailMovements]
DROP CONSTRAINT FK_DetailMovements_Materials;

-- Eliminar la columna ParentID
ALTER TABLE  [dbo].[tbl_DetailMovements]
DROP COLUMN MaterialID;

-- Procedimientos almacenados tabla Collections

CREATE PROCEDURE [dbo].[GestionarDetailMovements]
    @accion NVARCHAR(10),
    @DetailMovID INT = NULL,
	@MaterialTransactionID INT = NULL,
    @DetInitBalance DECIMAL(18,2) = NULL,
    @DetCantEntry DECIMAL(18,2)  = NULL,
	@DetCantExit DECIMAL(18,2)  = NULL,
    @DetCurrentBalance DECIMAL(18,2)  = NULL
AS
BEGIN
    IF @accion = 'agregar'
    BEGIN
        INSERT INTO [dbo].[tbl_DetailMovements]
           ([MaterialTransactionID]
           ,[DetInitBalance]
           ,[DetCantEntry]
           ,[DetCantExit]
           ,[DetCurrentBalance])
     VALUES
           (@MaterialTransactionID
           ,@DetInitBalance
           ,@DetCantEntry
           ,@DetCantExit
           ,@DetCurrentBalance)
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM [dbo].[tbl_DetailMovements] WHERE DetailMovID = @DetailMovID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        UPDATE [dbo].[tbl_DetailMovements]
   SET [MaterialTransactionID] = @MaterialTransactionID
      ,[DetInitBalance] = @DetInitBalance
      ,[DetCantEntry] = @DetCantEntry
      ,[DetCantExit] = @DetCantExit
      ,[DetCurrentBalance] = @DetCurrentBalance
        WHERE DetailMovID = @DetailMovID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT [DetailMovID]
      ,[MaterialTransactionID]
      ,[DetInitBalance]
      ,[DetCantEntry]
      ,[DetCantExit]
      ,[DetCurrentBalance]
  FROM [dbo].[tbl_DetailMovements]
        WHERE DetailMovID = @DetailMovID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;
GO

