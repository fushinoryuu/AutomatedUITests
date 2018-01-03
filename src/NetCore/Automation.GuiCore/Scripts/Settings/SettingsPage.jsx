import React from "react";
import ReactDOM from "react-dom";
import Jumbotron from "../Shared/Jumbotron.jsx";
import ReactTable from "react-table";
import "react-table/react-table.css";

// Jumbotron variables
const settingsMainText = "Automation Settings";
const settingsSubText = "You can use this page to:";
const strings = [
    "Add new test configurations.",
    "Edit existing test configurations.",
    "Set which configuration to use for unit tests.",
    "Run unit tests from the UI."];
const settingsListItems = strings.map((string) =>
    <li key={strings.indexOf(string)}>
        {string}
    </li>
);

// Table temp data
const data = [{
    targetBrowser: 'Chrome',
    operatingSystem: 'Any',
    seleniumHubUri: 'http://localhost:4444/wd/hub',
    screenshotFolder: 'C:\\UiTestScreenShots\\',
    isActive: true
}];

// Table variables
const columns = [{
    Header: 'Target Browser',
    accessor: 'targetBrowser'
}, {
    Header: 'Operating System',
    accessor: 'operatingSystem'
}, {
    Header: 'Selenium Hub Uri',
    accessor: 'seleniumHubUri'
}, {
    Header: 'Screenshot Folder',
    accessor: 'screenshotFolder'
}, {
    Header: 'Is Active',
    accessor: 'isActive'
}];

// Main component to render the whole page
class SettingsPage extends React.Component {
    render() {
        return (
            <div>
                <Jumbotron mainText={settingsMainText} subText={settingsSubText} items={settingsListItems} />
                <ReactTable data={data} columns={columns} />
            </div>
        );
    }
}

ReactDOM.render(<SettingsPage />, document.getElementById('SettingsPage'));