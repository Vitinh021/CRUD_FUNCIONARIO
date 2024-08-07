CREATE DATABASE Crud
GO

USE Crud
GO

--TABELAS
CREATE TABLE estado (
    iId INT IDENTITY(1,1) PRIMARY KEY,
	vNome NVARCHAR(255),
    vSigla NVARCHAR(255)
);
GO

CREATE TABLE cidade (
    iId INT IDENTITY(1,1) PRIMARY KEY,
	iId_Estado INT NULL,
    vNome NVARCHAR(255),
	FOREIGN KEY (iId_Estado) REFERENCES estado(iId)
);
GO

CREATE TABLE funcionario (
    iId INT IDENTITY(1,1) PRIMARY KEY,
    vNome NVARCHAR(255),
	vCpf NVARCHAR(11),
	dData DATE,
	iId_Cidade INT NOT NULL,
	FOREIGN KEY (iId_Cidade) REFERENCES cidade(iId)
);
GO

--INSERT EM ESTADO
INSERT INTO estado (vNome, vSigla)
VALUES 
('Acre', 'AC'),
('Alagoas', 'AL'),
('Amapá', 'AP'),
('Amazonas', 'AM'),
('Bahia', 'BA'),
('Ceará', 'CE'),
('Distrito Federal', 'DF'),
('Espírito Santo', 'ES'),
('Goiás', 'GO'),
('Maranhão', 'MA'),
('Mato Grosso', 'MT'),
('Mato Grosso do Sul', 'MS'),
('Minas Gerais', 'MG'),
('Pará', 'PA'),
('Paraíba', 'PB'),
('Paraná', 'PR'),
('Pernambuco', 'PE'),
('Piauí', 'PI'),
('Rio de Janeiro', 'RJ'),
('Rio Grande do Norte', 'RN'),
('Rio Grande do Sul', 'RS'),
('Rondônia', 'RO'),
('Roraima', 'RR'),
('Santa Catarina', 'SC'),
('São Paulo', 'SP'),
('Sergipe', 'SE'),
('Tocantins', 'TO');
GO

-- PROCEDURES DE CIDADE
CREATE PROCEDURE sp_DelCidade
    @iId INT
AS
BEGIN
    DELETE FROM cidade
    WHERE iId = @iId;
END;
GO

CREATE PROCEDURE sp_InsCidade
    @iId_Estado INT,
    @vNome NVARCHAR(255)
AS
BEGIN
    INSERT INTO cidade (iId_Estado, vNome)
    VALUES (@iId_Estado, @vNome);
END;
GO

CREATE PROCEDURE sp_UpdCidade
    @iId INT,
    @iId_Estado INT,
    @vNome NVARCHAR(255)
AS
BEGIN
    UPDATE cidade
    SET iId_Estado = @iId_Estado,
        vNome = @vNome
    WHERE iId = @iId;
END;
GO