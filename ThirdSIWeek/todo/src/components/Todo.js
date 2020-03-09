import React, { Component } from "react";
import TodoItem from "./TodoItem";
import PropTypes from "prop-types";

class Todo extends Component {
  render() {
    return this.props.todos.map(todo => (
      <TodoItem
        key={todo.id}
        todo={todo}
        markComplete={this.props.markComplete}
        delItem={this.props.delItem}
      />
    ));
  }
}

// PropTypes
Todo.propTypes = {
  todos: PropTypes.array.isRequired
};

export default Todo;
