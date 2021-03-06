import { EquityModel, EquityType } from "./models";


export const defaultEquity: EquityModel = {
    id: 0,
    ticker: "",
    type: EquityType.Stock,
    numberHeld: 0,
    purchasePrice: 0,
    portfolioId: 0,
    currentPrice: 0,
    change: 0
}
