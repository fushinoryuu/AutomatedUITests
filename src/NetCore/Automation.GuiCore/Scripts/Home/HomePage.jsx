import React from "react";
import ReactDOM from "react-dom";
import Jumbotron from "../Shared/Jumbotron.jsx";
import Thumbnail from "../Shared/Thumbnail.jsx";

// Jumbotron variables
const homeMainText = "Automation Dashboard";
const homeSubText = "You can use this simple web app to:";
const strings = ["Add/update test configurations.",
    "Generate a new App.config file for the automated tests.",
    "Run automated tests using stored configurations.",
    "See a history of test run results."];
const homeListItems = strings.map((string) =>
    <li key={strings.indexOf(string)}>
        {string}
    </li>
);

// Selenium thumbnail variables
const seleniumController = "Settings";
const seleniumLocation = "../images/SeleniumLogoGreen.png";
const seleniumAltText = "Settings";
const seleniumCaption = "Test Configurations";

// Nunit thumbnail variables.
const nunitController = "TestResults";
const nunitLocation = "../images/NunitLogo.png";
const nunitAltText = "Test Runs";
const nunitCaption = "NUnit Test Results";

// Tests thumbnail variables
const testsController = "TestCases";
const testsLocation = "../images/TestcasesLogo.png";
const testsAltText = "Test Cases";
const testsCaption = "Test Case Library";

// Main component to render the whole page
class HomePage extends React.Component {
    render() {
        return (
            <div>
                <Jumbotron mainText={homeMainText} subText={homeSubText} items={homeListItems} />
                <div className="row">
                    <Thumbnail link={seleniumController} location={seleniumLocation} altText={seleniumAltText} caption={seleniumCaption} />
                    <Thumbnail link={nunitController} location={nunitLocation} altText={nunitAltText} caption={nunitCaption} />
                    <Thumbnail link={testsController} location={testsLocation} altText={testsAltText} caption={testsCaption} />
                </div>
            </div>
        );
    }
}

ReactDOM.render(<HomePage />, document.getElementById('HomePage'));