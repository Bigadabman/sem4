import { FormEvent,  useState} from 'react';
import {Input} from './../components/inputLine'
import { Link } from 'react-router-dom';


export function LogIn(){

    
    const [isEmailError, toggleEmailError] = useState(false);
    const [isPasswordError, togglePasswordError] = useState(false);
    
   
    function ValidateEmail() {

        const email = (document.getElementById('email') as HTMLInputElement)?.value;

        const isValid = /^[^\s]+@[a-zA-Z]{2,}\.[a-zA-Z]{2,3}$/.test(email);
        toggleEmailError(!isValid);

        (document.getElementById('email') as HTMLElement).style.borderColor = isValid ? '#2196f3' : '#ff4444' ; 

        return isValid;
    }

    function ValidatePassword() {
        const password = (document.getElementById('password') as HTMLInputElement)?.value;
        const isValid = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?!.*\s)/.test(password);
        togglePasswordError(!isValid);
        (document.getElementById('password') as HTMLElement).style.borderColor = isValid ? '#2196f3' : '#ff4444' ; 
        return isValid;
    }

    function handleSubmit(e: FormEvent) {
        e.preventDefault();
        const isEmailValid = ValidateEmail();
        const isPasswordValid = ValidatePassword();
        
        if (isEmailValid && isPasswordValid) {
            
            alert('success')
        }
    }




    return(
        <form onSubmit={handleSubmit}>
            <h1>Log in</h1>
            <Input label = 'Email' name='email' isPassword = {false}  isError={isEmailError} errorMessage='Invalid email' validate={ValidateEmail}/>
            <Input label = 'Password' name='password' isPassword = {true} isError={isPasswordError}validate= {ValidatePassword} errorMessage='Invalid password'/>
            <button type='submit' className='buttonSubmit'>Submit</button>
            <span> Forgot password? <Link to = '/reset-password'>Reset</Link></span>
            <span>Dont have an account? <Link to='/sign-up'>Register</Link> </span>
        </form>
    );
}