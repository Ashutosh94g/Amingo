import React, { Component } from 'react';
import {Link} from "react-router-dom"
import axios from "axios";


import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import SaveIcon from '@material-ui/icons/Save';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';

class EditProfile extends Component {
	constructor(props) {
		super(props);
		this.state = {
			fields: {}
		}
		
	}
	componentDidMount() {
		axios.get(`api/Users/${this.props.id}`).then(response => {
			this.setState({ fields: response.data })
			console.log(this.state.fields)
		}).catch(error => {
			alert(error);
		})
	}
	changeHandler = (e) => {
		this.setState({
			fields: {
			...this.state.fields,
			[e.target.name]: e.target.value
		}})
	}
	submitHandler = (e) => {
		alert("worked")
	}
	
	render() { 
		const { first_name, last_name, age, sex, username, password, photoUrl } = this.state.fields;
		return (
			<Card className="EditProfile" style={{maxWidth: 345}}>
			<form onSubmit={this.submitHandler}>
      <CardActionArea>
        <CardMedia
          component="img"
          alt="Contemplative Reptile"
          height="200"
          image={photoUrl}
          title="Contemplative Reptile"
					/>
						
        <CardContent>
					<Typography gutterBottom variant="p" component="p">
            age: {age} | sex: {sex}
          </Typography>
          <TextField label="username" placeholder={username} value={username} onChange={this.changeHandler} />
          <TextField label="first_name" placeholder={first_name} value={first_name} onChange={this.changeHandler} />
          <TextField label="last_name" placeholder={last_name} value={last_name} onChange={this.changeHandler} />
          <TextField label="photoUrl" placeholder={photoUrl} value={photoUrl} onChange={this.changeHandler} />
          <TextField label="old-password" type="password" placeholder={password} onChange={this.changeHandler} value={password} />
          <TextField label="new-password" type="password" placeholder="new-password" onChange={this.changeHandler} />
					
        </CardContent>
      </CardActionArea>
				<CardActions>
					<Link to="/">
						<Button
							type="submit"
							variant="contained"
							color="primary"
							size="small"
							className="delete__button"
							startIcon={<SaveIcon />}>
						save</Button>
					</Link>
      </CardActions>
		</form>
    </Card>
		);
	}
}

export default EditProfile;