CREATE TABLE [dbo].[TbPlanoCobranca]
(
    [Id] UNIQUEIDENTIFIER NOT NULL, 
    [Grupo_Veiculo_Id] UNIQUEIDENTIFIER NOT NULL, 
    [Diario_Diaria] DECIMAL(18, 2) NOT NULL, 
    [Diario_Por_Km] DECIMAL(18, 2) NOT NULL, 
    [Livre_Diaria] DECIMAL(18, 2) NOT NULL, 
    [Controlado_Diaria] DECIMAL(18, 2) NOT NULL, 
    [Controlado_Por_Km] DECIMAL(18, 2) NOT NULL, 
    [Controlado_Limite_Km] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [PK_TbPlanoCobranca] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TbPlanoCobranca_TbGrupoDeVeiculos] FOREIGN KEY ([Grupo_Veiculo_Id]) REFERENCES [TbGrupoVeiculo]([Id])
)
