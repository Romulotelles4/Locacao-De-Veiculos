CREATE TABLE [dbo].[TbFuncionario]
(
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Nome] NVARCHAR(50) NOT NULL, 
    [Login] NVARCHAR(50) NOT NULL, 
    [Senha] NVARCHAR(50) NOT NULL, 
    [DataEntrada] DATE NOT NULL, 
    [Administrador] BIT NOT NULL, 
    [Salario] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [PK_TbFuncionario] PRIMARY KEY ([Id]), 
)
