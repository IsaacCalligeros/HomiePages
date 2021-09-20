import { observer } from "mobx-react";
import React, { useState } from "react";
import 'react-quill/dist/quill.snow.css';
import '../../CSS/notes.scss';
import { NoteItemComponent } from "./note-item";
import { NotesStore } from "./notes-store";

interface NotesProps {
  containerId: number;
}

const NotesComponent = observer((props: NotesProps) => {
  const [store] = useState(new NotesStore(props.containerId));
  console.dir(store.notes);

  return (
    <>
      {
        store.notes?.items.map(i => {
          
          return (
            <NoteItemComponent noteItem={i} store={store} />
          )
        })
      }
    </>
  );
});

export { NotesComponent }