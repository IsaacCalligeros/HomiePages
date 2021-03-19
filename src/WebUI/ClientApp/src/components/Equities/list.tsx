import React, { useEffect, useState } from "react";
import { Company, Equity, EquityModel, EquityType } from "../../models/models";
import TextField from "@material-ui/core/TextField";
import _ from "lodash";
import "../../CSS/news.scss";
import { EquityService } from "../../services/EquityService";
import { PortfolioStore } from "../Portfolio/portfolioStore";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import {
  Modal,
  ModalBody,
  ModalFooter,
  ModalHeader,
  Button,
  Input,
} from "reactstrap";
import { Tab, Tabs } from "@material-ui/core";
import { defaultEquity } from "../../models/modelDefaults";

interface EquityListProps {
  store: PortfolioStore;
}

interface TabPanelProps {
  children?: React.ReactNode;
  index: any;
  value: any;
}

const EquityList = (props: EquityListProps) => {
  const [loading, setLoading] = useState(true);
  const [asxCompanies, setAsxCompanies] = useState<Company[] | undefined>(undefined);
  const [modalOpen, setModalOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");
  const [value, setValue] = React.useState(0);

  const tabChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setValue(newValue);
  };

  const equityService = new EquityService();

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

  const [selectedCompany, setSelectedCompany] = useState<EquityModel>(defaultEquity);

  const mapToEquity = (company: Company) : EquityModel => {
    var equity = defaultEquity;
    equity.ticker = company.ticker;
    return equity;
  }

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  useEffect(() => {
    equityService.getCompanies(searchTerm).then((res) => {
      setAsxCompanies(res);
      setLoading(false);
    });
  }, [searchTerm]);

  return loading ? (
    <p>
      <em>Loading...</em>
    </p>
  ) : (
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
            </tr>
          </thead>
          <tbody>
            {props.store.portfolio.equities.map((e, idx) => (
              <tr key={`equity-${idx}`}>
                <td>{e.ticker}</td>
                <td>{e.numberHeld}</td>
                <td>{e.purchasePrice}</td>
                <td>{e.currentPrice}</td>
                <td>{e.change}</td>
                <td>{e.numberHeld * (e.currentPrice - e.purchasePrice)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </TabPanel>
      <TabPanel value={value} index={1}>
        <TextField
          id="outlined-name"
          className="search-field"
          label="searchTerm"
          value={searchTerm}
          onChange={handleChange}
          variant="outlined"
        />

        <table className="table table-striped" aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Company</th>
              <th>Industry</th>
              <th>Ticker</th>
              <th>Listing date</th>
              <th>Add to Portfolio</th>
            </tr>
          </thead>
          <tbody>
            {asxCompanies?.map((company, idx) => (
              <tr key={idx}>
                <td>{company.companyName}</td>
                <td>{company.industry}</td>
                <td>{company.ticker}</td>
                <td>{company.listingDate}</td>
                <td>
                  <Button
                    onClick={() => {
                      setSelectedCompany(mapToEquity(company));
                      setModalOpen(!modalOpen);
                    }}
                  >
                    <FontAwesomeIcon icon={faPlus} />
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </TabPanel>

      <Modal isOpen={modalOpen} toggle={() => setModalOpen(!modalOpen)}>
        <ModalHeader toggle={() => setModalOpen(!modalOpen)}>
          Add to Portfolio
        </ModalHeader>
        <ModalBody>
          {selectedCompany?.ticker}
          Quantity -
          <Input
            placeholder="Amount"
            type="number"
            step={1}
            onChange={(e) => {
              const equity = selectedCompany;
              equity.numberHeld = parseFloat(e.target.value);
              setSelectedCompany(selectedCompany);
            }}
          />
          Purchase Price -
          <Input
            placeholder="Price"
            type="number"
            onChange={(e) => {
              const equity = selectedCompany;
              equity.purchasePrice = parseFloat(e.target.value);
              setSelectedCompany(selectedCompany);
            }}
          />
        </ModalBody>
        <ModalFooter>
          <Button
            color="primary"
            onClick={() => {
              props.store.addToPortfolio(selectedCompany);
              setModalOpen(!modalOpen);
            }}
          >
            Add
          </Button>{" "}
          <Button color="secondary" onClick={() => setModalOpen(!modalOpen)}>
            Cancel
          </Button>
        </ModalFooter>
      </Modal>
    </>
  );
};

export { EquityList };
