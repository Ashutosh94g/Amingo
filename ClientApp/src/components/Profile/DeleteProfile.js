import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import DeleteIcon from '@material-ui/icons/Delete';

import axios from "axios";
class DeleteProfile extends Component {
	constructor(props) {
		super(props);
		this.state = {
			fields: {}
		}
		axios.get(`api/Users/${this.props.id}`).then(response => {
			this.setState({ fields: response.data })
			console.log(this.state.fields)
		}).catch(error => {
			alert(error);
		})
	}

	clickHandler = () => {
		axios.delete(`api/Users/${this.props.id}`).then(response => {
			alert("Your account has been deleted");
			this.props.loginer();
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
            {first_name} {last_name} | {age} | {sex}
          </Typography>
          <Typography variant="body2" color="textSecondary" component="h3">
							Do you want to delete {username}?
						</Typography>
        </CardContent>
      </CardActionArea>
				<CardActions>
					<Link to="/profile/delete">
						<Button size="small" color="secondary" startIcon={<DeleteIcon />} onClick={this.clickHandler}>
							Delete
						</Button>
					</Link>
					<Link to="/profile/">
						<Button size="small" color="primary">
							Cancel
						</Button>
					</Link>
      </CardActions>
    </Card>
		);
	}
}

export default DeleteProfile;