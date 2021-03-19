import axiosInstance from "../axiosInstance";
import { BaseContainer } from "../models/models";

export class ContainersService {

  DeleteContainer = async (i: number): Promise<boolean> => {
    const res : boolean = (await axiosInstance.delete(`api/Containers/Delete/${i}`)).data;
    return res;
  };

  UpdateContainers = async (containers: BaseContainer[]) => {
    const res : boolean = await axiosInstance.post("api/Containers/UpdateContainers", containers);
    return res;
  }

  UpdateContainer = async (container: BaseContainer) => {
    const res : boolean = await axiosInstance.post("api/Containers/UpdateContainer", container);
    return res;
  }

  GetContainers = async () => {
    const res : BaseContainer[] = await (await axiosInstance.get("api/Containers/getContainers")).data;
    return res;
  }

  SaveContainer = async (newContainer: BaseContainer) => {
    const res : BaseContainer = await (await axiosInstance
      .post("api/Containers/SaveContainer", newContainer)).data;
    return res;
  }
};
