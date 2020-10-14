import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";

import Header from "../components/Header/Header";
import TinderCards from "../components/TinderCards/TinderCards";
import SwipeButtons from "../components/SwipeButtons/SwipeButtons";
import Chats from "../components/Chats/Chats";
import ChatScreen from "../components/Chats/Chat/ChatScreen/ChatScreen";
import Login from "../components/Login/Login";
import './App.css';



function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route path="/chat/:person">
            <Header backButton="/chat" />
            <ChatScreen />
          </Route>
          <Route path="/Login">
            <Header backButton="/" />
            <Login />
          </Route>
          <Route path="/chat">
            <Header backButton="/" />
            <Chats />
          </Route>
          <Route path="/">
            <Header />
            <TinderCards />
            <SwipeButtons />
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
