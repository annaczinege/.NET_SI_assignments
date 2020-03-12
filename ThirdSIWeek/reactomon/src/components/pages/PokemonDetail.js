import React, { Component } from "react";
import Axios from "axios";

export class PokemonDetail extends Component {
  render() {
    return <div>{this.props.pokemon.url}</div>;
  }
}

export default PokemonDetail;
