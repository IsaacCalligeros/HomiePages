import axiosInstance from "../axiosInstance";
import { ComponentLayout } from "../components/Containers/types";

export class ContainersService {

  DeleteContainer = async (i: number): Promise<boolean> => {
    const res : boolean = (await axiosInstance.delete(`api/Containers/Delete/${i}`)).data;
    return res;
  };

  UpdateContainers = async (containers: ComponentLayout[]) => {
    const res : boolean = await axiosInstance.post("api/Containers/UpdateContainers", containers);
    return res;
  }

  GetContainers = async () => {
    const res : ComponentLayout[] = await (await axiosInstance.get("api/Containers/getContainers")).data;
    return res;
  }

  SaveContainer = async (newContainer: ComponentLayout) => {
    const res : boolean = await (await axiosInstance
      .post("api/Containers/SaveContainer", newContainer)).data;
    return res;
  }
};
