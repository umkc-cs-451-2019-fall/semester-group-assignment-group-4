/*
  Hi Team, I left this file here to have an example of how to create a new react.js file that can fetch data from the backend 
 The Main things to look at are:
 - Import Statement
 - Contructor
 - The use of props
 - ComponentDidMount() : This is a life cycle function of React. There are many and are some of the most useful parts of react
 - Render() : This is the one required element in a react file, whatever is returned in this function is what gets rendered on screen
 - async populateWeatherData() : This is just a function name, the async at the start lets the page do its thing while it's fetching data.
 - fetch(): this is the good stuff, it gets us the data from the 'controllerName/functionName' that you pass to it
*/




//import React, { Component } from 'react';

//export class FetchData extends Component {
//  static displayName = FetchData.name;

//  constructor(props) {
//    super(props);
//    this.state = { forecasts: [], loading: true };
//  }

//  componentDidMount() {
//    this.populateWeatherData();
//  }

//  static renderForecastsTable(forecasts) {
//    return (
//      <table className='table table-striped' aria-labelledby="tabelLabel">
//        <thead>
//          <tr>
//            <th>Date</th>
//            <th>Temp. (C)</th>
//            <th>Temp. (F)</th>
//            <th>Summary</th>
//          </tr>
//        </thead>
//        <tbody>
//          {forecasts.map(forecast =>
//            <tr key={forecast.date}>
//              <td>{forecast.date}</td>
//              <td>{forecast.temperatureC}</td>
//              <td>{forecast.temperatureF}</td>
//              <td>{forecast.summary}</td>
//            </tr>
//          )}
//        </tbody>
//      </table>
//    );
//  }

//  render() {
//    let contents = this.state.loading
//      ? <p><em>Loading...</em></p>
//      : FetchData.renderForecastsTable(this.state.forecasts);

//    return (
//      <div>
//        <h1 id="tabelLabel" >Weather forecast</h1>
//        <p>This component demonstrates fetching data from the server.</p>
//        {contents}
//      </div>
//    );
//  }

//  async populateWeatherData() {
//    const response = await fetch('weatherforecast');
//    const data = await response.json();
//    this.setState({ forecasts: data, loading: false });
//  }
//}
