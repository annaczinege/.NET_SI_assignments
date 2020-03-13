import React from "react";
import Pokemon from "../Pokemon";
import PropTypes from "prop-types";

export const PokemonList = props => {
  return props.pokemons.map(pokemon => (
    <div className="pokemon-names card">
      <Pokemon pokemon={pokemon} />
    </div>
  ));
};

PokemonList.propTypes = {
  pokemons: PropTypes.array.isRequired
};

export default PokemonList;
