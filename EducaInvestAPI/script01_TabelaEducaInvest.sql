IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Perfil] int NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Nome] nvarchar(30) NOT NULL,
    [Sobrenome] nvarchar(100) NOT NULL,
    [CPF] nvarchar(11) NOT NULL,
    [Telefone] nvarchar(11) NOT NULL,
    [LinkSocial] nvarchar(255) NOT NULL,
    [Cidade] nvarchar(100) NOT NULL,
    [UF] int NOT NULL,
    [DataAcesso] datetime2 NULL,
    [FileBytes] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_PROJETOS] (
    [Id] int NOT NULL IDENTITY,
    [StatusProjeto] int NOT NULL,
    [NomeProjeto] nvarchar(30) NOT NULL,
    [Subtitulo] nvarchar(65) NOT NULL,
    [DescricaoProjeto] nvarchar(255) NOT NULL,
    [CustoProjeto] decimal(18,2) NOT NULL,
    [Investido] bit NOT NULL,
    [DataPublicacao] datetime2 NOT NULL,
    [UsuarioId] int NOT NULL,
    [CronogramaId] int NOT NULL,
    [FileBytes] nvarchar(max) NULL,
    CONSTRAINT [PK_TB_PROJETOS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_PROJETOS_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_CRONOGRAMAS] (
    [Id] int NOT NULL IDENTITY,
    [ProjetoId] int NOT NULL,
    CONSTRAINT [PK_TB_CRONOGRAMAS] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_CRONOGRAMAS_TB_PROJETOS_ProjetoId] FOREIGN KEY ([ProjetoId]) REFERENCES [TB_PROJETOS] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_ATIVIDADES] (
    [Id] int NOT NULL IDENTITY,
    [DescricaoAtividade] nvarchar(200) NOT NULL,
    [StatusAtividade] int NOT NULL,
    [DataInicioAtividade] datetime2 NOT NULL,
    [DataTerminoAtividade] datetime2 NOT NULL,
    [Percentual] decimal(18,2) NOT NULL,
    [CronogramaId] int NOT NULL,
    CONSTRAINT [PK_TB_ATIVIDADES] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_ATIVIDADES_TB_CRONOGRAMAS_CronogramaId] FOREIGN KEY ([CronogramaId]) REFERENCES [TB_CRONOGRAMAS] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CPF', N'Cidade', N'DataAcesso', N'Email', N'FileBytes', N'LinkSocial', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Sobrenome', N'Telefone', N'UF') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [CPF], [Cidade], [DataAcesso], [Email], [FileBytes], [LinkSocial], [Nome], [PasswordHash], [PasswordSalt], [Perfil], [Sobrenome], [Telefone], [UF])
VALUES (1, N'', N'', '2024-06-17T03:25:14.8145501-03:00', N'educainvest.co@gmail.com', NULL, N'', N'', 0x9584BC658079103A423692F82AC36EBB8D407C97547DD24ACC4AB3C069892DA378DE80ACDD4CA7FCE5C8B3B93EC0B48F0D8CBE85AA6CE39AB5F59D1EE8C442ED, 0x34517CBFBD233A0FA096AD348DC8C2589825EF4C403B460DBECB09614F6459F47723191760E0900DEBE0273ED25318AA4C21403BBC9AE20095C57CE79E3E5A0DF057881A7612B5CD8C5476DBE31529DE04A0CC7518EEECC64534B7828B6BAEDC9873C2B66F0A138BBDA07C46A5BFAA283F0F6122E03C94F949DE846DB951EDBC, 1, N'', N'', 6);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CPF', N'Cidade', N'DataAcesso', N'Email', N'FileBytes', N'LinkSocial', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Sobrenome', N'Telefone', N'UF') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

CREATE INDEX [IX_TB_ATIVIDADES_CronogramaId] ON [TB_ATIVIDADES] ([CronogramaId]);
GO

CREATE UNIQUE INDEX [IX_TB_CRONOGRAMAS_ProjetoId] ON [TB_CRONOGRAMAS] ([ProjetoId]);
GO

CREATE INDEX [IX_TB_PROJETOS_UsuarioId] ON [TB_PROJETOS] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240617062515_FullDatabase', N'8.0.6');
GO

COMMIT;
GO

