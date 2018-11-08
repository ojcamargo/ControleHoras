
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/05/2016 15:01:20
-- Generated from EDMX file: C:\Users\fabio.candisani\Desktop\projeto\project_trunk\ControleHoras.DATA\Context\ControleHorasContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ControleHoras];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Alocacao_Lancamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lancamento] DROP CONSTRAINT [FK_Alocacao_Lancamento];
GO
IF OBJECT_ID(N'[dbo].[FK_Contrato_Alocacao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alocacao] DROP CONSTRAINT [FK_Contrato_Alocacao];
GO
IF OBJECT_ID(N'[dbo].[FK_Profissional_Alocacao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Alocacao] DROP CONSTRAINT [FK_Profissional_Alocacao];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_Contrato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contrato] DROP CONSTRAINT [FK_Cliente_Contrato];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_IP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteIp] DROP CONSTRAINT [FK_Cliente_IP];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_Local]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClienteLocal] DROP CONSTRAINT [FK_Cliente_Local];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Cliente_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Profissional_Dispositivo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfissionalDispositivo] DROP CONSTRAINT [FK_Profissional_Dispositivo];
GO
IF OBJECT_ID(N'[dbo].[FK_Profissional_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Profissional_Usuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Alocacao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alocacao];
GO
IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[ClienteIp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteIp];
GO
IF OBJECT_ID(N'[dbo].[ClienteLocal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClienteLocal];
GO
IF OBJECT_ID(N'[dbo].[Contrato]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contrato];
GO
IF OBJECT_ID(N'[dbo].[Lancamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lancamento];
GO
IF OBJECT_ID(N'[dbo].[Profissional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profissional];
GO
IF OBJECT_ID(N'[dbo].[ProfissionalDispositivo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfissionalDispositivo];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alocacao'
CREATE TABLE [dbo].[Alocacao] (
    [ContratoID] int  NOT NULL,
    [ProfissionalID] int  NOT NULL
);
GO

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [ClienteID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(30)  NOT NULL,
    [Ativo] bit  NOT NULL,
    [CNPJ] varchar(14)  NULL
);
GO

-- Creating table 'ClienteIp'
CREATE TABLE [dbo].[ClienteIp] (
    [ClienteIpID] int IDENTITY(1,1) NOT NULL,
    [ClienteID] int  NOT NULL,
    [Ip] varchar(15)  NOT NULL
);
GO

-- Creating table 'ClienteLocal'
CREATE TABLE [dbo].[ClienteLocal] (
    [LocalID] int IDENTITY(1,1) NOT NULL,
    [ClienteID] int  NOT NULL,
    [Logradouro] varchar(50)  NOT NULL,
    [NumeroLogradouro] varchar(10)  NULL,
    [Complemento] varchar(50)  NULL,
    [Bairro] varchar(50)  NOT NULL,
    [Cidade] varchar(50)  NOT NULL,
    [UF] char(2)  NOT NULL,
    [CEP] varchar(9)  NULL,
    [Longitude] float  NOT NULL,
    [Latitude] float  NOT NULL
);
GO

-- Creating table 'Contrato'
CREATE TABLE [dbo].[Contrato] (
    [ContratoID] int IDENTITY(1,1) NOT NULL,
    [ClienteID] int  NOT NULL,
    [NumeroReferencia] varchar(20)  NULL,
    [ModalidadeContrato] char(1)  NOT NULL,
    [ModalidadeApuracao] char(1)  NOT NULL,
    [QtdHorasMes] int  NULL,
    [ApuracaoHoraExtra] bit  NOT NULL,
    [ValorHoraExtra] decimal(19,4)  NULL,
    [DataCadastro] datetime  NULL,
    [DataInicio] datetime  NULL,
    [DataFim] datetime  NULL,
    [Descricao] varchar(50)  NULL,
    [Ativo] bit  NOT NULL,
    [ValorHora] decimal(19,4)  NULL,
    [HorarioEntrada] time  NULL,
    [HorarioSaida] time  NULL,
    [IntervaloInicio] time  NULL,
    [IntervaloFim] time  NULL,
    [ValidarLocalizacao] bit  NULL
);
GO

-- Creating table 'Lancamento'
CREATE TABLE [dbo].[Lancamento] (
    [LancamentoID] bigint IDENTITY(1,1) NOT NULL,
    [ContratoID] int  NOT NULL,
    [ProfissionalID] int  NOT NULL,
    [HorarioEntrada] datetime  NULL,
    [HorarioSaida] datetime  NULL,
    [Atividade] varchar(200)  NOT NULL,
    [LocalValidado] bit  NULL
);
GO

-- Creating table 'Profissional'
CREATE TABLE [dbo].[Profissional] (
    [ProfissionalID] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(50)  NOT NULL,
    [HorarioEntrada] time  NULL,
    [HorarioSaida] time  NULL,
    [ValorHora] decimal(19,4)  NULL,
    [ValorMensal] decimal(19,4)  NULL,
    [Ativo] bit  NOT NULL,
    [ModalidadeApuracao] char(1)  NOT NULL,
    [Regime] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'ProfissionalDispositivo'
CREATE TABLE [dbo].[ProfissionalDispositivo] (
    [ProfissionalDispositivoID] int IDENTITY(1,1) NOT NULL,
    [ProfissionalID] int  NOT NULL,
    [Imei] varchar(20)  NULL,
    [Telefone] varchar(20)  NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [UsuarioID] int IDENTITY(1,1) NOT NULL,
    [Login] varchar(20)  NOT NULL,
    [Senha] varchar(20)  NOT NULL,
    [ClienteID] int  NULL,
    [ProfissionalID] int  NULL,
    [Adm] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ContratoID], [ProfissionalID] in table 'Alocacao'
ALTER TABLE [dbo].[Alocacao]
ADD CONSTRAINT [PK_Alocacao]
    PRIMARY KEY CLUSTERED ([ContratoID], [ProfissionalID] ASC);
GO

-- Creating primary key on [ClienteID] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([ClienteID] ASC);
GO

-- Creating primary key on [ClienteIpID] in table 'ClienteIp'
ALTER TABLE [dbo].[ClienteIp]
ADD CONSTRAINT [PK_ClienteIp]
    PRIMARY KEY CLUSTERED ([ClienteIpID] ASC);
GO

-- Creating primary key on [LocalID] in table 'ClienteLocal'
ALTER TABLE [dbo].[ClienteLocal]
ADD CONSTRAINT [PK_ClienteLocal]
    PRIMARY KEY CLUSTERED ([LocalID] ASC);
GO

-- Creating primary key on [ContratoID] in table 'Contrato'
ALTER TABLE [dbo].[Contrato]
ADD CONSTRAINT [PK_Contrato]
    PRIMARY KEY CLUSTERED ([ContratoID] ASC);
GO

-- Creating primary key on [LancamentoID] in table 'Lancamento'
ALTER TABLE [dbo].[Lancamento]
ADD CONSTRAINT [PK_Lancamento]
    PRIMARY KEY CLUSTERED ([LancamentoID] ASC);
GO

-- Creating primary key on [ProfissionalID] in table 'Profissional'
ALTER TABLE [dbo].[Profissional]
ADD CONSTRAINT [PK_Profissional]
    PRIMARY KEY CLUSTERED ([ProfissionalID] ASC);
GO

-- Creating primary key on [ProfissionalDispositivoID] in table 'ProfissionalDispositivo'
ALTER TABLE [dbo].[ProfissionalDispositivo]
ADD CONSTRAINT [PK_ProfissionalDispositivo]
    PRIMARY KEY CLUSTERED ([ProfissionalDispositivoID] ASC);
GO

-- Creating primary key on [UsuarioID] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([UsuarioID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ContratoID], [ProfissionalID] in table 'Lancamento'
ALTER TABLE [dbo].[Lancamento]
ADD CONSTRAINT [FK_Alocacao_Lancamento]
    FOREIGN KEY ([ContratoID], [ProfissionalID])
    REFERENCES [dbo].[Alocacao]
        ([ContratoID], [ProfissionalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Alocacao_Lancamento'
CREATE INDEX [IX_FK_Alocacao_Lancamento]
ON [dbo].[Lancamento]
    ([ContratoID], [ProfissionalID]);
GO

-- Creating foreign key on [ContratoID] in table 'Alocacao'
ALTER TABLE [dbo].[Alocacao]
ADD CONSTRAINT [FK_Contrato_Alocacao]
    FOREIGN KEY ([ContratoID])
    REFERENCES [dbo].[Contrato]
        ([ContratoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProfissionalID] in table 'Alocacao'
ALTER TABLE [dbo].[Alocacao]
ADD CONSTRAINT [FK_Profissional_Alocacao]
    FOREIGN KEY ([ProfissionalID])
    REFERENCES [dbo].[Profissional]
        ([ProfissionalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Profissional_Alocacao'
CREATE INDEX [IX_FK_Profissional_Alocacao]
ON [dbo].[Alocacao]
    ([ProfissionalID]);
GO

-- Creating foreign key on [ClienteID] in table 'Contrato'
ALTER TABLE [dbo].[Contrato]
ADD CONSTRAINT [FK_Cliente_Contrato]
    FOREIGN KEY ([ClienteID])
    REFERENCES [dbo].[Cliente]
        ([ClienteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Contrato'
CREATE INDEX [IX_FK_Cliente_Contrato]
ON [dbo].[Contrato]
    ([ClienteID]);
GO

-- Creating foreign key on [ClienteID] in table 'ClienteIp'
ALTER TABLE [dbo].[ClienteIp]
ADD CONSTRAINT [FK_Cliente_IP]
    FOREIGN KEY ([ClienteID])
    REFERENCES [dbo].[Cliente]
        ([ClienteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_IP'
CREATE INDEX [IX_FK_Cliente_IP]
ON [dbo].[ClienteIp]
    ([ClienteID]);
GO

-- Creating foreign key on [ClienteID] in table 'ClienteLocal'
ALTER TABLE [dbo].[ClienteLocal]
ADD CONSTRAINT [FK_Cliente_Local]
    FOREIGN KEY ([ClienteID])
    REFERENCES [dbo].[Cliente]
        ([ClienteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Local'
CREATE INDEX [IX_FK_Cliente_Local]
ON [dbo].[ClienteLocal]
    ([ClienteID]);
GO

-- Creating foreign key on [ClienteID] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_Cliente_Usuario]
    FOREIGN KEY ([ClienteID])
    REFERENCES [dbo].[Cliente]
        ([ClienteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Usuario'
CREATE INDEX [IX_FK_Cliente_Usuario]
ON [dbo].[Usuario]
    ([ClienteID]);
GO

-- Creating foreign key on [ProfissionalID] in table 'ProfissionalDispositivo'
ALTER TABLE [dbo].[ProfissionalDispositivo]
ADD CONSTRAINT [FK_Profissional_Dispositivo]
    FOREIGN KEY ([ProfissionalID])
    REFERENCES [dbo].[Profissional]
        ([ProfissionalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Profissional_Dispositivo'
CREATE INDEX [IX_FK_Profissional_Dispositivo]
ON [dbo].[ProfissionalDispositivo]
    ([ProfissionalID]);
GO

-- Creating foreign key on [ProfissionalID] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [FK_Profissional_Usuario]
    FOREIGN KEY ([ProfissionalID])
    REFERENCES [dbo].[Profissional]
        ([ProfissionalID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Profissional_Usuario'
CREATE INDEX [IX_FK_Profissional_Usuario]
ON [dbo].[Usuario]
    ([ProfissionalID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------


select * from Profissional