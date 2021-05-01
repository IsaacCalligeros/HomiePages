import React from "react";
import { observer } from "mobx-react-lite";
import { ContainersStore } from "../../store/containersStore";
import DragFromOutsideLayout from "./grids";
import { SideBar } from "../App/SideBar";
import MenuPortal from "../App/menu-portal";

interface HomeProps {
  containersStore: ContainersStore;
}

const Home = observer((props: HomeProps) => {
  
  return (
    <>
    <MenuPortal children={<SideBar containersStore={props.containersStore}></SideBar>}></MenuPortal>
    <DragFromOutsideLayout
      containersStore={props.containersStore}
    ></DragFromOutsideLayout>
    </>
  );
});

export { Home };
