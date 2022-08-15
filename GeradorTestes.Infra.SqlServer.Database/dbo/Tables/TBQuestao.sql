CREATE TABLE [dbo].[TBQuestao] (
    [Numero]         INT           IDENTITY (1, 1) NOT NULL,
    [Enunciado]      VARCHAR (500) NOT NULL,
    [Materia_Numero] INT           NOT NULL,
    CONSTRAINT [PK_TBQuestao] PRIMARY KEY CLUSTERED ([Numero] ASC),
    CONSTRAINT [FK_TBQuestao_TBMateria] FOREIGN KEY ([Materia_Numero]) REFERENCES [dbo].[TBMateria] ([Numero])
);

