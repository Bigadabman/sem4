import { createStore } from "redux";
import { CounterReducer } from "./reducer";


export const store = createStore(CounterReducer);

