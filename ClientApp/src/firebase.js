import firebase from "firebase";

const firebaseConfig = {
	apiKey: "AIzaSyB43xozi7FaCADIsPHo1jXSY5MTjNadl3E",
	authDomain: "tinder-clone-fde8c.firebaseapp.com",
	databaseURL: "https://tinder-clone-fde8c.firebaseio.com",
	projectId: "tinder-clone-fde8c",
	storageBucket: "tinder-clone-fde8c.appspot.com",
	messagingSenderId: "10393654075",
	appId: "1:10393654075:web:d231f1e8e7ba462c285d1e",
	measurementId: "G-47ND34EKV9"
};

const firebaseApp = firebase.initializeApp(firebaseConfig);
const database = firebaseApp.firestore();

export default database;