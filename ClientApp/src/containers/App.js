import React, {Component} from 'react';
import {
  BrowserRouter,
  Route
} from "react-router-dom";

import Header from "../components/Header/Header";
import Chats from "../components/Chats/Chats";
import Login from "../components/Login/Login";
import Profile from "../components/Profile/Profile"
// import TempLogin from "../components/Login/TempLogin";
import './App.css';

import Home from './Home';
import EditProfile from '../components/Profile/EditProfile';



class App extends Component {

	state = {
		userlogedin: false,
		id: 9
	}

	loginStateHandler = () => {
		const userlog = this.state.userlogedin;
		this.setState({userlogedin: !userlog})
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
							</Route></div>}
				</BrowserRouter>

				
				{/* <Router>
					<Switch>
						<Route path="/chat/:person">
							<Header backButton="/chat" />
							<ChatScreen />
						</Route>
						<Route path="/Login">
							<Header backButton="/" />
							<Login />
						</Route>
						<Route path="/chat">
							<Header backButton="/" />
							<Chats />
						</Route>
						<Route path="/">
							<Header />
							<TinderCards />
							<SwipeButtons />
						</Route>
					</Switch>
				</Router> */}
			</div>
		)
	}
}

export default App;
