import React from "react";
import ReactDOM from "react-dom";
import Jumbotron from "../Shared/Jumbotron.jsx";
import Hello from "../Shared/Hello.jsx";

// Jumbotron variables
const testCasesMainText = "Test Cases";
const testCasesSubText = "You can use this page to:";
const testCasesBullets = ["Add new test configurations.",
    "Edit existing test configurations.",
    "Set which configuration to use for unit tests.",
    "Run unit tests from the UI."];
const testCasesListItems = testCasesBullets.map((string) =>
    <li key={testCasesBullets.indexOf(string)}>
        {string}
    </li>
);

// Main component to render the whole page
class TestCasesPage extends React.Component {
    render() {
        return (
            <div>
                <Jumbotron mainText={testCasesMainText} subText={testCasesSubText} items={testCasesListItems} />
                <Hello />
            </div>
        );
    }
}

ReactDOM.render(<TestCasesPage />, document.getElementById('TestCasesPage'));