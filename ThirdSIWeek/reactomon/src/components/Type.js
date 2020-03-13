import React from "react";
import PropTypes from "prop-types";
import Card from "./elements/Card";

export const Type = props => {
  const { name } = props.type;
  return (
    <Card className="pokemon-detail">
      <p>{name}</p>
    </Card>
  );
};

Type.propTypes = {
  type: PropTypes.object.isRequired
};

export default Type;
