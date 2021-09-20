import React from 'react';
import { globalStoreContext } from '../globalStoreContext';

const useGlobalStore = () => {
    const globalStoreRef = React.useContext(globalStoreContext);

    if (!globalStoreRef.current) {
        throw new Error('useGlobalStore must be called within a globalStoreContext.Provider');
    }

    return globalStoreRef.current;
};

export { useGlobalStore };