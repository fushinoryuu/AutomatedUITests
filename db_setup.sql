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
COMMENT = 'This local db will save test settings you wish to run on your automated tests.';

----------------------------
-- Populate 'settings' table
----------------------------
USE testsettings;

INSERT INTO settings(id, targetBrowser, operatingSystem, seleniumHubUri, screenshotFolder, isActive)
VALUES(1, 'Chrome', 'Any', 'http://localhost:4444/wd/hub', 'C:\\UiTestScreenshots\\', 1);

----------------------------
-- Update the 'settings' table
----------------------------

ALTER TABLE `testsettings`.`settings`
CHARACTER SET = DEFAULT ;

USE testsettings;
SET global optimizer_switch='derived_merge=off';
SET optimizer_switch='derived_merge=off';

-------------------------------------------------
-- Verify the information on the 'settings' table
-------------------------------------------------

SELECT * FROM settings;