CREATE TABLE [dbo].[TBTeste_TBQuestao] (
    [Teste_Numero]   INT NOT NULL,
    [Questao_Numero] INT NOT NULL,
    CONSTRAINT [FK_TBTeste_TBQuestaoTBTeste] FOREIGN KEY ([Teste_Numero]) REFERENCES [dbo].[TBTeste] ([Numero]),
    CONSTRAINT [FK_TBTesteTBQuestao_TBQuestao] FOREIGN KEY ([Questao_Numero]) REFERENCES [dbo].[TBQuestao] ([Numero])
);

