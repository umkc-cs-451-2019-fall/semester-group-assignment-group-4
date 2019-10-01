import React, { Component } from 'react';

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
                        <th> Amount</th>
                        <th> Date </th>
                        <th> Details </th>
                    </tr>
                </thead>
                <tbody>
                    {TransactionData.map(Transaction =>
                        <tr key={Transaction.id}>
                            <td>{Transaction.amount}</td>
                            <td>{Transaction.date}</td>
                            <td>{Transaction.details}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
    render()
    {
        //Quick Note the below is an assigment based on a conditional statement
        // contets = (if this.state.loading = false then it equals <p> ..</p>
        // else it equals the transaction table function data found above)
        let contents = this.state.loading ? <p><em>Loading...</em></p> : Home.renderTransactionTable(this.state.TransactionData);
        return (
            <div>
                <h1 id="tabelLabel" >Hi, Team</h1>
                <p>This is the Home page, below is a sample table</p>
                {contents}
            </div>
        );
    }
    async GetInitialLoadTransationData() {
        const response = await fetch('Home/GetInitialLoadTransactionData');
        const data = await response.json();
        this.setState({ TransactionData: data, loading: false });
    }
}