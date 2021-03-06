import React, { useState } from "react";
import _ from "lodash";
import { observer } from "mobx-react-lite";
// import "../../CSS/grid-layout.scss";
import { ContainersStore } from "../../store/containersStore";
import DragFromOutsideLayout from "./grids";

interface HomeProps {
  containersStore: ContainersStore;
}

const Home = observer((props: HomeProps) => {
  
  return (
    <DragFromOutsideLayout
      containersStore={props.containersStore}
    ></DragFromOutsideLayout>
  );
});

export { Home };
