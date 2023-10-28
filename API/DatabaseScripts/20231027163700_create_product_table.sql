-- [projeto-danilo-db].dbo.product definition

-- Drop table

-- DROP TABLE [projeto-danilo-db].dbo.product;

CREATE TABLE [projeto-danilo-db].dbo.product (
	id int IDENTITY(1,1) NOT NULL,
	name varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	unit_of_measure varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
);