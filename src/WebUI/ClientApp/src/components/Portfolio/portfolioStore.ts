import { observable, action, runInAction } from "mobx";
import { EquityModel, PortfolioModel } from "../../models/models";
import { EquityService } from "../../services/EquityService";
import { PortfolioService } from "../../services/PortfolioService";

export class PortfolioStore {
  private readonly equityService: EquityService;
  private readonly portfolioService: PortfolioService;
  private readonly containerId: number;

  @observable portfolio: PortfolioModel = {
    id: 0,
    userId: '',
    equities: [],
  };

  constructor(containerId: number) {
    this.containerId = containerId;
    this.equityService = new EquityService();
    this.portfolioService = new PortfolioService();
    console.dir(containerId);
    this.getPortfolio(containerId);
  }

  @action getPortfolio = async (containerId: number) => {
    var portfolio = await this.portfolioService.FindOrCreate(containerId);
    runInAction(() => {
      this.portfolio = portfolio;
    });
  };

  @action addToPortfolio = async (newEquity: EquityModel) => {
    var res = await this.equityService.getCompanyFinancials(newEquity.ticker);
    newEquity.currentPrice = res.latestPrice;
    newEquity.change = res.change;
    newEquity.portfolioId = this.portfolio.id;
    this.portfolio.equities.push(newEquity);
    this.equityService.AddEquity(newEquity);
  };

  @action deleteEquity = async (id: number) => {
    var res = await this.equityService.deleteEquity(id);
    if (res)
    {
      this.portfolio.equities = this.portfolio.equities.filter(e => e.id !== id);
    }
    //otherwise failed
  }
}
