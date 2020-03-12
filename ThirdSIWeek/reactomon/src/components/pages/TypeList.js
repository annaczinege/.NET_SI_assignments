import React, { Component } from "react";
import Type from "../Type";
import PropTypes from "prop-types";

export class TypeList extends Component {
  render() {
    return this.props.types.map(type => <Type type={type} />);
  }
}

TypeList.propTypes = {
  types: PropTypes.array.isRequired
};

export default TypeList;
