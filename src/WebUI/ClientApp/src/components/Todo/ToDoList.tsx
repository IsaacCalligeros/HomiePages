/* eslint-disable no-unused-vars */
import React, { useRef } from 'react';
import '../../CSS/ToDo.scss';
import { observer } from 'mobx-react';
import { SortableContainer, SortableElement } from 'react-sortable-hoc';
import arrayMove from 'array-move';
import TextareaAutosize from '@material-ui/core/TextareaAutosize/TextareaAutosize';
import { IconButton } from '@material-ui/core';
import { faCheck, faCheckCircle, faCircle, faCircleNotch, faTrash } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { ToDoItemModel } from '../../models/models';
import { ToDoStore } from './ToDoStore';
import { useHoverDirty } from 'react-use';
import { createRef } from 'react';

interface ToDoListProps {
  store: ToDoStore;
}

interface ToDoItemProps {
  item: ToDoItemModel;
  deleteItem: (itemId: number) => void;
  updateItem: (item: ToDoItemModel, value: string) => void;
  completeItem: (item: ToDoItemModel) => void;
  index: number;
}

const SortableItem = SortableElement((props: ToDoItemProps) => {
  const itemRef = createRef<HTMLDivElement>();
  const hoverState = useHoverDirty(itemRef);

  return (<li key={`sortable-list-item-${props.item.id}`} className="todo-item">
    <div ref={itemRef}>
      <IconButton
      className="sizeSmall"
      aria-controls="simple-menu"
      aria-haspopup="true"
      onClick={() => props.deleteItem(props.item.id)}
    >
      <FontAwesomeIcon
        icon={hoverState ? faCheckCircle : faCircle}
        size="xs"
        onClick={() => props.completeItem({ ...props.item, completionDate: new Date() })}
      />
    </IconButton>
    </div>
    <TextareaAutosize
      key={`sortable-item-input-${props.item.id}`}
      id={`sortable-item-input-${props.item.id}`}
      style={{ resize: 'none', width: '100%' }}
      placeholder="make a task"
      value={props.item.toDoText || ''}
      onChange={(e) => props.updateItem(props.item, e.target.value)}
    />
    <IconButton
      className="sizeSmall"
      aria-controls="simple-menu"
      aria-haspopup="true"
      onClick={() => props.deleteItem(props.item.id)}
    >
      <FontAwesomeIcon
        icon={faTrash}
        size="xs"
        onClick={() => props.deleteItem(props.item.id)}
      />
    </IconButton>
  </li>)}
  );

const ToDoItem = (props: ToDoItemProps) => (
  <SortableItem key={`sortable-item-container${props.index}`} {...props} />
);

const SortableList = SortableContainer(
  ({
    items,
    updateItem,
    deleteItem,
    completeItem,
  }: {
    items: ToDoItemModel[];
    updateItem: (item: ToDoItemModel, value: string) => void;
    deleteItem: (itemId: number) => void;
    completeItem: (item: ToDoItemModel) => void;
  }) => (
    <ul style={{ padding: 0 }}>
      {items.map((value: ToDoItemModel, index: number) => (
        <ToDoItem
          index={index}
          key={`todo-item-${value.id}`}
          updateItem={updateItem}
          deleteItem={deleteItem}
          completeItem={completeItem}
          item={value}
        />
      ))}
    </ul>
  ),
);

const ToDoList = observer((props: ToDoListProps) => {
  const unique = (value: any, index: any, self: any) => self.indexOf(value) === index;

  const updateItem = (item: ToDoItemModel, value: string) => props.store.updateToDoItem({ ...item, toDoText: value });

  const completeItem = (item: ToDoItemModel) => props.store.updateToDoItem(item);

  const deleteItem = (itemId: number) => {
    if (props.store.toDo !== null) {
      props.store.deleteItem(itemId);
    }
  };

  const types = props.store.toDo.items.map((i) => i.toDoType).filter(unique);

  const onSortEnd = ({
    oldIndex,
    newIndex,
  }: {
    oldIndex: number;
    newIndex: number;
  }) => {
    if (oldIndex !== newIndex && props.store.toDo !== null) {
      const updatedItems = arrayMove(
        props.store.toDo?.items,
        oldIndex,
        newIndex,
      );
      props.store.updateToDoItems(updatedItems);
    }
  };

  return (
    <SortableList
      key="sortable-list"
      items={props.store.toDo.items}
      updateItem={updateItem}
      deleteItem={deleteItem}
      completeItem={completeItem}
      onSortEnd={onSortEnd}
      distance={10}
    />
  );
});

export { ToDoList };
