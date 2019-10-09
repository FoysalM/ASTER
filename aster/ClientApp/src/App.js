import React, { Component } from 'react';
import { Switch } from 'react-router';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Assignment } from './components/Assignment';
import { SubmitToIPFS } from './components/student/SubmitToIPFS';
import { test } from './components/test';
import { decrypt } from './components/shared/decrypt';
import { Login } from './components/Login';

export default class App extends Component {
    displayName = App.name;

    render() {
        return (
        <Router>
            <Layout>
                <Switch>
                <Route path='/login' component={Login} />
                <Route exact path='/' component={Home} />
                <Route path='/assignments' component={Assignment} />
                <Route path='/fetchdata' component={FetchData} />
                <Route path='/student/submittoipfs' component={SubmitToIPFS} />
                <Route path='/test' component={test} />
                <Route path='/shared/decrypt' component={decrypt} />
                </Switch>
            </Layout>
        </Router>
        );
    }
}