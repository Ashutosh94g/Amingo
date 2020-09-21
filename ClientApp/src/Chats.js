import React from 'react';
import Chat from "./Chat";
import "./Chats.css";

function Chats() {
	return (
		<div className="chats">
			<Chat 
			name="kunika" 
			message="Hi"
			timeStamp="25 min ago"
			profilePic = "https://images.pexels.com/photos/1368382/pexels-photo-1368382.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
			/>
		</div>
	)
}

export default Chats
