import React from "react";
import ReactDOM from "react-dom";
import Jumbotron from "../Shared/Jumbotron.jsx";
import Hello from "../Shared/Hello.jsx";

// Jumbotron variables
const testResultsMainText = "Test Results";
const testResultsSubText = "You can use this page to:";
const testResultsBullets = ["See an overview of past automated test runs.",
    "Easily identify which runs failed.",
    "Drill into the test run and see which tests failed and why. (Feature not yet available)"];
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