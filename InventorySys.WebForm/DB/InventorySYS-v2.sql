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
	UserActive BIT NOT NULL,
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

-- Tabla tbl_MaterialTransactions
CREATE TABLE tbl_MaterialTransactions (
    MaterialTransactionID INT IDENTITY(1,1) PRIMARY KEY,
    MaterialTransactionType VARCHAR(50) NOT NULL,
    MaterialTransactionQuantity DECIMAL(18, 2) NOT NULL,
    MaterialTransactionDate DATETIME NOT NULL,
    UserID INT,
    MaterialID INT NULL, --NUEVO
    CONSTRAINT FK_MaterialTransactions_Users FOREIGN KEY (UserID) REFERENCES tbl_Users(UserID),
    CONSTRAINT FK_MaterialTransactions_Materials FOREIGN KEY (MaterialID) REFERENCES tbl_Materials(MaterialID) -- NUEVO
);

-- Tabla tbl_DetailMovements
CREATE TABLE tbl_DetailMovements (
    DetailMovID INT PRIMARY KEY IDENTITY(1,1),
    MaterialTransactionID INT,
    DetInitBalance DECIMAL(18, 2),
    DetCantEntry DECIMAL(18, 2),
    DetCantExit DECIMAL(18, 2),
    DetCurrentBalance DECIMAL(18, 2),
    CONSTRAINT FK_DetailMovements_MaterialTransactions FOREIGN KEY (MaterialTransactionID) REFERENCES tbl_MaterialTransactions(MaterialTransactionID)
);

----------------------------------------------------------------------------------------------------------------

-- Procedimientos almacenados -- 

-- Procedimientos almacenados tabla usuarios

CREATE PROCEDURE GestionarUsuarios
    @accion NVARCHAR(10),
    @UserID INT = NULL,
    @UserName VARCHAR(50) = NULL,
    @UserEmail VARCHAR(100) = NULL,
    @UserEncryptedPassword VARCHAR(100) = NULL,
	@UserActive BIT = NULL,
    @RoleID INT = NULL
AS
BEGIN
    DECLARE @EncryptedPassword NVARCHAR(100)
    
    IF @accion = 'agregar'
    BEGIN
        -- Encriptar contraseña antes de insertar
        SET @EncryptedPassword = dbo.EncryptPassword(@UserEncryptedPassword)
        
        INSERT INTO tbl_Users (UserName, UserEmail, UserEncryptedPassword, UserActive, RoleID) 
        VALUES (@UserName, @UserEmail, @EncryptedPassword, @UserActive, @RoleID);
    END
    ELSE IF @accion = 'borrar'
    BEGIN
        DELETE FROM tbl_Users WHERE UserID = @UserID;
    END
    ELSE IF @accion = 'modificar'
    BEGIN
        -- Si viene nueva contraseña, encriptarla
        IF @UserEncryptedPassword IS NOT NULL AND @UserEncryptedPassword != ''
        BEGIN
            SET @EncryptedPassword = dbo.EncryptPassword(@UserEncryptedPassword)
        END
        ELSE
        BEGIN
            -- Mantener la contraseña actual
            SELECT @EncryptedPassword = UserEncryptedPassword 
            FROM tbl_Users WHERE UserID = @UserID
        END
        
        UPDATE tbl_Users SET 
            UserName = @UserName,
            UserEmail = @UserEmail,
            UserEncryptedPassword = @EncryptedPassword,
            UserActive = @UserActive,
            RoleID = @RoleID
        WHERE UserID = @UserID;
    END
    ELSE IF @accion = 'consultar'
    BEGIN
        SELECT UserID, UserName, UserEmail, UserEncryptedPassword, RoleID, UserActive
        FROM tbl_Users
        WHERE UserID = @UserID;
    END
	ELSE IF @accion = 'listar'
    BEGIN
        SELECT u.UserID,
               u.UserName,
               u.UserEmail,
               u.UserEncryptedPassword,
               u.RoleID,
               r.RoleName,
               u.UserActive
        FROM [dbo].[tbl_Users] u 
        INNER JOIN [dbo].[tbl_Roles] r ON u.RoleID = r.RoleID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida' as Mensaje;
    END
END


-- Procedimientos almacenados tabla roles

CREATE PROCEDURE GestionarRoles
    @accion NVARCHAR(15),
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
	ELSE IF @accion = 'listar'
    BEGIN
        SELECT RoleID, RoleName, RoleActive
        FROM tbl_Roles;
    END
    ELSE IF @accion = 'listarActivos'
    BEGIN
        SELECT RoleID, RoleName, RoleActive
        FROM tbl_Roles
        WHERE RoleActive = 1;
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
	ELSE IF @accion = 'listar'
    BEGIN
        SELECT CollectionID, CollectionName, CollectionEffect, CollectionActive
        FROM tbl_Collections;
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
	ELSE IF @accion = 'listar'
    BEGIN
        SELECT FinitureID, FinitureCode, FinitureName, FinitureActive
        FROM tbl_Finitures;
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
	ELSE IF @accion = 'listar'
    BEGIN
        SELECT SiteID, SiteName, SiteLocation, SiteActive
        FROM tbl_Sites;
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
    ELSE IF @accion = 'listar'
    BEGIN
        SELECT [FormatID],[FormatName],[FormatSizeCM],[FormatActive]
        FROM [dbo].[tbl_Formats];
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;
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
	ELSE IF @accion = 'listar'
    BEGIN
        SELECT mt.MaterialTransactionID,
               mt.MaterialTransactionType,
               mt.MaterialTransactionQuantity,
               mt.MaterialTransactionDate,
               u.UserID,
               u.UserName,
               m.MaterialID,
               m.MaterialDescription,
               m.MaterialCode
        FROM [dbo].[tbl_MaterialTransactions] mt 
        INNER JOIN [dbo].[tbl_Users] u ON mt.UserID = u.UserID 
        INNER JOIN [dbo].[tbl_Materials] m ON mt.MaterialID = m.MaterialID;
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
      ,CONVERT(char(10), [MaterialReceivedDate], 103) AS MaterialReceivedDate  -- AGREGAR ALIAS
      ,[MaterialStock]
      ,[UserID]
  FROM [dbo].[tbl_Materials]
  WHERE MaterialID = @MaterialID;
    END
	ELSE IF @accion = 'listar'
    BEGIN
        SELECT m.MaterialID,
               m.MaterialCode,
               m.MaterialDescription,
               m.CollectionID,
               c.CollectionName,
               m.FinitureID,
               f.FinitureName,
               m.FormatID,
               ft.FormatName,
               m.SiteID,
               s.SiteName,
               m.MaterialIMG,
               m.MaterialReceivedDate,
               m.MaterialStock,
               m.UserID,
               u.UserName
        FROM [dbo].[tbl_Materials] m 
        INNER JOIN [dbo].[tbl_Collections] c ON c.CollectionID = m.CollectionID 
        INNER JOIN [dbo].[tbl_Finitures] f ON f.FinitureID = m.FinitureID 
        INNER JOIN [dbo].[tbl_Formats] ft ON ft.FormatID = m.FormatID 
        INNER JOIN [dbo].[tbl_Sites] s ON s.SiteID = m.SiteID 
        INNER JOIN [dbo].[tbl_Users] u ON u.UserID = m.UserID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;
GO

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
	ELSE IF @accion = 'listar'
    BEGIN
        SELECT dm.DetailMovID,
               dm.MaterialTransactionID,
               dm.DetInitBalance,
               dm.DetCantEntry,
               dm.DetCantExit,
               dm.DetCurrentBalance,
               mt.MaterialTransactionDate,
               mt.MaterialTransactionType,
               m.MaterialCode,
               m.MaterialDescription
        FROM [dbo].[tbl_DetailMovements] dm 
        INNER JOIN [dbo].[tbl_MaterialTransactions] mt ON dm.MaterialTransactionID = mt.MaterialTransactionID 
        INNER JOIN [dbo].[tbl_Materials] m ON mt.MaterialID = m.MaterialID;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida';
    END
END;
GO

-- Procedimiento almacenado para gestionar consultas del Dashboard

CREATE PROCEDURE GestionarDashboard
    @accion NVARCHAR(30)
AS
BEGIN
    IF @accion = 'ObtenerTotalMateriales'
    BEGIN
        SELECT COUNT(MaterialID) AS TotalMateriales
        FROM tbl_Materials;
    END
    ELSE IF @accion = 'ObtenerStockTotal'
    BEGIN
        SELECT ISNULL(SUM(MaterialStock), 0) AS StockTotal
        FROM tbl_Materials;
    END
    ELSE IF @accion = 'ObtenerTotalTransacciones'
    BEGIN
        SELECT COUNT(MaterialTransactionID) AS TotalTransacciones
        FROM tbl_MaterialTransactions;
    END
    ELSE IF @accion = 'ObtenerColeccionesActivas'
    BEGIN
        SELECT COUNT(CollectionID) AS ColeccionesActivas
        FROM tbl_Collections 
        WHERE CollectionActive = 1;
    END
    ELSE IF @accion = 'ObtenerSitiosActivos'
    BEGIN
        SELECT COUNT(SiteID) AS SitiosActivos
        FROM tbl_Sites 
        WHERE SiteActive = 1;
    END
    ELSE IF @accion = 'ObtenerFormatosActivos'
    BEGIN
        SELECT COUNT(FormatID) AS FormatosActivos
        FROM tbl_Formats 
        WHERE FormatActive = 1;
    END
    ELSE IF @accion = 'ObtenerAcabadosActivos'
    BEGIN
        SELECT COUNT(FinitureID) AS AcabadosActivos
        FROM tbl_Finitures 
        WHERE FinitureActive = 1;
    END
    ELSE IF @accion = 'ObtenerUsuariosRegistrados'
    BEGIN
        SELECT COUNT(UserID) AS UsuariosRegistrados
        FROM tbl_Users;
    END
    ELSE
    BEGIN
        SELECT 'Acción no válida' AS Error;
    END
END;


-- Procedimientos almacenado validar login

CREATE PROCEDURE ValidarUsuario
    @UserEmail VARCHAR(100),
    @UserEncryptedPassword VARCHAR(100)  -- Mantenemos el nombre original
AS
BEGIN
    DECLARE @EncryptedPassword NVARCHAR(100)
    
    -- Encriptar la contraseña que viene del login
    SET @EncryptedPassword = dbo.EncryptPassword(@UserEncryptedPassword)
    
    -- Buscar usuario con email y contraseña encriptada
    SELECT 
        u.UserID,
        u.UserName,
        u.UserEmail,
        u.UserEncryptedPassword,
		u.UserActive, 
        r.RoleID,
        r.RoleName
    FROM 
        tbl_Users u
    INNER JOIN 
        tbl_Roles r ON u.RoleID = r.RoleID
    WHERE 
        u.UserEmail = @UserEmail 
        AND u.UserEncryptedPassword = @EncryptedPassword
END

-- Crear función para encriptar contraseñas con SHA256
CREATE FUNCTION dbo.EncryptPassword(@password NVARCHAR(100))
RETURNS NVARCHAR(100)
AS
BEGIN
    DECLARE @hashedPassword NVARCHAR(100)
    
    -- Usar HASHBYTES con SHA2_256
    SET @hashedPassword = CONVERT(NVARCHAR(100), HASHBYTES('SHA2_256', @password), 2)
    
    RETURN @hashedPassword
END
GO

-- Ejemplo de uso:
-- Ver contraseñas actuales (antes de encriptar)
SELECT UserID, UserName, UserEmail, UserEncryptedPassword 
FROM tbl_Users

-- Encriptar todas las contraseñas existentes
UPDATE tbl_Users 
SET UserEncryptedPassword = dbo.EncryptPassword(UserEncryptedPassword)
WHERE LEN(UserEncryptedPassword) < 64  -- Solo actualizar si no están encriptadas ya

-- Verificar que se encriptaron (deberían tener 64 caracteres)
SELECT UserID, UserName, UserEmail, 
       UserEncryptedPassword, 
       LEN(UserEncryptedPassword) as PasswordLength
FROM tbl_Users
-- SELECT dbo.EncryptPassword('mipassword123') -- Retorna hash encriptado


-- Procedimientos almacenado para reporte materiales por fecha

CREATE PROCEDURE ReporteMaterialesByDate
    @fechaInicio VARCHAR(10),
    @fechaFin VARCHAR(10)
AS
BEGIN
    SET DATEFORMAT dmy;
        SELECT m.MaterialID AS [ID Material],
               m.MaterialCode AS [Codigo Material],
               m.MaterialDescription AS [Descripcion Material],
               c.CollectionName AS [Nombre Coleccion],
               f.FinitureName AS [Nombre de Acabado],
               fo.FormatName AS [Nombre Formato],
               s.SiteName AS [Nombre de Sitio],
               CONVERT(VARCHAR(10), m.MaterialReceivedDate, 103) AS [Fecha de Ingreso],
               m.MaterialStock,
               u.UserName AS [Nombre Usuario]
        FROM tbl_Materials m
        LEFT JOIN tbl_Collections c ON m.CollectionID = c.CollectionID
        LEFT JOIN tbl_Finitures f ON m.FinitureID = f.FinitureID
        LEFT JOIN tbl_Formats fo ON m.FormatID = fo.FormatID
        LEFT JOIN tbl_Sites s ON m.SiteID = s.SiteID
        LEFT JOIN tbl_Users u ON m.UserID = u.UserID
        WHERE m.MaterialReceivedDate BETWEEN CONVERT(DATE, @fechaInicio, 103) AND CONVERT(DATE, @fechaFin, 103);
END;

-- Procedimientos almacenado para reporte materiales

CREATE PROCEDURE ReporteMaterialesGeneral
AS
BEGIN
    SET DATEFORMAT dmy;
    SELECT m.MaterialID AS [ID Material],
           m.MaterialCode AS [Codigo Material],
           m.MaterialDescription AS [Descripcion Material],
           c.CollectionName AS [Nombre Coleccion],
           f.FinitureName AS [Nombre de Acabado],
           fo.FormatName AS [Nombre Formato],
           s.SiteName AS [Nombre de Sitio],
           CONVERT(VARCHAR(10), m.MaterialReceivedDate, 103) AS [Fecha de Ingreso],
           m.MaterialStock,
           u.UserName AS [Nombre Usuario]
    FROM tbl_Materials m
    LEFT JOIN tbl_Collections c ON m.CollectionID = c.CollectionID
    LEFT JOIN tbl_Finitures f ON m.FinitureID = f.FinitureID
    LEFT JOIN tbl_Formats fo ON m.FormatID = fo.FormatID
    LEFT JOIN tbl_Sites s ON m.SiteID = s.SiteID
    LEFT JOIN tbl_Users u ON m.UserID = u.UserID
END

-- Procedimientos almacenado para reporte materiales transacciones

CREATE PROCEDURE ReporteMaterialTransactions
AS
BEGIN
    -- Configura el formato de fecha
    SET DATEFORMAT dmy;

    -- Selecciona los datos deseados
    SELECT
        dm.MaterialTransactionID AS [ID Transacción Material],
        u.UserName AS [Nombre Usuario],
        mt.MaterialTransactionType AS [Tipo Transacción],
        m.MaterialCode AS [Código Material],
        m.MaterialDescription AS [Descripción Material],
        dm.DetInitBalance AS [Saldo Inicial],
        dm.DetCantEntry AS [Cantidad Entrada],
        dm.DetCantExit AS [Cantidad Salida],
        dm.DetCurrentBalance AS [Saldo Actual],
        mt.MaterialTransactionDate AS [Fecha Transacción]
    FROM 
        [dbo].[tbl_DetailMovements] dm
    INNER JOIN 
        [dbo].[tbl_MaterialTransactions] mt 
        ON dm.MaterialTransactionID = mt.MaterialTransactionID
    INNER JOIN 
        [dbo].[tbl_Materials] m 
        ON mt.MaterialID = m.MaterialID
    INNER JOIN 
        [dbo].[tbl_Users] u 
        ON mt.UserID = u.UserID;
END;

-- Procedimientos almacenado para reporte materiales transacciones por fecha

CREATE PROCEDURE ReporteMaterialTransactionsByDate
    @fechaInicio VARCHAR(10),
    @fechaFin VARCHAR(10)
AS
BEGIN
    -- Configura el formato de fecha
    SET DATEFORMAT dmy;

    -- Selecciona los datos deseados con un rango de fechas
    SELECT
        dm.MaterialTransactionID AS [ID Transacción Material],
        u.UserName AS [Nombre Usuario],
        mt.MaterialTransactionType AS [Tipo Transacción],
        m.MaterialCode AS [Código Material],
        m.MaterialDescription AS [Descripción Material],
        dm.DetInitBalance AS [Saldo Inicial],
        dm.DetCantEntry AS [Cantidad Entrada],
        dm.DetCantExit AS [Cantidad Salida],
        dm.DetCurrentBalance AS [Saldo Actual],
        mt.MaterialTransactionDate AS [Fecha Transacción]
    FROM 
        [dbo].[tbl_DetailMovements] dm
    INNER JOIN 
        [dbo].[tbl_MaterialTransactions] mt 
        ON dm.MaterialTransactionID = mt.MaterialTransactionID
    INNER JOIN 
        [dbo].[tbl_Materials] m 
        ON mt.MaterialID = m.MaterialID
    INNER JOIN 
        [dbo].[tbl_Users] u 
        ON mt.UserID = u.UserID
    WHERE 
        mt.MaterialTransactionDate BETWEEN CONVERT(DATE, @fechaInicio, 103) AND CONVERT(DATE, @fechaFin, 103);
END;