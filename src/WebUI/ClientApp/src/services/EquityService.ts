import { AxiosResponse } from "axios";
import axiosInstance from "../axiosInstance";
import { EquityModel, Quote, SearchResponse } from "../models/models";

export class EquityService {
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

  Search = async (fragment: string) => {
    if (fragment === '')
    {
      return [];
    }
    
    const res : SearchResponse[] = await (await axiosInstance
      .get(`api/Equity/search/${fragment}`)).data;
    return res;
  }

  AddEquity = async (equity: EquityModel) => {
    const res : boolean = await (await axiosInstance
      .post("api/Equity/AddEquity", equity)).data;
    return res;
  }

  deleteEquity = async (id: number) => {
    const res : boolean = await (await axiosInstance
      .delete(`api/Equity/DeleteEquity/${id}`)).data;
    return res;
  }
};
