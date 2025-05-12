export const INCREMENT = 'INCREMENT';
export const DECREMENT = 'DECREMENT';
export const RESET = 'RESET';

export interface StateType {
  counter: number;
}

type IncrementAction = {  type: typeof INCREMENT;}

type  DecrementAction = { type: typeof DECREMENT;}

type ResetAction  ={  type: typeof RESET;}

export type ActionTypes = | IncrementAction | DecrementAction | ResetAction;