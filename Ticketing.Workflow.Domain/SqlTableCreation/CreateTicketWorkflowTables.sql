
 /**************************************************************************
*	Run this SQL script to create											*
*	Categories,															    *
*	Sub-Categories,															*			
*	Resolutions, 															*
*	UserTypes,																*						
*	UserInfos,																*
*	PasswordInfos,															*															*
*	Tickets tables															*
 ***************************************************************************/


 --- Create Categories table ---
CREATE TABLE Categories
(
	CategoryId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	CategoryName VARCHAR(255) NOT NULL,
);

--- Create Sub-Categories table ---
CREATE TABLE Subcategories
(
	SubcategoryId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	SubcategoryName VARCHAR(255) NOT NULL,
	FK_Category INT NOT NULL,
	CONSTRAINT FK_Subcategories_FK_Categories
		FOREIGN KEY (FK_Category) REFERENCES Categories (CategoryId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

--- Create Resolutions table ---
CREATE TABLE Resolutions
(
	ResolutionId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Comments text NOT NULL,
	FK_Category INT NOT NULL,
	CONSTRAINT FK_Resolutions_FK_Categories
		FOREIGN KEY (FK_Category) REFERENCES Categories (CategoryId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

--- Create UserTypes table ---
CREATE TABLE UserTypes
(
	UserTypeId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	UserType VARCHAR (255) NOT NULL
);

--- Create UserInfos table ---
CREATE TABLE UserInfos
(
	UserId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Username VARCHAR (255) NOT NULL,
	FK_UserType INT NOT NULL,
	CONSTRAINT FK_UserInfos_FK_UserTypes
		FOREIGN KEY (FK_UserType) REFERENCES UserTypes (UserTypeId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

--- Create PasswordInfos table ---
Create Table PasswordInfos
(
	PassowrdInfoId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	password VARCHAR (255) NOT NULL,
	FK_User INT NOT NULL,
	CONSTRAINT FK_PasswordInfos_FK_UserInfos
		FOREIGN KEY (FK_User) REFERENCES UserInfos (UserId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);


--- Create Tickets table
CREATE TABLE Tickets ---
(
	TicketId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR(200) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	Status VARCHAR(255) NOT NULL,
	Description text NULL,
	SubcategoryId INT NOT NULL,
	FK_Category INT NOT NULL,
	CONSTRAINT Fk_Tickets_Categories
		FOREIGN KEY (FK_Category) REFERENCES Categories(CategoryId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FK_AssignedUser INT NULL,
	CONSTRAINT FK_Tickets_Fk_UserInfos
		FOREIGN KEY (FK_AssignedUser) REFERENCES UserInfos(UserId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
