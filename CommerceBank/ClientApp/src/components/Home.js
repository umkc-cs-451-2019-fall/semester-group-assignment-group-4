import React, { Component } from 'react';
import { CollapsibleComponent } from './shared/CollapsibleComponent';
import './styles/Home.css'



export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props)
        this.state = {TransactionData: [], SavingsData: [], CheckingBalance: "$459.26", SavingsBalance: "$2,000.00", loading: true };
    }

    componentDidMount() {
        this.GetInitialLoadTransactionData();
        this.GetSavingsLoadTransactionData();
    }
    static renderTransactionTable(TransactionData) {
        return (
            <table className='table table-striped' aria-labelledby="tableLable">
                <thead>
                    <tr>
                        <th> Date</th>
                        <th> Description</th>
                        <th> Amount</th>
                        <th> Account Number</th>
               
                    </tr>
                </thead>
                <tbody>
                    {TransactionData.map(Transaction =>
                        <tr key={Transaction.id}>           
                            <td>{Transaction.date}</td>
                           
                            <td>{Transaction.details}</td>
                            <td>{Transaction.amount}</td>
                            <td>{Transaction.account}</td>
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
        let checkingHeader = `Checking - ${this.state.CheckingBalance}`;
        let savingsHeader = `Savings - ${this.state.SavingsBalance}`;
        return (
            <div id="HomePageMainDiv" className="HomePageMainDivClassName">
                <div id="HomePageContentDiv">
                    <div className="homeContainterDiv">
                        <CollapsibleComponent header={checkingHeader} content={contents} componentID="1" />
                    </div>
                    <div className="homeContainterDiv">
                        <CollapsibleComponent header={savingsHeader} content={contents1} componentID="4" />
                    </div>
                    
                </div>
            </div>
        );
    }

    // Need to also fetch and assign account numbers and balances so they are not in the transactions table
    async GetInitialLoadTransactionData() {
        const response = await fetch('Home/GetInitialLoadTransactionData');
        const data = await response.json();
        this.setState({ TransactionData: data, loading: false });
    }
    
    async GetSavingsLoadTransactionData() {
        const response = await fetch('Home/GetSavingsLoadTransactionData');
        const data = await response.json();
        this.setState({ SavingsData: data, loading: false });
    }
}
