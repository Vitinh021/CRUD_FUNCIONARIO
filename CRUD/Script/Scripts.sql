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
('Amap�', 'AP'),
('Amazonas', 'AM'),
('Bahia', 'BA'),
('Cear�', 'CE'),
('Distrito Federal', 'DF'),
('Esp�rito Santo', 'ES'),
('Goi�s', 'GO'),
('Maranh�o', 'MA'),
('Mato Grosso', 'MT'),
('Mato Grosso do Sul', 'MS'),
('Minas Gerais', 'MG'),
('Par�', 'PA'),
('Para�ba', 'PB'),
('Paran�', 'PR'),
('Pernambuco', 'PE'),
('Piau�', 'PI'),
('Rio de Janeiro', 'RJ'),
('Rio Grande do Norte', 'RN'),
('Rio Grande do Sul', 'RS'),
('Rond�nia', 'RO'),
('Roraima', 'RR'),
('Santa Catarina', 'SC'),
('S�o Paulo', 'SP'),
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