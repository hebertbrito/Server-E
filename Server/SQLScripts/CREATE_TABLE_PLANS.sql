CREATE TABLE Plans (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    IdUser int FOREIGN KEY REFERENCES Users(ID) NOT NULL,
	PlanName varchar(255) NOT NULL,
	StartDatePlan varchar(255) NOT NULL,
	EndDatePlan varchar(255) NOT NULL,
	RegisterDate varchar(255) NOT NULL
);