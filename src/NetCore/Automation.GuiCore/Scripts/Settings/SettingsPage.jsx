import React from "react";
import ReactDOM from "react-dom";

const parentMainText = "Automation Settings";
const parentSubText = "You can use this page to update the test configurations for your Selenium tests.";

class Jumbotron extends React.Component {
    render() {
      return (
        <div className="jumbotron">
          <h2>{this.props.mainText}</h2>
          <p>{this.props.subText}</p>
        </div>
      )
    }
  }

ReactDOM.render(<Jumbotron mainText={parentMainText} subText={parentSubText} />, document.getElementById('SettingsJumbrotron'));