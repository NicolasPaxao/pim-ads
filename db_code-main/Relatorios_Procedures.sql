USE TSBSEGUROS

CREATE PROCEDURE DesempenhoFuncionario 
@DATA VARCHAR(7),
@FUNCID INT
AS 
SELECT plan_valor, apol_dataCriacaoApolice, apol_id,fun_nome FROM FUNCIONARIOS func
JOIN APOLICES apol
ON apol.apol_fun_id  = func.fun_id
JOIN PLANOS pla
ON apol.apol_plan_id  = pla.plan_id
WHERE (SUBSTRING(CONVERT(CHAR(8),@DATA,112),1,6) = SUBSTRING(CONVERT(CHAR(8),apol.apol_dataCriacaoApolice,112),1,6)) AND func.fun_id = @FUNCID
GO;


CREATE PROCEDURE DesempenhoEmpresa
@DATA VARCHAR(7)
AS 
SELECT plan_valor, apol_dataCriacaoApolice, apol_id FROM APOLICES apol
JOIN PLANOS pla
ON apol.apol_plan_id  = pla.plan_id
WHERE SUBSTRING(CONVERT(CHAR(8),@DATA,112),1,6) = SUBSTRING(CONVERT(CHAR(8),apol.apol_dataCriacaoApolice,112),1,6);
