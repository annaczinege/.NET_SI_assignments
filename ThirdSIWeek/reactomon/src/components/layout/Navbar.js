import React from "react";
import { Link } from "react-router-dom";

export default function Navbar() {
  return (
    <header>
      <h1 className="header-title">Pokemon</h1>
      <div className="link-section">
        <Link className="header-link" to="/pokemons">
          Pokemons
        </Link>{" "}
        <Link className="header-link" to="/types">
          Types
        </Link>
      </div>
    </header>
  );
}
