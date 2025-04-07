Create Database Resetar;
Use Resetar;
---------------------------------BD Prolink------------------------------------------------
Drop DATABASE Prolink;
CREATE DATABASE Prolink;
GO
USE Prolink;
GO

CREATE TABLE Funcionario (
    id_funcionario INT IDENTITY(1,1) PRIMARY KEY,
    email NVARCHAR(100) UNIQUE NOT NULL,
    senha NVARCHAR(255) NOT NULL,
    data_cadastro DATETIME DEFAULT GETDATE(),
    nome_completo NVARCHAR(255) NOT NULL
);
SELECT * FROM Funcionario;
DELETE FROM Funcionario;

INSERT INTO Funcionario (email, senha, nome_completo)
VALUES ('teste@empresa.com', 'senha123', 'Empresa Teste LTDA');