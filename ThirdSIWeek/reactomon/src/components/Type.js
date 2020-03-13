import React from "react";
import PropTypes from "prop-types";

export const Type = props => {
  const { name } = props.type;
  return (
    <div className="card pokemon-detail">
      <p>{name}</p>
    </div>
  );
};

Type.propTypes = {
  type: PropTypes.object.isRequired
};

export default Type;
