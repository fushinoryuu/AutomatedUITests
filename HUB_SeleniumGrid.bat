@ECHO OFF

TITLE Selenium Grid - HUB

ECHO Starting the HUB...
ECHO.
TIMEOUT /t 60
ECHO.
CD /Selenium
java -jar selenium-server-standalone-3.4.0.jar -role hub