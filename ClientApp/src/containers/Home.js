import { Divider } from "@material-ui/core";
import React, { Component } from "react";
import Header from "../components/Header/Header";
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