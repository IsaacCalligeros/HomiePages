import React from "react";
import { useContainerStore } from "../../store/hooks/containersStoreHook";
import { EquityList } from "../Equities/list";
import { PortfolioStore } from "./portfolioStore";

interface PortfolioProps {
  containerId: number;
}

const PortfolioComponent = (props: PortfolioProps) => {
  const portfolioStore = new PortfolioStore(props.containerId);

  return (
    <EquityList
    store={portfolioStore}></EquityList>
  );
};

export { PortfolioComponent };
