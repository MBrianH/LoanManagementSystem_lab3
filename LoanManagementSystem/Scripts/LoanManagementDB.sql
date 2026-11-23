CREATE DATABASE IF NOT EXISTS LoanManagementDB
CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE LoanManagementDB;

CREATE TABLE IF NOT EXISTS StaffUsers (
    UserID INT NOT NULL AUTO_INCREMENT,
    FullName VARCHAR(120) NOT NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(30) NOT NULL,
    AccountStatus VARCHAR(20) NOT NULL DEFAULT 'Active',
    PRIMARY KEY (UserID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Clients (
    ClientID INT NOT NULL AUTO_INCREMENT,
    FullName VARCHAR(120) NOT NULL,
    IdentificationNumber VARCHAR(50) NOT NULL UNIQUE,
    PhoneNumber VARCHAR(30) NOT NULL,
    Address VARCHAR(180) NOT NULL,
    RegistrationDate DATE NOT NULL,
    PRIMARY KEY (ClientID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS LoanApplications (
    ApplicationID INT NOT NULL AUTO_INCREMENT,
    ReferenceNumber VARCHAR(40) NOT NULL UNIQUE,
    ClientID INT NOT NULL,
    AmountRequested DECIMAL(15,2) NOT NULL,
    Purpose VARCHAR(250) NOT NULL,
    RepaymentPeriod INT NOT NULL,
    ApplicationDate DATE NOT NULL,
    Status VARCHAR(30) NOT NULL DEFAULT 'Pending Review',
    SupportingNotes TEXT NULL,
    PRIMARY KEY (ApplicationID),
    CONSTRAINT FK_Applications_Clients FOREIGN KEY (ClientID)
        REFERENCES Clients(ClientID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Decisions (
    DecisionID INT NOT NULL AUTO_INCREMENT,
    ApplicationID INT NOT NULL,
    DecisionStatus VARCHAR(20) NOT NULL,
    DecisionNote TEXT NULL,
    DecisionDate DATETIME NOT NULL,
    ApproverID INT NOT NULL,
    PRIMARY KEY (DecisionID),
    CONSTRAINT FK_Decisions_Applications FOREIGN KEY (ApplicationID)
        REFERENCES LoanApplications(ApplicationID),
    CONSTRAINT FK_Decisions_Staff FOREIGN KEY (ApproverID)
        REFERENCES StaffUsers(UserID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Loans (
    LoanID INT NOT NULL AUTO_INCREMENT,
    ApplicationID INT NOT NULL UNIQUE,
    ApprovedAmount DECIMAL(15,2) NOT NULL,
    AmountPaidOut DECIMAL(15,2) NOT NULL,
    PayoutDate DATE NOT NULL,
    PaymentMethod VARCHAR(40) NOT NULL,
    PaymentReference VARCHAR(80) NULL,
    LoanStatus VARCHAR(20) NOT NULL DEFAULT 'Active',
    PRIMARY KEY (LoanID),
    CONSTRAINT FK_Loans_Applications FOREIGN KEY (ApplicationID)
        REFERENCES LoanApplications(ApplicationID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS RepaymentSchedules (
    ScheduleID INT NOT NULL AUTO_INCREMENT,
    LoanID INT NOT NULL,
    DueDate DATE NOT NULL,
    ExpectedAmount DECIMAL(15,2) NOT NULL,
    InstalmentStatus VARCHAR(20) NOT NULL DEFAULT 'Pending',
    PRIMARY KEY (ScheduleID),
    CONSTRAINT FK_Schedules_Loans FOREIGN KEY (LoanID)
        REFERENCES Loans(LoanID)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Repayments (
    RepaymentID INT NOT NULL AUTO_INCREMENT,
    LoanID INT NOT NULL,
    AmountPaid DECIMAL(15,2) NOT NULL,
    PaymentDate DATE NOT NULL,
    PaymentMethod VARCHAR(40) NOT NULL,
    ReceiptReference VARCHAR(80) NULL,
    PRIMARY KEY (RepaymentID),
    CONSTRAINT FK_Repayments_Loans FOREIGN KEY (LoanID)
        REFERENCES Loans(LoanID)
) ENGINE=InnoDB;
