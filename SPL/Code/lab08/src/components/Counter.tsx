import React from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { increment, decrement, reset } from '../redux/actions';
import { MyButton } from './Button';
import styles from './Counter.module.css';
import { StateType } from '../redux/types';



export function Counter() {
  const count = useSelector((state:StateType) => state.counter);
  const dispatch = useDispatch();

  return (
    <div className={styles.counter}>
      <h1 className={styles.value}>{count}</h1>
      <div className={styles.buttons}>
        <MyButton onClick={() => dispatch(decrement())} content='-'></MyButton>
        <MyButton onClick={() => dispatch(reset())} content='Reset'></MyButton>
        <MyButton onClick={() => dispatch(increment())} content='+'></MyButton>
      </div>
    </div>
  );
};