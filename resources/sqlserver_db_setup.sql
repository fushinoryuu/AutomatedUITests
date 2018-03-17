-- Create 'AutomationDatabase' database

CREATE DATABASE AutomationDatabase
GO

-- Create 'TestConfiguration' table

USE AutomationDatabase
GO

CREATE TABLE dbo.TestConfiguration
(
    ConfigId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TargetBrowser VARCHAR(50) NOT NULL,
    OperatingSystem VARCHAR(50) NOT NULL,
    SeleniumHubUri VARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL
);
GO

-- Populate 'TestConfiguration' table

INSERT INTO dbo.TestConfiguration
    (TargetBrowser, OperatingSystem, IsActive)
VALUES('Chrome', 'Any', 1)
GO