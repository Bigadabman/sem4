import { FormEvent,  useState} from 'react';
import {Input} from './../components/inputLine'
import { Link } from 'react-router-dom';


export function SignUp(){

    
    const [isEmailError, toggleEmailError] = useState(false);
    const [isPasswordError, togglePasswordError] = useState(false);
    const [isNameError, toggleNameError] = useState(false);
    const [isRepeatPasswordError, toggleRepeatPasswordError] = useState(false);

    const [repeatPasswordMessage, ChangeRepeatPasswordMessage] = useState('');
   
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

    function ValidateName(){
        const name = (document.getElementById('name') as HTMLInputElement).value;
        const isValid = /^[a-zA-Zа-яА-яёЁ\s]{2,50}$/.test(name);
        toggleNameError(!isValid);
        (document.getElementById('name') as HTMLElement).style.borderColor = isValid ? '#2196f3' : '#ff4444' ; 
        return isValid;
    }


    function ValidateRepeatPassword(){
        const password = (document.getElementById('password') as HTMLInputElement).value;
        const repeatPassword = (document.getElementById('repeatPassword') as HTMLInputElement).value;
        const isValid = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?!.*\s)/.test(repeatPassword) && password == repeatPassword;
        toggleRepeatPasswordError(!isValid);


        if(/^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?!.*\s)/.test(repeatPassword))
            ChangeRepeatPasswordMessage('Invalid password')


        if(password != repeatPassword)
            ChangeRepeatPasswordMessage('Passwords dont match');

        (document.getElementById('repeatPassword') as HTMLElement).style.borderColor = isValid ? '#2196f3' : '#ff4444' ; 
        
        return isValid;

    }


    function handleSubmit(e: FormEvent) {
        e.preventDefault();
        const isEmailValid = ValidateEmail();
        const isPasswordValid = ValidatePassword();
        const isNameValid = ValidateName();
        const isRepeatPasswordValid = ValidateRepeatPassword();

        if (isEmailValid && isPasswordValid && isNameValid && isRepeatPasswordValid) {
            
            alert('success');
        }

    }



    return(
        <form onSubmit={handleSubmit}>
            <h1>Sign Up</h1>
            <Input label='Name' name='name' isPassword={false} errorMessage='Invalid name' isError={isNameError} validate={ValidateName}></Input>
            <Input label = 'Email' name='email' isPassword = {false}  isError={isEmailError} errorMessage='Invalid email' validate={ValidateEmail}/>
            <Input label = 'Password' name='password' isPassword = {true} isError={isPasswordError}validate= {ValidatePassword} errorMessage='Invalid password'/>
            <Input label = 'Repeat password' name='repeatPassword' isPassword = {true}  isError={isRepeatPasswordError} validate = {ValidateRepeatPassword} errorMessage={repeatPasswordMessage}></Input>
            <button type='submit' className='buttonSubmit'>Submit</button>
            <span>Already have an account? <Link to='/sign-in'>Sign In</Link></span>
        </form>
    );
}