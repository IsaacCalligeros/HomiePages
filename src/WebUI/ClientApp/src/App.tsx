import React, { useRef, useState } from 'react';
import { Route } from 'react-router';
import Container from '@material-ui/core/Container';
import { observer } from 'mobx-react';
import { Switch } from 'react-router-dom';
import { Home } from './components/Containers/Home';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import './CSS/custom.scss';
import { NavMenu } from './components/App/NavMenu';
import { ContainersStore } from './store/containersStore';
import { globalStoreContext } from './store/globalStoreContext';
import { GlobalStore } from './store/globalStore';

const App: React.FC = observer(() => {
  const [lightMode, setLightMode] = useState(true);
  const [locked, setLocked] = useState(false);
  const globalStoreRef = useRef<GlobalStore>(new GlobalStore());

  const HomeComponent = () => {
    const containersStore = new ContainersStore();
    return <Home containersStore={containersStore} />;
  };


  return (
    <globalStoreContext.Provider value={globalStoreRef}>
      <div className={`theme ${lightMode ? 'theme--default' : 'theme--dark'} app-container`}>
        {/* TODO: Add a global store, context wrap hook for calling on global settings like light/dark user / locked etc. */}
        <NavMenu lightMode={lightMode} setLightMode={setLightMode} locked={locked} setLocked={setLocked} />
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
    </globalStoreContext.Provider>
  );
});

export default App;
