USE TSBSEGUROS

CREATE PROCEDURE ReturnClient
@EMAIL VARCHAR(50),
@SENHA VARCHAR(18)
AS
SELECT ap.apol_id, 
au.*,
cli.*, 
assist.*,
cobert.*,
seg.segu_razaoSocial,
pla.plan_id,
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
JOIN ASSISTENCIAS assist
ON pla.plan_id  = assist.assist_plan_id
JOIN COBERTURAS cobert
ON pla.plan_id  = cobert.cober_plan_id

WHERE cli.cli_email = @EMAIL AND cli.cli_senha = @SENHA
;