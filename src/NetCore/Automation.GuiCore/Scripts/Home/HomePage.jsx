import React from "react";
import ReactDOM from "react-dom";

class Jumbotron extends React.Component {
    render() {
        return (
            <div className="jumbotron">
                <h2>{this.props.mainText}</h2>
                <p>{this.props.subText}</p>
                <ul>{this.props.items}</ul>
            </div>
        )
    }
}

class Thumbnail extends React.Component {
    render() {
        return (
            <div className="col-xs-6 col-md-3">
                <a href="#" className="thumbnail">
                    <img src={this.props.location} alt={this.props.altText} />
                    <div class="caption">
                        <h3 align="center">{this.props.caption}</h3>
                    </div>
                </a>
            </div>
        )
    }
}

// Jumbotron variables
const parentMainText = "Automation Dashboard";
const parentSubText = "You can use this simple web app to:";
const strings = ["Add/update test configurations.",
    "Generate a new App.config file for the automated tests.",
    "Run automated tests using stored configurations.",
    "See a history of test run results."];
const parentListItems = strings.map((string) =>
    <li key={strings.indexOf(string)}>
        {string}
    </li>
);

// Selenium thumbnail variables
const seleniumLocation = "../../wwwroot/images/SeleniumLogoGreen.png";
const seleniumAltText = "Settings";
const seleniumCaption = "Test Configurations";

// Nunit thumbnail variables
const nunitLocation = "../../wwwroot/images/NunitLogo.png";
const nunitAltText = "Test Runs";
const nunitCaption = "NUnit Test Results";

// Tests thumbnail variables
const testsLocation = "../../wwwroot/images/TestcasesLogo.png";
const testsAltText = "Test Cases";
const testsCaption = "Test Case Library";

// Main component to render the whole page
class App extends React.Component {
    render() {
        return (
            <div>
                <div>
                    <Jumbotron mainText={parentMainText} subText={parentSubText} items={parentListItems} />
                </div>

                <hr />

                <div className="row">
                    <Thumbnail location={seleniumLocation} altText={seleniumAltText} caption={seleniumCaption} />
                    <Thumbnail location={nunitLocation} altText={nunitAltText} caption={nunitCaption} />
                    <Thumbnail location={testsLocation} altText={testsAltText} caption={testsCaption} />
                </div>
            </div>
        )
    }
}

ReactDOM.render(<App />, document.getElementById('HomeApp'));