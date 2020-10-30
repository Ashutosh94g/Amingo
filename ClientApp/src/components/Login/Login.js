import React, {Component} from 'react';
import axios from "axios";

import InstagramIcon from '@material-ui/icons/Instagram';
import FacebookIcon from '@material-ui/icons/Facebook';
import MailIcon from '@material-ui/icons/Mail';
import IconButton from '@material-ui/core/IconButton';

import MenuItem from '@material-ui/core/MenuItem';

import "./Login.css";
import SignUp from './SignUp/SignUp';
import SignIn from './SignIn/SignIn';

class Login extends Component {

	// constructor(props) {
	// 	super(props);
	// }
	
	state = {
		classList: "container",
		getData: [],
		logedin: false
	}

	submitHandler = (e) => {
		e.preventDefault();
		console.log(this.state.fields)
		
		axios.post("/api/Users", this.state.fields)
			.then(response => {
				alert(response);
				this.props.loginer();
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

	loginsubmitHandler = (e) => {
		e.preventDefault();
		console.log(e);
		axios.get("/api/Users").then(response => {
			this.setState({ getData: response.data })
			this.state.getData.map(user => {
				if ((user.username === this.state.signupFields.username) && (user.password === this.state.signupFields.password)) {
					this.setState({ logedin: true })
					this.props.getId(user.id);
					this.props.loginer();
				}
				return null;
			})
			if (!this.state.logedin) {
				alert("please enter correct details");
			}
		}).catch(error => {
			alert(error);
		})
	}
	signInChangeHandler = (e) => {
		this.setState({
			signupFields: {
			...this.state.signupFields,
			[e.target.name]: e.target.value
		}})
	}

	render() {

		// const { username, password, gender, dateOfBirth, knownAs, city, country } = this.state.fields;

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
					<SignUp />
				</div>


				<div className="form-container sign-in-container">
					<SignIn button={buttons} />
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
