import React, { useEffect, useState } from "react";
import { EquityModel, SearchResponse } from "../../models/models";
import TextField from "@material-ui/core/TextField";
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
  const [asxCompanies, setAsxCompanies] = useState<SearchResponse[] | null>(null);
  
  const equityService = new EquityService();

  const [selectedCompany, setSelectedCompany] = useState<EquityModel>(
    defaultEquity
  );

  useEffect(() => {
    equityService.Search(searchTerm).then((res) => {
      setAsxCompanies(res);
    });
  }, [searchTerm, equityService]);

  const mapToEquity = (company: SearchResponse): EquityModel => {
    var equity = defaultEquity;
    equity.ticker = company.symbol;
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

          {asxCompanies && asxCompanies?.map((company, idx) => (
            <tr key={idx}>
              <td>{company.symbol}</td>
              <td>{company.exchange}</td>
              <td>{company.region}</td>
              <td>{company.securityName}</td>
              <td>{company.securityType}</td>
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
