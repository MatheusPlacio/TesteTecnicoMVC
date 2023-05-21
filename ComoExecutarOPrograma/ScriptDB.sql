CREATE DATABASE TesteMVC;

USE [TesteMVC]
GO

/****** Object:  Table [dbo].[Pacientes]    Script Date: 21/05/2023 20:15:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pacientes](
	[PacienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](30) NOT NULL,
	[SobreNome] [nvarchar](100) NOT NULL,
	[DataDeNascimento] [datetime2](7) NOT NULL,
	[Genero] [nvarchar](30) NOT NULL,
	[CPF] [nvarchar](11) NULL,
	[RG] [nvarchar](14) NOT NULL,
	[UF_RG] [nvarchar](30) NOT NULL,
	[Celular] [nvarchar](14) NOT NULL,
	[TelefoneFixo] [nvarchar](14) NOT NULL,
	[Email] [nvarchar](70) NULL,
	[CarteirinhaDoConvenio] [nvarchar](70) NOT NULL,
	[ValidadeDaCarteirinha] [nvarchar](7) NOT NULL,
	[ConvenioId] [int] NOT NULL,
 CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED 
(
	[PacienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_Convenios_ConvenioId] FOREIGN KEY([ConvenioId])
REFERENCES [dbo].[Convenios] ([ConvenioId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_Convenios_ConvenioId]
GO

CREATE TABLE [dbo].[Convenios](
	[ConvenioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](30) NOT NULL,
	[Descricao] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Convenios] PRIMARY KEY CLUSTERED 
(
	[ConvenioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Convenios (Nome, Descricao)
VALUES ('Convênio A', 'Descrição do Convênio A');

INSERT INTO Convenios (Nome, Descricao)
VALUES ('Convênio B', 'Descrição do Convênio B');

INSERT INTO Pacientes (Nome, SobreNome, DataDeNascimento, Genero, CPF, RG, UF_RG, Celular, TelefoneFixo, Email, CarteirinhaDoConvenio, ValidadeDaCarteirinha, ConvenioId)
VALUES ('João', 'Silva', '1990-01-01', 'Masculino', '12345678901', '123456789', 'SP', '999999999', '888888888', 'joao@example.com', 'ABC123', '12/2023', 1);

INSERT INTO Pacientes (Nome, SobreNome, DataDeNascimento, Genero, CPF, RG, UF_RG, Celular, TelefoneFixo, Email, CarteirinhaDoConvenio, ValidadeDaCarteirinha, ConvenioId)
VALUES ('Maria', 'Santos', '1985-05-10', 'Feminino', '98765432109', '987654321', 'RJ', '777777777', '666666666', 'maria@example.com', 'DEF456', '10/2022', 2);

INSERT INTO Pacientes (Nome, SobreNome, DataDeNascimento, Genero, CPF, RG, UF_RG, Celular, TelefoneFixo, Email, CarteirinhaDoConvenio, ValidadeDaCarteirinha, ConvenioId)
VALUES ('Carlos', 'Ferreira', '1982-09-15', 'Masculino', '56789012345', '567890123', 'MG', '555555555', '444444444', 'carlos@example.com', 'GHI789', '09/2024', 1);

INSERT INTO Pacientes (Nome, SobreNome, DataDeNascimento, Genero, CPF, RG, UF_RG, Celular, TelefoneFixo, Email, CarteirinhaDoConvenio, ValidadeDaCarteirinha, ConvenioId)
VALUES ('Ana', 'Lima', '1995-12-20', 'Feminino', '32165498709', '321654987', 'RS', '333333333', '222222222', 'ana@example.com', 'JKL012', '06/2023', 2);