import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Notifications } from './components/Notifications';
import { CustomAlerts } from './components/CustomAlerts';
import { UserSettings } from './components/UserSettings';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/' component={Notifications} />
            <Route exact path='/' component={CustomAlerts} />
            <Route exact path='/' component={UserSettings} />
      </Layout>
    );
  }
}
