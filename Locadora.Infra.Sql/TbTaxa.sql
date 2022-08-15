CREATE TABLE [dbo].[TbTaxa]
(
    [Valor] DECIMAL(18, 2) NOT NULL, 
    [Descricao] VARCHAR(50) NOT NULL, 
    [Enum_TipoDeCalculo] INT NOT NULL, 
    [id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_TbTaxa] PRIMARY KEY ([id])
)
