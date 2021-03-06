import { observable, action } from "mobx";
import { Equity, EquityModel, PortfolioModel } from "../../models/models";
import { EquityService } from "../../services/EquityService";
import { PortfolioService } from "../../services/PortfolioService";

export class PortfolioStore {
  private readonly equityService : EquityService;
  private readonly portfolioService : PortfolioService;

  @observable portfolioCompanies: EquityModel[] = [];
  
  @observable portfolio: PortfolioModel = {
    id: 0,
    userId: 0,
    equities: [],
  }

  constructor() {
    this.equityService = new EquityService();
    this.portfolioService = new PortfolioService();
    this.getPortfolio();
  }

  @action getPortfolio = async () => {
    var test = await this.portfolioService.FindOrCreate();

    //this.portfolio = test;

    var testy = await (this.portfolioService.FindOrCreatePromise());
    this.portfolio = testy;

    console.dir(this.portfolio);
  };

  @action addToPortfolio = async (newEquity: EquityModel) => 
  {
    var res = await this.equityService.getCompanyFinancials(newEquity.ticker);
    newEquity.currentPrice = res.latestPrice;
    newEquity.change = res.change;
    console.dir(this.portfolio);
    newEquity.portfolioId = this.portfolio.id;
    this.portfolioCompanies.push(newEquity);
    this.equityService.AddEquity(newEquity);
  }
}
