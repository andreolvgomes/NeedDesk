-- TABELAS CADATROS

CREATE TABLE tenants (
  tenant_id 				BIGINT NOT NULL AUTO_INCREMENT,
  
  PRIMARY KEY (tenant_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE users (
  user_id 				BIGINT NOT NULL AUTO_INCREMENT,
  tenant_id				BIGINT,
  use_email 			VARCHAR(50) NOT NULL DEFAULT '0',
  use_senha				VARCHAR(50) NOT NULL DEFAULT '',
  use_inativo			BIT NOT NULL DEFAULT 0,
  
  PRIMARY KEY (user_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE categorias (
  cat_id	 				BIGINT NOT NULL AUTO_INCREMENT,
  tenant_id					BIGINT,
  cat_descricao				VARCHAR(50) NOT NULL DEFAULT '',
  cat_inativo				BIT NOT NULL DEFAULT 0,
  
  PRIMARY KEY (cat_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE classificacao (
  cla_id	 				BIGINT NOT NULL AUTO_INCREMENT,
  tenant_id					BIGINT,
  cla_descricao				VARCHAR(50) NOT NULL DEFAULT '',
  cla_inativo				BIT NOT NULL DEFAULT 0,
  
  PRIMARY KEY (cla_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE prioridades (
  pri_id	 				BIGINT NOT NULL AUTO_INCREMENT,
  tenant_id					BIGINT,
  pri_descricao				VARCHAR(50) NOT NULL DEFAULT '',
  pri_inativo				BIT NOT NULL DEFAULT 0,
  
  PRIMARY KEY (pri_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE status (
  sta_id	 				BIGINT NOT NULL AUTO_INCREMENT,
  tenant_id					BIGINT,
  sta_descricao				VARCHAR(50) NOT NULL DEFAULT '',
  sta_inativo				BIT NOT NULL DEFAULT 0,
  
  PRIMARY KEY (sta_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE departamentos (
  dep_id	 				BIGINT NOT NULL AUTO_INCREMENT,
  tenant_id					BIGINT,
  dep_descricao				VARCHAR(50) NOT NULL DEFAULT '',
  dep_inativo				BIT NOT NULL DEFAULT 0,
  
  PRIMARY KEY (dep_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

CREATE TABLE clientes (
  cli_id	 				BIGINT NOT NULL AUTO_INCREMENT,
  tenant_id					BIGINT,
  cli_nome					VARCHAR(50) NOT NULL DEFAULT '',
  cli_inativo				BIT NOT NULL DEFAULT 0,
  
  PRIMARY KEY (cli_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- CREATE FK
ALTER TABLE users ADD CONSTRAINT fk_users_tanants FOREIGN KEY (tenant_id) REFERENCES tenants(tenant_id);
ALTER TABLE categorias ADD CONSTRAINT fk_categorias_tanants FOREIGN KEY (tenant_id) REFERENCES tenants(tenant_id);
ALTER TABLE classificacao ADD CONSTRAINT fk_classificacao_tanants FOREIGN KEY (tenant_id) REFERENCES tenants(tenant_id);
ALTER TABLE clientes ADD CONSTRAINT fk_clientes_tanants FOREIGN KEY (tenant_id) REFERENCES tenants(tenant_id);
ALTER TABLE departamentos ADD CONSTRAINT fk_departamentos_tanants FOREIGN KEY (tenant_id) REFERENCES tenants(tenant_id);
ALTER TABLE prioridades ADD CONSTRAINT fk_prioridades_tanants FOREIGN KEY (tenant_id) REFERENCES tenants(tenant_id);
ALTER TABLE status ADD CONSTRAINT fk_status_tanants FOREIGN KEY (tenant_id) REFERENCES tenants(tenant_id);
