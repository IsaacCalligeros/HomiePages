import React, { useState, useEffect } from 'react';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { Button } from '@material-ui/core';
import { observer } from 'mobx-react';
import { ToDoStore } from './ToDoStore';
import { ToDoList } from './ToDoList';
import { defaultToDoItem } from '../../models/modelDefaults';
import '../../CSS/ToDo.scss';

interface ToDoProps {
  containerId: number;
}

const ToDoComponent = observer((props: ToDoProps) => {
  const [store] = useState(new ToDoStore(props.containerId));

  useEffect(() => {
    store.FindOrCreate();
  }, []);

  const newToDoItem = () => {
    if (store.toDo !== null) {
      store.addToToDoItems(defaultToDoItem(store.toDo.items.length + 1));
    }
  };

  return (
    <div className="to-do-container">
      <Button
        aria-controls="simple-menu"
        aria-haspopup="true"
        onClick={() => newToDoItem()}
      >
        <FontAwesomeIcon icon={faPlus} />
      </Button>
      {store.toDo.items
        && <ToDoList store={store} />}
    </div>
  );
});

export { ToDoComponent };
