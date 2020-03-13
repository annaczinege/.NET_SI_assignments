import React from "react";
import styled, { ThemeProvider } from "styled-components";
import "./App.css";
import Button from "./elements/Button";

const theme = {
  primary: "teal",
  secondary: "green",
  font: "sans-serif"
};

const H1 = styled.h1`
  font-size: 3rem;
`;

function App() {
  return (
    <ThemeProvider theme={theme}>
      <div className="App">
        <H1>Styled Components</H1>
        <from action="">
          <input type="text" />
          <button>Create</button>
          <Button>Create</Button>
        </from>
      </div>
    </ThemeProvider>
  );
}

export default App;
