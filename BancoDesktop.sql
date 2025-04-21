
Create Database Resetar;
Use Resetar;
---------------------------------BD Prolink------------------------------------------------
Drop DATABASE Prolink;
CREATE DATABASE Prolink;
GO
USE Prolink;
GO

CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nome NVARCHAR(255) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    senha NVARCHAR(255) NOT NULL,
    dataNascimento DATE NULL,
    telefone NVARCHAR(15) NULL,
    qr_code NVARCHAR(255) NULL,
    data_geracao_qr DATETIME NULL
);

CREATE TABLE Funcionario (
    id_funcionario INT IDENTITY(1,1) PRIMARY KEY,
    nome_completo NVARCHAR(255) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    senha NVARCHAR(255) NOT NULL,  -- Armazenará o hash (ou texto puro temporariamente)
    nivel_acesso INT NOT NULL DEFAULT 2,  -- 0=Admin, 1=Gerente, 2=Supervisor
    criado_por INT NULL,                 -- ID de quem cadastrou (NULL = Admin Master)
    data_cadastro DATETIME DEFAULT GETDATE(),
    ultimo_acesso DATETIME NULL,         -- Último login
    ativo BIT DEFAULT 1,                 -- 1=Ativo, 0=Inativo
    FOREIGN KEY (criado_por) REFERENCES Funcionario(id_funcionario)
);

CREATE TABLE AreaAtuacao (
    id_area INT IDENTITY(1,1) PRIMARY KEY,
    nome_area NVARCHAR(100) NOT NULL
);


CREATE TABLE Vagas (
    id_vaga INT IDENTITY(1,1) PRIMARY KEY,
    id_func INT NOT NULL FOREIGN KEY REFERENCES Funcionario(id_funcionario),
    titulo_vaga NVARCHAR(255) NOT NULL,
    localizacao NVARCHAR(255),
    tipo_emprego NVARCHAR(20) NOT NULL,
    id_area INT,
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    empresa NVARCHAR(255) NOT NULL,
    FOREIGN KEY (id_area) REFERENCES AreaAtuacao(id_area),
    CONSTRAINT chk_tipo_emprego CHECK (tipo_emprego IN ('full-time', 'part-time', 'internship'))
);

INSERT INTO Funcionario (nome_completo, email, senha, nivel_acesso, criado_por)
VALUES (
    'Pedro Henrique', 
    'admin@empresa.com', 
    'senha123',  -- Troque por um hash depois!
    0,           -- Nível 0 (Admin)
    NULL         -- Criado manualmente (sem referência)
);

INSERT INTO Funcionario (nome_completo, email, senha, nivel_acesso, criado_por)
VALUES (
    'Alberto Ramos', 
    'gerente@empresa.com', 
    'senha456',  -- Substituir por hash depois!
    1,           -- Nível 1 (Pode gerenciar usuários)
    1            -- Cadastrado pelo Admin Master (id 1)
);
INSERT INTO Funcionario (nome_completo, email, senha, nivel_acesso, criado_por)
VALUES (
    'Hugo Souza', 
    'supervisor@empresa.com', 
    'senha789',  -- Substituir por hash depois!
    2,           -- Nível 2 (Acesso restrito)
    2            -- Cadastrado pelo Gerente (id 2)
);
SELECT * FROM Funcionario;
DELETE FROM Funcionario;



SELECT id_funcionario, nome_completo, email, ultimo_acesso 
FROM Funcionario 
ORDER BY ultimo_acesso DESC;