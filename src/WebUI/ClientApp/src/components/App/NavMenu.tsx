import React, { useState } from 'react';
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
} from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from '../api-authorization/LoginMenu';
import '../../CSS/nav-menu.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faLock, faMoon, faSun, faUnlock } from '@fortawesome/free-solid-svg-icons';
import { useGlobalStore } from '../../store/hooks/globalStoreHook';
import { observer } from 'mobx-react';
import { isMobile } from "react-device-detect";

interface NavMenuProps {
  lightMode: boolean;
  setLightMode: React.Dispatch<React.SetStateAction<boolean>>;
  locked: boolean;
  setLocked: React.Dispatch<React.SetStateAction<boolean>>;
}

const NavMenu = observer((props: NavMenuProps) => {
  const [collapsed, setCollapsed] = useState(true);
  const globalStore = useGlobalStore();
  console.dir(isMobile);

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
            className={(isMobile ? "mobile " : "") + "d-sm-inline-flex flex-sm-row-reverse collapseMenu"}
            isOpen={!collapsed}
            navbar
            style={{zIndex: 1000}}
          >
            <ul className="navbar-nav flex-grow" style={{alignItems: 'center'}}>
              <NavItem className="theme-toggle header-link" onClick={() => props.setLightMode(!props.lightMode)} style={{margin: '0 1em 0 1em'}}>
                <FontAwesomeIcon icon={props.lightMode ? faSun : faMoon} />
              </NavItem>
              <NavItem className="theme-toggle header-link" onClick={() => globalStore.toggleEditMode()} style={{margin: '0 1em 0 1em'}}>
                <FontAwesomeIcon icon={globalStore.editMode ? faUnlock : faLock} />
              </NavItem>
              <LoginMenu></LoginMenu>
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
});

export { NavMenu };
