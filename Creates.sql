CREATE TABLE [dbo].[Instituicao] (
    [Id]          INT            NOT NULL,
    [Tipo]        NVARCHAR (20)  NOT NULL,
    [Nome]        NVARCHAR (50)  NOT NULL,
    [Email]       NVARCHAR (80)  NOT NULL,
    [Telefone]    INT            NOT NULL,
    [Cidade]      NVARCHAR (50)  NOT NULL,
    [Morada]      NVARCHAR (100) NOT NULL,
    [Classificao] FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_Instituicao] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Servicos] (
    [Id]             INT            NOT NULL,
    [Tipo]           NVARCHAR (50)  NOT NULL,
    [Descricao]      NVARCHAR (100) NOT NULL,
    [Preco]          FLOAT          NOT NULL,
    [Vagas]          INT            NOT NULL,
    [Ocupadas]       INT,
    [Id_Instituicao] INT            NOT NULL,
    CONSTRAINT [PK_Servicos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Servicos_Instituicao] FOREIGN KEY ([Id_Instituicao]) REFERENCES [dbo].[Instituicao] ([Id])
);

CREATE TABLE [dbo].[Anuncios] (
    [Id]        INT            NOT NULL,
    [Titulo]    NVARCHAR (50)  NOT NULL,
    [Descricao] NVARCHAR (200) NOT NULL,
    [Data]      DATE           NOT NULL,
    [Id_Instituicao] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Anuncios_Instituicao] FOREIGN KEY ([Id_Instituicao]) REFERENCES [Instituicao]([Id])
);

CREATE TABLE [dbo].[Pais] (
    [Id]        INT           NOT NULL,
    [Nome]      NVARCHAR (80) NOT NULL,
    [Cc]        INT           NOT NULL,
    [Nif]       INT           NOT NULL,
    [Telemovel] INT           NOT NULL,
    [Email]     NVARCHAR (80) NOT NULL,
    CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Resposta] (
    [Id]             INT            NOT NULL,
    [Descricao]      NVARCHAR (100) NOT NULL,
    [Id_Instituicao] INT            NOT NULL,
    CONSTRAINT [PK_Resposta] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Resposta_Instituicao] FOREIGN KEY ([Id_Instituicao]) REFERENCES [dbo].[Instituicao] ([Id])
);

CREATE TABLE [dbo].[Avaliacao] (
    [Id]          INT NOT NULL,
    [Preco]       INT NOT NULL,
    [Localizacao] INT NOT NULL,
    [Ambiente]    INT NOT NULL,
    [NotaGeral]   INT NOT NULL,
    [Id_Pais]     INT NOT NULL,
    [Id_Servico]  INT NOT NULL,
    CONSTRAINT [PK_Avaliacao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Avaliacao_Pais] FOREIGN KEY ([Id_Pais]) REFERENCES [dbo].[Pais] ([Id]),
    CONSTRAINT [FK_Avaliacao_Servico] FOREIGN KEY ([Id_Servico]) REFERENCES [dbo].[Servicos] ([Id])
);

CREATE TABLE [dbo].[Pedido] (
    [Id]          INT NOT NULL,
    [Id_Pais]     INT NOT NULL,
    [Id_Anuncios] INT NOT NULL,
    [Id_Resposta] INT NULL,
    CONSTRAINT [FK_Pedido_Anuncios] FOREIGN KEY ([Id_Anuncios]) REFERENCES [dbo].[Anuncios] ([Id]),
    CONSTRAINT [FK_Pedido_Pais] FOREIGN KEY ([Id_Pais]) REFERENCES [dbo].[Pais] ([Id]),
    CONSTRAINT [FK_Pedido_Resposta] FOREIGN KEY ([Id_Resposta]) REFERENCES [dbo].[Resposta] ([Id]),
    CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED ([Id] ASC)
);

