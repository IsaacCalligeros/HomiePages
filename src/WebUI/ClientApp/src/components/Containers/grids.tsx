import React, { useState, useEffect } from "react";
import _ from "lodash";
import { Responsive, WidthProvider, Layout } from "react-grid-layout";
import "../../CSS/grid-layout.scss";
import Weather from "../Weather/Weather";
import { v4 as uuidv4 } from "uuid";
import { News } from "../News/News";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faArrowsAlt, faTimes } from "@fortawesome/free-solid-svg-icons";
import { BaseContainer, ComponentType } from "../../models/models";
import { ContainersStore } from "../../store/containersStore";
import { observer } from "mobx-react-lite";
import { PortfolioComponent } from "../Portfolio/Portfolio";
import { containersStoreContext } from "../../store/containerStoreContext";

const ResponsiveReactGridLayout = WidthProvider(Responsive);

interface DragFromOutsideLayoutProps {
  containersStore: ContainersStore;
}

const DragFromOutsideLayout = observer((props: DragFromOutsideLayoutProps) => {
  const layouts = {
    lg: props.containersStore.containers,
  };

  const defaultProps = {
    className: "layout",
    rowHeight: 30,
    onLayoutChange: function () {},
    cols: { lg: 12, md: 10, sm: 6, xs: 4, xxs: 2 },
  };

  const [currentBreakpoint, setCurrentBreakpoint] = useState("lg");
  const [compactType, setCompactType] = useState<string | null>(null);
  const [mounted, setMounted] = useState(false);

  useEffect(() => {
    setMounted(true);
  }, []);

  const onBreakpointChange = () => (breakpoint: any) => {
    setCurrentBreakpoint(currentBreakpoint);
  };

  const onDrop = (layout: any, layoutItem: Layout, event: any) => {
    layoutItem.i = uuidv4();
    layoutItem.w = 3;
    layoutItem.h = 3;
    
    console.dir(layoutItem);
    const newContainer: BaseContainer = {
      layout: layoutItem,
      containerId: 0,
      userId: '',
      layoutId: '',
      componentType: ComponentType.Weather,
    };
    props.containersStore.addContainer(newContainer);

    props.containersStore.saveContainer(newContainer);
  };

  const onRemoveItem = (i: any) => {
    props.containersStore.deleteContainer(i);
  };

  // const containerStoreRef = React.useRef<ContainersStore>(
  //   props.containersStore
  // );

  const generateDOM = () => {
    return _.map(layouts.lg, (l) => {
      return (
        <div
          key={l.layout.i}
          className="control-container"
          data-grid={l.layout}
        >
          <div className="container-controls">
            <div className="drag-handle">
              <FontAwesomeIcon icon={faArrowsAlt} />
            </div>
            <button className="remove" onClick={() => onRemoveItem(l.layout.i)}>
              <FontAwesomeIcon icon={faTimes} />
            </button>
          </div>
            {l.componentType == ComponentType.Weather && <Weather></Weather>}
            {l.componentType == ComponentType.News && <News></News>}
            {l.componentType == ComponentType.Portfolio && (
              <PortfolioComponent containerId={l.containerId}></PortfolioComponent>
            )}
        </div>
      );
    });
  };

  return (
    <div>
      <ResponsiveReactGridLayout
        {...defaultProps}
        onBreakpointChange={() => onBreakpointChange}
        onResizeStop={(layouts, layout) => props.containersStore.updateLayout(layout)}
        onDragStop={(layouts, layout) => props.containersStore.updateLayout(layout)}
        onDrop={onDrop}
        draggableHandle=".drag-handle"
        // WidthProvider option
        measureBeforeMount={false}
        useCSSTransforms={mounted}
        compactType={compactType as any}
        preventCollision={!compactType}
        isDroppable={true}
      >
        {/* <containersStoreContext.Provider value={containerStoreRef}> */}
          {generateDOM()}
        {/* </containersStoreContext.Provider> */}
      </ResponsiveReactGridLayout>
    </div>
  );
});

export default DragFromOutsideLayout;
