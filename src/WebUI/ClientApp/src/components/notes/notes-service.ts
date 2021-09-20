import { AxiosResponse } from "axios";
import axiosInstance from "../../axiosInstance";
import { NoteItem, Notes } from "../../models/models";

export class NotesService {
    private containerId: number;

    constructor(containerId: number)
    {
        this.containerId = containerId;
    }

    FindOrCreate = async () => {
        const res: Notes = await (
            await axiosInstance.put(`api/Notes/FindOrCreate/${this.containerId}`)
        ).data;
        return res;
    };

    deleteNote = async (toDoItemId: number) => {
        const res: AxiosResponse = await (
            await axiosInstance.delete(`api/Notes/Delete/${toDoItemId}`)
        ).data;

        return res;
    };
}
