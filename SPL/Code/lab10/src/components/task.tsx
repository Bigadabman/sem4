import React from "react";
import { useDispatch } from "react-redux";
import { toggleTask, deleteTask, ITask } from "../redux/tasksSlice";

interface IProps {
  task: ITask;
  onEdit: (id: number, content: string) => void;
}

export function Task({ task, onEdit }: IProps) {
  const dispatch = useDispatch();

  return (
    <div className="task">
      <span className={task.done ? "completed" : ""}>{task.content}</span>
      <input
        type="checkbox"
        checked={task.done}
        onChange={() => dispatch(toggleTask(task.id))}
      />
      <button onClick={() => onEdit(task.id, task.content)}>Edit</button>
      <button onClick={() => dispatch(deleteTask(task.id))}>Delete</button>
    </div>
  );
}
