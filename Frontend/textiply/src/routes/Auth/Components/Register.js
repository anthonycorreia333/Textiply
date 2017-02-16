import React, { PropTypes } from 'react'
import { Link } from 'react-router';
import { Panel, FormControl, FormGroup, Button } from 'react-bootstrap';


class Register extends React.Component {
  constructor(props){
    super(props);

    this.state= {
      emailAddress: '',
      password: '',
      confirmPassword: '',
      firstName:'',
      lastName:'',
      business:''
    }

    this.register = this.register.bind(this);
    this.handleChange = this.handleChange.bind(this);
  }
    handleChange(event){
      const target = event.target;
      const value = event.value;
      const name = event.name;

      this.setState({
        [name]: value
      });
    }
    register() {
      this.props.onRegister(this.state);
    }

  render () {
    return(
      <div>
        <Panel header="Register">
        <FormGroup bsSize="large">
            <FormControl name="emailAddress" type="text" placeholder="Email Address" value={this.state.emailAddress} onChange={this.handleChange} />
          </FormGroup>
          <FormGroup bsSize="large">
              <FormControl name="password" type="password" placeholder="Password" value={this.state.password} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup bsSize="large">
              <FormControl name="confirmPassword" type="password" placeholder="Confirm Password" value={this.state.confirmPassword} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup bsSize="large">
              <FormControl name="businessName" type="text" placeholder="Business Name" value={this.state.businessName} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup bsSize="large">
              <FormControl name="firstName" type="text" placeholder="First Name" value={this.state.firstName} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup bsSize="large">
              <FormControl name="lastName" type="text" placeholder="Last Name" value={this.state.lastName} onChange={this.handleChange} />
            </FormGroup>
            <Button bsStyle="primary" onClick={this.register}>Register</Button>
        </Panel>
      </div>
    )
  }
}

export default Register;
