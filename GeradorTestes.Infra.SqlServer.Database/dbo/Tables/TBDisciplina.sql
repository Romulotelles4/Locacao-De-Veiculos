CREATE TABLE [dbo].[TBDisciplina] (
    [Numero] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]   VARCHAR (100) NULL,
    CONSTRAINT [PK_TBDisciplina] PRIMARY KEY CLUSTERED ([Numero] ASC)
);

