import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { users: [], loading: true };
  }

  componentDidMount() {
    this.populateUsers();
  }

  static renderusersTable(users) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Username</th>
            <th>Last Namer</th>
            <th>Role</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user =>
            <tr key={user.id}>
              <td>{user.username}</td>
              <td>{user.lName}</td>
              <td>{user.role}</td>
              <td>{user.description}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderusersTable(this.state.users);

    return (
      <div>
        <h1 id="tabelLabel" >User list</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateUsers() {
    const response = await fetch('https://localhost:7082/User');
    const data = await response.json();
    this.setState({ users: data, loading: false });
  }
}
