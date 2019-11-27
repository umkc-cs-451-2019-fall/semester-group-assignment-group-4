import React, { Component, useState } from 'react';
import { CollapsibleComponent } from './shared/CollapsibleComponent';
import './styles/CustomAlerts.css';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

export class CustomAlerts extends Component {
    static displayName = CustomAlerts.name;

    constructor(props) {
        super(props);
        this.toggle = this.toggle.bind(this);
        this.renderDropDown = this.renderDropDown.bind(this);
        this.renderAllAlerts = this.renderAllAlerts.bind(this);
        this.dropDownOptionSelected = this.dropDownOptionSelected.bind(this);
        this.handleUserInput = this.handleUserInput.bind(this);
        this.addCondition = this.addCondition.bind(this);
        this.removeCondition = this.removeCondition.bind(this);
        this.restConditions = this.restConditions.bind(this);
        this.getAllAlert = this.getAllAlert.bind(this);
        this.deleteRule = this.deleteRule.bind(this);
        this.handleDelete = this.handleDelete.bind(this);
        this.CreateNewRule = this.CreateNewRule.bind(this);
        this.PostNewRule = this.PostNewRule.bind(this);
        this.state = {
            AlertFilters: [],
            AllAlerts:[]
            , numberOfConditions: [{ value: "Select A Trigger", id: 1, dropDownState: false }]
            , UserInput: [{ DivID: 0, AlertID: 0, value: "" }]
            , DeleteAlertID: null
        };
    }

    componentDidMount() {
        this.getAllAlertFilters();
        this.getAllAlert();
    }

    componentDidUpdate() {
        if (this.state.DeleteAlertID != null) {
            this.deleteRule(this.state.DeleteAlertID);
        }
    }
    async getAllAlertFilters() {
        const response = await fetch('CustomAlerts/GetAlertFiltersAndIDs');
        const data = await response.json();
        this.setState({ AlertFilters: data});
    }
    async getAllAlert() {
        const response = await fetch('Reports/GetClientAlertsIDAndName');
        const data = await response.json();
        this.setState({ AllAlerts: data});
    }

    async deleteRule(ID) {
        const response = await fetch('CustomAlerts/DeleteAlert/' + ID);
        const data = await response.json();
        this.setState({ AllAlerts: data, DeleteAlertID: null});
    }

    async PostNewRule(Filters) {
        //$.ajax({
        //    url: 'CustomeAlerts/PostNewAlert/',
        //    type: 'GET',
        //    data: { Filters: Filters },
        //    success: function (result) {
        //        this.state.numberOfConditions = [{ value: "Select A Trigger", id: 1, dropDownState: false }];
        //        this.state.UserInput = [{ DivID: 0, AlertID: 0, value: "" }];
        //        this.setState({
        //            numberOfConditions: this.state.numberOfConditions,
        //            UserInput: this.state.UserInput,
        //            AllAlerts: result,
        //            DeleteAlertID: null
        //        })}
        //})
        var url = 'CustomAlerts/PostNewAlert/?Filters=' + Filters;
        const response = await fetch(url);
        const data = await response.json();
        this.state.numberOfConditions = [{ value: "Select A Trigger", id: 1, dropDownState: false }];
        this.state.UserInput = [{ DivID: 0, AlertID: 0, value: "" }];
        this.setState({
            numberOfConditions: this.state.numberOfConditions,
            UserInput: this.state.UserInput,
            AllAlerts: data,
            DeleteAlertID: null
        })
    }

    CreateNewRule() {
        //var FiltersString = encodeURIComponent(JSON.stringify(this.state.UserInput));
        var FiltersString = JSON.stringify(this.state.UserInput);
        this.PostNewRule(FiltersString);
    }

    handleDelete(event) {
        var ID = event.target.value;
        this.setState({ DeleteAlertID: ID });
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

    removeCondition(event) {
        var elementToRemoveID = parseInt(event.target.id);
        if (this.state.numberOfConditions.length > 1) {
            document.getElementById("RuleCreationDiv_" + elementToRemoveID).style.display = "none";
            this.state.UserInput[elementToRemoveID - 1].AlertID = 0;
            this.state.UserInput[elementToRemoveID - 1].DivID = 0;
            this.state.UserInput[elementToRemoveID - 1].value = "";
            this.setState({ UserInput: this.state.UserInput });
        }
    }

    restConditions() {
        this.state.numberOfConditions = [{ value: "Select A Trigger", id: 1, dropDownState: false }];
        this.state.UserInput = [{ DivID: 0, AlertID: 0, value: "" }];
        this.setState({
            numberOfConditions: this.state.numberOfConditions,
            UserInput: this.state.UserInput
        })
    }

    handleUserInput(event) {
        var userValue = event.target.value;
        var updateID = parseInt(event.target.id.split("_")[1]);
        this.state.UserInput[updateID - 1].value = userValue;
        this.setState({ UserInput: this.state.UserInput });
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
                        <button onClick={this.removeCondition} className="RemoveCondition" title="Remove this condition" id={numberOfConditions.id}>-</button>
                    </div>)
        )
    }

    renderAllAlerts(AllAlerts) {
        return (
            <table className='table table-striped' aria-labelledby="tableLable">
                <tbody>
                    {AllAlerts.map(Alerts =>
                        <tr key={Alerts.alertsID}>
                            <td>
                                <button value={Alerts.alertsID} title="Delete this rule" onClick={this.handleDelete}> X </button>
                                <label className="option">
                                    <text> {Alerts.alertName} </text>
                                </label>
                            </td>
                        </tr>)}
                </tbody>
            </table>
        )
    }

    render() {
        return (
            <div>
                <div className="ruleSelectionContainer">
                    <div>Custom Rules Selector</div>
                    {this.renderDropDown()}
                    <button onClick={this.restConditions} className="RestConditions" title="Reset the custom alert">Rest</button>
                    <button onClick={this.CreateNewRule} className="CreateRule">Create</button>
                </div>
                <div className="AlertsContainterDiv">
                    <CollapsibleComponent header='Alerts' content={this.renderAllAlerts(this.state.AllAlerts)} componentID="ActiveAlerts" />
                </div>
            </div>

        );
    }
}