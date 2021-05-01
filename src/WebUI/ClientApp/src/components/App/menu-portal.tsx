import React from "react";
import ReactDOM from "react-dom";

interface MenuPortalProps {
    children: React.ReactElement;
}

const MenuPortal = (props: MenuPortalProps) => {
    const container = document.getElementById('menu-portal-entry') as HTMLElement;
  return (ReactDOM.createPortal(props.children, container));
};

export default MenuPortal;

