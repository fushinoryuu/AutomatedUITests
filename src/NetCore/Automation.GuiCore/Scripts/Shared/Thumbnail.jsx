import React from "react";

export default class Thumbnail extends React.Component {
    render() {
        return (
            <div className="col-xs-6 col-md-3">
                <a href={this.props.link} className="thumbnail">
                    <img src={this.props.location} alt={this.props.altText} />
                    <div className="caption">
                        <h3 align="center">{this.props.caption}</h3>
                    </div>
                </a>
            </div>
        )
    }
}