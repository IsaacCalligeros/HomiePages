import React from 'react';
import { containersStoreContext } from '../containerStoreContext';

const useContainerStore = () => {
    const containerStoreRef = React.useContext(containersStoreContext);

    if (!containerStoreRef.current) {
        throw new Error('useContainerStore must be called within a ContainerStoreContext.Provider');
    }

    return containerStoreRef.current;
};

export { useContainerStore };