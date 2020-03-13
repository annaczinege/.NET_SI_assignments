import React from "react";
import Pokemon from "../Pokemon";
import PropTypes from "prop-types";
import Card from "../elements/Card";

export const PokemonList = props => {
  return props.pokemons.map(pokemon => (
    <Card className="pokemon-names">
      <Pokemon pokemon={pokemon} />
    </Card>
  ));
};

PokemonList.propTypes = {
  pokemons: PropTypes.array.isRequired
};

export default PokemonList;
