import React, { Component } from "react";

import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import DeleteIcon from '@material-ui/icons/Delete';

import "./Profile.css"
import Axios from "axios";
import { Link, Redirect } from "react-router-dom";


class Profile extends Component {
	constructor(props) {
		super(props);
		this.state = {}
	}


	

	render() {
		const { id, username, gender, age, knowAs, photoUrl } = this.props.bio;
		console.log(this.props.bio);

		return (
			<Card className="Profile" style={{maxWidth: 345}}>
      <CardActionArea>
        <CardMedia
          component="img"
          alt="Contemplative Reptile"
          height="200"
          image={photoUrl}
          title="Contemplative Reptile"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
            {username} | {age} | {gender}
          </Typography>
          <Typography variant="body2" color="textSecondary" component="h3">
							Name: {knowAs}
						</Typography>
        </CardContent>
      </CardActionArea>
				<CardActions>
					<Link to="/profile/edit">
						<Button size="small" color="primary">
							Edit
						</Button>
					</Link>
					<Link to="/">
						<Button size="small" color="primary" onClick={this.props.loginer}>
							Logout
						</Button>
					</Link>
					<Link to="/profile/delete">
						<Button size="small" color="secondary" startIcon={<DeleteIcon />}>
							Delete
						</Button>
					</Link>
      </CardActions>
    </Card>
		);
	}
}

export default Profile;