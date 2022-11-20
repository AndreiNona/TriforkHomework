import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello, there!</h1>
          Feel free to Create a user in "<strong>Create User</strong>".<br/>
          All the users can be seen in "<strong>Fetch Data</strong>".
        </div>
    );
  }
}
