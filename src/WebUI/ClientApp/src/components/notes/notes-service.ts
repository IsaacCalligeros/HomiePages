import { AxiosResponse } from "axios";
import axiosInstance from "../../axiosInstance";
import { Notes } from "../../models/models";

export class NotesService {
    FindOrCreate = async (containerId: number) => {
        const res: Notes = await (
            await axiosInstance.put(`api/Notes/FindOrCreate/${containerId}`)
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
