CREATE TABLE [dbo].[TBAlternativa] (
    [Numero]         INT           IDENTITY (1, 1) NOT NULL,
    [Letra]          CHAR (1)      NOT NULL,
    [Resposta]       VARCHAR (100) NOT NULL,
    [Correta]        BIT           NOT NULL,
    [Questao_Numero] INT           NOT NULL,
    CONSTRAINT [PK_TBAlternativa] PRIMARY KEY CLUSTERED ([Numero] ASC),
    CONSTRAINT [FK_TBAlternativa_TBQuestao] FOREIGN KEY ([Questao_Numero]) REFERENCES [dbo].[TBQuestao] ([Numero])
);

