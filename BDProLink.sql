-- =============================================
-- Criação do Banco de Dados e Estrutura Principal
-- =============================================

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'prolink01')
BEGIN
    ALTER DATABASE prolink01 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE prolink01;
END
GO

CREATE DATABASE prolink01;
GO

USE prolink01;
GO

-- =============================================
-- Tabela: Usuario
-- =============================================
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

-- =============================================
-- Tabela: Funcionario
-- =============================================
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

-- Stored Procedure para validação de login
CREATE PROCEDURE sp_ValidarLogin
    @Email NVARCHAR(100),
    @Senha NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @IdFuncionario INT = 0;
    DECLARE @NomeCompleto NVARCHAR(255) = '';
    DECLARE @NivelAcesso INT = -1;
    DECLARE @LoginValido BIT = 0;
    
    -- Verifica se existe funcionário ativo com email e senha informados
    SELECT 
        @IdFuncionario = id_funcionario,
        @NomeCompleto = nome_completo,
        @NivelAcesso = nivel_acesso,
        @LoginValido = 1
    FROM Funcionario 
    WHERE email = @Email 
      AND senha = @Senha 
      AND ativo = 1;
    
    -- Se login é válido, atualiza último acesso e registra histórico
    IF @LoginValido = 1
    BEGIN
        -- Atualiza último acesso
        UPDATE Funcionario 
        SET ultimo_acesso = GETDATE() 
        WHERE id_funcionario = @IdFuncionario;
        
        -- Encerra acessos anteriores não finalizados para funcionários
        UPDATE HistoricoAcessos 
        SET data_logout = GETDATE() 
        WHERE id_funcionario = @IdFuncionario 
          AND data_logout IS NULL
          AND tipo_acesso = 'F';
        
        -- Registra novo acesso
        INSERT INTO HistoricoAcessos (id_funcionario, id_usuario, email, data_login, tipo_acesso)
        VALUES (@IdFuncionario, NULL, @Email, GETDATE(), 'F');
    END
    
    -- Retorna resultado
    SELECT 
        @LoginValido as LoginValido,
        @IdFuncionario as IdFuncionario,
        @NomeCompleto as NomeCompleto,
        @NivelAcesso as NivelAcesso;
END
GO

-- =============================================
-- Tabela: HistoricoAcessos
-- =============================================
CREATE TABLE HistoricoAcessos (
    id_historico INT IDENTITY(1,1) PRIMARY KEY,
    id_funcionario INT NULL,
    id_usuario INT NULL,
    email NVARCHAR(100) NOT NULL,
    data_login DATETIME NOT NULL DEFAULT GETDATE(),
    data_logout DATETIME NULL,
    tipo_acesso CHAR(1) NULL CHECK (tipo_acesso IN ('F', 'U')),
    FOREIGN KEY (id_funcionario) REFERENCES Funcionario(id_funcionario),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT CK_ApenasUmId CHECK (
        (id_funcionario IS NOT NULL AND id_usuario IS NULL) OR
        (id_usuario IS NOT NULL AND id_funcionario IS NULL)
    )
);
GO

-- =============================================
-- Tabela: Perfil
-- =============================================
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

-- =============================================
-- Tabela: AreaAtuacao
-- =============================================
CREATE TABLE AreaAtuacao (
    id_area INT IDENTITY(1,1) PRIMARY KEY,
    nome_area NVARCHAR(100) NOT NULL
);
GO

-- =============================================
-- Tabela: Vagas
-- =============================================
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

-- =============================================
-- Tabela: ProfissionalArea
-- =============================================
CREATE TABLE ProfissionalArea (
    id_profissional_area INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_area INT NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_area) REFERENCES AreaAtuacao(id_area)
);
GO

-- =============================================
-- Tabela: Candidatura
-- =============================================
CREATE TABLE Candidatura (
    id_candidatura INT IDENTITY(1,1) PRIMARY KEY,
    id_vaga INT NOT NULL,
    id_perfil INT NOT NULL,
    data_candidatura DATETIME DEFAULT GETDATE(),
    status NVARCHAR(20) DEFAULT 'Pendente',
    FOREIGN KEY (id_vaga) REFERENCES Vagas(id_vaga),
    FOREIGN KEY (id_perfil) REFERENCES Perfil(id_perfil)
);
GO

-- =============================================
-- Tabela: Mensagem
-- =============================================
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

-- =============================================
-- Tabela: Webinar
-- =============================================
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

-- =============================================
-- Tabela: inscricoes_webinar
-- =============================================
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

-- =============================================
-- Tabela: Contatos
-- =============================================
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
SELECT * FROM Usuario
SELECT * FROM Funcionario
SELECT * FROM Webinar
SELECT * FROM Vagas
SELECT * FROM Candidatura
SELECT * FROM HistoricoAcessos



