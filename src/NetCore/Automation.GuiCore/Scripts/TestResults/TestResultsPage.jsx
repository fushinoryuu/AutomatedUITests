import React from "react";
import ReactDOM from "react-dom";
import Jumbotron from "../Shared/Jumbotron.jsx";
import Hello from "../Shared/Hello.jsx";

// Jumbotron variables
const testResultsMainText = "Test Results";
const testResultsSubText = "You can use this page to:";
const testResultsBullets = ["Add new test configurations.",
    "Edit existing test configurations.",
    "Set which configuration to use for unit tests.",
    "Run unit tests from the UI."];
const testResultsListItems = testResultsBullets.map((string) =>
    <li key={testResultsBullets.indexOf(string)}>
        {string}
    </li>
);

// Main component to render the whole page
class TestResultsPage extends React.Component {
    render() {
        return (
            <div>
                <Jumbotron mainText={testResultsMainText} subText={testResultsSubText} items={testResultsListItems} />
                <Hello />
            </div>
        );
    }
}

ReactDOM.render(<TestResultsPage />, document.getElementById('TestResultsPage'));