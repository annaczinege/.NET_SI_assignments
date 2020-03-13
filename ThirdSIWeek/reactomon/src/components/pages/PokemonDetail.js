import React, { Component } from "react";
import Axios from "axios";

export class PokemonDetail extends Component {
  state = {
    abilities: [],
    base_experience: 0,
    height: 0,
    id: 0,
    moves: [],
    name: "",
    types: [],
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
        height: res.data.height,
        id: res.data.id,
        name: res.data.name,
        types: res.data.types,
        sprites: res.data.sprites,
        weight: res.data.weight
      })
    );
  }

  render() {
    const types = this.state.types.map(item => {
      return <div> {item.type.name}</div>;
    });
    const abilities = this.state.abilities.map(function(item) {
      if (item.is_hidden === false) {
        return <div>{item.ability.name}</div>;
      }
      return "";
    });
    return (
      <div className="card">
        <div>#{this.state.id}</div>
        <img src={`${this.state.sprites.front_default}`} alt="new"></img>
        <div>Name: {this.Capitalize(this.state.name)}</div>
        <div>Height: {this.state.height}</div>
        <div>Weight: {this.state.weight}</div>
        <div>Experience: {this.state.base_experience}</div>
        <h3>Types:</h3>
        <ul>{types}</ul>
        <h3>Abilities:</h3>
        <ul>{abilities}</ul>
      </div>
    );
  }
}

export default PokemonDetail;
