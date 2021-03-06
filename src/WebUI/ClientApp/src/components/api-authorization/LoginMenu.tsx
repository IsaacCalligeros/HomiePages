import React, { Component, Fragment, useState, useEffect } from "react";
import { NavItem, NavLink } from "reactstrap";
import { Link } from "react-router-dom";
import authService from "./AuthorizeService";
import { ApplicationPaths } from "./ApiAuthorizationConstants";
import Button from "@material-ui/core/Button";
import Menu from "@material-ui/core/Menu";
import MenuItem from "@material-ui/core/MenuItem";

const LoginMenu = () => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [userName, setUsername] = useState(null);
  const [subscription, setSubscription] = useState<null | number>(null);

  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  useEffect(() => {
    const currSub = authService.subscribe(() => populateState());
    setSubscription(currSub);

    populateState();
    return () => {
      authService.unsubscribe(subscription);
    };
  }, []);

  const populateState = async () => {
    const [isAuthenticated, user] = await Promise.all([
      authService.isAuthenticated(),
      authService.getUser(),
    ]);
    setIsAuthenticated(isAuthenticated);
    setUsername(user && user.name);
  };

  const authenticatedView: any = () => {
    const profilePath = `${ApplicationPaths.Profile}`;
    const logoutPath = {
      pathname: `${ApplicationPaths.LogOut}`,
      state: { local: true },
    };

    return (
      <Fragment>
        <Button
          aria-controls="simple-menu"
          aria-haspopup="true"
          onClick={handleClick}
        >
          {userName}
        </Button>
        <Menu
          id="simple-menu"
          anchorEl={anchorEl}
          keepMounted
          open={Boolean(anchorEl)}
          onClose={handleClose}
        >
          <MenuItem onClick={handleClose}>
            {" "}
            <NavLink tag={Link} className="text-dark" to={profilePath}>
              Profile
            </NavLink>
          </MenuItem>
          <MenuItem onClick={handleClose}>
            {" "}
            <NavLink tag={Link} className="text-dark" to={logoutPath}>
              Logout
            </NavLink>
          </MenuItem>
        </Menu>
      </Fragment>
    );
  };

  const anonymousView: any = () => {
    const registerPath = `${ApplicationPaths.Register}`;
    const loginPath = `${ApplicationPaths.Login}`;

    return (
      <Fragment>
        <NavItem>
          <NavLink tag={Link} className="text-dark" to={registerPath}>
            Register
          </NavLink>
        </NavItem>
        <NavItem>
          <NavLink tag={Link} className="text-dark" to={loginPath}>
            Login
          </NavLink>
        </NavItem>
      </Fragment>
    );
  };

  return <>{isAuthenticated ? authenticatedView() : anonymousView()}</>;
};

export { LoginMenu };
