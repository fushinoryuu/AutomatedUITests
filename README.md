# Automated UI Testing
This is the skeleton code to starting Selenium automation for a site. The skeleton uses oneexchange.com, but it can be easily updated to something else.

This repo also includes Cake scripts to automate the building of the project and running the tests.

## Solutions
There are two projects in the solution:

1. Healthcare.Framework - The framework used to build the automation tests.
2. Healthcare.Tests - The NUnit tests created using the framework project.

## Starting the Selenium Hub
On the host machine:

1. Update to the latest version of Java.
2. Download the latest version of [Selenium Standalone Server](http://www.seleniumhq.org/download) and save it to `C:\Selenium`.
3. Run the following command: `npm run hub`
   - Or you can also run the `HUB_SeleniumGrid.bat` file included in this repo.

## Starting the Selenium Nodes
On each worker/node machine:

1. Update to the latest version of Java.
2. Update the Chrome browser to the latest version via:
   - The browser options `Customize and Control Google Chrome > Settings > About`.
   - Or by simply entering `chrome://help/` on the url box of an open Chrome tab.
3. Download the latest version of [Selenium Standalone Server](http://www.seleniumhq.org/download) and save it to `C:\Selenium` on each machine.
4. Download the latest version of [ChromeDriver](https://sites.google.com/a/chromium.org/chromedriver/downloads)  and save it to `C:\Selenium` on each machine.
5. Run the following command: `npm run node`
   - Or you can also run the `NODE_SeleniumGrid.bat` file included in this repo.
   - If the [Hub](#starting-the-selenium-hub) is running on a different machine, open the `NODE_SeleniumGrid.bat` file and update the address for the Hub.

**Note:** The host machine can also be a node. You just need to run both bat files to start the hub and node on the same machine.

## Running the Automated UI Tests

### Running in Visual Studio
1. Clone the directory `git clone https://github.com/fushinoryuu/AutomatedUiTests.git`.
2. Install the Paket dependencies:
   - First run `.paket\paket.bootstrapper.exe`
   - Then run `.paket\paket.exe install`
3. Install the Node dependencies: `npm install`
4. Change to the `AutomatedUiTests` directory and open up the `HealthcareAutomatedTests.sln` file.
5. Update the `Healthcare.Tests\App.config` file with the correct hub address.
   - If you are running the test locally, don't update the address.
   - More information on configuration settings can be found [here.](#configuration-settings)
6. Simply build the solution with `Ctrl + B`.
7. Then run the test cases through the Test Explorer in Visual Studio.

**Note:** Builds with VS2015 and later.

### Running from Console
1. Clone the directory `git clone https://github.com/fushinoryuu/AutomatedUiTests.git`.
2. Change to the `AutomatedUiTests` directory
3. Update the `Healthcare.Tests\App.config` file with the correct hub address.
   - If you are running the test locally, don't update the address.
   - More information on configuration settings can be found [here](#configuration-settings).
4. Make sure the [Hub](#starting-the-selenium-hub) and at least one [Node](#starting-the-selenium-nodes) are up and running.
5. Run the following command: `npm run build`

## Configuration Settings
The following configuration settings can be set in the `MedicareAutomation.Tests/App.config` file:

1. `seleniumHubURL` is the url where the selenium hub is running.
   - For example `http://localhost:4444/grid/register` would be a valid setting.
   - If you change the hub url, don't forget to also update the url in the `NODE_SeleniumGrid.bat`.
2. `operatingSystem` is the operating system that the selenium nodes is running.
   - For example the parameters `Windows` or `Linux` would be valid settings.
   - The default value is `Windows`.
3. `baseUri` is the url of the environment you want to run the tests on.
	 - The default value is `https://qa.oneexchange.com/` or you can change it to `https://stage.oneexchange.com/`
	 - If you fork this repo, this is where you would set the base url for all your UI tests.
4. `enabletestrail` is to indicate if you want to report the results to TestRail.
	 - Default value is `True`, but it can be set to `False`
	 - Setting this parameter to `False` will cut the time it takes for the tests to run.
