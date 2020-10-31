import React, {Component} from 'react';

import InstagramIcon from '@material-ui/icons/Instagram';
import FacebookIcon from '@material-ui/icons/Facebook';
import MailIcon from '@material-ui/icons/Mail';
import IconButton from '@material-ui/core/IconButton';

import "./Login.css";
import SignUp from './SignUp/SignUp';
import SignIn from './SignIn/SignIn';

class Login extends Component {

	state = {
		classList: "container",
		token: "",
		logedin: false
	}

	render() {

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
					<SignUp
						tokener={(token) => this.tokenHandler(token)}
						logedInUser={(userToReturn) => this.props.logedInUser(userToReturn)}
					/>
				</div>


				<div className="form-container sign-in-container">
					<SignIn
						button={buttons}
						tokener={(token) => this.props.tokener(token)}
						logedInUser={(userToReturn) => this.props.logedInUser(userToReturn)}
					/>
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
