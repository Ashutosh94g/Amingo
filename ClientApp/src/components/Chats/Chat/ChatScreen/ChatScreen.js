import React, { Component } from 'react';
import axios from "axios";

import Avatar from "@material-ui/core/Avatar";

import "./ChatScreen.css";

class ChatScreen extends Component {
	state = {
		messages: [],
		input: ""
	}

	componentDidMount() {
		console.log(this.props.user)
		axios.defaults.headers.common['Authorization'] = "Bearer " + this.props.token;
		axios.get(`api/users/${this.props.bio.id}/messages/thread/${this.props.user}`)
			.then(response => {
				this.setState({ messages: response.data })
				console.log(this.state.messages)
			}).catch(error => {
				console.log(error)
			})
	}

	changeHandler = (e) => {
		this.setState({ input: e.target.value })
	};

	submitHandler = () => {
		console.log(this.state.input);
	}

	render() { 
		return (
			<div className="chatScreen">
			{/* <p className = "chatScreen__timeStamp"> {`You matched with Kunika on 28 / 4 / 2019 `}</p> */}
			{this.state.messages.map((arrMess) => 
			arrMess.username == this.props.bio.username ? (
				<div className="chatScreen__messages">
				<Avatar
				src={arrMess.image} 
				alt={arrMess.name}
				/>
				<p className="chatScreen__text">{arrMess.message}</p>
			</div>
			):(
				<div className = "chatScreen__messages">
					<p className="chatScreen__textUser">{arrMess.message}</p>
				</div>
			)
			)}
			
			<form className = "chatScreen__input">
				<input className="chatScreen__inputField" type="text" placeholder="Write a message..." value={this.state.input} onChange={this.changeHandler} />
				<button type="submit" onClick={this.submitHandler} className="chatScreen__inputButton">SEND</button>
			</form>
		</div>);
	}
}

export default ChatScreen;