import {actionTypes, stateType, taskType} from './types'

let initialState: taskType[] = []


export let reducer = (state = initialState, action:actionTypes) =>{

    switch(action.type){
        case 'ADD': return [...state, {id: Date.now(), content: action.payload, done: false }]
        case 'DEL': return state.filter((task) => task.id !== action.payload)
        case 'EDIT': return state.map((task) =>
             task.id == action.payload.id ? {...task, content: action.payload.content} : task);
        case 'TOGGLE': return state.map((task) => task.id == action.payload ? {...task, done: !task.done}: task)

        default: return state;
    }
}