import React, { Component } from 'react';
import axios from "axios";
import Chat from "./Chat/Chat";
import "./Chats.css";

class Chats extends Component {
	constructor(props) {
    super(props);
    this.state = { userdata: []};
  }

	componentDidMount() {
		console.log(this.props.bio.id)
		axios.defaults.headers.common['Authorization'] = "Bearer " + this.props.token;
		axios.get(`api/users/${this.props.bio.id}/messages`)
			.then(response => {
				this.setState({ userdata: response.data });
				console.log(this.state.userdata);
			}).catch(error => {
				console.log(error);
			})
	};
	
	render() {
		return (
			<div>{
				this.state.userdata.map((user, index) =>
					<Chat
						chatUser={(receiverId, username) => this.props.chatUser(receiverId, username)}
						key={index}
						username={user.senderUsername}
						message={user.content}
						id={user.senderId}
						timeStamp={user.messageSent}
						profilePic={(user.senderPhotoUrl == null) ?
							"https://images.pexels.com/photos/1368382/pexels-photo-1368382.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
							: user.senderPhotoUrl}

			/>
				)}
		</div>
		);
	}
}

export default Chats;

