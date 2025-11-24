CREATE DATABASE ETFormulasDB;
GO

USE ETFormulasDB;
GO

CREATE TABLE Rol (
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Usuario NVARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(200) NOT NULL,
    Rol INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
CONSTRAINT FK_Usuario_Rol FOREIGN KEY (Rol) REFERENCES Rol(IdRol)
);

CREATE TABLE Producto (
    IDProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(150) NOT NULL,
    Cantidad INT NOT NULL DEFAULT 0,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Formula (
    IDFormula INT IDENTITY(1,1) PRIMARY KEY,
    IDProducto INT NOT NULL,
    Nombre VARCHAR(150) NOT NULL,
    IDUsuarioCreacion INT NOT NULL,
    IDUsuarioActualizacion INT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaActualizacion DATETIME NULL,
    Descripcion VARCHAR(500),

    CONSTRAINT FK_Formula_Producto FOREIGN KEY (IDProducto) REFERENCES Producto(IDProducto),
    CONSTRAINT FK_Formula_Usuario_Crea FOREIGN KEY (IDUsuarioCreacion) REFERENCES Usuario(IdUsuario),
    CONSTRAINT FK_Formula_Usuario_Act FOREIGN KEY (IDUsuarioActualizacion) REFERENCES Usuario(IdUsuario)
);

CREATE TABLE FormulaDetalle(
    IDFormula INT NOT NULL,
    Linea INT NOT NULL,
    Nombre VARCHAR(150) NOT NULL,
    Cantidad DECIMAL(18,2) NOT NULL,
    
    CONSTRAINT PK_FormulaDetalle PRIMARY KEY (IDFormula, Linea),
    CONSTRAINT FK_FormulaDetalle_Formula FOREIGN KEY (IDFormula) REFERENCES Formula(IDFormula)
);
GO