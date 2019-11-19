import React, { Component } from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './../styles/SideBarButtons.css';
import { Notifications } from './Notifications';
import reportIcon from '../images/reports.png';
import homeIcon from '../images/home.png';
import customIcon from '../images/custom.png';

export class SideBarButtons extends Component {
    constructor(props) {
        super(props);
        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.toggleHover = this.toggleHover.bind(this);
        this.state = {
            collapsed: true,
            homeHover: false,
            reportsHover: false,
            customHover: false
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    toggleHover(tab) {
        switch (tab) {
            case "home":
                this.setState({ homeHover: !this.state.homeHover });
                break;
            case "reports":
                this.setState({ reportsHover: !this.state.reportsHover });
                break;
            case "custom":
                this.setState({ customHover: !this.state.customHover });
                break;
        }
    }

    render() {
        let home = "home";
        let reports = "reports";
        let custom = "custom";

        return (
            <div className="sideBarDiv">
                <NavLink tag={Link} className={this.state.homeHover ? "navbar navText" : "navbar"} to="/">
                    <div className={this.state.homeHover ? "item itemExpand" : "item"}>
                        <img onMouseOut={this.toggleHover.bind(this, home)} onMouseEnter={this.toggleHover.bind(this, home)} src={homeIcon} className="navIcon"></img>
                        <text className="text">Home</text>
                    </div>
                </NavLink>
                <NavLink className="navbar" tag={Link} to="/Reports">
                    <div className={this.state.reportsHover ? "item itemExpand" : "item"}>
                        <img onMouseOut={this.toggleHover.bind(this, reports)} onMouseEnter={this.toggleHover.bind(this, reports)} src={reportIcon} className="navIcon"></img>
                        <text className="text">Reports</text>
                    </div>
                </NavLink>
                <NavLink className="navbar" tag={Link} to="/CustomAlerts">
                    <div className={this.state.customHover ? "item itemExpand" : "item"}>
                        <img onMouseOut={this.toggleHover.bind(this, custom)} onMouseEnter={this.toggleHover.bind(this, custom)} src={customIcon} className="navIcon"></img>
                        <text className="text">Custom Alerts</text>
                    </div>
                </NavLink>
                <Notifications />
            </div>
            );
    }
}
