

export const ADD = 'ADD';
export const DEL = 'DEL';
export const EDIT = 'EDIT';
export const TOGGLE = 'TOGGLE'


export let add = (content: string)=>({type: ADD, payload: content});
export let del = (id: number)=>({type: DEL, payload: id})
export let edit = (id: number, content: string)=>({type: EDIT, payload: {id, content}});
export let toggle = (id: number)=>({type: TOGGLE, payload: id})

