import React, { Component } from "react";
import Pokemon from "../Pokemon";
import PropTypes from "prop-types";

export class PokemonList extends Component {
  render() {
    return this.props.pokemons.map(pokemon => (
      <div className="pokemon-names">
        <Pokemon pokemon={pokemon} />
      </div>
    ));
  }
}

PokemonList.propTypes = {
  pokemons: PropTypes.array.isRequired
};

export default PokemonList;
