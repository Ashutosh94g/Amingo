import React, {useState} from 'react';

import InstagramIcon from '@material-ui/icons/Instagram';
import FacebookIcon from '@material-ui/icons/Facebook';
import MailIcon from '@material-ui/icons/Mail';
import IconButton from '@material-ui/core/IconButton';
import TextField from '@material-ui/core/TextField';
import Link from '@material-ui/core/Link';

import "./Login.css";

function Login() {

	const [classList, setClassList] = useState("container");
	const buttons = <div><IconButton>
							<InstagramIcon style={{color: "#69f0ae"}} fontSize="large" />
						</IconButton>
						<IconButton>
							<FacebookIcon style={{color: "blue"}} fontSize="large" />
						</IconButton>
						<IconButton>
							<MailIcon style={{color: "red"}} fontSize="large" />
						</IconButton></div>

	return (
		<div className={classList} id="container">
		
			<div className="form-container sign-up-container">
				
				<form className="form__SignUp" action="#">
						<h1 className="create__account">Create Account</h1>
						<div className="social-container">
							{buttons}
						</div>
						<span className="spanTag">or use your email for registration</span>
						<TextField fullWidth variant="filled" label="Name" id="standard-size-normal" type="text" />
						<TextField fullWidth variant="filled" label="Email" id="standard-size-normal" type="email" />
						<TextField
						fullWidth
						variant = "filled"
						id="standard-password-input"
						label="Password"
						type="password"
						autoComplete="current-password"
						style={{marginBottom: 10}}
					/>
						<button className="signUp__button">Sign up</button>
					</form>

			</div>
			<div className="form-container sign-in-container">

				<form className="form__SignIn" action="#">
					<h1 className="signin__account">Sign in</h1>
					<div className="social-container">
						{buttons}
					</div>
					<span>or use your account</span>
					<TextField fullWidth variant="filled" label="Email" id="standard-size-normal" type="email" />
					<TextField
						fullWidth
						variant = "filled"
						id="standard-password-input"
						label="Password"
						type="password"
						autoComplete="current-password"
					/>
					<Link href="#" color="inherit" style={{ padding: 10}}>Forgot your password?</Link>
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
						<button className="ghost" onClick={()=>{
								setClassList("container");
							}}>Sign In</button>
					</div>
					<div className="overlay-panel overlay-right">
							<h1 className="hello__friends">Hello, Friend!</h1>
							<p>Enter your personal details and start journey with us</p>
							<button className="ghost" onClick={()=>{
								setClassList("container right-panel-active");
							}}>Sign up</button>
					</div>
			</div>
			</div>
</div>
	)
}

export default Login;
