import { AxiosResponse } from "axios";
import axiosInstance from "../axiosInstance";
import { Company, Equity, Quote } from "../models/models";

export class EquityService {
  getCompanies = (searchTerm: string): Promise<Company[]> => {
    return new Promise<Company[]>((resolve, reject) => {
      axiosInstance
        .get("api/equity/GetAsxCompanies", {
          params: {
            searchTerm: searchTerm,
          },
        })
        .then((response: AxiosResponse<Company[]>) => {
          resolve(response.data);
        })
        .catch(() => {
          reject();
        });
    });
  };

  getCompanyFinancials = (ticker: string): Promise<Quote> => {
    return new Promise<Quote>((resolve, reject) => {
      axiosInstance
        .get("api/equity/GetCompany", {
          params: {
            companyTicker: ticker,
          },
        })
        .then((response: AxiosResponse<Quote>) => {
          resolve(response.data);
        })
        .catch(() => {
          reject();
        });
    });
  };

  AddEquity = async (equity: Equity) => {
    const postData = {
      equity: equity
  };

    const res : boolean = await (await axiosInstance
      .post("api/Equity/AddEquity", postData)).data;
    return res;
  }
};
