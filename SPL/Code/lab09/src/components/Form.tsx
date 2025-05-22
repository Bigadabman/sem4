import { useDispatch, useSelector } from "react-redux"
import { stateType, taskType } from "../redux/types"
import { Task } from "./task";
import { add, edit } from "../redux/actions";
import { useState } from "react";

export function Form(){


    
    const tasks = useSelector((state:taskType[]) => state);
    const dispatch = useDispatch();

    const [inputValue, setInputValue] = useState<string>("");
    const [editingId, setEditingId] = useState<number | null>(null);
  
    const handleSubmit = () => {
      if (!inputValue.trim()) return;
  
      if (editingId === null) {
        dispatch(add(inputValue));
      } else {
        dispatch(edit(editingId, inputValue));
      }
  
      setInputValue("");
      setEditingId(null);
    };
  
    const handleEdit = (id: number, content: string) => {
      setInputValue(content);
      setEditingId(id);
    };
  


    return (
        <div id='container'>
              <div id='inputs'> 
                <input  value={inputValue} onChange={(e) => setInputValue(e.target.value)} type='text'></input>
                <button  onClick={handleSubmit}>
                {editingId === null ? "Add" : "Save"}</button>
                </div>  

                <div id='tasks'>

                {tasks.map((task)=>( 
                    <Task key={task.id} task={task} onEdit={handleEdit}></Task>
                )) 
            }

                </div>
            </div>
    )
};