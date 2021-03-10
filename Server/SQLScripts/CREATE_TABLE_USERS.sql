CREATE TABLE Users (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL,
	RG varchar(255),
	CPF varchar (255),
	CNPJ varchar(255),
	Email varchar(255) NOT NULL,
	Telephone varchar(255) NOT NULL,
	DateBirth varchar(255) NOT NULL,
	RegisterDate varchar(255) NOT NULL,
	TypeUser varchar(255) NOT NULL
);