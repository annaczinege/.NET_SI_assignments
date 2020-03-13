import React from "react";
import PropTypes from "prop-types";

export const Type = props => {
  const { name } = props.type;
  return (
    <div>
      <p>{name}</p>
    </div>
  );
};

Type.propTypes = {
  type: PropTypes.object.isRequired
};

export default Type;
