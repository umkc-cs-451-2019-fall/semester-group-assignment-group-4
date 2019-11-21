import React, { Component, useState } from 'react';
import './styles/CustomAlerts.css';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

export class CustomAlerts extends Component {
    static displayName = CustomAlerts.name;

    constructor(props) {
        super(props);

        this.dropDownEqualities = this.dropDownEqualities.bind(this);

        this.toggle = this.toggle.bind(this);

        this.state = {
            dropdownOpen: false
        };
    }

    componentDidMount() {
    }

    toggle() {
        this.setState(prevState => ({
            dropdownOpen: !prevState.dropdownOpen
        }));
    }

    dropDownEqualities() {
        return(
            <Dropdown isOpen={this.state.dropdownOpen} className="dropMenu" toggle={this.toggle}>
                <DropdownToggle caret>
                    Dropdown
                </DropdownToggle>
                <DropdownMenu>
                    <DropdownItem header>Header</DropdownItem>
                    <DropdownItem>Some Action</DropdownItem>
                    <DropdownItem disabled>Action (disabled)</DropdownItem>
                    <DropdownItem divider />
                    <DropdownItem>Foo Action</DropdownItem>
                    <DropdownItem>Bar Action</DropdownItem>
                    <DropdownItem>Quo Action</DropdownItem>
                </DropdownMenu>
            </Dropdown>
        );
    }

    render() {
        return (
            <div className="ruleSelectionContainer">
                <div>Custom Rules Selector</div>
                <div className="selectionDiv">Transactions that are
                    <Dropdown isOpen={this.state.dropdownOpen} className="dropMenu" toggle={this.toggle}>
                        <DropdownToggle caret>
                            Dropdown
                        </DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem header>Header</DropdownItem>
                            <DropdownItem>Some Action</DropdownItem>
                            <DropdownItem>Foo Action</DropdownItem>
                            <DropdownItem>Bar Action</DropdownItem>
                            <DropdownItem>Quo Action</DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                    second option
                    <Dropdown isOpen={this.state.dropdownOpen} className="dropMenu" toggle={this.toggle}>
                        <DropdownToggle caret>
                            Dropdown
                        </DropdownToggle>
                        <DropdownMenu>
                            <DropdownItem header>Header</DropdownItem>
                            <DropdownItem>Some Action</DropdownItem>
                            <DropdownItem>Foo Action</DropdownItem>
                            <DropdownItem>Bar Action</DropdownItem>
                            <DropdownItem>Quo Action</DropdownItem>
                        </DropdownMenu>
                    </Dropdown>
                </div>
            </div>
        );
    }
}