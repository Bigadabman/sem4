import { INCREMENT, DECREMENT, RESET, StateType, ActionTypes } from "./types";

const initialState: StateType = {
    counter: 0,
}


export const CounterReducer = (state = initialState, action:ActionTypes):StateType  =>{

    switch(action.type){
        case "INCREMENT": return {...state, counter: state.counter + 1};
        case "DECREMENT": return {...state, counter: state.counter -1};
        case "RESET": return {...state, counter: state.counter = 0};
        default:
            return state;

    }


}