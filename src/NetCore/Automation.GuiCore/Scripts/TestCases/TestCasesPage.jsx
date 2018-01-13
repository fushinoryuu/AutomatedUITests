import React from "react";
import ReactDOM from "react-dom";
import Jumbotron from "../Shared/Jumbotron.jsx";
import Hello from "../Shared/Hello.jsx";

// Jumbotron variables
const testCasesMainText = "Test Cases";
const testCasesSubText = "You can use this page to:";
const testCasesBullets = ["See all the test suites that have been imported.",
    "Drill into each suite and see what test cases are in the suite.",
    "See a historical test results for each test. (Feature not yet available."];
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