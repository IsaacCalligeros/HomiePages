import { AxiosResponse } from "axios";
import axiosInstance from "../axiosInstance";
import { ToDoItemModel, ToDoModel } from "../models/models";

export class ToDoService {
    CreateToDoList = async (containerId: number) => {
        const res: ToDoModel = await (
          await axiosInstance.put(`api/ToDo/FindOrCreate/${containerId}`)
        ).data;
        return res;
      };

    AddToDoItem = async (containerId: number, toDoItem: ToDoItemModel, toDoId: number) => {
        const res: ToDoItemModel = await (
          await axiosInstance.post(`api/ToDo/AddToDoItem/${containerId}`, { toDoItem, toDoId: toDoId})
        ).data;
        return res;
      };

    UpdateOrder = async (containerId: number, toDoItems: ToDoItemModel[]) => {
        const res: ToDoModel = await (
          await axiosInstance.post(`api/ToDo/UpdateOrder/${containerId}`, toDoItems)
        ).data;
        return res;
      };

    UpdateToDoItem = async (containerId: number, toDoItem: ToDoItemModel) => {
        const res: ToDoItemModel = await (
          await axiosInstance.post(`api/ToDo/UpdateToDoItem/${containerId}`, toDoItem)
        ).data;
    
        return res;
      };

    deleteToDoItem = async (toDoItemId: number) => {
        const res: AxiosResponse = await (
          await axiosInstance.delete(`api/ToDo/DeleteToDoItem/${toDoItemId}`)
        ).data;
    
        return res;
      };
      
}
