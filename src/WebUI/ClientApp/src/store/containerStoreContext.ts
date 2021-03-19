import React from "react";
import { ContainersStore } from "./containersStore";

const containersStoreRef = {
    current: null
}

const containersStoreContext = React.createContext<React.RefObject<ContainersStore>>(containersStoreRef);

export { containersStoreContext };