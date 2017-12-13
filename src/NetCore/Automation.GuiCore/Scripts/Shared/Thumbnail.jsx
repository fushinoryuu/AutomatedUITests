import React from "react";

export default class Thumbnail extends React.Component {
    render() {
        return (
            <div className="col-xs-6 col-md-3">
                <a href="#" className="thumbnail">
                    <img src={this.props.location} alt={this.props.altText} />
                    <div class="caption">
                        <h3 align="center">{this.props.caption}</h3>
                    </div>
                </a>
            </div>
        )
    }
}