CREATE TABLE [dbo].[TbCliente]
(
    [Nome] VARCHAR(50) NOT NULL, 
    [Cpf] VARCHAR(50) NULL, 
    [Cnpj] VARCHAR(50) NULL, 
    [Endereco] VARCHAR(50) NOT NULL, 
    [Cnh] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Telefone] VARCHAR(50) NOT NULL, 
    [TipoCadastro] BIT NOT NULL, 
    [Id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_TbCliente] PRIMARY KEY ([Id])
)
