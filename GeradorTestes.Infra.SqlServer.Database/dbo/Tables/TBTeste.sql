CREATE TABLE [dbo].[TBTeste] (
    [Numero]             INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]             VARCHAR (250) NOT NULL,
    [QuantidadeQuestoes] INT           NOT NULL,
    [DataGeracao]        DATETIME      NOT NULL,
    [Provao]             BIT           NOT NULL,
    [Materia_Numero]     INT           NULL,
    [Disciplina_Numero]  INT           NOT NULL,
    CONSTRAINT [PK_TBTeste] PRIMARY KEY CLUSTERED ([Numero] ASC),
    CONSTRAINT [FK_TBTeste_TBDisciplina] FOREIGN KEY ([Disciplina_Numero]) REFERENCES [dbo].[TBDisciplina] ([Numero]),
    CONSTRAINT [FK_TBTeste_TBMateria] FOREIGN KEY ([Materia_Numero]) REFERENCES [dbo].[TBMateria] ([Numero])
);

