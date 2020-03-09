import React, { Component } from "react";

export class AddTodo extends Component {
  render() {
    return (
      <form style={{ display: "flex" }}>
        <input
          type="text"
          name="title"
          placeholder="Add Todo ..."
          style={{ felx: "10", padding: "5px" }}
        ></input>
        <input
          type="submit"
          value="Submit"
          className="btn"
          style={{ flex: "1" }}
        ></input>
      </form>
    );
  }
}

export default AddTodo;
