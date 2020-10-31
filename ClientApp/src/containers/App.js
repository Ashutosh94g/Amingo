import React, {Component, lazy, Suspense} from 'react';
import {
  BrowserRouter,
	Route,
	Redirect
} from "react-router-dom";

import './App.css';


const Home = lazy(() => import('./Home'));
const Header = lazy(() => import("../components/Header/Header"));
const Chats = lazy(() => import("../components/Chats/Chats"));
const Login = lazy(() => import("../components/Login/Login"));
const Profile = lazy(() => import("../components/Profile/Profile"));
const EditProfile = lazy(() => import("../components/Profile/EditProfile"));
const DeleteProfile = lazy(() => import("../components/Profile/DeleteProfile"));



class App extends Component {

	state = {
		userlogedin: false,
		user: "",
		token: ""
	}

	loginStateHandler = () => {

	}

	tokenHandler = (token) => {
		this.setState({ token: token });
		console.log(token);
	};

	getUserId = (id) => {
		this.setState({id: id})
	}

	logedInUser = (user) => {
		const userlog = this.state.userlogedin;
		this.setState({ user: user,  userlogedin: !userlog});
	}

	render() {
		return (
			<div className="App">
				<BrowserRouter>
					<Suspense fallback="Loading...">
					{!this.state.userlogedin ?
						<Route path="/">
								<Login
									logedInUser={(userToReturn) => this.logedInUser(userToReturn)}
									tokener={(token) => this.tokenHandler(token)}
								/>
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
								<Profile id={this.state.id} loginer={this.loginStateHandler} />
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
						</Suspense>
				</BrowserRouter>
			</div>
		)
	}
}

export default App;
