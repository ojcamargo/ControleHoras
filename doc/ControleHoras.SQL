USE ControleHoras
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Lancamentos') AND XTYPE = 'U')
	DROP TABLE Lancamentos
GO
IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Alocacao') AND XTYPE = 'U')
	DROP TABLE Alocacao
GO
IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Contrato') AND XTYPE = 'U')
	DROP TABLE Contrato
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Usuario') AND XTYPE = 'U')
	DROP TABLE Usuario
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('ProfissionalDispositivo') AND XTYPE = 'U')
	DROP TABLE ProfissionalDispositivo
GO
IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Profissional') AND XTYPE = 'U')
	DROP TABLE Profissional
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('ClienteLocal') AND XTYPE = 'U')
	DROP TABLE ClienteLocal
GO
IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('ClienteIp') AND XTYPE = 'U')
	DROP TABLE ClienteIp
GO
IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Cliente') AND XTYPE = 'U')
	DROP TABLE Cliente
GO


CREATE TABLE Cliente ( 
	ClienteID int identity(1,1) primary key,
	Nome varchar(30) NOT NULL,
	Ativo bit NOT NULL,
	CNPJ varchar(14)
)
;

CREATE TABLE ClienteLocal ( 
	LocalID int identity(1,1) primary key,
	ClienteID int NOT NULL,
	Logradouro varchar(50) NOT NULL,
	NumeroLogradouro varchar(10),
	Complemento varchar(50),
	Bairro varchar(50) NOT NULL,
	Cidade varchar(50) NOT NULL,
	UF char(2) NOT NULL,
	CEP varchar(8),
	Longitude float NOT NULL,
	Latitude float NOT NULL,
	CONSTRAINT FK_Cliente_Local foreign key (ClienteID) references Cliente (ClienteID)
)
;

CREATE TABLE ClienteIp ( 
	ClienteIpID int identity(1,1) primary key,
	ClienteID int NOT NULL,
	Ip varchar(15) NOT NULL,
	CONSTRAINT FK_Cliente_IP foreign key (ClienteID) references Cliente (ClienteID)
)
;


CREATE TABLE Profissional ( 
	ProfissionalID int identity(1,1) primary key,
	Nome varbinary(50) NOT NULL,
	HorarioEntrada time,
	HorarioSaida time,
	ValorHora money,
	ValorMensal money,
	Ativo bit NOT NULL,
	ModalidadeApuracao char(1) NOT NULL
)
;


CREATE TABLE ProfissionalDispositivo ( 
	ProfissionalDispositivoID int identity(1,1) primary key,
	ProfissionalID int NOT NULL,
	Imei bigint NOT NULL,
	Telefone varchar(11),
	CONSTRAINT FK_Profissional_Dispositivo foreign key (ProfissionalID) references Profissional (ProfissionalID)
)
;


CREATE TABLE Contrato ( 
	ContratoID int identity(1,1) primary key,
	ClienteID int NOT NULL,
	NumeroReferencia varchar(50) NOT NULL,
	ModalidadeContrato char(1) NOT NULL,
	ModalidadeApuracao char(1) NOT NULL,
	QtdHorasMes int,
	ApuracaoHoraExtra bit NOT NULL,
	ValorHoraExtra money,
	DataCadastro datetime,
	DataInicio datetime,
	DataFim datetime,
	Descricao varchar(50),
	Ativo bit NOT NULL,
	ValorHora money,
	HorarioEntrada time,
	HorarioSaida time,
	Intervalo time,
	ValidarLocalizacao bit,
	CONSTRAINT FK_Cliente_Contrato foreign key (ClienteID) references Cliente (ClienteID)
)
;

CREATE TABLE Alocacao ( 
	ContratoID int NOT NULL,
	ProfissionalID int NOT NULL,
	CONSTRAINT PK_Alocacao primary key (ContratoID, ProfissionalID),
	CONSTRAINT FK_Profissional_Alocacao foreign key (ProfissionalID) references Profissional (ProfissionalID),
	CONSTRAINT FK_Contrato_Alocacao foreign key (ContratoID) references Contrato (ContratoID)
)
;

CREATE TABLE Lancamentos ( 
	LancamentoID bigint identity(1,1) primary key,
	ContratoID int NOT NULL,
	ProfissionalID int NOT NULL,
	HorarioEntrada datetime,
	HorarioSaida datetime,
	Atividade varchar(200) NOT NULL,
	LocalValidado bit,
	CONSTRAINT FK_Alocacao_Lancamento foreign key (ContratoID, ProfissionalID) references Alocacao (ContratoID, ProfissionalID)
)
;

CREATE TABLE Usuario ( 
	UsuarioID int identity(1,1) primary key,
	[Login] varchar(20) NOT NULL,
	Senha varchar(20) NOT NULL,
	ClienteID int,
	ProfissionalID int,
	Adm bit,
	CONSTRAINT FK_Profissional_Usuario foreign key (ProfissionalID) references Profissional (ProfissionalID),
	CONSTRAINT FK_Cliente_Usuario foreign key (ClienteID) references Cliente (ClienteID)
)
;
