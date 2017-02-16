import React from 'react'
import { Panel, FormGroup, FormControl, Button, Grid, Row, Col } from 'react-bootstrap'
import axios from 'axios';
import config from '../../../config';



class AddPerson extends React.Component {
  constructor(props){
    super(props)
    this.state = {
      phoneNumber:'',
      firstName:'',
      lastName:'',
      city:'',
      zip:'',
      gender:''
    }
    this.handleChange = this.handleChange.bind(this);
    this.addPerson = this.addPerson.bind(this);
  }
  handleChange(event){
    const target = event.target;
    const value = target.value;
    const name = target.name;
    this.setState({
      [name]: value
    });
  }

  addPerson(event){
    axios
      .post(config.apiUrl + '/api/Audiences', this.state)
      .then((response)=>{
        alert('You added a contact to your list!')
      })
  }

  deletePerson(id){
    axios
      .delete(config.apiUrl + '/api/Audiences' + id)
  }
  render () {
    return (
      <div>
        <Panel header="Add Contact">
        <form>
          <FormGroup bsSize="large">
              <FormControl name="phoneNumber" type="text" placeholder="Phone Number" value={this.state.phoneNumber} onChange={this.handleChange} />
            </FormGroup>
            <FormGroup bsSize="large">
                <FormControl name="firstName" type="text" placeholder="First Name" value={this.state.firstName} onChange={this.handleChange} />
              </FormGroup>
              <FormGroup bsSize="large">
                <FormControl name="lastName" type="text" placeholder="Last Name" value={this.state.lastName} onChange={this.handleChange} />
              </FormGroup>
              <FormGroup bsSize="large">
                <FormControl name="city" type="text" placeholder="City" value={this.state.city} onChange={this.handleChange} />
              </FormGroup>
              <FormGroup bsSize="large">
                <FormControl name="zip" type="text" placeholder="Zip" value={this.state.zip} onChange={this.handleChange} />
              </FormGroup>
              <FormGroup bsSize="large">
                <FormControl name="lastName" type="text" placeholder="Last Name" value={this.state.lastName} onChange={this.handleChange} />
              </FormGroup>
              <br />
              <div className="col-sm-4">
                                  Gender:
                                  <select className="classtype form-control" value={this.state.gender} name="classType" onChange={this.handleChange}>
                                    <option value="male"> Male</option>
                                    <option value="female"> Female</option>
                                  </select>
              </div>
              </form>
              <Button bsStyle="primary" className="pull-right" onClick={this.addPerson}>Add Contact</Button>
          </Panel>
        </div>

    )
  }
}

export default AddPerson;
