import React, { Component } from 'react';

// STATELESS CLASS COMPONENT
export default class UserRole extends Component {
    render() {
        return (
            <div onClick={() => this.props.click(this.props.name)} className="item user-role">
                {this.props.name}
            </div>
        );
    }
}