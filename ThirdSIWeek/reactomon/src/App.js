import React, { Component } from "react";
import Navbar from "./components/layout/Navbar";
import Axios from "axios";
import { BrowserRouter as Router, Route } from "react-router-dom";
import "./App.css";
import PokemonList from "./components/pages/PokemonList";
import TypeList from "./components/pages/TypeList";

class App extends Component {
  state = {
    pokemons: []
  };

  componentDidMount() {
    Axios.get("https://pokeapi.co/api/v2/pokemon").then(res =>
      this.setState({ pokemons: res.data })
    );
  }

  render() {
    return (
      <Router>
        <div className="App">
          <div className="container">
            <Navbar />
            <Route path="/pokemons" component={PokemonList} />

            <Route path="/types" component={TypeList} />
          </div>
        </div>
      </Router>
    );
  }
}

export default App;
