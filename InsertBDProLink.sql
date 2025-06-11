-- =============================================
-- Inserts para Tabela: Usuario
-- =============================================
INSERT INTO Usuario (nome, email, senha, dataNascimento, telefone, ativo)
VALUES 
('João Silva', 'joao.silva@email.com', 'senha123', '1990-05-15', '11987654321', 1),
('Maria Oliveira', 'maria.oliveira@email.com', 'senha456', '1985-08-22', '21987654321', 1),
('Carlos Souza', 'carlos.souza@email.com', 'senha789', '1995-11-30', '31987654321', 1);
GO

-- =============================================
-- Inserts para Tabela: Funcionario
-- =============================================
INSERT INTO Funcionario (nome_completo, email, senha, nivel_acesso, ativo)
VALUES 
('Pedro Henrique', 'adm@prolink.com', 'admin123', 0, 1),
('Gerente RH', 'rh@prolink.com', 'rh123', 1, 1),
('Recrutador TI', 'ti@prolink.com', 'ti123', 2, 1);
GO


-- =============================================
-- Inserts para Tabela: HistoricoAcessos
-- =============================================
INSERT INTO HistoricoAcessos (id_funcionario, id_usuario, email, data_login, data_logout, tipo_acesso)
VALUES 
(1, NULL, 'admin@prolink.com', '2023-01-10T09:00:00', '2023-01-10T18:00:00', 'F'),
(NULL, 1, 'joao.silva@email.com', '2023-01-10T10:00:00', '2023-01-10T17:30:00', 'U'),
(2, NULL, 'rh@prolink.com', '2023-01-11T08:30:00', NULL, 'F');
GO

-- =============================================
-- Inserts para Tabela: AreaAtuacao
-- =============================================
INSERT INTO AreaAtuacao (nome_area)
VALUES 
('Tecnologia da Informação'),
('Recursos Humanos'),
('Marketing Digital'),
('Finanças');
GO

-- =============================================
-- Inserts para Tabela: Perfil
-- =============================================
INSERT INTO Perfil (id_usuario, idade, endereco, formacao, experiencia_profissional)
VALUES 
(1, 33, 'Rua A, 123 - São Paulo', 'Ciência da Computação', '5 anos como Desenvolvedor Full Stack'),
(2, 38, 'Av. B, 456 - Rio de Janeiro', 'Administração', '10 anos em RH'),
(3, 28, 'Rua C, 789 - Belo Horizonte', 'Engenharia de Software', '3 anos como QA');
GO

-- =============================================
-- Inserts para Tabela: Vagas
-- =============================================
INSERT INTO Vagas (id_funcionario, titulo_vaga, localizacao, tipo_emprego, descricao, id_area, empresa, salario, ativa)
VALUES 
(2, 'Desenvolvedor Back-end', 'Remoto', 'full-time', 'Desenvolver APIs RESTful com Node.js', 1, 'Prolink', 8000.00, 1),
(3, 'Analista de RH', 'São Paulo', 'full-time', 'Recrutamento e seleção de talentos', 2, 'Prolink', 5000.00, 1),
(2, 'Designer UX/UI', 'Híbrido', 'part-time', 'Criação de interfaces para aplicativos', 3, 'Prolink', 3500.00, 1);
GO

-- =============================================
-- Inserts para Tabela: ProfissionalArea
-- =============================================
INSERT INTO ProfissionalArea (id_usuario, id_area)
VALUES 
(1, 1),
(2, 2),
(3, 1),
(1, 3);
GO

-- =============================================
-- Inserts para Tabela: Candidatura
-- =============================================
INSERT INTO Candidatura (id_vaga, id_perfil, status)
VALUES 
(1, 1, 'Aprovado'),
(2, 2, 'Pendente'),
(3, 3, 'Recusado');
GO

-- =============================================
-- Inserts para Tabela: Mensagem
-- =============================================
INSERT INTO Mensagem (id_usuario_remetente, id_usuario_destinatario, texto)
VALUES 
(1, 2, 'Olá Maria, gostaria de saber mais sobre a vaga.'),
(2, 1, 'Claro João, qual sua dúvida?'),
(3, 1, 'Ei João, vamos trabalhar juntos?');
GO

-- =============================================
-- Inserts para Tabela: Webinar
-- =============================================
INSERT INTO Webinar (tema, data_hora, palestrante, link, descricao)
VALUES 
('Carreiras em TI', '2023-02-15T19:00:00', 'Carlos Souza', 'https://meet.prolink.com/ti', 'Como ingressar no mercado de tecnologia'),
('Gestão de Pessoas', '2023-02-20T18:00:00', 'Maria Oliveira', 'https://meet.prolink.com/rh', 'Tendências em RH para 2023');
GO

-- =============================================
-- Inserts para Tabela: inscricoes_webinar
-- =============================================
INSERT INTO inscricoes_webinar (nome_completo, email, telefone, recebe_notificacoes, consentimento_lgpd, id_usuario)
VALUES 
('João Silva', 'joao.silva@email.com', '11987654321', 1, 1, 1),
('Ana Costa', 'ana.costa@email.com', '21987654321', 0, 1, NULL);
GO

-- =============================================
-- Inserts para Tabela: Contatos
-- =============================================
INSERT INTO Contatos (id_usuario, id_contato, bloqueado)
VALUES 
(1, 2, 0),
(1, 3, 0),
(2, 1, 0);
GO