import React, { Component } from "react";
import PropTypes from "prop-types";

export class Pokemon extends Component {
  render() {
    const { name } = this.props.pokemon;
    return (
      <div>
        <p>{name}</p>
      </div>
    );
  }
}

Pokemon.propTypes = {
  pokemon: PropTypes.object.isRequired
};

export default Pokemon;
