import { observable, action, runInAction } from 'mobx';
import { EquityModel, PortfolioModel } from '../../models/models';
import { EquityService } from '../../services/EquityService';
import { PortfolioService } from '../../services/PortfolioService';

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
    this.getPortfolio(containerId);
  }

  @action getPortfolio = async (containerId: number) => {
    const portfolio = await this.portfolioService.FindOrCreate(containerId);
    runInAction(() => {
      this.portfolio = portfolio;
    });
  };

  @action addToPortfolio = async (newEquity: EquityModel) => {
    const res = await this.equityService.getCompanyFinancials(newEquity.ticker || '');
    const equity = newEquity;
    equity.currentPrice = res.latestPrice || 0;
    equity.change = res.change || 0;
    equity.portfolioId = this.portfolio.id;
    this.portfolio.equities?.push(newEquity);
    this.equityService.AddEquity(newEquity);
  };

  @action deleteEquity = async (id: number) => {
    const res = await this.equityService.deleteEquity(id);
    if (res) {
      this.portfolio.equities = this.portfolio.equities?.filter(e => e.id !== id) || null;
    }
    //otherwise failed
  }
}
