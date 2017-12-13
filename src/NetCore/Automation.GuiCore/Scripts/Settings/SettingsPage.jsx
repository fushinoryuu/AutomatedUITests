import React from "react";
import ReactDOM from "react-dom";
import Jumbotron from "../Shared/Jumbotron.jsx";

// Jumbotron variables
const settingsMainText = "Automation Settings";
const settingsSubText = "You can use this page to:";
const strings = ["Add new test configurations.",
    "Edit existing test configurations.",
    "Set which configuration to use for unit tests.",
    "Run unit tests from the UI."];
const settingsListItems = strings.map((string) =>
    <li key={strings.indexOf(string)}>
        {string}
    </li>
);

// Main component to render the whole page
class SettingsPage extends React.Component {
    render() {
        return <Jumbotron mainText={settingsMainText} subText={settingsSubText} items={settingsListItems} />;
    }
}

ReactDOM.render(<SettingsPage />, document.getElementById('SettingsPage'));