import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface ITask {
  id: number;
  content: string;
  done: boolean;
}

const initialState: ITask[] = [];

const tasksSlice = createSlice({
  name: "tasks",
  initialState,
  reducers: {
    addTask(state, action: PayloadAction<string>) {
      const newTask: ITask = {
        id: Date.now(),
        content: action.payload,
        done: false,
      };
      state.push(newTask);
    },
    editTask(state, action: PayloadAction<{ id: number; content: string }>) {
      const task = state.find((t) => t.id === action.payload.id);
      if (task) task.content = action.payload.content;
    },
    toggleTask(state, action: PayloadAction<number>) {
      const task = state.find((t) => t.id === action.payload);
      if (task) task.done = !task.done;
    },
    deleteTask(state, action: PayloadAction<number>) {
      return state.filter((t) => t.id !== action.payload);
    },
  },
});

export const { addTask, editTask, toggleTask, deleteTask } = tasksSlice.actions;
export default tasksSlice.reducer;
export type { ITask };
