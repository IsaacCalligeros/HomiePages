import _, { debounce } from "lodash";
import { observable, action, runInAction } from "mobx";
import { Notes } from "../../models/models";
import { NotesService } from "./notes-service";

export class NotesStore {
  private readonly notesService: NotesService;
  @observable notes: Notes | null;
  @observable containerId: number;

  constructor(containerId: number) {
    this.notesService = new NotesService();
    this.containerId = containerId;
    this.notes = null;
  }

  @action FindOrCreate = async () => {
    this.notesService.FindOrCreate(this.containerId).then((res) => {
      this.notes = res;
    });
  }

  @action Delete = async () => {
    this.notesService.deleteNote(this.containerId).then((res) => {
      return res;
    });
  }
}
