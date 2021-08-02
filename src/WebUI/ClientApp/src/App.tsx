import React from "react";
import { Route } from "react-router";
import { Home } from "./components/Containers/Home";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { ApplicationPaths } from "./components/api-authorization/ApiAuthorizationConstants";

import Container from "@material-ui/core/Container";

import "../src/CSS/custom.scss";
import { Switch } from "react-router-dom";
import { NavMenu } from "./components/App/NavMenu";
import { ContainersStore } from "./store/containersStore";
import { observer } from "mobx-react";

const App: React.FC = observer(() => {
    const HomeComponent = () => {
      const containersStore = new ContainersStore();
      return <Home containersStore={containersStore} />;
    };

    return (
      <div>
        <NavMenu></NavMenu>
        <Container maxWidth="xl" className="component-container">
          <Switch>
            <AuthorizeRoute exact path="/home" component={HomeComponent} />
            <Route
              path={ApplicationPaths.ApiAuthorizationPrefix}
              component={ApiAuthorizationRoutes}
            />
            <Route exact path="/about">
              <h1>About Page</h1>
            </Route>
          </Switch>
        </Container>
      </div>
    );
});

export default App;
