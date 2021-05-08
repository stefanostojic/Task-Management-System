import React, { Component } from 'react';
// import { Route } from 'react-router';
import UserRolesManager from './components/UserRolesManager/UserRolesManager';
import CitiesManager from './components/CitiesManager/CitiesManager';

import './custom.css'

export default class App extends Component {
  // state = {
  //   persons: [
  //     { name: 'Stefan', age: '23' },
  //     { name: 'Dejan', age: '22' },
  //     { name: 'Gaja', age: '22' }
  //   ]
  // }

  render () {
    return (
      <div className="app"> 
        {/* <h1>Hi, I'm a React App</h1> 
        <button>Add role</button>
        <Person name={this.state.persons[0].name} age={this.state.persons[0].age} />
        <Person name={this.state.persons[1].name} age={this.state.persons[0].age} >My hobbies: Racing </Person>
        <Person name={this.state.persons[2].name} age={this.state.persons[0].age} /> */}
        <UserRolesManager></UserRolesManager>
        <CitiesManager></CitiesManager>
      </div>
    );
  }
}
