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
COMMENT = 'This local db will save test configurations you can use to run your automated tests.';

--------------------------
-- Create 'testruns' table
--------------------------

CREATE TABLE `testsettings`.`testruns` (
  `guid` BINARY(16) NOT NULL,
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
COMMENT = 'This local db will save test run results after running the automated tests.';

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