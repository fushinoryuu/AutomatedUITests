-------------------------------
-- Create 'testsettings' schema
-------------------------------

CREATE SCHEMA `testsettings` ;

--------------------------
-- Create 'settings' table
--------------------------

CREATE TABLE `testsettings`.`settings` (
  `id` INT NOT NULL,
  `targetBrowser` VARCHAR(50) NOT NULL,
  `operatingSystem` VARCHAR(50) NOT NULL,
  `seleniumHubUri` VARCHAR(100) NOT NULL,
  `screenshotFolder` VARCHAR(100) NOT NULL,
  `isActive` TINYINT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
COMMENT = 'This table will save test configurations you can use to run your automated tests.';

--------------------------
-- Create 'testruns' table
--------------------------

CREATE TABLE `testsettings`.`testruns` (
  `guid` VARCHAR(36) NOT NULL,
  `testcasecount` INT NOT NULL,
  `result` VARCHAR(12) NOT NULL,
  `passed` INT NOT NULL,
  `failed` INT NOT NULL,
  `inconclusive` INT NOT NULL,
  `skipped` INT NOT NULL,
  `starttime` DATETIME NOT NULL,
  `endtime` DATETIME NOT NULL,
  `duration` DOUBLE NOT NULL,
  PRIMARY KEY (`guid`),
  UNIQUE INDEX `guid_UNIQUE` (`guid` ASC))
COMMENT = 'This table will save test run results after running the automated tests.';

----------------------------
-- Create 'testsuites' table
----------------------------

CREATE TABLE `testsettings`.`testsuites` (
  `testsuiteid` INT NOT NULL AUTO_INCREMENT,
  `testsuitename` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`testsuiteid`),
  UNIQUE INDEX `testsuiteid_UNIQUE` (`testsuiteid` ASC),
  UNIQUE INDEX `testsuitename_UNIQUE` (`testsuitename` ASC))
COMMENT = 'This table will save test suites that are imported using the web app.';

---------------------------
-- Create 'testcases' table
---------------------------

CREATE TABLE `testsettings`.`testcases` (
  `testcaseid` INT NOT NULL AUTO_INCREMENT,
  `testcasename` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`testcaseid`),
  UNIQUE INDEX `testcaseid_UNIQUE` (`testcaseid` ASC),
  UNIQUE INDEX `testcasename_UNIQUE` (`testcasename` ASC))
COMMENT = 'This table will save test cases that are imported using the web app.';

--------------------------
-- Create 'teststeps' table
--------------------------

CREATE TABLE `testsettings`.`teststeps` (
  `teststepid` INT NOT NULL AUTO_INCREMENT,
  `steptext` TEXT(500) NOT NULL,
  PRIMARY KEY (`teststepid`),
  UNIQUE INDEX `teststepid_UNIQUE` (`teststepid` ASC))
COMMENT = 'This table will save test steps that are imported using the web app.';

----------------------------
-- Populate 'settings' table
----------------------------
USE testsettings;

INSERT INTO settings(id, targetBrowser, operatingSystem, seleniumHubUri, screenshotFolder, isActive)
VALUES(1, 'Chrome', 'Any', 'http://localhost:4444/wd/hub', 'C:\\UiTestScreenshots\\', 1);

----------------
-- Update tables
----------------

ALTER TABLE `testsettings`.`settings`
CHARACTER SET = DEFAULT;

ALTER TABLE `testsettings`.`testruns`
CHARACTER SET = DEFAULT;

USE testsettings;
SET global optimizer_switch='derived_merge=off';
SET optimizer_switch='derived_merge=off';

-------------------------------------------------
-- Verify the information on the 'settings' table
-------------------------------------------------

SELECT * FROM settings;