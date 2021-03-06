import { AxiosResponse } from "axios";
import axiosInstance from "../axiosInstance";
import { Portfolio, PortfolioModel } from "../models/models";

export class PortfolioService {
  CreatePortfolio = async (portfolio: Portfolio) => {
    const res: PortfolioModel = await (
      await axiosInstance.post("api/Portfolio/CreatePortfolio", portfolio)
    ).data;
    return res;
  };

  FindOrCreate = async () => {
    const res: PortfolioModel = await (
      await axiosInstance.put("api/Portfolio/FindOrCreate")
    ).data;
    
    return res;
  };

  DeletePortfolio = async (portfolio: Portfolio) => {
    const res: PortfolioModel = await (
      await axiosInstance.delete(`api/Portfolio/DeletePortfolio${portfolio.id}`)
    ).data;
    return res;
  };

  FindOrCreatePromise = (): Promise<PortfolioModel> => {
    return new Promise<PortfolioModel>((resolve, reject) => {
      axiosInstance
      .put("api/Portfolio/FindOrCreate")
        .then((response: AxiosResponse<PortfolioModel>) => {
          resolve(response.data);
        })
        .catch(() => {
          reject();
        });
    });
  };
}
