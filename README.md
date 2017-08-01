# Automated UI Testing
This is the skeleton code to starting Selenium automation for a site. The skeleton uses oneexchange.com, but it can be easily updated to something else.

This repo also includes Cake scripts to automate the building of the project and running the tests.

## Solution
There are five projects in the solution:

1. Automation.Framework - The framework used to build the automation tests.
2. Automation.Gui - A simple web app used to updated the settings for the Selenium tests.s
3. Automation.Selenium - Reads the App.settings file and wraps the Selenium WebDriver.
4. Automation.Tests - The NUnit tests created using the framework project.
5. Automation.XmlWriter - Gets the information from the DB and creates a new App.config file.

## Starting the Selenium Hub
On the host machine:

1. Update to the latest version of Java.
2. Download the latest version of [Selenium Standalone Server](http://www.seleniumhq.org/download) and save it to `C:\Selenium`.
3. Run the following command: `npm run hub`.
   - Or you can also run the `HUB_SeleniumGrid.bat` file included in this repo.

## Starting the Selenium Nodes
On each worker/node machine:

1. Update to the latest version of Java.
2. Update the Chrome browser to the latest version via:
   - The browser options `Customize and Control Google Chrome > Settings > About`.
   - Or by simply entering `chrome://help/` on the url box of an open Chrome tab.
3. Download the latest version of [Selenium Standalone Server](http://www.seleniumhq.org/download) and save it to `C:\Selenium` on each machine.
4. Download the latest version of [ChromeDriver](https://sites.google.com/a/chromium.org/chromedriver/downloads)  and save it to `C:\Selenium` on each machine.
5. Run the following command: `npm run node`.
   - Or you can also run the `NODE_SeleniumGrid.bat` file included in this repo.
   - If the [Hub](#starting-the-selenium-hub) is running on a different machine, open the `NODE_SeleniumGrid.bat` file and update the address for the Hub.

**Note:** The host machine can also be a node. You just need to run both bat files to start the hub and node on the same machine.

## Running the Automated UI Tests

### Running in Visual Studio
1. Clone the directory `git clone https://github.com/fushinoryuu/AutomatedUiTests.git`.
2. Install the Paket dependencies:
   - First run `.paket\paket.bootstrapper.exe`.
   - Then run `.paket\paket.exe restore`.
3. Install the Node dependencies: `npm install`.
4. Change to the `AutomatedUiTests` directory and open up the `AutomatedTests.sln` file.
5. Update the `Automation.Tests\App.config` file with the correct hub address.
   - If you are running the test locally, don't update the address.
   - More information on configuration settings can be found [here](#configuration-settings).
6. Simply build the solution with `Ctrl + B`.
7. Then run the test cases through the Test Explorer in Visual Studio.

**Note:** Builds with VS2015 and later.

### Running from Console
1. Clone the directory `git clone https://github.com/fushinoryuu/AutomatedUiTests.git`.
2. Change to the `AutomatedUiTests` directory.
3. Update the `Automation.Tests\App.config` file with the correct hub address.
   - If you are running the test locally, don't update the address.
   - More information on configuration settings can be found [here](#configuration-settings).
4. Make sure the [Hub](#starting-the-selenium-hub) and at least one [Node](#starting-the-selenium-nodes) are up and running.
5. Run the following command: `npm run build`.

## Configuration Settings

### Update the XML File Directly
The following configuration settings can be set in the [App.config](src/Automation.Tests/App.config) file:

1. `targetBrowser` - The desired browser you wish to run your tests on.
   - You can enter: `Chrome` or `Firefox`.
   - For now the grid scripts are only set up to run tests on Chrome.
2. `operatingSystem` - The operating system you wish to run your tests on.
   - You can enter: `Windows`, `Mac`, or `Any`.
3. `seleniumHubUri` - The uri where the Selenium hub is running.
   - For example `http://localhost:4444/wd/hub` would be a valid setting.
4. `screenshotFolder` - The directory where you want to save screenshots for failed tests.
   - For example `C:\UI_Test_Screenshots\` would be a valid setting.

### Update the XML File Using GUI
1. Download the latest version of [MySQL Installer](https://dev.mysql.com/downloads/windows/installer/).
2. Run the installer:
   - Use the default developer install and use the default values for the install.
   - For the root account, you can use `root` as the password.
3. Open MySQL Workbench.
   - Open the default local instance of MySQL.
   - Open and run the [setup script](db_setup.sql) included in the project.
4. Install the Paket dependencies:
   - First run `.paket\paket.bootstrapper.exe`.
   - Then run `.paket\paket.exe restore`.
5. Install the Node dependencies: `npm install`.
6. Change to the `AutomatedUiTests` directory and open up the `AutomatedTests.sln` file.
7. Simply build the solution with `Ctrl + Shift + B` and press `F5` to run the GUI.
   - If the web application doesn't start up, make sure you set `Automation.Gui` as the startup project in Visual Studio.