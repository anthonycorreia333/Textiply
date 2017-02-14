import React, { PropTypes } from 'react';
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
