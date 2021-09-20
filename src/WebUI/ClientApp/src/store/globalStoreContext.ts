import React from "react";
import { GlobalStore } from "./globalStore";

const globalStoreRef = {
    current: null
}

const globalStoreContext = React.createContext<React.RefObject<GlobalStore>>(globalStoreRef);

export { globalStoreContext };