import _ from "lodash";
import { observable, action } from "mobx";
import { BaseContainer } from "../models/models";

export class GlobalStore {

  @observable editMode: boolean = false;
  @observable lightMode: boolean = false;

  constructor() {

  }

  @action 
  toggleEditMode = () => this.editMode = !this.editMode;

  @action 
  toggleLightMode = () => this.lightMode = !this.lightMode;

}
