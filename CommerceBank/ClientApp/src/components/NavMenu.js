import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './styles/NavMenu.css';
import imgLink from './images/logo.png';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

      this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
        collapsed: true,
        userData: ""
    };
    }

    componentDidMount() {
        this.getUser();
    }

    async getUser() {
        var userID = 1;// TODO: This is hardcoded. Ideally would use a login that would do some checks and get this value for us
        const response = await fetch('Reports/GetUserData/' + userID);
        const data = await response.json();
        this.setState({ userData: data });
    }
  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

    render() {
        var firstName = (this.state.userData != "") ? this.state.userData[0].firstName : "Unknown";
        var lastName = (this.state.userData != "") ? this.state.userData[0].lastName : "User";
      return (
          <header>
              <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" dark>
                  <Container>
                      <NavbarBrand><img src={imgLink} className="bannerIcon"></img></NavbarBrand>
                      <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                      <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                          <ul className="navbar-nav flex-grow">
                              <NavItem>
                                  <NavLink tag={Link} className="text-light" to="/">{firstName} {lastName}</NavLink>
                              </NavItem>
                              <NavItem>
                                 <NavLink tag={Link} className="text-light" to="/Notifications">Logout</NavLink>
                              </NavItem>
                              <NavItem>
                                  <NavLink tag={Link} className="text-light" to="/UserSettings">Settings</NavLink>
                              </NavItem>
                          </ul>
                      </Collapse>
                  </Container>
              </Navbar>
          </header>
    );
  }
}
