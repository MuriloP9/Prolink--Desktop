-- Criando o banco de dados
CREATE DATABASE Prolink;
GO

-- Usando o banco de dados criado
USE Prolink;
GO

-- Criando a tabela Administrador
CREATE TABLE Administrador (
    id_admin INT IDENTITY(1,1) PRIMARY KEY,
    email NVARCHAR(100) UNIQUE NOT NULL,
    senha NVARCHAR(255) NOT NULL,
    data_cadastro DATETIME DEFAULT GETDATE(),
    cnpj NVARCHAR(18) UNIQUE NOT NULL,
    razao_social NVARCHAR(255) NOT NULL,
    nome_fantasia NVARCHAR(255)
);
SELECT * FROM Administrador;
DELETE FROM Administrador;