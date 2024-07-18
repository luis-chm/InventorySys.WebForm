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
