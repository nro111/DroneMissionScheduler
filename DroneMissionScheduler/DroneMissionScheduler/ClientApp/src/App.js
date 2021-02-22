import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Drones } from './components/Drones';
import { Pilots } from './components/Pilots';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/pilots' component={Pilots} />
        <Route path='/drones' component={Drones} />
      </Layout>
    );
  }
}
