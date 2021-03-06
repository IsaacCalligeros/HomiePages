import React, { useEffect, useState } from "react";
import { Portfolio } from "../../models/models";
import { PortfolioService } from "../../services/PortfolioService";
import { EquityList } from "../Equities/list";
import { PortfolioStore } from "./portfolioStore";

const PortfolioComponent = () => {
  const portfolioService = new PortfolioService();
  const [Portfolio, SetPortfolio] = useState<null | Portfolio>(null);

    const portfolioStore = new PortfolioStore();

  return (
    <EquityList
    store={portfolioStore}></EquityList>
  );
};

export { PortfolioComponent };
