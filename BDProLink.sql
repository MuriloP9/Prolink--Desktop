-- Verifica e remove o banco existente
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'prolink01')
BEGIN
    ALTER DATABASE prolink01 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE prolink01;
	use Resetar;
END
GO
-- Cria o banco de dados
CREATE DATABASE prolink01;
GO

USE prolink01;
GO

-- Tabela de Usuários
CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nome NVARCHAR(255) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    senha NVARCHAR(255) NOT NULL,
    dataNascimento DATE NULL,
    telefone NVARCHAR(15) NULL,
    qr_code NVARCHAR(255) NULL,
    data_criacao DATETIME NOT NULL DEFAULT GETDATE(),
    data_geracao_qr DATETIME NULL,
    ultimo_acesso DATETIME NULL,
    ativo BIT DEFAULT 1,
    foto_perfil VARBINARY(MAX) NULL,
    token_rec_senha NVARCHAR(64) NULL,
    dt_expiracao_token DATETIME NULL,
    timestamp_expiracao BIGINT NULL,
    statusLGPD BIT NOT NULL DEFAULT 0,
    IP_registro VARCHAR(45) NULL
);
GO

-- Tabela de Funcionários
CREATE TABLE Funcionario (
    id_funcionario INT IDENTITY(1,1) PRIMARY KEY,
    nome_completo NVARCHAR(255) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    senha NVARCHAR(255) NOT NULL,
    nivel_acesso INT NOT NULL DEFAULT 2,
    criado_por INT NULL,
    data_cadastro DATETIME DEFAULT GETDATE(),
    ultimo_acesso DATETIME NULL,
    ativo BIT DEFAULT 1,
    FOREIGN KEY (criado_por) REFERENCES Funcionario(id_funcionario)
);
GO

-- Tabela de Histórico de Acessos (que adicionamos)
CREATE TABLE HistoricoAcessos (
    id_historico INT IDENTITY(1,1) PRIMARY KEY,
    id_funcionario INT NOT NULL,
    email NVARCHAR(100) NOT NULL,
    data_login DATETIME NOT NULL DEFAULT GETDATE(),
    data_logout DATETIME NULL,
    FOREIGN KEY (id_funcionario) REFERENCES Funcionario(id_funcionario)
);
GO

-- Tabela de Perfil
CREATE TABLE Perfil (
    id_perfil INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    idade INT,
    endereco NVARCHAR(100),
    formacao NVARCHAR(255),
    experiencia_profissional NVARCHAR(MAX),
    interesses NVARCHAR(MAX),
    projetos_especializacoes NVARCHAR(MAX),
    habilidades NVARCHAR(MAX),
    qr_code NVARCHAR(255),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario) ON DELETE CASCADE
);
GO

-- Tabela de Áreas de Atuação
CREATE TABLE AreaAtuacao (
    id_area INT IDENTITY(1,1) PRIMARY KEY,
    nome_area NVARCHAR(100) NOT NULL
);
GO

-- Tabela de Vagas (com campos adicionais que você pediu)
CREATE TABLE Vagas (
    id_vaga INT IDENTITY(1,1) PRIMARY KEY,
    id_funcionario INT NOT NULL,
    titulo_vaga NVARCHAR(255) NOT NULL,
    localizacao NVARCHAR(255),
    tipo_emprego NVARCHAR(20) NOT NULL,
    descricao NVARCHAR(MAX),
    id_area INT,
    id_usuario INT,
    empresa NVARCHAR(100) NOT NULL,
    salario DECIMAL(10,2) NULL,
    requisitos NVARCHAR(MAX) NULL,
    beneficios NVARCHAR(MAX) NULL,
    data_publicacao DATETIME DEFAULT GETDATE(),
    data_encerramento DATETIME NULL,
    ativa BIT DEFAULT 1,
    FOREIGN KEY (id_funcionario) REFERENCES Funcionario(id_funcionario),
    FOREIGN KEY (id_area) REFERENCES AreaAtuacao(id_area),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT CHK_TipoEmprego CHECK (tipo_emprego IN ('full-time', 'part-time', 'internship'))
);
GO

-- Tabela de Profissionais em Áreas
CREATE TABLE ProfissionalArea (
    id_profissional_area INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_area INT NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_area) REFERENCES AreaAtuacao(id_area)
);
GO

-- Tabela de Candidaturas

CREATE TABLE Candidatura (
    id_candidatura INT IDENTITY(1,1) PRIMARY KEY,
    id_vaga INT NOT NULL,
    id_perfil INT NOT NULL,
    data_candidatura DATETIME DEFAULT GETDATE(),
    status NVARCHAR(20) DEFAULT 'Pendente',
    FOREIGN KEY (id_vaga) REFERENCES Vagas(id_vaga),
    FOREIGN KEY (id_perfil) REFERENCES Perfil(id_perfil)
);



-- Tabela de Mensagens
CREATE TABLE Mensagem (
    id_mensagem INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario_remetente INT NOT NULL,
    id_usuario_destinatario INT NOT NULL,
    texto NVARCHAR(MAX) NOT NULL,
    data_hora DATETIME DEFAULT GETDATE(),
    lida BIT DEFAULT 0,
    FOREIGN KEY (id_usuario_remetente) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_usuario_destinatario) REFERENCES Usuario(id_usuario)
);
GO

-- Tabela de Webinar
CREATE TABLE Webinar (
    id_webinar INT IDENTITY(1,1) PRIMARY KEY,
    tema NVARCHAR(255),
    data_hora DATETIME,
    palestrante NVARCHAR(255),
    link NVARCHAR(500),
    descricao NVARCHAR(MAX),
    ativo BIT DEFAULT 1,
    data_cadastro DATETIME DEFAULT GETDATE()
);
GO

-- Tabela de Inscrições em Webinars
CREATE TABLE inscricoes_webinar (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome_completo VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(20),
    recebe_notificacoes BIT DEFAULT 0,
    consentimento_lgpd BIT NOT NULL,
    id_usuario INT,
    data_inscricao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);
GO

-- Tabela de Contatos
CREATE TABLE Contatos (
    id_contatos INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_contato INT NOT NULL,
    data_adicao DATETIME NOT NULL DEFAULT GETDATE(),
    bloqueado BIT DEFAULT 0,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_contato) REFERENCES Usuario(id_usuario),
    CONSTRAINT UC_Contato UNIQUE (id_usuario, id_contato)
);
GO

select * from Funcionario
select * from Webinar 