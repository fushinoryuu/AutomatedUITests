# Automated UI Testing
This is the skeleton code to starting Selenium automation for a site. The skeleton uses oneexchange.com, but it can be easily updated to something else.

## Solutions
There are two projects in the solution:

1. Healthcare.Framework - The framework used to build the automation tests.
2. Healthcare.Tests - The xUnit tests for the automation tests.

## Starting the Selenium Hub
1. Update to the latest version of Java.
2. Download the latest version of [Selenium Standalone Server](http://www.seleniumhq.org/download) and save it to `C:\Selenium` on the host machine.
3. Run the `SeleniumGrid_HUB.bat` file included in this repo on the host machine.

## Starting the Selenium Nodes
On each of the nodes:

1. Update to the latest version of Java.
2. Update Chrome browser to the latest version via `Customize and Control Google Chrome > Settings > About`.
3. Download the latest version of [Selenium Standalone Server](http://www.seleniumhq.org/download) and save it to `C:\Selenium` on each machine that will be one of the nodes.
4. Download the latest version of [ChromeDriver](https://sites.google.com/a/chromium.org/chromedriver/downloads)  and save it to `C:\Selenium` on each node machine.
5. Run the `SeleniumGrid_NODE.bat` file included in this repo on each node machine.

## Running the Automated UI Tests
### Running in Visual Studio

1. Clone the directory `git clone https://github.com/fushinoryuu/AutomatedUiTests.git`.
2. Install the Paket dependencies
  - First run `.paket\paket.bootstrapper.exe`
  - Then run `.paket\paket.exe install`
3. Change to the `AutomatedUiTests` directory and open up the `HealthcareAutomatedTests.sln` file.
4. Update the `Healthcare.Framework\WebDriver.cs` file with the correct hub address.
  - If you are running the test locally, don't update the address.
5. Simply build the solution with `Ctrl + b`.
6. Then run the test cases through Test Explorer in Visual Studio.

Note: Builds with VS2015 and later.