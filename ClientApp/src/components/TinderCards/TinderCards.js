import React, { Component } from 'react';
import Axios from 'axios';
import TinderCard from "react-tinder-card";
import "./TinderCards.css"
class TinderCards extends Component {
	constructor(props) {
		super(props);
		this.state = {
			people: []
		}
	}

	componentDidMount() {
		Axios.get("/api/users/", {
			params: {
				
			}
		})
  }

	render() { 
		return ( 
			<div className="tinderCards">
				{
					this.state.people.map((person) => (
						<TinderCard
							className="swipe" 
							key={person.id}
							//preventSwipe={"up", "down"}
						>
							<div className="card" style={{backgroundImage:`url(${person.photoUrl})`}}>
								<h3>{person.first_name}</h3>
							</div>
						</TinderCard>
					))
				}
		</div>
		);
	}
}

export default TinderCards;