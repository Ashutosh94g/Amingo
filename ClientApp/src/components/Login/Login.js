import React, {Component} from 'react';
import axios from "axios";

import InstagramIcon from '@material-ui/icons/Instagram';
import FacebookIcon from '@material-ui/icons/Facebook';
import MailIcon from '@material-ui/icons/Mail';
import IconButton from '@material-ui/core/IconButton';
import TextField from '@material-ui/core/TextField';
import Link from '@material-ui/core/Link';

import "./Login.css";

class Login extends Component {

	constructor(props) {
		super(props);
	}
	
	state = {
		classList: "container",
		fields: {
			first_name: null,
			last_name: null,
			age: null,
			sex: null,
			username: null,
			password: null,
			photoUrl: null
		}
	}

	submitHandler = (e) => {
		e.preventDefault();
		console.log(this.state.fields)
		axios.post("/api/Users", this.state.fields)
			.then(response => {
				alert(response);
			}).catch(error => {
				alert(error);
		})
	}
	changeHandler = (e) => {
		this.setState({
			fields: {
				...this.state.fields,
				[e.target.name] : e.target.value 
		}})
	}

	render() {

		const { first_name, last_name, age, sex, username, password, photoUrl } = this.state.fields;

		const buttons = <div><IconButton>
			<InstagramIcon style={{ color: "#69f0ae" }} fontSize="large" />
		</IconButton>
			<IconButton>
				<FacebookIcon style={{ color: "blue" }} fontSize="large" />
			</IconButton>
			<IconButton>
				<MailIcon style={{ color: "red" }} fontSize="large" />
			</IconButton></div>

		return (
			
			<div className={this.state.classList} id="container">
		
				<div className="form-container sign-up-container">
				
					<form className="form__SignUp" action="#" onSubmit={this.submitHandler}>
						<h1 className="create__account">Create Account</h1>
						<div style={{ display: "flex", flexDirection: "column"}} className="social-container">
							{/* {buttons} */}
						</div>
						{/* <span className="spanTag">or use your email for registration</span> */}
						<div style={{ display: "flex", flexDirection: "row"}}><TextField
							fullWidth
							variant="filled"
							label="First name"
							id="standard-size-normal"
							type="text" value={first_name}
							onChange={this.changeHandler}
							name="first_name"
						/>
						<TextField
							fullWidth
							variant="filled"
							label="Last name"
							id="standard-size-normal"
							type="text" value={last_name}
							onChange={this.changeHandler}
							name="last_name"
							/></div>
						<div style={{ display: "flex", flexDirection: "row"}}><TextField
							fullWidth
							variant="filled"
							label="age"
							id="standard-size-normal"
							type="number" value={age}
							onChange={this.changeHandler}
							name="age"
						/>
						<TextField
							fullWidth
							variant="filled"
							label="Sex"
							id="standard-size-normal"
							type="text" value={sex}
							onChange={this.changeHandler}
							name="sex"
							/></div>
						<div style={{ display: "flex", flexDirection: "row"}}>
						<TextField
							fullWidth
							variant="filled"
							label="Username"
							id="standard-size-normal"
							type="username"
							value={username}
							onChange={this.changeHandler}
							name="username"
						/>
						<TextField
							fullWidth
							variant="filled"
							id="standard-password-input"
							label="Password"
							type="password"
							autoComplete="current-password"
							name="password"
							// style={{ marginBottom: 10 }}
							onChange={this.changeHandler}
							value={password}
						/>
						</div>
						<TextField
							fullWidth
							variant="filled"
							id="standard-password-input"
							label="photoUrl"
							type="text"
							autoComplete="current-password"
							name="photoUrl"
							onChange={this.changeHandler}
							value={photoUrl}
						/>
						<button className="signUp__button" type="submit">Sign up</button>
					</form>

				</div>
				<div className="form-container sign-in-container">

					<form className="form__SignIn" action="#">
						<h1 className="signin__account">Sign in</h1>
						<div className="social-container">
							{buttons}
						</div>
						{/* <span>or use your account</span> */}
						<TextField fullWidth variant="filled" label="Username" id="standard-size-normal" type="username" />
						<TextField
							fullWidth
							variant="filled"
							id="standard-password-input"
							label="Password"
							type="password"
							autoComplete="current-password"
						/>
						<Link href="#" color="inherit" style={{ padding: 10 }}>Forgot your password?</Link>
						<button className="signIn__button">Sign In</button>
					</form>

				</div>

				<div className="overlay-container">
					<div className="overlay">
						<div className="overlay-panel overlay-left">
							<h1 className="Welcome__back">Welcome Back!</h1>
							<p>
								To keep connected with us please login with your personal info
						</p>
							<button className="ghost" onClick={() => {
								this.setState({ classList: "container"});
							}}>Sign In</button>
						</div>
						<div className="overlay-panel overlay-right">
							<h1 className="hello__friends">Hello, Friend!</h1>
							<p>Enter your personal details and start journey with us</p>
							<button className="ghost" onClick={() => {
								this.setState({ classList: "container right-panel-active" });
							}}>Sign up</button>
						</div>
					</div>
				</div>
			</div>
		)
	}
}

export default Login;
