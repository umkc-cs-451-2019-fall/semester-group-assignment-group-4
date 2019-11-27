import React, { Component, useState } from 'react';
import './styles/CustomAlerts.css';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

export class CustomAlerts extends Component {
    static displayName = CustomAlerts.name;

    constructor(props) {
        super(props);
        this.toggle = this.toggle.bind(this);
        this.renderDropDown = this.renderDropDown.bind(this);
        this.dropDownOptionSelected = this.dropDownOptionSelected.bind(this);
        this.handleUserInput = this.handleUserInput.bind(this);
        this.addCondition = this.addCondition.bind(this);
        this.state = {
            AlertFilters: []
            , numberOfConditions: [{ value: "Select A Trigger", id: 1, dropDownState: false }]
            , UserInput: [{DivID:0,AlertID:0,value:""}]
        };
    }

    componentDidMount() {
        this.getAllAlertFilters();
    }

    async getAllAlertFilters() {
        const response = await fetch('CustomAlerts/GetAlertFiltersAndIDs');
        const data = await response.json();
        this.setState({ AlertFilters: data});
    }

    toggle(event) {
        var updateID = parseInt(event.currentTarget.id) - 1;
        var updateValue = (this.state.numberOfConditions[updateID].dropDownState == true) ? false : true;
        this.state.numberOfConditions[updateID].dropDownState = updateValue;
        this.setState({ numberOfConditions: this.state.numberOfConditions });
    }

    dropDownOptionSelected(event) {
        var optionValue = event.currentTarget.innerHTML;
        var updateID = parseInt(event.currentTarget.parentNode.parentNode.id) -1;
        this.state.numberOfConditions[updateID].value = optionValue;
        this.state.UserInput[updateID].DivID = updateID + 1;
        this.state.UserInput[updateID].AlertID = parseInt(event.currentTarget.id);
        this.setState({ numberOfConditions: this.state.numberOfConditions, UserInput: this.state.UserInput });
        document.getElementById("input_" + event.currentTarget.parentNode.parentNode.id).style.display = "inline-block";
    }

    addCondition() {
        var increaser = this.state.numberOfConditions.length + 1;
        this.state.numberOfConditions.push({ value: "Select A Trigger", id: increaser, dropDownState: false });
        this.state.UserInput.push({ DivID: 0, AlertID: 0, value: "" });
        this.setState({ numberOfConditions: this.state.numberOfConditions, UserInput: this.state.UserInput })
    }

    handleUserInput(event) {
        var userValue = event.target.value;
        var updateID = parseInt(event.target.id.split("_")[1]);
        this.state.UserInput.filter(userinput => userinput.DivID == updateID).value = userValue;
    }

    renderDropDown() {
        return (
            this.state.numberOfConditions.map
                (numberOfConditions =>
                    <div className="selectionDiv" id={"RuleCreationDiv_" + numberOfConditions.id} key={numberOfConditions.id}>Transactions that are
                        <Dropdown className="dropMenu" id={numberOfConditions.id} isOpen={numberOfConditions.dropDownState} onClick={this.toggle}>
                            <DropdownToggle caret id={numberOfConditions.id}> {numberOfConditions.value}</DropdownToggle>
                        <DropdownMenu>
                                {this.state.AlertFilters.map(Triggers => <DropdownItem key={Triggers.id} id={Triggers.id} className="dropdownOptions" onClick={this.dropDownOptionSelected}>
                                {Triggers.alertFilter}</DropdownItem>
                            )}
                        </DropdownMenu>
                        </Dropdown>
                        <input type="text" placeholder="Enter a value" onBlur={this.handleUserInput} className={"UserInputField"} id={"input_" + numberOfConditions.id}></input>
                        <button onClick={this.addCondition} className="AddCondition" title="Add another condition">+</button>
                    </div>)
        )
    }

    render() {
        return (
            <div className="ruleSelectionContainer">
                <div>Custom Rules Selector</div>
                {this.renderDropDown()}
            </div>
        );
    }
}