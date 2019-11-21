import React, { Component } from 'react';
import { CollapsibleComponent } from './shared/CollapsibleComponent';
import './styles/Reports.css';

export class Reports extends Component {
    constructor(props) {
        super(props);
        this.state = { rule1: false, rule2: false, rule3: false, TransactionData: []};
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name

        this.setState({ [name]: value})
    }

    static renderCheckBox() {
        return (
            <table className='table table-striped' aria-labelledby="tableLable">
                <tr>
                    <label className="option">
                        <input name="rule1" type="checkbox"
                            //checked={this.state.rule1}
                            onChange={this.handleInputChange} />
                        <text className="ruleText">rule 1</text>
                    </label>
                </tr>
                <tr>
                    <label className="option">
                        <input name="rule2" type="checkbox"
                            //checked={this.state.rule2}
                            onChange={this.handleInputChange} />
                            <text className="ruleText">rule 2</text>
                    </label>
                </tr>
                <tr>
                    <label className="option">
                        <input name="rule3" type="checkbox"
                            //checked={this.state.rule3}
                            onChange={this.handleInputChange} />
                        <text className="ruleText">rule 3</text>
                    </label>
                </tr>
            </table>
        )
    }

    static renderTransactionTable(TransactionData) {
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
        let checkboxes = this.state.loading ? <p><em>Loading...</em></p> : Reports.renderCheckBox();
        
        let transactionTable = this.state.loading ? <p><em>Loading...</em></p> : Reports.renderTransactionTable(this.state.TransactionData);
         
        return (
            <div className="ReportsPageMainDivClassName">
                <div>
                    <div className="reportsContainterDiv">
                        <CollapsibleComponent header= 'Business Rules' content={checkboxes} componentID="1" />
                    </div>
                    <div className="reportsContainterDiv">
                        <CollapsibleComponent header= 'Notifications' content={transactionTable} componentID="4" />
                    </div>
                </div>
            </div>
        );
    }
}
