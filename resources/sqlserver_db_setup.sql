-- Create 'AutomationDatabase' database

CREATE DATABASE AutomationDatabase
GO

USE AutomationDatabase
GO

-- Create 'TestConfiguration' table

CREATE TABLE dbo.TestConfiguration
(
    ConfigId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TargetBrowser VARCHAR(50) NOT NULL,
    OperatingSystem VARCHAR(50) NOT NULL,
    SeleniumHubUri VARCHAR(100) NOT NULL,
    ScreenshotFolder VARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL
);
GO

-- Create 'TestRun' table

CREATE TABLE dbo.TestRun
(
    RunId VARCHAR(36) NOT NULL PRIMARY KEY,
    TestCaseCount INT NOT NULL,
    Result VARCHAR(12) NOT NULL,
    TestsPassed INT NOT NULL,
    TestsFailed INT NOT NULL,
    TestsInconclusive INT NOT NULL,
    TestsSkipped INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    Duration FLOAT NOT NULL
);
GO

-- Create 'TestSuite' table

CREATE TABLE dbo.TestSuite
(
    SuiteId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SuiteName VARCHAR(100) NOT NULL
);
GO

-- Create 'TestCase' table

CREATE TABLE dbo.TestCase
(
    CaseId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CaseName VARCHAR(100) NOT NULL,
    BelongsToSuite INT FOREIGN KEY REFERENCES TestSuite(SuiteId) NOT NULL,
    CaseDescription VARCHAR(500) NOT NULL
);
GO

-- Populate 'TestConfiguration' table

INSERT INTO dbo.TestConfiguration
    (TargetBrowser, OperatingSystem, SeleniumHubUri, ScreenshotFolder, IsActive)
VALUES('Chrome', 'Any', 'http://localhost:4444/wd/hub', 'C:\\UiTestScreenshots\\', 1)
GO

-- Verify the data in the 'TestConfiguration' table

SELECT * FROM dbo.TestConfiguration
GO