import { EquityModel, EquityType, ToDoItem, ToDoItemModel } from "./models";
import { v4 as uuidv4 } from "uuid";

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

export const defaultToDoItem = (order: number): ToDoItemModel => {
    return {
    id: 0,
    toDoText: "",
    dueDate: null,
    completionDate: null,
    toDoTypeId: null,
    toDoType: null,
    order: order,
    }
  };
