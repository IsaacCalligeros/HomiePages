import _, { debounce } from "lodash";
import { observable, action, runInAction } from "mobx";
import { NoteItem, Notes } from "../../models/models";
import { NotesItemService } from "./note-item-service";
import { NotesService } from "./notes-service";

export class NotesStore {
  private readonly notesService: NotesService;
  private readonly notesItemService: NotesItemService;
  @observable notes: Notes | null = null;
  @observable containerId: number;

  constructor(containerId: number) {
    this.containerId = containerId;
    this.notesService = new NotesService(this.containerId);
    this.notesItemService = new NotesItemService(this.containerId);

    this.FindOrCreate();
  }

  @action FindOrCreate = async () => {
    this.notesService.FindOrCreate().then((res) => {
      runInAction(() => { this.notes = res; });
    });
  }

  @action ClientSetNoteItem = async (noteItem: NoteItem) => {
      const idx = this.notes?.items?.map(i => i.id).indexOf(noteItem.id);
      if (idx !== undefined && this.notes) {
        this.notes.items[idx] = noteItem;
      }
  }

  @action UpdateNoteItem = async (noteItem: NoteItem) => {
    this.notesItemService.Update(noteItem).then((res) => {
      this.ClientSetNoteItem(res);
    });
  }

  @action AddItem = async (noteItem: NoteItem) => {
    this.notesItemService.AddItem(noteItem);
  }

  @action UpdateOrder = async (noteItems: NoteItem[]) => {
    this.notesItemService.UpdateOrder(noteItems);
  }

  @action DeleteItem = async (toDoItemId: number) => {
    this.notesItemService.delete(toDoItemId);
  }

  @action DeleteNotes = async () => {
    this.notesService.deleteNote(this.containerId).then((res) => {
      return res;
    });
  }
}
