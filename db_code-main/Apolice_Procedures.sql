USE TSBSEGUROS

CREATE PROCEDURE GetAllApolices
AS
SELECT * FROM APOLICES 
GO;

CREATE PROCEDURE GetApolicesByCarId
AS
SELECT ap.apol_id, 
au.*,
cli.cli_nome, 
cli.cli_razaoSocial,
seg.segu_razaoSocial,
pla.plan_nomePlano,
pla.plan_valor,
apol_tempoVigencia,
apol_formaPagamento,
apol_dataCriacaoApolice

FROM APOLICES ap
JOIN AUTOMOVEIS au
ON ap.apol_auto_id  = au.auto_id
JOIN CLIENTES cli
ON ap.apol_cli_id  = cli.cli_id
JOIN PLANOS pla
ON ap.apol_plan_id  = pla.plan_id
JOIN SEGURADORAS seg
ON pla.plan_segu_id  = seg.segu_id
GO;

CREATE PROCEDURE PostApolice
@IDCLIENTE INT,
@IDAUTOMOVEL INT,
@IDPLANO INT,
@IDFUNCIONARIO INT,
@FORMAPAGAMENTO INT,
@DATACRIACAOAPOLICE DATETIME
AS
INSERT INTO APOLICES(
apol_cli_id, apol_auto_id,apol_plan_id, apol_fun_id ,apol_formaPagamento,apol_dataCriacaoApolice,apol_tempoVigencia)
VALUES(@IDCLIENTE, @IDAUTOMOVEL,@IDPLANO, @IDFUNCIONARIO, @FORMAPAGAMENTO, @DATACRIACAOAPOLICE, 12)
GO;
