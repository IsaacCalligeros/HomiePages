import React, { Component } from "react";
import clsx from "clsx";
import { makeStyles } from "@material-ui/core/styles";
import Drawer from "@material-ui/core/Drawer";
import Button from "@material-ui/core/Button";
import { ComponentLayout } from "../Containers/types";
import { v4 as uuidv4 } from "uuid";
import { ComponentType } from "../../models/models";
import { ContainersStore } from "../../store/containersStore";

const useStyles = makeStyles({
  list: {
    width: 250,
  },
  fullList: {
    width: "auto",
  },
});

type Anchor = "top" | "left" | "bottom" | "right";

interface sideBarProps {
  containersStore: ContainersStore;
}

const SideBar = (props: sideBarProps) => {
  const classes = useStyles();
  const [state, setState] = React.useState({
    top: false,
    left: false,
    bottom: false,
    right: false,
  });

  const componentTypes = Object.values(ComponentType).filter(
    (t): t is ComponentType => typeof t === "number"
  );

  const toggleDrawer = (anchor: Anchor, open: boolean) => (
    event: React.KeyboardEvent | React.MouseEvent
  ) => {
    if (
      event.type === "keydown" &&
      ((event as React.KeyboardEvent).key === "Tab" ||
        (event as React.KeyboardEvent).key === "Shift")
    ) {
      return;
    }

    setState({ ...state, [anchor]: open });
  };

  const addControl = (componentType: ComponentType) => {
    const newContainer: ComponentLayout = {
      layout: {
        i: uuidv4(),
        w: 2,
        h: 2,
        x: 0,
        y: 0,
      },
      componentType: componentType,
    };
    const res = props.containersStore.saveContainer(newContainer);
  };

  const list = (anchor: Anchor) => (
    <div
      className={clsx(classes.list, {
        [classes.fullList]: anchor === "top" || anchor === "bottom",
      })}
      role="presentation"
      onClick={toggleDrawer(anchor, false)}
      onKeyDown={toggleDrawer(anchor, false)}
      onDragLeave={toggleDrawer(anchor, false)}
      //Can reopen etc?
      //onDragEnd={toggleDrawer(anchor, false)}
    >
      {componentTypes?.map((c, idx) => (
        <div
          className="droppable-element"
          draggable={true}
          unselectable="on"
          key={c}
          // this is a hack for firefox
          // Firefox requires some kind of initialization
          // which we can do by adding this attribute
          // @see https://bugzilla.mozilla.org/show_bug.cgi?id=568313
          onDragStart={(e) => e.dataTransfer.setData("text/plain", "")}
        >
          (Drag me!)
          <button onClick={() => addControl(c)}>{ComponentType[c]}</button>
        </div>
      ))}
    </div>
  );

  return (
    <div>
      {(["left"] as Anchor[]).map((anchor) => (
        <React.Fragment key={anchor}>
          <Button onClick={toggleDrawer(anchor, true)}>Sidebar</Button>
          <Drawer
            anchor={anchor}
            open={state[anchor]}
            onClose={toggleDrawer(anchor, false)}
          >
            {list(anchor)}
          </Drawer>
        </React.Fragment>
      ))}
    </div>
  );
};

export { SideBar };
