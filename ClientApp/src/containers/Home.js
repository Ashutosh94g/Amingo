import React, { Component } from "react";
import TinderCards from "../components/TinderCards/TinderCards";
import SwipeButtons from "../components/SwipeButtons/SwipeButtons";


class Home extends Component {
	constructor(props) {
		super(props);
		this.state = {  }
	}
	render() { 
		return ( 
			<div className="Home">
				<TinderCards />
				<SwipeButtons />
			</div>
		);
	}
}

export default Home;