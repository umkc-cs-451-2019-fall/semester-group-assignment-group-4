
import React, { Component } from 'react';
import '../styles/Notifications.css';
import Logo from '../images/notification.png';


export class Notifications extends Component {
    static displayName = Notifications.name;
    constructor(props) {
        super(props);
        this.toggleClass = this.toggleClass.bind(this);
        this.toggleHover = this.toggleHover.bind(this);
        this.state = {
            active: false,
            tabHover: false
        };
    }

    toggleClass() {
        const currentState = this.state.active;
        this.setState({ active: !currentState });
    }

    toggleHover() {
        this.setState({ tabHover: !this.state.tabHover });
    }

    render() {
        return (
            <div onClick={this.toggleClass}
                className={this.state.tabHover ? "tabConExpand" : "tabConExpand tabConShrink"}>
                <img src={Logo}
                    onMouseOut={this.toggleHover}
                    onMouseEnter={this.toggleHover}
                    className={this.state.active ? "IconExpand" : "IconCollapse Icon"}></img>
                {this.state.tabHover &&
                    <div id={this.state.active ? "contentShow" : "contentHide"}>To Be Inserted</div>}
            </div>
        );
    }
}