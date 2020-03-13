import React from "react";
import { Link } from "react-router-dom";

export default function Navbar() {
  return (
    <header>
      <div className="link-section">
        <Link className="header-link" to="/pokemons">
          Pokemons
        </Link>{" "}
        <Link className="header-link" to="/types">
          Types
        </Link>
      </div>
      <img
        className="header-title"
        src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/98/International_Pok%C3%A9mon_logo.svg/1200px-International_Pok%C3%A9mon_logo.svg.png"
        alt="header"
      />
    </header>
  );
}
