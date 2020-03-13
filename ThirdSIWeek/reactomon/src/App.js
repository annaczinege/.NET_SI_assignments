import React, { useState, useEffect } from "react";
import Navbar from "./components/layout/Navbar";
import { BrowserRouter as Router, Route } from "react-router-dom";
import "./App.css";
import PokemonList from "./components/pages/PokemonList";
import TypeList from "./components/pages/TypeList";
import Axios from "axios";
import PokemonDetail from "./components/pages/PokemonDetail";
//import styled from "styled-components";

const App = () => {
  const [pokemons, setPokemons] = useState([]);
  const [types, setTypes] = useState([]);

  const fetchPokemons = () => {
    Axios.get("https://pokeapi.co/api/v2/pokemon").then(res =>
      setPokemons(res.data.results)
    );
  };

  const fetchTypes = () => {
    Axios.get("https://pokeapi.co/api/v2/type").then(res =>
      setTypes(res.data.results)
    );
  };

  useEffect(() => {
    fetchPokemons();
    fetchTypes();
  }, []);

  return (
    <Router>
      <div className="App">
        <div className="container">
          <Navbar />

          <div className="card-container">
            <Route
              exact
              path="/"
              render={props => (
                <React.Fragment>
                  <PokemonList pokemons={pokemons} />
                </React.Fragment>
              )}
            ></Route>
            <Route path="/pokemons">
              <React.Fragment>
                <PokemonList pokemons={pokemons} />
              </React.Fragment>
            </Route>

            <Route
              path="/types"
              render={props => <TypeList {...props} types={types} />}
            />
            <Route path="/pokemon/" component={PokemonDetail} />
          </div>
        </div>
      </div>
    </Router>
  );
};

export default App;
