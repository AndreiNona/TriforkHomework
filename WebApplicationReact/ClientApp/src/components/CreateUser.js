import React, { Component } from 'react';

export class CreateUser extends Component {
  static displayName = CreateUser.name;

  constructor(props) {
    super(props);
    this.state = {
        user: {

            username: props.username,

            lName: props.lName,

            role: props.role,
            
            description: props.description,
            id: 0

        }};
  }
//Creates console error
    changeUsername(event) {

        var user = this.state.user;

        user.username  = event.target.value;


        this.setState({ user: user });

    }


    changeLName(event) {

        var user      = this.state.user;

        user.lName = event.target.value;


        this.setState({ user: user });

    }
//Since the role select uses onChange, if the user dose not interact the end object will not have a value for role
    handleRoleChanged(event) {

        var user    = this.state.user;

        user.role = event.target.value;


        this.setState({ user: user });

    }
    changeDescription(event) {

        var user    = this.state.user;

        user.description = event.target.value;


        this.setState({ user: user });

    }


    handleButtonClicked() {

        console.log(this.state.user);
        console.log(JSON.stringify(this.state.user));
        fetch('https://localhost:7082/User/Add', {
            method: 'POST',
            //Additional headers will need changes in server policy 
            headers:{'accept': 'application/json','Content-Type': 'application/json'},
            body: JSON.stringify(this.state.user)
        }).then(()=>{
            console.log('new user added')
        })
    }

  render() {
    return (
        <div>

            <label>

                Username:

            </label>

            <input type="text" value={this.state.user.username} onChange={this.changeUsername.bind(this)}/>

            <br/>

            <label>

                Last Name:

            </label>

            <input type="text" value={this.state.user.lName} onChange={this.changeLName.bind(this)}/>

            <br/>

            <label>

                Role:

            </label>
            
            <select value={this.state.user.role} onChange={this.handleRoleChanged.bind(this)}>

                <option value="User">

                    User

                </option>

                <option value="Admin">

                    Admin

                </option>

            </select>
            <br/>
            <label>

                Description:

            </label>

            <input type="text" value={this.state.user.description} onChange={this.changeDescription.bind(this)}/>

            <br/>
            <button onClick={this.handleButtonClicked.bind(this)}>

                Make User

            </button>
        </div>
    );
  }
}
