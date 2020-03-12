import React, { Component } from "react";
import Axios from "axios";

export class PokemonDetail extends Component {
  state = {
    abilities: [],
    base_experience: 0,
    forms: [],
    height: 0,
    id: 0,
    moves: [],
    name: "",
    types: [],
    stats: [],
    sprites: {},
    weight: 0
  };

  Capitalize(str) {
    return str.charAt(0).toUpperCase() + str.slice(1);
  }

  componentDidMount() {
    Axios.get(`${this.props.location.state.url}`).then(res =>
      this.setState({
        abilities: res.data.abilities,
        base_experience: res.data.base_experience,
        forms: res.data.forms,
        height: res.data.height,
        id: res.data.id,
        name: res.data.name,
        moves: res.data.moves,
        types: res.data.types,
        stats: res.data.stats,
        sprites: res.data.sprites,
        weight: res.data.weight
      })
    );
  }

  render() {
    return (
      <div className="card">
        <img src={`${this.state.sprites.front_default}`} alt="new"></img>
        <div>Name: {this.Capitalize(this.state.name)}</div>
        <div>Height: {this.state.height}</div>
        <div>Experience: {this.state.base_experience}</div>
        <div>Weight: {this.state.weight}</div>
      </div>
    );
  }
}

export default PokemonDetail;
