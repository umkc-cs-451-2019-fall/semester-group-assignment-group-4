import React, { Component } from 'react';
import { CollapsibleComponent } from './shared/CollapsibleComponent';
import './styles/Reports.css';

export class Reports extends Component {
    constructor(props) {
        super(props);
        this.handleInputChange = this.handleInputChange.bind(this);
        this.renderCheckBox = this.renderCheckBox.bind(this);
        this.renderTransactionTable = this.renderTransactionTable.bind(this);
        this.state = { loading: true, TransactionData: [], clientAlerts: [], selectedAlert: null};
    }

    handleInputChange = (event) => {
        var selectedAlertID = event.currentTarget.defaultValue;
        this.setState({ selectedAlert: selectedAlertID });
    }

    componentDidMount() {
        this.GetClientAlerts();
    }

    componentDidUpdate() {
        if (this.state.selectedAlert != null) {
            this.LoadSelectedAlertsTransactions(this.state.selectedAlert);
        }
    }

    async LoadSelectedAlertsTransactions(selectedAlert) {
        const response = await fetch('Reports/GetSelectedAlertsTransactions/' + selectedAlert);
        const data = await response.json();
        this.setState({ TransactionData: data });
    }

    async GetClientAlerts() {
        const response = await fetch('Reports/GetClientAlertsIDAndName');
        const data = await response.json();
        this.setState({ clientAlerts: data, loading: false });
    }

    renderCheckBox(clientAlerts) {
        return (
            <table className='table table-striped' aria-labelledby="tableLable">
                <tbody>
                    {clientAlerts.map(Alerts =>
                        <tr key={Alerts.alertsID}>
                            <td>
                                <label className="option">
                                    <input value={Alerts.alertsID} name="alertOption" type="radio" onClick={this.handleInputChange}/>
                                    <text> {Alerts.alertName} </text>
                                </label>
                            </td>
                        </tr>)}
                </tbody>
            </table>
        )
    }

    renderTransactionTable(TransactionData) {
        return (
            <table className='table table-striped' aria-labelledby="tableLable">
                <thead>
                    <tr>
                        <th> Transaction Number</th>
                        <th> Type </th>
                        <th> Date </th>
                        <th> Ammount </th>
                        <th> Description</th>
                        <th> Balance</th>

                    </tr>
                </thead>
                <tbody>
                    {TransactionData.map(Transaction =>
                        <tr key={Transaction.tansactionId}>
                            <td>{Transaction.transactionId}</td>
                            <td>{Transaction.transactionType}</td>
                            <td>{Transaction.transactionDate}</td>
                            <td>{Transaction.transactionAmount}</td>
                            <td>{Transaction.transactionDescription}</td>
                            <td>{Transaction.accountBalance}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        //Quick Note the below is an assigment based on a conditional statement
        // contents = (if this.state.loading = false then it equals <p> ..</p>
        // else it equals the transaction table function data found above)
        //just a placeholder until the business rules actually fetch data from the sql server
        let checkboxes = this.state.loading ? <p><em>Loading...</em></p> : this.renderCheckBox(this.state.clientAlerts);
        
        let transactionTable = this.state.loading ? <p><em>Loading...</em></p> : this.renderTransactionTable(this.state.TransactionData);
         
        return (
            <div className="ReportsPageMainDivClassName">
                <div>
                    <div className="reportsContainterDiv">
                        <CollapsibleComponent header= 'Alerts' content={checkboxes} componentID="1" />
                    </div>
                    <div className="reportsContainterDiv">
                        <CollapsibleComponent header= 'Notifications' content={transactionTable} componentID="4" />
                    </div>
                </div>
            </div>
        );
    }
}
