import React, { Component } from "react";
import PropTypes from "prop-types";

export class Type extends Component {
  render() {
    const { name } = this.props.type;
    return (
      <div>
        <p>{name}</p>
      </div>
    );
  }
}

Type.propTypes = {
  type: PropTypes.object.isRequired
};

export default Type;
