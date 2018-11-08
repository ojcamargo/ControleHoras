USE [master]
GO
/****** Object:  Database [ControleHoras]    Script Date: 08/23/2016 17:02:30 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'ControleHoras')
BEGIN
CREATE DATABASE [ControleHoras] ON  PRIMARY 
( NAME = N'ControleHoras', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008R2\MSSQL\DATA\ControleHoras.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ControleHoras_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQL2008R2\MSSQL\DATA\ControleHoras_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [ControleHoras] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ControleHoras].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ControleHoras] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ControleHoras] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ControleHoras] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ControleHoras] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ControleHoras] SET ARITHABORT OFF
GO
ALTER DATABASE [ControleHoras] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ControleHoras] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ControleHoras] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ControleHoras] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ControleHoras] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ControleHoras] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ControleHoras] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ControleHoras] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ControleHoras] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ControleHoras] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ControleHoras] SET  DISABLE_BROKER
GO
ALTER DATABASE [ControleHoras] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ControleHoras] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ControleHoras] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ControleHoras] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ControleHoras] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ControleHoras] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ControleHoras] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ControleHoras] SET  READ_WRITE
GO
ALTER DATABASE [ControleHoras] SET RECOVERY FULL
GO
ALTER DATABASE [ControleHoras] SET  MULTI_USER
GO
ALTER DATABASE [ControleHoras] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ControleHoras] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ControleHoras', N'ON'
GO
USE [ControleHoras]
GO
/****** Object:  ForeignKey [FK_Cliente_Usuario]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Cliente_Usuario]
GO
/****** Object:  ForeignKey [FK_Profissional_Usuario]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Profissional_Usuario]
GO
/****** Object:  ForeignKey [FK_Profissional_Dispositivo]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Dispositivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProfissionalDispositivo]'))
ALTER TABLE [dbo].[ProfissionalDispositivo] DROP CONSTRAINT [FK_Profissional_Dispositivo]
GO
/****** Object:  ForeignKey [FK_Cliente_Contrato]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Contrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] DROP CONSTRAINT [FK_Cliente_Contrato]
GO
/****** Object:  ForeignKey [FK_Cliente_Local]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Local]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClienteLocal]'))
ALTER TABLE [dbo].[ClienteLocal] DROP CONSTRAINT [FK_Cliente_Local]
GO
/****** Object:  ForeignKey [FK_Cliente_IP]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_IP]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClienteIp]'))
ALTER TABLE [dbo].[ClienteIp] DROP CONSTRAINT [FK_Cliente_IP]
GO
/****** Object:  ForeignKey [FK_Contrato_Alocacao]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contrato_Alocacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alocacao]'))
ALTER TABLE [dbo].[Alocacao] DROP CONSTRAINT [FK_Contrato_Alocacao]
GO
/****** Object:  ForeignKey [FK_Profissional_Alocacao]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Alocacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alocacao]'))
ALTER TABLE [dbo].[Alocacao] DROP CONSTRAINT [FK_Profissional_Alocacao]
GO
/****** Object:  ForeignKey [FK_Alocacao_Lancamento]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Alocacao_Lancamento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Lancamento]'))
ALTER TABLE [dbo].[Lancamento] DROP CONSTRAINT [FK_Alocacao_Lancamento]
GO
/****** Object:  Check [CK_ProfissionalModalidadeApuracao]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ProfissionalModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Profissional]'))
BEGIN
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ProfissionalModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Profissional]'))
ALTER TABLE [dbo].[Profissional] DROP CONSTRAINT [CK_ProfissionalModalidadeApuracao]

END
GO
/****** Object:  Check [CK_ContratoModalidadeApuracao]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
BEGIN
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] DROP CONSTRAINT [CK_ContratoModalidadeApuracao]

END
GO
/****** Object:  Check [CK_ContratoModalidadeContrato]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeContrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
BEGIN
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeContrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] DROP CONSTRAINT [CK_ContratoModalidadeContrato]

END
GO
/****** Object:  Table [dbo].[Lancamento]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Alocacao_Lancamento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Lancamento]'))
ALTER TABLE [dbo].[Lancamento] DROP CONSTRAINT [FK_Alocacao_Lancamento]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lancamento]') AND type in (N'U'))
DROP TABLE [dbo].[Lancamento]
GO
/****** Object:  Table [dbo].[Alocacao]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contrato_Alocacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alocacao]'))
ALTER TABLE [dbo].[Alocacao] DROP CONSTRAINT [FK_Contrato_Alocacao]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Alocacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alocacao]'))
ALTER TABLE [dbo].[Alocacao] DROP CONSTRAINT [FK_Profissional_Alocacao]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Alocacao]') AND type in (N'U'))
DROP TABLE [dbo].[Alocacao]
GO
/****** Object:  Table [dbo].[ClienteIp]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_IP]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClienteIp]'))
ALTER TABLE [dbo].[ClienteIp] DROP CONSTRAINT [FK_Cliente_IP]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClienteIp]') AND type in (N'U'))
DROP TABLE [dbo].[ClienteIp]
GO
/****** Object:  Table [dbo].[ClienteLocal]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Local]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClienteLocal]'))
ALTER TABLE [dbo].[ClienteLocal] DROP CONSTRAINT [FK_Cliente_Local]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClienteLocal]') AND type in (N'U'))
DROP TABLE [dbo].[ClienteLocal]
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Contrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] DROP CONSTRAINT [FK_Cliente_Contrato]
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] DROP CONSTRAINT [CK_ContratoModalidadeApuracao]
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeContrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] DROP CONSTRAINT [CK_ContratoModalidadeContrato]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contrato]') AND type in (N'U'))
DROP TABLE [dbo].[Contrato]
GO
/****** Object:  Table [dbo].[ProfissionalDispositivo]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Dispositivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProfissionalDispositivo]'))
ALTER TABLE [dbo].[ProfissionalDispositivo] DROP CONSTRAINT [FK_Profissional_Dispositivo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProfissionalDispositivo]') AND type in (N'U'))
DROP TABLE [dbo].[ProfissionalDispositivo]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Cliente_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK_Profissional_Usuario]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Profissional]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ProfissionalModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Profissional]'))
ALTER TABLE [dbo].[Profissional] DROP CONSTRAINT [CK_ProfissionalModalidadeApuracao]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Profissional]') AND type in (N'U'))
DROP TABLE [dbo].[Profissional]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 08/23/2016 17:02:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
DROP TABLE [dbo].[Cliente]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cliente](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[CNPJ] [varchar](14) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND name = N'IX_ClienteNome')
CREATE UNIQUE NONCLUSTERED INDEX [IX_ClienteNome] ON [dbo].[Cliente] 
(
	[Nome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON
INSERT [dbo].[Cliente] ([ClienteID], [Nome], [Ativo], [CNPJ]) VALUES (1, N'Computecnica', 1, N'07107637000152')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
/****** Object:  Table [dbo].[Profissional]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Profissional]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Profissional](
	[ProfissionalID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[HorarioEntrada] [time](7) NULL,
	[HorarioSaida] [time](7) NULL,
	[ValorHora] [money] NULL,
	[ValorMensal] [money] NULL,
	[Ativo] [bit] NOT NULL,
	[ModalidadeApuracao] [char](1) NOT NULL,
 CONSTRAINT [PK__Profissi__C7415A8D5535A963] PRIMARY KEY CLUSTERED 
(
	[ProfissionalID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_ProfissionalNome] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Profissional] ON
INSERT [dbo].[Profissional] ([ProfissionalID], [Nome], [HorarioEntrada], [HorarioSaida], [ValorHora], [ValorMensal], [Ativo], [ModalidadeApuracao]) VALUES (1, N'Otavio', CAST(0x070010ACD1530000 AS Time), CAST(0x0700B893419F0000 AS Time), 10.0000, NULL, 0, N'A')
SET IDENTITY_INSERT [dbo].[Profissional] OFF
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Senha] [varchar](20) NOT NULL,
	[ClienteID] [int] NULL,
	[ProfissionalID] [int] NULL,
	[Adm] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_UsuarioLogin] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([UsuarioID], [Login], [Senha], [ClienteID], [ProfissionalID], [Adm]) VALUES (1, N'otavio.camargo', N'123', 1, 1, 0)
INSERT [dbo].[Usuario] ([UsuarioID], [Login], [Senha], [ClienteID], [ProfissionalID], [Adm]) VALUES (3, N'cpt', N'cpt', 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Table [dbo].[ProfissionalDispositivo]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProfissionalDispositivo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProfissionalDispositivo](
	[ProfissionalDispositivoID] [int] IDENTITY(1,1) NOT NULL,
	[ProfissionalID] [int] NOT NULL,
	[Imei] [varchar](20) NULL,
	[Telefone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfissionalDispositivoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contrato]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contrato](
	[ContratoID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NOT NULL,
	[NumeroReferencia] [varchar](20) NULL,
	[ModalidadeContrato] [char](1) NOT NULL,
	[ModalidadeApuracao] [char](1) NOT NULL,
	[QtdHorasMes] [int] NULL,
	[ApuracaoHoraExtra] [bit] NOT NULL,
	[ValorHoraExtra] [money] NULL,
	[DataCadastro] [datetime] NULL,
	[DataInicio] [datetime] NULL,
	[DataFim] [datetime] NULL,
	[Descricao] [varchar](50) NULL,
	[Ativo] [bit] NOT NULL,
	[ValorHora] [money] NULL,
	[HorarioEntrada] [time](7) NULL,
	[HorarioSaida] [time](7) NULL,
	[IntervaloInicio] [time](7) NULL,
	[IntervaloFim] [time](7) NULL,
	[ValidarLocalizacao] [bit] NULL,
 CONSTRAINT [PK__Contrato__B238E9535DCAEF64] PRIMARY KEY CLUSTERED 
(
	[ContratoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Contrato]') AND name = N'IX_ContratoNumeroReferencia')
CREATE UNIQUE NONCLUSTERED INDEX [IX_ContratoNumeroReferencia] ON [dbo].[Contrato] 
(
	[NumeroReferencia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteLocal]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClienteLocal]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClienteLocal](
	[LocalID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NOT NULL,
	[Logradouro] [varchar](50) NOT NULL,
	[NumeroLogradouro] [varchar](10) NULL,
	[Complemento] [varchar](50) NULL,
	[Bairro] [varchar](50) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[UF] [char](2) NOT NULL,
	[CEP] [varchar](9) NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LocalID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClienteIp]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClienteIp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClienteIp](
	[ClienteIpID] [int] IDENTITY(1,1) NOT NULL,
	[ClienteID] [int] NOT NULL,
	[Ip] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteIpID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Alocacao]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Alocacao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Alocacao](
	[ContratoID] [int] NOT NULL,
	[ProfissionalID] [int] NOT NULL,
 CONSTRAINT [PK_Alocacao] PRIMARY KEY CLUSTERED 
(
	[ContratoID] ASC,
	[ProfissionalID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Table [dbo].[Lancamento]    Script Date: 08/23/2016 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lancamento]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lancamento](
	[LancamentoID] [bigint] IDENTITY(1,1) NOT NULL,
	[ContratoID] [int] NOT NULL,
	[ProfissionalID] [int] NOT NULL,
	[HorarioEntrada] [datetime] NULL,
	[HorarioSaida] [datetime] NULL,
	[Atividade] [varchar](200) NOT NULL,
	[LocalValidado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LancamentoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Check [CK_ProfissionalModalidadeApuracao]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ProfissionalModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Profissional]'))
ALTER TABLE [dbo].[Profissional]  WITH CHECK ADD  CONSTRAINT [CK_ProfissionalModalidadeApuracao] CHECK  (([ModalidadeApuracao]='A' OR [ModalidadeApuracao]='F'))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ProfissionalModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Profissional]'))
ALTER TABLE [dbo].[Profissional] CHECK CONSTRAINT [CK_ProfissionalModalidadeApuracao]
GO
/****** Object:  Check [CK_ContratoModalidadeApuracao]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [CK_ContratoModalidadeApuracao] CHECK  (([ModalidadeApuracao]='A' OR [ModalidadeApuracao]='F'))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeApuracao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [CK_ContratoModalidadeApuracao]
GO
/****** Object:  Check [CK_ContratoModalidadeContrato]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeContrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [CK_ContratoModalidadeContrato] CHECK  (([ModalidadeContrato]='A' OR [ModalidadeContrato]='P'))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_ContratoModalidadeContrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [CK_ContratoModalidadeContrato]
GO
/****** Object:  ForeignKey [FK_Cliente_Usuario]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
/****** Object:  ForeignKey [FK_Profissional_Usuario]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Profissional_Usuario] FOREIGN KEY([ProfissionalID])
REFERENCES [dbo].[Profissional] ([ProfissionalID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Usuario]'))
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Profissional_Usuario]
GO
/****** Object:  ForeignKey [FK_Profissional_Dispositivo]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Dispositivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProfissionalDispositivo]'))
ALTER TABLE [dbo].[ProfissionalDispositivo]  WITH CHECK ADD  CONSTRAINT [FK_Profissional_Dispositivo] FOREIGN KEY([ProfissionalID])
REFERENCES [dbo].[Profissional] ([ProfissionalID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Dispositivo]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProfissionalDispositivo]'))
ALTER TABLE [dbo].[ProfissionalDispositivo] CHECK CONSTRAINT [FK_Profissional_Dispositivo]
GO
/****** Object:  ForeignKey [FK_Cliente_Contrato]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Contrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Contrato] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Contrato]') AND parent_object_id = OBJECT_ID(N'[dbo].[Contrato]'))
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Cliente_Contrato]
GO
/****** Object:  ForeignKey [FK_Cliente_Local]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Local]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClienteLocal]'))
ALTER TABLE [dbo].[ClienteLocal]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Local] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_Local]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClienteLocal]'))
ALTER TABLE [dbo].[ClienteLocal] CHECK CONSTRAINT [FK_Cliente_Local]
GO
/****** Object:  ForeignKey [FK_Cliente_IP]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_IP]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClienteIp]'))
ALTER TABLE [dbo].[ClienteIp]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_IP] FOREIGN KEY([ClienteID])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cliente_IP]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClienteIp]'))
ALTER TABLE [dbo].[ClienteIp] CHECK CONSTRAINT [FK_Cliente_IP]
GO
/****** Object:  ForeignKey [FK_Contrato_Alocacao]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contrato_Alocacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alocacao]'))
ALTER TABLE [dbo].[Alocacao]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Alocacao] FOREIGN KEY([ContratoID])
REFERENCES [dbo].[Contrato] ([ContratoID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Contrato_Alocacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alocacao]'))
ALTER TABLE [dbo].[Alocacao] CHECK CONSTRAINT [FK_Contrato_Alocacao]
GO
/****** Object:  ForeignKey [FK_Profissional_Alocacao]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Alocacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alocacao]'))
ALTER TABLE [dbo].[Alocacao]  WITH CHECK ADD  CONSTRAINT [FK_Profissional_Alocacao] FOREIGN KEY([ProfissionalID])
REFERENCES [dbo].[Profissional] ([ProfissionalID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Profissional_Alocacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Alocacao]'))
ALTER TABLE [dbo].[Alocacao] CHECK CONSTRAINT [FK_Profissional_Alocacao]
GO
/****** Object:  ForeignKey [FK_Alocacao_Lancamento]    Script Date: 08/23/2016 17:02:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Alocacao_Lancamento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Lancamento]'))
ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD  CONSTRAINT [FK_Alocacao_Lancamento] FOREIGN KEY([ContratoID], [ProfissionalID])
REFERENCES [dbo].[Alocacao] ([ContratoID], [ProfissionalID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Alocacao_Lancamento]') AND parent_object_id = OBJECT_ID(N'[dbo].[Lancamento]'))
ALTER TABLE [dbo].[Lancamento] CHECK CONSTRAINT [FK_Alocacao_Lancamento]
GO
