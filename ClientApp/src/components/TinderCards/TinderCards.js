import React, {Component} from 'react';
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
    this.populateTinderCardsData();
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
	async populateTinderCardsData() {
    const response = await fetch('api/Users');
    const data = await response.json();
    this.setState({ people: data });
  }
}

export default TinderCards;