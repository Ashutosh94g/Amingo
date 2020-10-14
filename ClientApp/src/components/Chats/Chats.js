import React, { Component } from 'react';
import Chat from "./Chat/Chat";
import "./Chats.css";

class Chats extends Component {
	constructor(props) {
    super(props);
    this.state = { userdata: []};
  }

	componentDidMount() {
    this.populateUserData();
  }
	
	render() {
		return (
			<div>{
				this.state.userdata.map(user => 
					<Chat 
			name={user.first_name} 
			message={user.last_name}
			timeStamp="25 min ago"
			profilePic = "https://images.pexels.com/photos/1368382/pexels-photo-1368382.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
			/>
				)}
				
		</div>
		);
	}
	async populateUserData() {
    const response = await fetch('api/Users');
    const data = await response.json();
    this.setState({ userdata: data });
  }
}

export default Chats;

