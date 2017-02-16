import React, { PropTypes } from 'react'
import AuthService from '../../AuthService';
import Register from './Components/Register';
import { Grid, Row, Col } from 'react-bootstrap';



class Auth extends React.Component {
  constructor(props) {
    super(props);

    this.login = this.login.bind(this);
    this.register = this.register.bind(this);
  }
  login(email, password) {
    AuthService
      .login(email, password)
      .then((response) => {
          this.props.router.push('/dashboard');
      })
      .catch((error) => {

        alert('No login for you')
      });
  }

  register(data) {
    AuthService
      .register(data)
      .then((response) => {
        alert('Registered and logged in!');
        this.props.router.push('/dashboard');
      })
      .catch((error) => {
        console.log(error);
        console.log(JSON.stringify(error));
        alert(error.response.data.message);
        console.log('Report:', error);
      });
  }
  render () {
    return (
      <div className="auth">
        <Grid>
                <Row>
                  <Col sm={6}>
                    <p>Place holder test..</p>
                  </Col>
                  <Col sm={6}>
                    <Register onRegister={this.register}/>
                  </Col>
                </Row>
        </Grid>
      </div>
    )
  }
}

export default Auth;
