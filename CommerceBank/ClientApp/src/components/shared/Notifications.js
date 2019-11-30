
import React, { Component } from 'react';
import '../styles/Notifications.css';
import Logo from '../images/notification.png';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

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

    static notificationLinks() {
        return (
        <div>
        <NavLink tag={Link} className="links" to="/Reports">
            <text className="textLin">ID: 12309887   11/20/1994</text>
        </NavLink>
        <NavLink tag={Link} className="links" to="/Reports">
            <text className="textLin">ID: 12529887   11/10/1998</text>
        </NavLink>
        </div>
            );
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
                className={this.state.tabHover || this.state.active ? "notiContainer tabConExpand" : "notiContainer tabConExpand tabConShrink"}>
                <text className="notiTitle"> Notifications </text>
                <img src={Logo}
                    onMouseOut={this.toggleHover}
                    onMouseEnter={this.toggleHover}
                    className="icon"></img>
                <div className={this.state.active ? "notiContent" : "notiContent notiContentShrink"}>{Notifications.notificationLinks()}</div>
            </div>
        );
    }
}