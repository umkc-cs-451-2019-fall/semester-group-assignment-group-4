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
        this.GetSavingsLoadTransactionData();
    }

    static renderReportsDescription() {
        return (

            <div>
                <p> </p>
            <p>This is where we plan to implement the interface for customers to view reports based on their business rules and notifications.</p>
            <p></p>
            <p>Customers will easily be able set the parameters for the type of data they do or do not want to see on the screen.</p>
            <p>They also should be able to easily export this data to excel, along with the transaction data related to their accounts.</p>
        </div>
        );
    }
    static renderCustomAlertsDescription() {
        return (

            <div>
                <p> </p>
            <p>Here we will have the interface that gives customers CRUD operations for the Business Rules.</p>
            <p></p>
            <p>Business Rules are events that customers want to receive notifications for and that the application will generate reports for.</p>
            <p>We decided that "Custom Alerts" made a bit more sense as a descriptor for "Business Rules" on the Front-End. They're interchangeable.</p>
        </div>
        );
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
        let contents1 = this.state.loading ? <p><em>Loading...</em></p> : Home.renderTransactionTable(this.state.SavingsData);

        let reportsDescrip = this.state.loading ? <p><em>Loading...</em></p> : Home.renderReportsDescription();
        let alertsDescrip = this.state.loading ? <p><em>Loading...</em></p> : Home.renderCustomAlertsDescription();

        return (
            <div>
                <h1 id="tabelLabel" >Hi, Class!</h1>
                <p>This is the sample Home page for a customer, below is a prototype of the main User Interface</p>
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Checking" content={contents} componentID="1" />
                </div>
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Savings" content={contents1} componentID="4" />
                </div>
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Reports" content={reportsDescrip} componentID="2"/>
                </div>
                <div class="homeContainterDiv">
                    <CollapsibleComponent header="Custom Alerts" content={alertsDescrip} componentID="3"/>
                </div>
            </div>
        );
    }
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
