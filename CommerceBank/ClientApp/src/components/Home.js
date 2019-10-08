import React, { Component } from 'react';
import { CollapsibleComponent } from './shared/CollapsibleComponent';
export class Home extends Component {
    static displayName = Home.name;
    constructor(props) {
        super(props)
        this.state = { TransactionData: [], loading: true };
    }

    componentDidMount() {
        this.GetInitialLoadTransationData();
    }
    static renderTransactionTable(TransactionData) {
        return (
            <table className='table table-striped' aria-labelledby="tableLable">
                <thead>
                    <tr>
                        <th> Date</th>
                        <th> Transaction ID</th>
                        <th> Description</th>
                        <th> Amount</th>
                        <th> Account Number</th>
               
                    </tr>
                </thead>
                <tbody>
                    {TransactionData.map(Transaction =>
                        <tr key={Transaction.id}>           
                            <td>{Transaction.date}</td>
                            <td>{Transaction.id}</td>
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
        return (
            <div>
                <h1 id="tabelLabel" >Hi, Class!</h1>
                <p>This is the sample Home page for a customer, below is a sample table of transaction data</p>
                {contents}
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Spending" content={contents} />
                </div>
            </div>
        );
    }
    async GetInitialLoadTransationData() {
        const response = await fetch('Home/GetInitialLoadTransactionData');
        const data = await response.json();
        this.setState({ TransactionData: data, loading: false });
    }
}
