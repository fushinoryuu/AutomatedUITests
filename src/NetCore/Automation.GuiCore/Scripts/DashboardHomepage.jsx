import React from "react";
import ReactDOM from "react-dom";

class Jumbotron extends React.Component {
  render() {
    return (
      <div className="jumbotron">
        <h2>Automation Dashboard</h2>
        <p class="lead">You can use this simple web app to:</p>
        <ul>
          <li>Add/update test configurations.</li>
          <li>Generate a new App.config file for the automated tests.</li>
          <li>Run automated tests using stored configurations.</li>
          <li>See a history of test run results.</li>
        </ul>
      </div>
    )
  }
}

ReactDOM.render(<Jumbotron />, document.getElementById('content'));