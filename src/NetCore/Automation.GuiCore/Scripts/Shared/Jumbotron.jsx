import React from "react";
import ReactDOM from "react-dom";

export default class Jumbotron extends React.Component {
    render() {
        return (
            <div className="jumbotron">
                <h2>{this.props.mainText}</h2>
                <p>{this.props.subText}</p>
                <ul>{this.props.items}</ul>
            </div>
        );
    }
}