CREATE DATABASE TSBSEGUROS

USE TSBSEGUROS

CREATE TABLE FUNCIONARIOS(
	fun_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	fun_email VARCHAR(50) NOT NULL UNIQUE,
	fun_nome VARCHAR(50) NOT NULL UNIQUE,
	fun_senha VARCHAR(11) NOT NULL,
	fun_dataNascimento varchar(10) NOT NULL,
	fun_dataAdmissao varchar(10) NOT NULL,
	fun_cpf VARCHAR(11) NOT NULL UNIQUE,
	fun_rg VARCHAR(11) NOT NULL UNIQUE,
	fun_telefone VARCHAR(11) NOT NULL,
	fun_cep VARCHAR(8) NOT NULL,
	fun_logradouro VARCHAR(50) NOT NULL,
	fun_cargo VARCHAR(50) NOT NULL,
	fun_salario DECIMAL NOT NULL,
	fun_sexo INT NOT NULL, CHECK (fun_sexo IN(0,1)),
	fun_estadoCivil INT NOT NULL, CHECK (fun_estadoCivil IN(0,1,2,3)),
	fun_status INT NOT NULL, CHECK (fun_status IN(0,1,2)),
);

CREATE TABLE CLIENTES(
    cli_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	cli_email VARCHAR(50)NOT NULL UNIQUE,
	cli_senha VARCHAR(18),
	cli_cep VARCHAR(8) NOT NULL,
	cli_logradouro VARCHAR(50) NOT NULL,
	cli_telefone VARCHAR(12),
    cli_nome VARCHAR(50),
	cli_cpf VARCHAR(11),
	cli_cnh VARCHAR(11),
	cli_rg VARCHAR(11),
	cli_dataNascimento VARCHAR(10),
	cli_estadoCivil INT, CHECK (cli_estadoCivil IN(0,1,2,3)),
	cli_sexo INT, CHECK (cli_sexo IN(0,1)),
	cli_razaoSocial VARCHAR(50),
	cli_contratoSocial VARCHAR(50),
	cli_cnpj VARCHAR(14),
	cli_dataCriacao VARCHAR(10),
	cli_tipoCliente INT NOT NULL, CHECK (cli_tipoCliente IN(0,1)),
	cli_status INT NOT NULL, CHECK (cli_status IN(0,1,2)),
);

CREATE TABLE AUTOMOVEIS (
    auto_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	auto_cli_id INT NOT NULL,
    auto_modelo VARCHAR(50)NOT NULL,
	auto_marca VARCHAR(50)NOT NULL,
	auto_anoModelo VARCHAR(4) NOT NULL,
	auto_cor VARCHAR(50)NOT NULL,
	auto_renavam VARCHAR(50)NOT NULL,
	auto_numeroMotor VARCHAR(50)NOT NULL ,
	auto_placa VARCHAR(7) NOT NULL ,
	auto_crlv VARCHAR(50)NOT NULL ,
	auto_status INT NOT NULL, CHECK (auto_status IN(0,1,2)),
	FOREIGN KEY (auto_cli_id) REFERENCES CLIENTES(cli_id) ON DELETE CASCADE,
);

CREATE TABLE SEGURADORAS(
	segu_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	segu_razaoSocial VARCHAR(50) NOT NULL,
	segu_cnpj VARCHAR(50) NOT NULL ,
	segu_contratoSocial VARCHAR(50) NOT NULL ,
	segu_email VARCHAR(50) NOT NULL ,
	segu_telefone VARCHAR(11) NOT NULL,
	segu_cep VARCHAR(8) NOT NULL,
	segu_logradouro VARCHAR(50) NOT NULL,
	segu_status INT NOT NULL, CHECK (segu_status IN(0,1,2)),
);

CREATE TABLE PLANOS(
	plan_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	plan_nomePlano VARCHAR(50) ,
	plan_segu_id INT NOT NULL,
	plan_tipoPlano INT NOT NULL, CHECK (plan_tipoPlano IN(0,1,2)),
	plan_valor DECIMAL NOT NULL,
	plan_status INT NOT NULL, CHECK (plan_status IN(0,1,2)),
	FOREIGN KEY (plan_segu_id) REFERENCES SEGURADORAS(segu_id) ON DELETE CASCADE,
);

CREATE TABLE ASSISTENCIAS(
	assist_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	assist_plan_id INT NOT NULL,
	assist_nome VARCHAR(50) NOT NULL ,
	assist_empresaSuporte VARCHAR(50) NOT NULL,
	assist_descricao VARCHAR(200) NOT NULL,
	assist_contato VARCHAR(50) NOT NULL,
	FOREIGN KEY (assist_plan_id) REFERENCES PLANOS(plan_id) ON DELETE CASCADE,
);

CREATE TABLE COBERTURAS(
	cober_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	cober_plan_id INT NOT NULL,
	cober_nome VARCHAR(50) NOT NULL ,
	cober_descricao VARCHAR(200) NOT NULL,
	cober_indenizacao DECIMAL NOT NULL,
	FOREIGN KEY (cober_plan_id) REFERENCES PLANOS(plan_id) ON DELETE CASCADE,
);


CREATE TABLE APOLICES(
	apol_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	apol_cli_id INT,
	apol_auto_id INT,
	apol_plan_id INT,
	apol_fun_id INT,
	apol_formaPagamento INT NOT NULL, CHECK (apol_formaPagamento IN(0,1,2)),
	apol_dataCriacaoApolice DATETIME NOT NULL,
	apol_tempoVigencia INT NOT NULL,
	FOREIGN KEY (apol_cli_id) REFERENCES CLIENTES(cli_id) ,
	FOREIGN KEY (apol_auto_id) REFERENCES AUTOMOVEIS(auto_id) ,
	FOREIGN KEY (apol_plan_id) REFERENCES PLANOS(plan_id) ,
	FOREIGN KEY (apol_fun_id) REFERENCES FUNCIONARIOS(fun_id)
);
