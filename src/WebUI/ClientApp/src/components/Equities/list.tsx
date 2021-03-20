import React, { useEffect, useState } from "react";
import { Company, EquityModel } from "../../models/models";
import TextField from "@material-ui/core/TextField";
import _ from "lodash";
import "../../CSS/news.scss";
import { EquityService } from "../../services/EquityService";
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
import { defaultEquity } from "../../models/modelDefaults";
import { PortfolioStore } from "../Portfolio/portfolioStore";

interface EquityListProps {
  store: PortfolioStore;
}

const EquityList = (props: EquityListProps) => {
  const [modalOpen, setModalOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");
  const [asxCompanies, setAsxCompanies] = useState<Company[] | undefined>(undefined);

  const equityService = new EquityService();

  const [selectedCompany, setSelectedCompany] = useState<EquityModel>(
    defaultEquity
  );

  useEffect(() => {
    equityService.getCompanies(searchTerm).then((res) => {
      setAsxCompanies(res);
    });
  }, [searchTerm]);

  const mapToEquity = (company: Company): EquityModel => {
    var equity = defaultEquity;
    equity.ticker = company.ticker;
    return equity;
  };

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  return (
    <>
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
              {/* TODO: change jsonAttribute */}
              <td>{company.Company}</td>
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
