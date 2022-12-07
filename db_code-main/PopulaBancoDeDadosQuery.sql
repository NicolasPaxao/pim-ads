USE TSBSEGUROS

EXEC PostFuncionario
@NOME  = 'João Paulo',
@EMAIL= 'jp123@gmail.com',
@DATANASCIMENTO = '02/12/2000',
@DATAADMISSAO = '07/12/2022',
@CPF = '12345678910',
@RG = '12378945614',
@TELEFONE = '11988774411',
@CEP = '064878212',
@LOGRADOURO = 'Rua Olária, Nº165 Barueri - SP',
@CARGO = 'Vendedor',
@SEXO=  0,
@SALARIO = 2600,
@ESTADOCIVIL = 0;

EXEC PostSeguradora 
@RAZAOSOCIAL ='Ituram Seguros',
@CNPJ ='11111111111111',
@CONTRATOSOCIAL ='2521514114415',
@EMAIL ='ituram@seguros.com',
@TELEFONE ='11989644854',
@CEP ='05215345',
@LOGRADOURO ='Rua XPTO, Nº111 - São Paulo';

EXEC PostPlano
@NOMEPLANO = 'Ituram - Premium',
@IDSEGURADORA = 1,
@VALOR = 1200,
@TIPOPLANO = 1;

EXEC PostCobertura
@IDPLANO = 1,
@NOME = 'Acidente',
@DESCRICAO ='Caso ocorra de incêndio atingir o veículo, 69% do valor do veículo em caso de perda total será coberto e 69% do valor da manutenção será por conta da empresa.',
@INDENIZACAO = 69 ;

EXEC PostAssistencia
@IDPLANO = 1,
@DESCRICAO = 'Suporte de guincho em todo o território nacional, trazendo a melhor assistência em caso de problemas no seu veículo, assistência 24 horas.',
@CONTATO ='11988323723',
@EMPRESASUPORTE ='Guincho Dois Irmãos LTDA',
@NOME ='Guincho';

EXEC PostClientPf
@NOME = 'Luiz Antonio',
@EMAIL = 'luizantonio@gmail.com',
@CPF = '14447888889',
@CNH = '23151561651', 
@RG = '111111111',
@TELEFONE = '11981414521',
@DATANASCIMENTO = '18/11/2000',
@CEP = '02504141',
@LOGRADOURO = 'Rua Anastasia, Nº150 São Paulo - SP',
@ESTADOCIVIL = 0,
@SEXO = 0;

EXEC PostAutomovel
@IDCLIENTE = 1,
@MODELO = 'Sandero Expression 1.0',
@MARCA = 'Renault',
@ANOMODELO = '2015',
@COR = 'Vermelho',
@PLACA = 'FDR1515',
@RENAVAM = '56415241521',
@NUMEROMOTOR = '2020012010201',
@CRLV = '41154545454';

EXEC PostApolice
@IDCLIENTE = 1,
@IDAUTOMOVEL = 1,
@IDPLANO = 1,
@IDFUNCIONARIO = 1,
@FORMAPAGAMENTO = 0,
@DATACRIACAOAPOLICE = '2022-08-12 19:50:00.000';

EXEC ChangeStatusAutomovelById
@ID  = 1,
@STATUS = 2; 