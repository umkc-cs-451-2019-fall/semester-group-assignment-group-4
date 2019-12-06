import React, { Component } from 'react';
import { CollapsibleComponent } from './shared/CollapsibleComponent';
import './styles/Home.css'



export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props)
        this.state = {TransactionData: [], SavingsData: [], CheckingBalance: "$4571.08", SavingsBalance: "$2,000.00", loading: true };
    }

    componentDidMount() {
        this.GetInitialLoadTransactionData();    
    }
    static renderTransactionTable(TransactionData) {
        return (
            <table className='table table-striped' aria-labelledby="tableLable">
                <thead>
                    <tr>
                        <th> Date </th>
                        <th> Type </th>
                        <th> Amount </th>
                        <th> Description</th>
                        <th> State</th>
            
                    </tr>
                </thead>
                <tbody>
                    {TransactionData.map(Transaction =>
                        <tr key={Transaction.tansactionId}>  
                            <td>{Transaction.transactionDate}</td>
                            <td>{Transaction.transactionType}</td>
                            <td>{Transaction.transactionAmount}</td>
                            <td>{Transaction.transactionDescription}</td>
                            <td>{Transaction.state}</td>
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
        let contents1 = this.state.loading ? <p><em>Loading...</em></p> : Home.renderTransactionTable(this.state.TransactionData);
        let checkingHeader = `Checking - ${this.state.CheckingBalance}`;
        let savingsHeader = `Savings - ${this.state.SavingsBalance}`;
        return (
            <div className="HomePageMainDivClassName">
                <div >
                    <div className="homeContainterDiv">
                        <CollapsibleComponent header={checkingHeader} content={contents} componentID="1" />
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
   
}
