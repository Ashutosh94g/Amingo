import React, { Component } from 'react';
import Axios from "axios";

import TextField from '@material-ui/core/TextField';
import Link from '@material-ui/core/Link';


class SignIn extends Component {
	constructor(props) {
		super(props);
		this.state = {
			fields: {
				username     : "",
				password     : "",
			}
		}
	};
	changeHandler = (e) => {
		this.setState({
			fields: {
				...this.state.fields,
				[e.target.name]: e.target.value
			}
		})
	};
	submitHandler = (e) => {
		e.preventDefault();
		Axios.post("/api/auth/login", this.state.fields)
			.then(response => {
				this.props.logedInUser(response.data.userToReturn);
				this.props.tokener(response.data.token);
			}).catch(error => {
				console.log(error);
			})
	};
	render() {
		const { username, password } = this.state.fields;

		const usernameField = <TextField
			fullWidth
			variant="filled"
			label="Username"
			type="username"
			name="username"
			value={username}
			onChange={this.changeHandler}
		/>;
		const passwordField = <TextField
			fullWidth
			variant="filled"
			label="Password"
			type="password"
			autoComplete="current-password"
			name="password"
			value={password}
			onChange={this.changeHandler}
		/>;
		return (
			<form className="form__SignIn" action="#" onSubmit={this.submitHandler}>
						<h1 className="signin__account">Sign in</h1>
						<div className="social-container">
							{this.props.button}
						</div>
						{usernameField}
						{passwordField}
						<Link href="#" color="inherit" style={{ padding: 10 }}>Forgot your password?</Link>
						<button className="signIn__button" type="submit">Sign In</button>
					</form>
		);
	}
}

export default SignIn;