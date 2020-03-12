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
    stats: []
  };

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
        stats: res.data.stats
      })
    );
  }
  render() {
    return (
      <div>
        <div>ID: {this.state.id}</div>
        <div>Name: {this.state.name}</div>
        <div>Height: {this.state.height}</div>
        <div>Experience: {this.state.base_experience}</div>
      </div>
    );
  }
}

export default PokemonDetail;
