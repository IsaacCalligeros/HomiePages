import { debounce } from "lodash";
import { observer } from "mobx-react";
import React from "react";
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';
import '../../CSS/notes.scss';
import { NoteItem } from "../../models/models";
import { NotesStore } from "./notes-store";

interface NoteItemProps {
    noteItem: NoteItem;
    store: NotesStore;
}

const NoteItemComponent = observer((props: NoteItemProps) => {

    const updateNoteItem = (content: string) => {
        const n = props.store.notes?.items[0];
        if (n !== undefined) {
            n.content = content
            props.store.ClientSetNoteItem(n);
        }
    }

    const serverUpdate = debounce((noteItem: NoteItem) => {
        props.store.UpdateNoteItem(noteItem);
    }, 2000);

    return (
        <ReactQuill
            theme="snow"
            value={props.noteItem.content ?? ''}
            onChange={(content) => updateNoteItem(content)}

        />
    );
});

export { NoteItemComponent }