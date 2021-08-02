import _, { debounce } from "lodash";
import { observable, action, runInAction } from "mobx";
import { ToDoItemModel, ToDoModel } from "../../models/models";
import { ToDoService } from "../../services/ToDoService";

export class ToDoStore {
  private readonly toDoService: ToDoService;

  @observable toDo: ToDoModel;
  @observable containerId: number;

  constructor(containerId: number) {
    this.toDoService = new ToDoService();
    this.containerId = containerId;
    this.toDo = {
      id: 0,
      userId: '',
      items: []
    };
  }

  @action FindOrCreate = async () => {
    this.toDoService.CreateToDoList(this.containerId).then((res) => {
      this.toDo = res;
    });
  }

  @action updateToDoItem = async (toDoItem: ToDoItemModel) => {
    const idx = this.toDo?.items?.findIndex((i) => i.id == toDoItem.id);
    if (this.toDo != null) {
      this.toDo.items[idx] = toDoItem;
      this.updateToDoItemServerSide(toDoItem, idx);
    }
  };

  @action updateToDoItemServerSide = debounce((toDoItem: ToDoItemModel, idx: number) => {
    console.dir("yoo?");
        this.toDoService
          .UpdateToDoItem(this.containerId, toDoItem)
          .then((res) => {
            if (this.toDo != null) {
              this.toDo.items[idx] = res;
            }
          });
  }, 2000);

  @action addToToDoItems = async (toDoItem: ToDoItemModel) => {
    if (this.toDo !== null) {
      const item = await this.toDoService.AddToDoItem(
        this.containerId,
        toDoItem,
        this.toDo?.id
      );
      runInAction(() => {
        this.toDo?.items?.push(item);
      });
    }
  };

  @action deleteItem = async (id: number) => {
    var res = await this.toDoService.deleteToDoItem(id);
    if (res) {
      if (this.toDo !== null) {
        this.toDo.items = this.toDo?.items?.filter((e) => e.id !== id) || null;
      }
    }
  };

  @action updateToDoItems = async (toDoItems: ToDoItemModel[]) => {
    if (this.toDo !== null) {
      this.toDo.items = toDoItems;
      var updateedToDo = this.toDoService.UpdateOrder(
        this.containerId,
        toDoItems
      );
    }
  };
}
