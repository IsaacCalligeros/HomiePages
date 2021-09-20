import { AxiosResponse } from "axios";
import axiosInstance from "../../axiosInstance";
import { NoteItem, Notes } from "../../models/models";

export class NotesItemService {
    private containerId: number;

    constructor(containerId: number)
    {
      this.containerId = containerId;
    }

    AddItem = async (noteItem: NoteItem) => {
        const res: Notes = await (
          await axiosInstance.post(`api/NoteItem/Add/${this.containerId}`, { noteItem })
        ).data;
        return res;
      };

    UpdateOrder = async (noteItems: NoteItem[]) => {
        const res: Notes = await (
          await axiosInstance.post(`api/NoteItem/UpdateNotesOrder/${this.containerId}`, noteItems)
        ).data;
        return res;
      };

    Update = async (toDoItem: NoteItem) => {
        const res: NoteItem = await (
          await axiosInstance.post(`api/NoteItem/Update/${this.containerId}`, toDoItem)
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
