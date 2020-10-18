import React, {Component} from 'react';
import {
  BrowserRouter,
	Route,
	Redirect
} from "react-router-dom";

import Header from "../components/Header/Header";
import Chats from "../components/Chats/Chats";
import Login from "../components/Login/Login";
import Profile from "../components/Profile/Profile"
import './App.css';

import Home from './Home';
import EditProfile from '../components/Profile/EditProfile';
import DeleteProfile from "../components/Profile/DeleteProfile";



class App extends Component {

	state = {
		userlogedin: false,
		id: 9
	}

	loginStateHandler = () => {
		const userlog = this.state.userlogedin;
		this.setState({ userlogedin: !userlog })
	}
	getUserId = (id) => {
		this.setState({id: id})
	}

	render() {
		return (
			<div className="App">
				<BrowserRouter>
					{!this.state.userlogedin ?
						<Route path="/">
							<Login loginer={this.loginStateHandler} getId={(id) => this.getUserId(id)} />
						</Route> : <div><Route path="/" exact>
								<div><Route path="/" exact component={Header} /><Home /></div>
						</Route>
							<Route path="/Chats" exact>
								<Header backButton="/" />
								<Chats />
							</Route>
							{/* <Route path="/Login" exact component={Header} /> */}
							<Route path="/profile" exact>
								<Header backButton="/" />
								<Profile id={this.state.id} />
							</Route>
							<Route path="/profile/edit" exact>
								<Header backButton="/profile" />
								<EditProfile id={this.state.id} />
							</Route>
						<Route path="/profile/delete" exact>
								<Header backButton="/profile" />
								<DeleteProfile id={this.state.id} loginer={this.loginStateHandler} />
								{!this.state.userlogedin ? 
									<Redirect to="/" />: null
								}
							</Route></div>
					}
				</BrowserRouter>
			</div>
		)
	}
}

export default App;
