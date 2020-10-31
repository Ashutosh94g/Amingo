import React, { Component } from 'react';
import Axios from "axios";

import TextField from '@material-ui/core/TextField';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';

class SignUp extends Component {
	constructor(props) {
		super(props);
		this.state = {  
			fields: {
				username     : "",
				password     : "",
				gender       : "",
				dateOfBirth  : "",
				knowAs    	 : "",
				city         : "",
				country      : ""
			}
		}
	}
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
		console.log(this.state.fields);
		Axios.post("/api/auth/register", this.state.fields)
			.then(response => {
				this.props.tokener(response.data.token);
				this.props.logedInUser(response.data.userToReturn);
			}).catch(error => {
				console.log(error);
			})
	};

	genderHandler = (e) => {
		this.setState({
			fields: {
				...this.state.fields,
				gender: e.target.value
			}
		})
	};
	dateChangeHandler = (e) => {
		this.setState({ fields: { ...this.state.fields, dateOfBirth: e.target.value.toString() } })
	};
	render() { 
		const { username, password, gender, dateOfBirth, knowAs, city, country } = this.state.fields;


		const passwordField = <TextField
			fullWidth
			variant="filled"
			label="Password"
			type="password"
			autoComplete="current-password"
			name="password"
			// style={{ marginBottom: 10 }}
			onChange={this.changeHandler}
			value={password} />;
		
		
		const usernameField = <TextField
			fullWidth
			variant="filled"
			label="Username"
			type="username"
			value={username}
			onChange={this.changeHandler}
			name="username"
		/>;

		const nameField = <TextField
			fullWidth
			variant="filled"
			label="Name"
			type="text" value={knowAs}
			onChange={this.changeHandler}
			name="knowAs"
		/>;

		const genderField = <FormControl fullWidth>
			<InputLabel
				fullWidth
				style={{ marginLeft: "12px" }}
				id="Gender">Gender
						</InputLabel>
			<Select
				id="Gender"
				fullWidth
				variant="filled"
				label="gender"
				name="gender"
				value={gender}
				onChange={this.genderHandler}>
				<MenuItem value="">
					<em>None</em>
				</MenuItem>
				<MenuItem value="male">Male</MenuItem>
				<MenuItem value="female">Female</MenuItem>
			</Select>
		</FormControl>;

		const dateOfBirthField = <TextField
			fullWidth
			id="date"
			label="Birthday"
			variant="filled"
			type="date"
			onChange={this.dateChangeHandler}
			defaultValue={dateOfBirth}
			InputLabelProps={{
				shrink: true,
			}} />;
		
		const cityField = <TextField
			fullWidth
			variant="filled"
			label="City"
			type="text" value={city}
			onChange={this.changeHandler}
			name="city"
		/>;

		const countryField = <TextField
			fullWidth
			variant="filled"
			label="Country"
			type="text" value={country}
			onChange={this.changeHandler}
			name="country"
		/>;
		
		return ( 
		<form className="form__SignUp" action="#" onSubmit={this.submitHandler}>
						<h1 className="create__account">Create Account</h1>
						<div style={{ display: "flex", flexDirection: "column"}} className="social-container">
							{/* {buttons} */}
						</div>
						<div>
						<div style={{display: "flex", flexDirection: "row"}}>
							{nameField}
							{genderField}
						</div>
							{dateOfBirthField}
					
				<div style={{flexDirection: "row", display: "flex"}}>
					{usernameField}
					<div>{cityField}</div>
				</div>
				<div style={{flexDirection: "row", display: "flex"}}>
					{passwordField}
					<div>{countryField}</div>
				</div>
			</div>
						<button className="signUp__button" type="submit">Sign up</button>
					</form>
			
		);
	}
}

export default SignUp;