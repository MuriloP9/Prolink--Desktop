-- 1. Inserção na tabela Funcionario (primeiro porque é auto-referencial)
INSERT INTO Funcionario (nome_completo, email, senha, nivel_acesso, ativo, data_cadastro)
VALUES 
('Admin Master', 'admin@prolink.com', 'SenhaAdmin@123', 0, 1, '2023-01-01T08:00:00'),
('Gerente Geral', 'gerente@prolink.com', 'SenhaGerente@123', 1, 1, '2023-01-02T09:00:00'),
('Supervisor TI', 'ti@prolink.com', 'SenhaTI@123', 2, 1, '2023-01-03T10:00:00'),
('Recrutador', 'rh@prolink.com', 'SenhaRH@123', 2, 1, '2023-01-04T11:00:00');

-- Atualiza o criado_por para os demais funcionários
UPDATE Funcionario SET criado_por = 1 WHERE id_funcionario IN (2,3,4);
GO

-- 2. Inserção na tabela Usuario
INSERT INTO Usuario (nome, email, senha, dataNascimento, telefone, ativo, statusLGPD, data_criacao)
VALUES
('João da Silva', 'joao@email.com', 'senhaJoao123', '1990-05-15', '11999998888', 1, 1, '2023-05-01T10:00:00'),
('Maria Oliveira', 'maria@email.com', 'senhaMaria123', '1988-08-20', '21988887777', 1, 1, '2023-05-02T11:00:00'),
('Carlos Souza', 'carlos@email.com', 'senhaCarlos123', '1995-03-10', '31977776666', 1, 1, '2023-05-03T12:00:00'),
('Ana Pereira', 'ana@email.com', 'senhaAna123', '1992-11-25', '41966665555', 1, 1, '2023-05-04T13:00:00'),
('Pedro Costa', 'pedro@email.com', 'senhaPedro123', '1985-07-30', '51955554444', 1, 1, '2023-05-05T14:00:00');
GO

-- 3. Inserção na tabela AreaAtuacao
INSERT INTO AreaAtuacao (nome_area)
VALUES
('Tecnologia da Informação'),
('Recursos Humanos'),
('Engenharia'),
('Design'),
('Marketing Digital'),
('Administração'),
('Saúde'),
('Educação');
GO

-- 4. Inserção na tabela Perfil
INSERT INTO Perfil (id_usuario, idade, endereco, formacao, experiencia_profissional, habilidades)
VALUES
(1, 33, 'Rua A, 100 - São Paulo/SP', 'Ciência da Computação', '5 anos como Desenvolvedor Java', 'Java, Spring, SQL'),
(2, 28, 'Av. B, 200 - Rio de Janeiro/RJ', 'Administração', '3 anos em RH', 'Recrutamento, Treinamento'),
(3, 35, 'Rua C, 300 - Belo Horizonte/MG', 'Engenharia Civil', '8 anos em Construção Civil', 'AutoCAD, Gestão de Obras'),
(4, 30, 'Av. D, 400 - Curitiba/PR', 'Design Gráfico', '5 anos como UI/UX Designer', 'Figma, Photoshop, Illustrator'),
(5, 40, 'Rua E, 500 - Porto Alegre/RS', 'Medicina', '12 anos como Clínico Geral', 'Diagnóstico, Emergências');
GO

-- 5. Inserção na tabela Vagas
INSERT INTO Vagas (id_funcionario, titulo_vaga, localizacao, tipo_emprego, descricao, id_area, empresa, salario, requisitos, data_publicacao)
VALUES
(3, 'Desenvolvedor Java Pleno', 'São Paulo/SP', 'full-time', 'Desenvolvimento de sistemas corporativos', 1, 'Tech Solutions', 8000.00, 'Java, Spring Boot, SQL', '2023-06-01T00:00:00'),
(4, 'Analista de RH', 'Rio de Janeiro/RJ', 'full-time', 'Recrutamento e seleção', 2, 'RH Corporativo', 5000.00, 'Experiência com recrutamento', '2023-06-02T00:00:00'),
(3, 'Engenheiro Civil', 'Belo Horizonte/MG', 'full-time', 'Gestão de obras', 3, 'Construções Modernas', 9500.00, 'CREA ativo', '2023-06-03T00:00:00'),
(4, 'UI/UX Designer', 'Remoto', 'part-time', 'Design de interfaces', 4, 'Digital Design', 3500.00, 'Figma, Adobe XD', '2023-06-04T00:00:00'),
(3, 'Médico Clínico', 'Porto Alegre/RS', 'full-time', 'Atendimento ambulatorial', 7, 'Saúde Plus', 12000.00, 'CRM ativo', '2023-06-05T00:00:00');
GO

-- 6. Inserção na tabela HistoricoAcessos
INSERT INTO HistoricoAcessos (id_funcionario, email, data_login, data_logout)
VALUES
(1, 'admin@prolink.com', '2023-06-01T08:00:00', '2023-06-01T18:00:00'),
(2, 'gerente@prolink.com', '2023-06-01T08:30:00', '2023-06-01T17:30:00'),
(3, 'ti@prolink.com', '2023-06-02T09:00:00', '2023-06-02T18:30:00'),
(4, 'rh@prolink.com', '2023-06-02T09:15:00', '2023-06-02T17:45:00'),
(1, 'admin@prolink.com', '2023-06-03T08:05:00', '2023-06-03T18:10:00');
GO

-- 7. Inserção na tabela ProfissionalArea
INSERT INTO ProfissionalArea (id_usuario, id_area)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 7);
GO

-- 8. Inserção na tabela Candidatura
INSERT INTO Candidatura (id_vaga, id_perfil, status, data_candidatura)
VALUES
(1, 1, 'Aprovada', '2023-06-10T10:00:00'),
(2, 2, 'Pendente', '2023-06-11T11:00:00'),
(3, 3, 'Aprovada', '2023-06-12T12:00:00'),
(4, 4, 'Recusada', '2023-06-13T13:00:00'),
(5, 5, 'Pendente', '2023-06-14T14:00:00');
GO

-- 9. Inserção na tabela Webinar (CORRIGIDA com formato ISO 8601)
INSERT INTO Webinar (tema, data_hora, palestrante, link, descricao, ativo)
VALUES
('Carreiras em TI', '2023-07-15T19:00:00', 'Carlos Fontes', 'https://meet.prolink.com/ti', 'Oportunidades na área de tecnologia', 1),
('Gestão de Pessoas', '2023-07-20T18:30:00', 'Ana Beatriz', 'https://meet.prolink.com/rh', 'Tendências em gestão de equipes', 1),
('Inovação em Engenharia', '2023-07-25T20:00:00', 'Roberto Silva', 'https://meet.prolink.com/eng', 'Novas tecnologias na construção civil', 1);
GO

-- 10. Inserção na tabela inscricoes_webinar
INSERT INTO inscricoes_webinar (nome_completo, email, telefone, recebe_notificacoes, consentimento_lgpd, id_usuario, data_inscricao)
VALUES
('João da Silva', 'joao@email.com', '11999998888', 1, 1, 1, '2023-07-01T10:00:00'),
('Maria Oliveira', 'maria@email.com', '21988887777', 1, 1, 2, '2023-07-02T11:00:00'),
('Carlos Souza', 'carlos@email.com', '31977776666', 0, 1, 3, '2023-07-03T12:00:00');
GO

-- 11. Inserção na tabela Mensagem
INSERT INTO Mensagem (id_usuario_remetente, id_usuario_destinatario, texto, data_hora)
VALUES
(1, 2, 'Olá Maria, vi seu perfil e gostaria de conversar sobre oportunidades', '2023-06-15T14:00:00'),
(2, 1, 'Oi João, claro! Podemos marcar uma reunião', '2023-06-15T14:30:00'),
(3, 4, 'Ana, você tem interesse em trabalhar conosco?', '2023-06-16T15:00:00'),
(4, 3, 'Sim Carlos, me conte mais sobre a vaga', '2023-06-16T15:30:00');
GO

-- 12. Inserção na tabela Contatos
INSERT INTO Contatos (id_usuario, id_contato, data_adicao)
VALUES
(1, 2, '2023-06-01T10:00:00'),
(1, 3, '2023-06-02T11:00:00'),
(2, 1, '2023-06-03T12:00:00'),
(3, 4, '2023-06-04T13:00:00');
GO

INSERT INTO Candidatura (id_vaga, id_perfil, status)
VALUES 
(1, 1, 'Pendente'),
(1, 2, 'Aprovado'),
(2, 3, 'Pendente'),
(3, 1, 'Rejeitado'),
(3, 2, 'Pendente');