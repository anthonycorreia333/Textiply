import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import { Router, Route, hashHistory } from 'react-router';
import Layout from './routes/Layout/Layout';
import Register from './routes/Auth/Components/Register';
import Auth from './routes/Auth/Auth';
import AddPerson from './routes/Layout/AddPerson/AddPerson';
import Dashboard from './routes/Layout/Dashboard/Dashboard';


ReactDOM.render(
  (
    <Router history={hashHistory}>
      <Route path="/" component={App}>
          <Route path="/auth" component={Auth} />
          <Route path="/register" component={Register}/>
          <Route path="/layout" component={Layout}>
            <Route path="/dashboard" component={Dashboard}/>
            <Route path="/addcontact" component={AddPerson}/>


        </Route>
      </Route>
    </Router>

  ),
  document.getElementById('root')
);
