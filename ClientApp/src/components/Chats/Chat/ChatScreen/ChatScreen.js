import React, {useState} from 'react';

import Avatar from "@material-ui/core/Avatar";

import "./ChatScreen.css";

function ChatScreen() {
	const [input, setInput] = useState('');
	const [messages, setMessages] = useState([
		{
			name: "Muskan",
			image: "https://images.pexels.com/photos/1368382/pexels-photo-1368382.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
			message: "Hello"
		},
		{
			name: "Muskan",
			image: "https://images.pexels.com/photos/1368382/pexels-photo-1368382.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
			message: "How is it going?"
		},
		{
			message: "Hi! How is it hanging?"
		},
	]);
	let handleSend = (e) => {
		e.preventDefault();
		setMessages([...messages, {message: input}])
		setInput('');
	}
	return (
		<div className="chatScreen">
			<p className = "chatScreen__timeStamp"> {`You matched with Kunika on 28 / 4 / 2019 `}</p>
			{messages.map((arrMess) => 
			arrMess.name ? (
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
				<input className="chatScreen__inputField" type="text" placeholder="Write a message..." value={input} onChange={(e) => setInput(e.target.value)} />
				<button type="submit" onClick={handleSend} className="chatScreen__inputButton">SEND</button>
			</form>
		</div>
	)
}

export default ChatScreen;
