import {ADD, DEL, EDIT, TOGGLE} from './actions'

export interface stateType{
    tasks:[]
}

export type actionTypes = {type: typeof ADD, payload: string} | {type: typeof DEL, payload: number} 
    | {type: typeof EDIT, payload: {id: number, content: string}} | {type: typeof TOGGLE, payload: number};


export type taskType = {
    id: number,
    content: string,
    done: boolean
}