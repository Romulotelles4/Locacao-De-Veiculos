CREATE TABLE [dbo].[TbVeiculo]
(
    [Modelo] VARCHAR(50) NOT NULL, 
    [Placa ] VARCHAR(50) NOT NULL, 
    [Marca] VARCHAR(50) NOT NULL, 
    [Cor] VARCHAR(50) NOT NULL, 
    [EnumTipoDeCombustivel] INT NULL, 
    [CapacidadeTanque] DECIMAL(18, 2) NOT NULL, 
    [KmPercorrido] DECIMAL(18, 2) NOT NULL, 
    [GrupoVeiculo_Id] UNIQUEIDENTIFIER NOT NULL, 
    [Foto] VARBINARY(MAX) NULL, 
    [id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_TbVeiculo_TbGrupoDeVeiculos] FOREIGN KEY ([GrupoVeiculo_Id]) REFERENCES TbGrupoVeiculo(Id), 
    CONSTRAINT [PK_TbVeiculo] PRIMARY KEY ([id]) 
)
