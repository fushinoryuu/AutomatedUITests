-- Create 'SeleniumAutomationToolbox' database

CREATE DATABASE SeleniumAutomationToolbox
GO

-- Create 'TestConfiguration' table

USE SeleniumAutomationToolbox
GO

CREATE TABLE dbo.TestConfiguration
(
    ConfigId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TargetBrowser VARCHAR(50) NOT NULL,
    OperatingSystem VARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL
);
GO

-- Populate 'TestConfiguration' table

INSERT INTO dbo.TestConfiguration
    (TargetBrowser, OperatingSystem, IsActive)
VALUES('Chrome', 'Any', 1)
GO