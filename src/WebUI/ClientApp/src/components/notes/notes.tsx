import React, { useState } from "react";
import ReactQuill from 'react-quill';
import 'react-quill/dist/quill.snow.css';
import '../../CSS/notes.scss';
import { NotesStore } from "./notes-store";

interface NotesProps {
    containerId: number;
}

const Notes = (props: NotesProps) => {
  const [value, setValue] = useState('');
  const store = new NotesStore(props.containerId);

  return (
    <ReactQuill 
    theme="snow" 
    value={value} 
    onChange={setValue}
    
    />
  );
}

export { Notes }