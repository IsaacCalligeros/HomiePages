import { AxiosResponse } from "axios";
import axiosInstance from "../../axiosInstance";
import { NoteItem, Notes } from "../../models/models";

export class NotesItemService {
    AddItem = async (containerId: number, noteItem: NoteItem) => {
        const res: Notes = await (
          await axiosInstance.post(`api/NoteItem/Add/${containerId}`, { noteItem })
        ).data;
        return res;
      };

    UpdateOrder = async (containerId: number, noteItems: NoteItem[]) => {
        const res: Notes = await (
          await axiosInstance.post(`api/NoteItem/UpdateNotesOrder/${containerId}`, noteItems)
        ).data;
        return res;
      };

    Update = async (containerId: number, toDoItem: NoteItem) => {
        const res: NoteItem = await (
          await axiosInstance.post(`api/NoteItem/Update/${containerId}`, toDoItem)
        ).data;
    
        return res;
      };

    delete = async (toDoItemId: number) => {
        const res: AxiosResponse = await (
          await axiosInstance.delete(`api/NoteItem/Delete/${toDoItemId}`)
        ).data;
    
        return res;
      };
      
}
