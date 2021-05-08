import React, { Component } from 'react';
import UserRole from '../UserRole/UserRole'

// STATEFUL CLASS COMPONENT
class UserRolesManager extends Component {

  state = {
    userRoles: [], 
    selectedUserRole: null
  }

  componentDidMount() {
    this.loadRolesHandler();
  }

  loadRolesHandler = async () => {
    fetch('http://localhost:54720/api/userRoles')
      .then((response) => response.json())
      .then(userRoles => {
        this.setState({ userRoles });
      });
  }

  saveRoleHandler = async () => {
    let newRoleName = document.getElementById('role-name').value;
    if (newRoleName == null || newRoleName.length === 0) {
      console.error('Role name can\'t be empty.');
      return;
    }

    let userRole = {
      name: newRoleName
    }

    console.log('role that will be saved: ', userRole);

    let res = await fetch(`http://localhost:54720/api/userRoles`, {
      method: 'post',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(userRole)
    });
    let confirmation = await res.json();
    if (res.ok) {
      console.log('The new user role was saved successfully.');
      this.setState({
        userRoles: [...this.state.userRoles, confirmation]
      })
    } else {
      console.warn(res);
    }
    console.log(confirmation);
    document.getElementById('role-name').value = "";
  }

  selectUserRoleHandler = (userRoleName) => {
    console.log('Selected UserRole: ', userRoleName);
  }

  render() {
    return (
      <div className="manager user-roles-manager">
        <h1>User Roles Manager</h1>
        <hr />
        <h4>Number of user roles: {this.state.userRoles.length}</h4>
        {this.state.userRoles.map(userRole => (
          <UserRole
            key={userRole.id}
            name={userRole.name}
            click={this.selectUserRoleHandler} />
        ))}
        <hr />
        <button className="btn btn-sm btn-primary" onClick={this.loadRolesHandler}>Load roles</button>
        <p>Role name: </p>
        <input className="input input-sm" id="role-name" placeholder="New role name" />
        <button className="btn btn-sm btn-primary" onClick={this.saveRoleHandler}>Save</button>
      </div>
    );
  }
}

export default UserRolesManager;