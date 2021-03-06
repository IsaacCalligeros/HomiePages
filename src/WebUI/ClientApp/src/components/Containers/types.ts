import { Layout } from "react-grid-layout";
import { ComponentType } from "../../models/models";

export interface ComponentLayout {
  layout: Layout;
  componentType: ComponentType;
}
export interface ComponentLayouts {
  lg: ComponentLayout[];
}
