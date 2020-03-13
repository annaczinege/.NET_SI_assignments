import React, { useState, useEffect } from "react";
import Axios from "axios";

export const PokemonDetail = props => {
  const [pokeAbilities, setPokeAbilities] = useState([]);
  const [experience, setExperience] = useState(0);
  const [height, setHeight] = useState(0);
  const [weight, setWeight] = useState(0);
  const [id, setId] = useState(0);
  const [name, setName] = useState("");
  const [pokeTypes, setPokeTypes] = useState([]);
  const [sprites, setSprites] = useState({});

  const Capitalize = str => {
    return str.charAt(0).toUpperCase() + str.slice(1);
  };

  const fecthPokemonDetails = () => {
    Axios.get(`${props.location.state.url}`).then(res => {
      setPokeAbilities(res.data.abilities);
      setExperience(res.data.base_experience);
      setHeight(res.data.height);
      setWeight(res.data.weight);
      setId(res.data.id);
      setName(res.data.name);
      setPokeTypes(res.data.types);
      setSprites(res.data.sprites);
    });
  };

  useEffect(() => {
    fecthPokemonDetails();
  });

  const types = pokeTypes.map(item => {
    return <div> {item.type.name}</div>;
  });

  const abilities = pokeAbilities.map(function(item) {
    if (item.is_hidden === false) {
      return <div>{item.ability.name}</div>;
    }
    return "";
  });

  return (
    <div className="">
      <div className="card pokemon-detail">
        <div>#{id}</div>
        <img src={`${sprites.front_default}`} alt="new"></img>
        <div>Name: {Capitalize(name)}</div>
        <p></p>
        <div>Height: {height}</div>
        <div>Weight: {weight}</div>
        <div>Experience: {experience}</div>
        <p></p>
      </div>
      <div className="card pokemon-detail">
        <h3>Types:</h3>
        <ul>{types}</ul>
        <h3>Abilities:</h3>
        <ul>{abilities}</ul>
      </div>
    </div>
  );
};

export default React.memo(PokemonDetail);
