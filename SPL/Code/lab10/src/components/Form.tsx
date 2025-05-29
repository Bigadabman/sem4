import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../redux/store";
import { addTask, editTask, ITask } from "../redux/tasksSlice";
import { Task as TaskComponent } from "./task";

export function Form() {

  const tasks = useSelector((state: RootState) => state);
  const dispatch = useDispatch();
  
  const [inputValue, setInputValue] = useState("");
  const [editingId, setEditingId] = useState<number | null>(null);

  const handleSubmit = () => {
    if (!inputValue.trim()) return;
    if (editingId === null) {
      dispatch(addTask(inputValue));
    } else {
      dispatch(editTask({ id: editingId, content: inputValue }));
    }
    setInputValue("");
    setEditingId(null);
  };

  const handleEdit = (id: number, content: string) => {
    setEditingId(id);
    setInputValue(content);
  };

  return (
    <div id="container">
      <div id="inputs">
        <input
          type="text"
          value={inputValue}
          onChange={(e) => setInputValue(e.target.value)}
        />
        <button onClick={handleSubmit}>{editingId ? "Save" : "Add"}</button>
      </div>

      <div id="tasks">
        {tasks.map((task) => (
          <TaskComponent
            key={task.id}
            task={task}
            onEdit={handleEdit}
          />
        ))}
      </div>
    </div>
  );
}