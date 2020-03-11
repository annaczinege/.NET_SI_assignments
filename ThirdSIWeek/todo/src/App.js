import React, { Component } from "react";
import { BrowserRouter as Router, Route } from "react-router-dom";
import Todo from "./components/Todo";
import AddTodo from "./components/AddTodo";
import About from "./components/pages/About";
import Header from "./components/layout/Header";
import Axios from "axios";
import "./App.css";

class App extends Component {
  state = {
    todos: []
  };

  componentDidMount() {
    Axios.get("http://jsonplaceholder.typicode.com/todos?_limit=10").then(res =>
      this.setState({ todos: res.data })
    );
  }

  // Toggle Complete
  markComplete = id => {
    this.setState({
      todos: this.state.todos.map(todo => {
        if (todo.id === id) {
          todo.completed = !todo.completed;
        }
        return todo;
      })
    });
  };

  // Delete Todo Item
  delItem = id => {
    this.setState({
      todos: [...this.state.todos.filter(todo => todo.id !== id)]
    });
  };

  // Add new Todo
  addTodo = title => {
    Axios.post("http://jsonplaceholder.typicode.com/todos", {
      title: title,
      completed: false
    }).then(res => this.setState({ todos: [...this.state.todos, res.data] }));
  };

  render() {
    return (
      <Router>
        <div className="App">
          <div className="container">
            <Header />
            <Route
              exact
              path="/"
              render={props => (
                <React.Fragment>
                  <AddTodo addTodo={this.addTodo} />
                  <Todo
                    todos={this.state.todos}
                    markComplete={this.markComplete}
                    delItem={this.delItem}
                  />
                </React.Fragment>
              )}
            />
            <Route path="/about" component={About} />
          </div>
        </div>
      </Router>
    );
  }
}

export default App;
