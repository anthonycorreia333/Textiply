import axios from 'axios';
import config from './config';
import qs from 'qs';


export default {
  login(email, password) {
    return new Promise((resolve, reject) => {

      // if we're already logged in
      if(localStorage.authData) {
        resolve();
        this.onChange(true);
        return;
      }

      // otherwise, go out to the server and get a token
      axios
        .post(config.apiUrl + '/api/users/login', qs.stringify({
          grant_type: 'password',
          username: email,
          password: password,

        }))
        .then((response) => {
          localStorage.authData = JSON.stringify(response.data);
          console.log(localStorage.authData)
          resolve();
          this.onChange(true);
        })
        .catch((error) => {
          reject(error);
          this.onChange(false);
        })

    });
  },

  register(data) {

    console.log(config.apiUrl, JSON.stringify(data));
    return axios
      .post(config.apiUrl + '/api/users/register', data)
      .then((response) => {
        console.log('Register Post:', response.data)
        return this.login(data.emailAddress, data.password);
      })

  },

  logout() {
    delete localStorage.authData;
    this.onChange(false);



  },

  getToken() {
    if (localStorage.authData){
      return JSON.parse(localStorage.authData).access_token;
    }
    else {
      return null;
    }
  },

  loggedIn() {
    return !!localStorage.authData;
  },

  onChange() {}
}
