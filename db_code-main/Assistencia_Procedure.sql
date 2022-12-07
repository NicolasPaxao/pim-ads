USE TSBSEGUROS

CREATE PROCEDURE GetAllAssistencias
AS
SELECT * FROM ASSISTENCIAS
GO;

CREATE PROCEDURE PostAssistencia
@IDPLANO INT,
@DESCRICAO VARCHAR(200),
@CONTATO VARCHAR(50),
@EMPRESASUPORTE VARCHAR(50),
@NOME VARCHAR(50)
AS
BEGIN 
	IF NOT EXISTS (SELECT * FROM ASSISTENCIAS WHERE ASSISTENCIAS.assist_nome = @NOME)
	BEGIN
		INSERT INTO ASSISTENCIAS(assist_plan_id, assist_descricao, assist_contato,assist_empresaSuporte ,assist_nome)
		VALUES(@IDPLANO, @DESCRICAO, @CONTATO, @EMPRESASUPORTE, @NOME)
	END
END
GO;

CREATE PROCEDURE PutAssistencia
@ID INT,
@DESCRICAO VARCHAR(200),
@CONTATO VARCHAR(50)  
AS
UPDATE ASSISTENCIAS 
SET ASSISTENCIAS.assist_descricao = @DESCRICAO,
ASSISTENCIAS.assist_contato = @CONTATO
WHERE ASSISTENCIAS.assist_id = @ID
GO;

CREATE PROCEDURE DeleteAssistencia
@ID INT
AS
DELETE FROM ASSISTENCIAS
WHERE ASSISTENCIAS.assist_id = @ID;
GO;