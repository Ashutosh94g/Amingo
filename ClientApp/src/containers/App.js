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
		id: 9,
		token: ""
	}

	loginStateHandler = () => {
		const userlog = this.state.userlogedin;
		this.setState({ userlogedin: !userlog })
	}

	tokenHandler = (token) => {
		this.setState({ token: token });
		console.log(token);
	};

	getUserId = (id) => {
		this.setState({id: id})
	}

	render() {
		return (
			<div className="App">
				<BrowserRouter>
					<Suspense fallback="<div>Loading...</div>">
					{!this.state.userlogedin ?
						<Route path="/">
							<Login loginer={this.loginStateHandler} getId={(id) => this.getUserId(id)} tokener={(token) => this.tokenHandler(token)} />
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
