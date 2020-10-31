import React, { Component } from 'react';
import Axios from 'axios';
import TinderCard from "react-tinder-card";
import "./TinderCards.css"


class TinderCards extends Component {
	constructor(props) {
		super(props);
		this.state = {
			profiles: []
		}
	}

	componentDidMount() {
		Axios.defaults.headers.common['Authorization'] = "Bearer " + this.props.token;
		Axios.get("/api/users/")
			.then(response => {
				this.setState({ profiles: response.data });
				console.log(this.state.profiles)
			}).catch(error => {
				console.log(error);
			}) 
	};
	leftHandler = () => {

	}

	rightHandler = (profile) => {
		Axios.defaults.headers.common['Authorization'] = "Bearer " + this.props.token;
		Axios.post(`/api/users/${this.props.bio.id}/like/${profile.id}`)
			.then(response => {
				console.log(response);
			}).catch(error => {
				alert("failed" + error);
			})
	};

	onSwipe= (profile, direction) => {
		console.log("direction: " + direction, "profile: " + profile);
		(direction == 'right') ? this.rightHandler(profile): this.leftHandler(profile)
	};
	onCardLeftScreen = (e) => {
		console.log(e);
	}

	render() { 
		return ( 
			<div className="tinderCards">
				{
					this.state.profiles.map((profile, index) => (
						<TinderCard
							// onCardLeftScreen = {this.onCardLeftScreen.bind(this, profile)}
							className="swipe" 
							onSwipe={this.onSwipe.bind(this, profile)}
							key={index}
							//preventSwipe={"up", "down"}
						>
							<div className="card" style={{
								backgroundImage: (profile.photoUrl != null) ?
									`url(${profile.photoUrl})` : (profile.gender == "male") ?
										`url("https://cdn.pixabay.com/photo/2016/07/28/01/13/boy-1546843_1280.jpg")` :
										`url("https://cdn.pixabay.com/photo/2018/03/12/12/32/woman-3219507_960_720.jpg")`
							}}>
								<h3>{profile.username}</h3>
							</div>
						</TinderCard>
					))
				}
		</div>
		);
	}
}

export default TinderCards;