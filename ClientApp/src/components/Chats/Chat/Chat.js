import React from 'react';
import { Link } from "react-router-dom";

import Avatar from "@material-ui/core/Avatar";

import "./Chat.css";

const Chat = (props) => (
	<Link onClick={() => props.chatUser(props.id, props.username)} to={`chat/${props.username}`}>
			<div className="chat">
				<Avatar className="chat__image" alt={props.username} src={props.PhotoUrl} />
				<div className="chat__details">
				<h2>{props.username}</h2>
				<p>{props.message}</p>
				</div>
				<p className="chat__timestamp">{props.timeStamp}</p>
			</div>
		</Link>
	)

export default Chat
