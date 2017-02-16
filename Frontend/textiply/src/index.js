import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import { Router, Route, hashHistory } from 'react-router';
import Layout from './routes/Layout/Layout';
import Register from './routes/Auth/Components/Register';
import Auth from './routes/Auth/Auth';


ReactDOM.render(
  (
    <Router history={hashHistory}>
      <Route path="/" component={App}>
          <Route path="/auth" component={Auth} />
          <Route path="/register" component={Register}/>
          <Route path="/layout" component={Layout}>


        </Route>
      </Route>
    </Router>

  ),
  document.getElementById('root')
);
