-- Script SQL para apagar todos os dados existentes
-- Ordem de exclusão respeitando as relações de chave estrangeira

-- 1. Apagar TimePartida (tabela de relacionamento entre Time e Partida)
DELETE FROM TimePartida;

-- 2. Apagar Jogadores (têm FK para Time)
DELETE FROM Jogador;

-- 3. Apagar Partidas (têm FK para Campo)
DELETE FROM Partida;

-- 4. Apagar Times (podem ser deletados após os jogadores)
DELETE FROM Time;

-- 5. Apagar Campos (podem ser deletados após as partidas)
DELETE FROM Campo;

-- Verificar se as tabelas estão vazias (opcional - descomente para verificar)
-- SELECT COUNT(*) AS TotalJogadores FROM Jogador;
-- SELECT COUNT(*) AS TotalTimes FROM Time;
-- SELECT COUNT(*) AS TotalCampos FROM Campo;
-- SELECT COUNT(*) AS TotalPartidas FROM Partida;
-- SELECT COUNT(*) AS TotalTimePartida FROM TimePartida;

