import React, { useEffect, useState } from "react";
import _ from "lodash";
import "../../CSS/news.scss";
import { PortfolioStore } from "../Portfolio/portfolioStore";
import { Button, Tab, Tabs } from "@material-ui/core";
import { EquityList } from "../Equities/list";
import { faMinus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

interface PortfolioProps {
  containerId: number;
}

interface TabPanelProps {
  children?: React.ReactNode;
  index: any;
  value: any;
}

const PortfolioComponent = (props: PortfolioProps) => {
  const [portfolioStore] = useState(new PortfolioStore(props.containerId));
  const [value, setValue] = React.useState(0);

  const tabChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setValue(newValue);
  };

  useEffect(() => {
    
  }, [portfolioStore.portfolio.equities]);

  const TabPanel = (props: TabPanelProps) => {
    const { children, value, index, ...other } = props;

    return (
      <div
        role="tabpanel"
        hidden={value !== index}
        id={`scrollable-auto-tabpanel-${index}`}
        aria-labelledby={`scrollable-auto-tab-${index}`}
        {...other}
      >
        {value === index && <div>{children}</div>}
      </div>
    );
  };

  return (
    <>
      <Tabs
        indicatorColor="primary"
        textColor="primary"
        value={value}
        onChange={tabChange}
        centered
      >
        <Tab label="Portfolio" />
        <Tab label="Search" />
      </Tabs>

      <TabPanel value={value} index={0}>
        <table className="table table-striped" aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Ticker</th>
              <th>Number Held</th>
              <th>Price of Purchase</th>
              <th>Current Price</th>
              <th>% change</th>
              <th>Profit / Loss</th>
              <th>Remove</th>
            </tr>
          </thead>
          <tbody>
            {portfolioStore.portfolio.equities.map((e, idx) => (
              <tr key={`equity-${idx}`}>
                <td>{e.ticker}</td>
                <td>{e.numberHeld}</td>
                <td>{e.purchasePrice}</td>
                <td>{e.currentPrice}</td>
                <td>{e.change}</td>
                <td>{e.numberHeld * (e.currentPrice - e.purchasePrice)}</td>
                <td>                
                  <Button
                  onClick={() => {
                    portfolioStore.deleteEquity(e.id);
                  }}
                >
                  <FontAwesomeIcon icon={faMinus} />
                </Button></td>
              </tr>
            ))}
          </tbody>
        </table>
      </TabPanel>
      <TabPanel value={value} index={1}>
        <EquityList store={portfolioStore}></EquityList>
      </TabPanel>
    </>
  );
};

export { PortfolioComponent };

