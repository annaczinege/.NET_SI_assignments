import React, { Component } from "react";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";

export class Pokemon extends Component {
  Capitalize(str) {
    return str.charAt(0).toUpperCase() + str.slice(1);
  }
  render() {
    let { name } = this.props.pokemon;
    name = this.Capitalize(name);
    return (
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
    );
  }
}

Pokemon.propTypes = {
  pokemon: PropTypes.object.isRequired
};

export default Pokemon;
