@ECHO OFF

TITLE Selenium Grid - NODE

ECHO Starting the NODE...
ECHO.
TIMEOUT /t 60
ECHO.
CD /Selenium
java -jar selenium-server-standalone-3.4.0.jar -role node -hub http://localhost:4444/grid/register -maxSession 5