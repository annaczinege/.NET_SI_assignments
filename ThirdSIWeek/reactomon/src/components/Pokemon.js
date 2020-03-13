import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import Axios from "axios";
import Card from "./elements/Card";

export const Pokemon = props => {
  const [imgUrl, setImgUrl] = useState("");

  const Capitalize = str => {
    return str.charAt(0).toUpperCase() + str.slice(1);
  };

  const fetchImage = () => {
    const pokeUrl = props.pokemon.url;
    Axios.get(`${pokeUrl}`).then(res =>
      setImgUrl(res.data.sprites.front_default)
    );
  };

  useEffect(() => {
    fetchImage();
  });

  let name = props.pokemon.name;
  name = Capitalize(name);
  return (
    <Card>
      <img src={`${imgUrl}`} alt=""></img>
      <div>
        <Link
          to={{
            pathname: `/pokemon/${props.pokemon.name}`,
            state: {
              url: props.pokemon.url
            }
          }}
        >
          {name}
        </Link>
      </div>
    </Card>
  );
};

Pokemon.propTypes = {
  pokemon: PropTypes.object.isRequired
};

export default Pokemon;
