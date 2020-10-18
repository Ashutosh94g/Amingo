import React, { Component } from 'react';
import axios from "axios";


import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';

class EditProfile extends Component {
	constructor(props) {
		super(props);
		this.state = {
			fields: {},
			datafetched: false,
			putFields: {},
			patchFields: [],
			patchArray: []
		}
		
	}
	componentDidMount() {
		if (!this.state.datafetched) {
			axios.get(`api/Users/${this.props.id}`).then(response => {
				this.setState({ fields: response.data })
				console.log(this.state.fields)
				this.setState({ datafetched: true })
			}).catch(error => {
				alert(error);
			})
		}
	}
	changeHandler = (e) => {
		var lpatchFields = this.state.patchFields
		lpatchFields.push(e.target.name)
		this.setState({
			fields: {
				...this.state.fields,
				[e.target.name]: e.target.value
			},
			putFields: {
				...this.state.putFields,
				[e.target.name]: e.target.value
			},
			patchFields: lpatchFields
		})
	}
	submitHandler = (e) => {
		e.preventDefault();
		console.log(this.state.putFields);
		this.state.patchFields.forEach(element => {
			let lpatchArray = this.state.patchArray
			lpatchArray.push({ "op": "replace", "path": element, "value": this.state.putFields[element] })
			this.setState({ patchArray: lpatchArray });
		});
		console.log(this.state.patchArray);
		axios.patch(`/api/Users/${this.state.fields.id}`, this.state.patchArray).then(response => {
			console.log(response)
			alert("Your profile is updated");
		}).catch(error => {
			console.log(error)
		})
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
          <TextField label="username" name="username" placeholder={username} value={username} onChange={this.changeHandler} />
          <TextField label="first_name" name="first_name" placeholder={first_name} value={first_name} onChange={this.changeHandler} />
          <TextField label="last_name"  name="last_name" placeholder={last_name} value={last_name} onChange={this.changeHandler} />
          <TextField label="photoUrl" name="photoUrl" placeholder={photoUrl} value={photoUrl} onChange={this.changeHandler} />
          <TextField label="old-password" name="password" type="password" placeholder={password} onChange={this.changeHandler} value={password} />
          <TextField label="new-password" type="password" placeholder="new-password" onChange={this.changeHandler} />
					
        </CardContent>
      </CardActionArea>
				<CardActions>
					<button type="submit">SAVE</button>
					{/* <Link to="/">
						<Button
							type="submit"
							variant="contained"
							color="primary"
							size="small"
							className="delete__button"
							startIcon={<SaveIcon />}>
						save</Button>
					</Link> */}
      </CardActions>
		</form>
    </Card>
		);
	}
}

export default EditProfile;