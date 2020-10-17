import React, {Component} from 'react';
import {
  BrowserRouter,
  Route
} from "react-router-dom";

import Header from "../components/Header/Header";
import Chats from "../components/Chats/Chats";
import Login from "../components/Login/Login";
// import TempLogin from "../components/Login/TempLogin";
import './App.css';

import Home from './Home';



class App extends Component {

	state = {
		userlogedin : false
	}

	loginStateHandler = () => {
		const userlog = this.state.userlogedin;
		this.setState({userlogedin: !userlog})
	}

	render() {
		return (
			<div className="App">
				<BrowserRouter>
					<Route path="/" exact>
						{this.state.userlogedin ? 
						<div><Route path="/" exact component={Header} /><Home /></div>: <Login loginer={this.loginStateHandler} />
					}
					</Route>
					<Route path="/Chats" exact>
						<Header backButton="/" />
						<Chats />
				</Route>
				{/* <Route path="/Login" exact component={Header} /> */}
				<Route path="/Login" exact component={Login} />
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
