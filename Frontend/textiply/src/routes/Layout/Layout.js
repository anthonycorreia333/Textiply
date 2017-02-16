import React, { PropTypes } from 'react';
import {Navbar, NavItem, NavDropdown, MenuItem, Nav} from 'react-bootstrap';
import NavBar from './NavBar/NavBar';


class Layout  extends React.Component {
  render () {
    return (
      <div className="Layout">
        <NavBar />
        <div className="container">
          {this.props.children}
        </div>
      </div>
    )
  }
}

export default Layout;
