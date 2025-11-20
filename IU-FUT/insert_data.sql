-- Script SQL para inserção de dados de teste
-- 2 Campos, 2 Times, 10 Jogadores (5 em cada time)

-- Hash SHA256 em Base64 da senha "123": pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=

-- Inserir 2 Campos
INSERT INTO Campo (Nome, Endereco, Cidade, Descricao) VALUES
('Campo Central', 'Rua das Flores, 123', 'São Paulo', 'Campo de futebol society com grama sintética'),
('Arena Esportiva', 'Av. Principal, 456', 'Rio de Janeiro', 'Campo profissional com iluminação noturna');

-- Inserir 2 Times
INSERT INTO Time (Nome, Descricao) VALUES
('Os Ruim de bola', 'Equipe formada por jogadores experientes'),
('Grupo 2', 'Equipe com foco em desenvolvimento');

-- Inserir 10 Jogadores
-- Primeiros 5 jogadores para o Time "Os Ruim de bola"
INSERT INTO Jogador (Nome, Idade, Email, Posicao, Senha, IdTime) VALUES
('João Silva', 25, 'joao.silva@email.com', 'ATA', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Os Ruim de bola')),
('Pedro Santos', 28, 'pedro.santos@email.com', 'MEI', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Os Ruim de bola')),
('Carlos Oliveira', 23, 'carlos.oliveira@email.com', 'MEI', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Os Ruim de bola')),
('Lucas Costa', 26, 'lucas.costa@email.com', 'DEF', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Os Ruim de bola')),
('Rafael Lima', 24, 'rafael.lima@email.com', 'GOL', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Os Ruim de bola'));

-- Últimos 5 jogadores para o Time "Grupo 2"
INSERT INTO Jogador (Nome, Idade, Email, Posicao, Senha, IdTime) VALUES
('Davi Garutti', 27, 'davigarutti@email.com', 'ATA', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Grupo 2')),
('Pedro Antonio', 22, 'pedroant@email.com', 'MEI', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Grupo 2')),
('Victor Hugo', 25, 'victorhugo@email.com', 'MEI', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Grupo 2')),
('Iago', 29, 'iagoliveira@email.com', 'DEF', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Grupo 2')),
('Gabriel Martins', 23, 'gabriel.martins@email.com', 'GOL', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', (SELECT Id FROM Time WHERE Nome = 'Grupo 2'));
