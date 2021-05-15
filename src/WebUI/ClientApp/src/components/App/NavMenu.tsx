import React, { useState } from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
} from "reactstrap";
import { Link } from "react-router-dom";
import { LoginMenu } from "../api-authorization/LoginMenu";
import "../../CSS/NavMenu.scss";

const NavMenu = () => {
    const [collapsed, setCollapsed] = useState(true);

    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
          <div id='menu-portal-entry'></div>          
            <NavbarBrand tag={Link} to="/">
            HomiePages
            </NavbarBrand>
            <NavbarToggler onClick={() => setCollapsed(!collapsed)} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!collapsed}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                <LoginMenu></LoginMenu>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
}

export { NavMenu };
