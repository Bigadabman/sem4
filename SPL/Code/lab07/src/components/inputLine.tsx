
import React, { useState } from 'react'
import { ErrorMessage } from './error';


interface IInputProps{
    label: string,
    name: string,
    isPassword: boolean,
    isError: boolean, 
    validate:()=>void
    errorMessage: string
}

export function Input({label, name, isPassword,isError, validate, errorMessage}:IInputProps){
    const [show, setShow] = useState(false);
    const type = isPassword ? (show ? 'text' : 'password') : 'text';
    



    return (
        <div className='InputContainer'>
            <label>{label}</label>

            <input
            type={type}
            onBlur={validate}
            onChange={validate}
            id={name}
            className={name}
            >
            </input>
            {isPassword && <button onClick={() => setShow(prev=>!prev)}>{show? 'hide': 'show'}</button>}

            {isError && <ErrorMessage message ={errorMessage} />}

        </div>
    );


}