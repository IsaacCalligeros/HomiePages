import _ from "lodash";
import { observable, action } from "mobx";
import { Layout } from "react-grid-layout";
import axiosInstance from "../axiosInstance";
import { ComponentLayout } from "../components/Containers/types";
import { ContainersService } from "./containersService";

export class ContainersStore {

  private readonly containersService: ContainersService;

  constructor() {
    this.containersService = new ContainersService();
    this.getContainers();
  }
  
  @observable containers: ComponentLayout[] = [];

  @action setContainers = (containers: ComponentLayout[]) => {
    this.containers = containers;
  };

  @action addContainer = (container: ComponentLayout) => {
    this.containers.push(container);
  };

  @action deleteContainer = async (i: number) => {
    var res = await this.containersService.DeleteContainer(i);
    if (res) {
      this.setContainers(
        _.reject(this.containers, (l) => l.layout.i == i.toString())
      );
    }
  };

  @action updateContainers = async (containers: ComponentLayout[]) => {
    var res = await this.containersService.UpdateContainers(containers);
    if (res) {
      this.containers = containers;
    }
  };

  @action getContainers = async () => {
    this.containers = await this.containersService.GetContainers();
  };

  @action saveContainer = async (newContainer: ComponentLayout) => {
    var res = await this.containersService.SaveContainer(newContainer);
    if (res) {
      this.addContainer(newContainer);
    }
  };

  @action updateLayouts = (layouts: Layout[]) => {
    this.containers.forEach(
      (c) =>
        (c.layout = layouts[layouts.findIndex((lo) => lo.i === c.layout.i)])
    );
    this.updateContainers(this.containers);
  };
}
