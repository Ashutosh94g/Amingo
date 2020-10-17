import React, { Component } from 'react';
// import axios from "axios";
import "./TempLogin.css"

class TempLogin extends Component {
	constructor(props) {
		super(props);
		this.state = { 
			fields: {
				first_name: null,
				last_name: null,
				username: null,
				password: null,
				age: null,
				sex: null,
				Photourl: null
			},
			loginpg: true
		}
	}

	// changeHandler = (e) => {
	// 	this.setState({[e.target.name] : e.target.value});
	// }

	// submitHandler = (e) => {
	// 	e.preventDefault();
	// 	console.log(this.state)
	// 	axios.post("https://localhost:5001/api/Users", this.state)
	// 		.then(response => {
	// 			alert(response);
	// 		}).catch(error => {
	// 			alert(error);
	// 		})
	// }

	toggleLogin = () => {
		const pg = this.state.loginpg
		this.setState({ loginpg: !pg })
	}

	render() { 
		// const { first_name, last_name, username, password, age, sex, Photourl } = this.state;
		return (  
			<div className="box">
        <div className="form-box">
            <div className="button-box">
                <div id="btn" style={{left: this.loginpg ? "0px": "110px"}}></div>
						<button type="button" className="toggle-btn" onClick={this.toggleLogin}>Login</button>
						<button type="button" className="toggle-btn" onClick={this.toggleLogin}>Register</button>  
            </div>
            <div className="social-icons">
                <img src="./104069.png" alt="" />
                <img src="./59439.png" alt="" />
								<img src="./insta.png" alt="" />		
					</div>
					<form id="login" style={this.loginpg ? { left: "50px" } : { left: "-400px" }} className="input-group">
                <input type="text" className="input-field"  required />
                <label>Username</label> 
                <input type="password" className="input-field"  required />
                <label id="pass">Password</label> 
                <input type="checkbox" className="check-box" /><span>Remember Password</span>
                <button type="submit" className="submit-btn">Login</button>
            </form> 
            <form id="register" style={{left: this.loginpg ? "450px": "50px"}} className="input-group2">
                <input type="text" className="input-field2" placeholder="First Name" required />
                <input type="text" className="input-field2" placeholder="Last Name" required />
                <input type="text" className="input-field2" placeholder="Age" required />
                <input type="text" className="input-field2" placeholder="Sex" required />
                <input type="text" className="input-field2" placeholder="Profile Pic" />
                <input type="text" className="input-field2" placeholder="Username" required />
                <input type="password" className="input-field2" placeholder="Password" required />
                <input type="checkbox" className="check-box" /><span>I agree to the terms & conditions</span>
                <button type="submit" className="submit-btn">Register</button>
            </form>
        </div>
        
    </div>
		);
	}
}

export default TempLogin;