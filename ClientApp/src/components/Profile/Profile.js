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
import { Link } from "react-router-dom";


class Profile extends Component {
	constructor(props) {
		super(props);
		this.state = {
			fields: {}
		}
		Axios.get(`api/Users/${this.props.id}`).then(response => {
			this.setState({ fields: response.data })
			console.log(this.state.fields)
		}).catch(error => {
			alert(error);
		})
	}


	

	render() {
		const { first_name, last_name, age, sex, username, password, photoUrl } = this.state.fields;
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
            {username} | {age} | {sex}
          </Typography>
          <Typography variant="body2" color="textSecondary" component="h3">
							Name: {first_name} {last_name}
						</Typography>
        </CardContent>
      </CardActionArea>
				<CardActions>
					<Link to="/profile/edit">
						<Button size="small" color="primary">
							Edit
						</Button>
					</Link>
					<Link to="/profile/delete">
						<Button size="small" color="secondary" startIcon={<DeleteIcon />}>
							Delete
						</Button>
					</Link>
      </CardActions>
    </Card>
			// <div className="background">
			// 	<div className="main">
			// 		<div className="rowfriend">
			// 			<div className="one">
			// 				<div className="img" > 
			// 					{/* <img style="width:100%;" /> */}
			// 				</div>
			// 				<div className="text" >
      //           <input type="text" className="username" placeholder="Username" />
			// 					<input type="text" className="bio" placeholder="Just assume this is a really good sample bio." />
			// 				</div>
			// 			</div>
			// 			<div className="two">
			// 				<div className="text_two">
			// 					<label className="label2">First Name</label> <input type="text" className="input-field2" placeholder="First Name"  />
			// 					<label className="label2">Last Name</label> <input type="text" className="input-field2" placeholder="Last Name"  />
			// 					<label className="label2">Age</label> <input type="text" className="input-field2" placeholder="Age"  />
			// 					<label className="label2">Sex</label> <input type="text" style={{marginBottom:"25px"}} className="input-field2" placeholder="Sex"  />
			// 					<button className="submit-btn">Edit</button>
			// 					<button className="submit-btn">Delete account</button>
			// 				</div>
			// 			</div>
			// 		</div>
			// 	</div>
			// </div>
		);
	}
}

export default Profile;