import React, { Component } from "react";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import { Route } from "react-router-dom";
import PokemonDetail from "./pages/PokemonDetail";

export class Pokemon extends Component {
  render() {
    const { name } = this.props.pokemon;
    return (
      <div>
        <Link
          to={{
            pathname: `/${this.props.pokemon.name}`
          }}
        >
          {name}
        </Link>
        <Route
          path="/bulbasaur"
          render={props => (
            <PokemonDetail {...props} pokemon={this.props.pokemon} />
          )}
        />
      </div>
    );
  }
}

Pokemon.propTypes = {
  pokemon: PropTypes.object.isRequired
};

export default Pokemon;
