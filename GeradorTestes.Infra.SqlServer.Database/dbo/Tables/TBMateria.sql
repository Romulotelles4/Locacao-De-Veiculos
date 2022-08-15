CREATE TABLE [dbo].[TBMateria] (
    [Numero]            INT           IDENTITY (1, 1) NOT NULL,
    [Nome]              VARCHAR (100) NOT NULL,
    [Serie]             INT           NOT NULL,
    [Disciplina_Numero] INT           NULL,
    CONSTRAINT [PK_TBMateria] PRIMARY KEY CLUSTERED ([Numero] ASC),
    CONSTRAINT [FK_TBMateria_TBDisiplina] FOREIGN KEY ([Disciplina_Numero]) REFERENCES [dbo].[TBDisciplina] ([Numero])
);

