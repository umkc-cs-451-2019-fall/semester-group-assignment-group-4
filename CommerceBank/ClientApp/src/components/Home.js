import React, { Component } from 'react';
import { CollapsibleComponent } from './shared/CollapsibleComponent';
export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props)
        this.state = {TransactionData: [], SavingsData: [], loading: true };
    }

    componentDidMount() {
        this.GetInitialLoadTransactionData();
        
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
                        <tr key={Transaction.TansactionId}>  
                            <td>{Transaction.TransactionId}</td>
                            <td>{Transaction.TransactionType}</td>
                            <td>{Transaction.TransactionDate}</td>
                            <td>{Transaction.TransactionAmount}</td>
                            <td>{Transaction.TransactionDescription}</td>
                            <td>{Transaction.AccountBalance}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
    render()
    {
        //Quick Note the below is an assigment based on a conditional statement
        // contents = (if this.state.loading = false then it equals <p> ..</p>
        // else it equals the transaction table function data found above)
        let contents = this.state.loading ? <p><em>Loading...</em></p> : Home.renderTransactionTable(this.state.TransactionData);
        let contents1 = this.state.loading ? <p><em>Loading...</em></p> : Home.renderTransactionTable(this.state.SavingsData);
        return (
            <div>
                <h1 id="tabelLabel" >Hi, Class!</h1>
                <p>This is the sample Home page for a customer, below is a sample table of transaction data</p>
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Checking" content={contents} componentID="1" />
                </div>
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Savings" content={contents1} componentID="4" />
                </div>
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Reports" content={contents1} componentID="2"/>
                </div>
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Custom Alerts" content={contents} componentID="3"/>
                </div>
            </div>
        );
    }
    async GetInitialLoadTransactionData() {
        const response = await fetch('Home/GetInitialLoadTransactionData');
        const data = await response.json();
        this.setState({ TransactionData: data, loading: false });
    }
   
}
