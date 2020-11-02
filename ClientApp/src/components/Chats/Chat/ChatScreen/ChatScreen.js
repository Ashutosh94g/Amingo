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
	};

	componentDidUpdate() {
		axios.defaults.headers.common['Authorization'] = "Bearer " + this.props.token;
		axios.get(`api/users/${this.props.bio.id}/messages/thread/${this.props.user}`)
			.then(response => {
				if (response.data !== this.state.messages)
					{
						this.setState({messages: response.data})
					}
			}).catch(error => {
				console.log(error)
			})
	}

	changeHandler = (e) => {
		this.setState({ input: e.target.value })
	};

	submitHandler = (e) => {
		e.preventDefault();
		console.log(this.state.input);
		axios.post(`api/users/${this.props.bio.id}/messages`,
			{ senderId: this.props.bio.id, receiverId: this.props.user, content: this.state.input })
			.then(response => {
				this.setState({input: ""})
				console.log(response);
			}).catch(error => {
				console.log(error);
			})
	};

	render() { 
		return (
			<div className="chatScreen">
			{/* <p className = "chatScreen__timeStamp"> {`You matched with Kunika on 28 / 4 / 2019 `}</p> */}
			{this.state.messages.reverse().map((arrMess, index) => 
			arrMess.receiverUsername != this.props.bio.username ? (
				<div className="chatScreen__messages" key={index}>
				<Avatar
				src={arrMess.senderPhotoUrl} 
				alt={arrMess.senderUsername}
				key={index}
				/>
				<p className="chatScreen__text" key={index}>{arrMess.content}</p>
			</div>
			):(
				<div className = "chatScreen__messages" key={index}>
					<p className="chatScreen__textUser">{arrMess.content}</p>
				</div>
			)
			)}
			
			<form className = "chatScreen__input" onSubmit={this.submitHandler} action="#">
				<input className="chatScreen__inputField" type="text" placeholder="Write a message..." value={this.state.input} onChange={this.changeHandler} />
				<button type="submit" className="chatScreen__inputButton">SEND</button>
			</form>
		</div>);
	}
}

export default ChatScreen;