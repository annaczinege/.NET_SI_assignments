import React from "react";
import Type from "../Type";
import PropTypes from "prop-types";

export const TypeList = props => {
  return props.types.map(type => <Type key={type.id} type={type} />);
};

TypeList.propTypes = {
  types: PropTypes.array.isRequired
};

export default TypeList;
