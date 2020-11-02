import React, { Component } from 'react';
import axios from "axios";
import Chat from "./Chat/Chat";
import "./Chats.css";

class Chats extends Component {
	constructor(props) {
    super(props);
    this.state = { userdata: [], preusername: "", sortedSendMessages: {}, sortedReceivedMessages: {}};
  }

	componentDidMount() {
		console.log(this.props.bio.id)
		axios.defaults.headers.common['Authorization'] = "Bearer " + this.props.token;
		axios.get(`api/users/${this.props.bio.id}/messages`)
			.then(response => {
				this.setState({ userdata: response.data });
				console.log(this.state.userdata);
				this.sortingTheMessages();
			}).catch(error => {
				console.log(error);
			})
	};

	sortingTheMessages = () => {
		let previousUsername = "";
		let previousSenderUsername = this.state.userdata[0].senderUsername;
		this.state.userdata.reverse().forEach(user => {

			//if the sender is logedIn user ==> messages send
			if (user.senderUsername === this.props.bio.username) {
				// console.log("test1")
				if (user.receiverUsername !== previousUsername)
					{
					this.setState({
						sortedSendMessages: {
							receiverUsername: user.receiverUsername,
							messages: [...this.state.sortedSendMessages.messages, user.content]
						}
					});
					previousUsername = user.receiverUsername;
					}//end of the inner if
			}//end of outer if

			if (user.receiverUsername === this.props.bio.username)
			{
				// console.log("test2")
				console.log(user);
				console.log(previousSenderUsername);
				if (user.senderUsername === previousSenderUsername)
				{
					// console.log("test3")
					this.setState({
						sortedReceivedMessages: {
							senderId: user.senderId,
							senderUsername: user.senderUsername,
							message: user.content
						}
					});
					previousSenderUsername = user.senderUsername;
						}//end of inner if
			}//end of outer if
			
		});
		console.log(this.state.sortedReceivedMessages);
		console.log(this.state.sortedSendMessages);
	}
	
	render() {

		
		// const chatsFromState = this.state.sortedReceivedMessages.map((user, index) =>
				
		// 				<Chat
		// 					chatUser={(receiverId, username) => this.props.chatUser(receiverId, username)}
		// 					key={index}
		// 					username={user.senderUsername}
		// 					message={user.content}
		// 					id={user.senderId}
		// 					timeStamp={user.messageSent}
		// 					profilePic={(user.senderPhotoUrl == null) ?
		// 						"https://images.pexels.com/photos/1368382/pexels-photo-1368382.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
		// 						: user.senderPhotoUrl}
		// 				/>
		// 		)

		return (
			<div>
				<Chat
							chatUser={(receiverId, username) => this.props.chatUser(receiverId, username)}
							id={this.state.sortedReceivedMessages.senderId}
							username={this.state.sortedReceivedMessages.senderUsername}
							message={this.state.sortedReceivedMessages.message}
						/>
			</div>
		)
	}
}

export default Chats;

