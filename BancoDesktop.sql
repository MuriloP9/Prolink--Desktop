
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

INSERT INTO AreaAtuacao (nome_area) VALUES 
('Tecnologia da Informação'),
('Marketing'),
('Recursos
 Humanos'),
('Finanças'),
('Vendas');

INSERT INTO Vagas (id_func, titulo_vaga, localizacao, tipo_emprego, id_area, empresa) VALUES
(2, 'Vndedor iNterno', 'Belo Horizonte', 'part-time', 5, 'Vendas');

INSERT INTO Vagas (id_func, titulo_vaga, localizacao, tipo_emprego, id_area, empresa) VALUES
(1, 'Desenvolvedor Full Stack', 'São Paulo/Remoto', 'full-time', 1, 'Prolink Solutions'),
(2, 'Analista de RH Pleno', 'Rio de Janeiro', 'full-time', 3, 'Prolink RH'),
(3, 'Estagiário em Marketing Digital', 'São Paulo', 'internship', 2, 'Prolink Marketing'),
(1, 'Gerente Financeiro', 'São Paulo', 'full-time', 4, 'Prolink Finance'),
(2, 'Vendedor Externo', 'Belo Horizonte', 'part-time', 5, 'Prolink Vendas');


INSERT INTO Usuario (nome, email, senha, dataNascimento, telefone, qr_code, data_geracao_qr)
VALUES 
('João Silva', 'joao.silva@email.com', 'senha123', '19900515', '(11) 98765-4321', 'QR123456', '20231001 09:30:00'),
('Maria Oliveira', 'maria.oliveira@email.com', 'mariA321', '19850822', '(21) 99876-5432', 'QR789012', '20231002 14:15:00'),
('Carlos Souza', 'carlos.souza@email.com', 'carlos456', '19950210', '(31) 98765-1234', NULL, NULL),
('Ana Pereira', 'ana.pereira@email.com', 'ana789', '19881130', '(41) 99999-8888', 'QR345678', '20230928 16:45:00'),
('Pedro Costa', 'pedro.costa@email.com', 'pedroC0sta', '19920718', '(51) 98888-7777', 'QR901234', '20231003 10:20:00'),
('Juliana Santos', 'juliana.santos@email.com', 'julianaS', '19980425', '(11) 97777-6666', NULL, NULL),
('Marcos Rocha', 'marcos.rocha@email.com', 'marcosR2023', '19801205', '(21) 96666-5555', 'QR567890', '20230930 08:10:00'),
('Fernanda Lima', 'fernanda.lima@email.com', 'fernandaL1', '19930912', '(31) 95555-4444', 'QR123890', '20231004 11:35:00'),
('Ricardo Alves', 'ricardo.alves@email.com', 'ricardoA', '19870620', '(41) 94444-3333', NULL, NULL),
('Patrícia Nunes', 'patricia.nunes@email.com', 'patriciaN', '19910308', '(51) 93333-2222', 'QR456123', '20231005 13:50:00');
GO
GO

SELECT * FROM Funcionario;
DELETE FROM Funcionario;



SELECT id_funcionario, nome_completo, email, ultimo_acesso 
FROM Funcionario 
ORDER BY ultimo_acesso DESC;