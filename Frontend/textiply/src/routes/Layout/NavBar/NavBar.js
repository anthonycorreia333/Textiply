import React, { Component } from 'react'
import {Navbar, NavItem, NavDropdown, MenuItem, Nav} from 'react-bootstrap';
import { withRouter } from 'react-router';
import './NavBar.css';
import { LinkContainer } from 'react-router-bootstrap';



class NavBar extends Component {
  render () {
    return (
      <div className="NavBar">
      <Navbar inverse collapseOnSelect>
  <Navbar.Header>
    <Navbar.Brand>
      <p>Textiply</p>
    </Navbar.Brand>
    <Navbar.Toggle />
  </Navbar.Header>
  <Navbar.Collapse>
    <Nav>
      <LinkContainer to="/dashboard"><NavItem eventKey={1} href="#">Dashboard</NavItem></LinkContainer>
      <LinkContainer to="/addcontact"><NavItem eventKey={2} href="#">Add Contacts</NavItem></LinkContainer>
      <NavDropdown eventKey={3} title="Dropdown" id="basic-nav-dropdown">
        <MenuItem eventKey={3.1}>Action</MenuItem>
        <MenuItem eventKey={3.2}>Another action</MenuItem>
        <MenuItem eventKey={3.3}>Something else here</MenuItem>
        <MenuItem divider />
        <MenuItem eventKey={3.3}>Separated link</MenuItem>
      </NavDropdown>
    </Nav>
    <Nav pullRight>
      <LinkContainer to="/auth"><NavItem eventKey={1} href="#">Logout</NavItem></LinkContainer>

    </Nav>
  </Navbar.Collapse>
</Navbar>
      </div>


    )
  }
}

export default NavBar;
