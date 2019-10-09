import React, { Component } from 'react';
//import './App.css';
import { Form } from 'react-bootstrap';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';



export class Login extends Component {
    displayName = Login.name

    constructor() {
        super();

        this.state = {
            Email: '',
            Password: ''
        }

        this.Password = this.Password.bind(this);
        this.Email = this.Email.bind(this);
        this.Login = this.Login.bind(this);
    }

    Email(event) {
        this.setState({ Email: event.target.value })
    }

    Password(event) {
        this.setState({ Password: event.target.value })
    }
    Login() {
    // debugger;
        this.event = fetch('https://localhost:44332/api/login', {
            credentials: 'include',
            method: 'get', headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' }
        }).then((Response) => Response.json())
          .then((result) => {
        console.log('result:', result);
                if (result.Status === 'Invalid')
                    alert('Invalid User');
                else
                    this.props.history.push("/FetchData");
            })
    }

    render() {

        return (
            <div>
                <Grid>
                    <h3> Login to ASTER </h3>
                    <Form>
                        <input type="email" onChange={this.Email} />
                        <br />
                        <input type="password" placeholder="Password" onChange={this.Password} />

                        <Button onClick={this.Login} type="submit">
                            Login
                        </Button>
                    </Form>
                </Grid>
                    <hr />
            </div>

        );
    }
}

// export default Login;