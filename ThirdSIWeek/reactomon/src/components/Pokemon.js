import React, { Component } from "react";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import Axios from "axios";

export class Pokemon extends Component {
  state = {
    front_default: ""
  };

  Capitalize(str) {
    return str.charAt(0).toUpperCase() + str.slice(1);
  }

  componentDidMount() {
    const pokeUrl = this.props.pokemon.url;
    Axios.get(`${pokeUrl}`).then(res =>
      this.setState({ front_default: res.data.sprites.front_default })
    );
  }

  render() {
    let { name } = this.props.pokemon;
    name = this.Capitalize(name);
    return (
      <div className="card">
        <img src={`${this.state.front_default}`} alt=""></img>
        <div>
          <Link
            to={{
              pathname: `/pokemon/${this.props.pokemon.name}`,
              state: {
                url: this.props.pokemon.url
              }
            }}
          >
            {name}
          </Link>
        </div>
      </div>
    );
  }
}

Pokemon.propTypes = {
  pokemon: PropTypes.object.isRequired
};

export default Pokemon;
