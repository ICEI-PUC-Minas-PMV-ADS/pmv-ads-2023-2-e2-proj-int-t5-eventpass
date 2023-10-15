CREATE TABLE [Evento] (
    [IdEvento] int NOT NULL IDENTITY,
    [nomeEvento] nvarchar(max) NOT NULL,
    [dataHora] datetime2 NOT NULL,
    [totalIngressos] int NOT NULL,
    [uf] nvarchar(max) NULL,
    [cidade] nvarchar(max) NULL,
    [bairro] nvarchar(max) NULL,
    [cep] nvarchar(max) NOT NULL,
    [numero] int NOT NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY ([IdEvento])
);
GO


CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [NomeUsuario] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [ConfirmarSenha] nvarchar(max) NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO


