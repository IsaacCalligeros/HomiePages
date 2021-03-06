import React, { useState } from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import { LoginMenu } from "../api-authorization/LoginMenu";
import "../../CSS/NavMenu.scss";
import { SideBar } from "./SideBar";
import { ContainersStore } from "../../store/containersStore";

interface NavMenuProps {
  containersStore: ContainersStore;
}
const NavMenu = (props: NavMenuProps) => {
    const [collapsed, setCollapsed] = useState(true);
    const [open, setOpen] = useState(false);

    const setOpenProp = () => {
      setOpen(!open);
    }

    return (
      <header>        
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
          <SideBar containersStore={props.containersStore}></SideBar>
          
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
