import React from "react";
import ReactDOM from "react-dom";

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

ReactDOM.render(<Jumbotron mainText={parentMainText} subText={parentSubText} items={parentListItems} />, document.getElementById('HomeJumbrotron'));