import React, { useState } from 'react';
import { Route } from 'react-router';
import Container from '@material-ui/core/Container';
import { observer } from 'mobx-react';
import { Switch } from 'react-router-dom';
import { NavItem } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Home } from './components/Containers/Home';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './CSS/custom.scss';
import { NavMenu } from './components/App/NavMenu';
import { ContainersStore } from './store/containersStore';

const App: React.FC = observer(() => {
  const [lightMode, setLightMode] = useState(true);

  const HomeComponent = () => {
    const containersStore = new ContainersStore();
    return <Home containersStore={containersStore} />;
  };


  return (
    <div className={`theme ${lightMode ? 'theme--default' : 'theme--dark'} app-container`}>
      <NavMenu lightMode={lightMode} setLightMode={setLightMode} />
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
