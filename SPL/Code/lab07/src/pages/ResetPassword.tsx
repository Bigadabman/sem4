import { FormEvent,  useState} from 'react';
import {Input} from './../components/inputLine'
import { Link } from 'react-router-dom';


export function ResetPassword(){

    
    const [isEmailError, toggleEmailError] = useState(false);
    const [isPasswordError, togglePasswordError] = useState(false);
    const [isNewPasswordError, toggleNewPasswordError] = useState(false);
    const [newPasswordMessage, ChangeNewPasswordMessage] = useState('');


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

    
    function ValidateNewPassword(){
        const password = (document.getElementById('password') as HTMLInputElement).value;
        const newPassword = (document.getElementById('newPassword') as HTMLInputElement).value;
        const isValid = /^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?!.*\s)/.test(newPassword) && password != newPassword;
        toggleNewPasswordError(!isValid);


        if(password == newPassword)
            ChangeNewPasswordMessage('New password must be different')


        else if(!/^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?!.*\s)/.test(newPassword))
            ChangeNewPasswordMessage('Invalid password');

        else
            ChangeNewPasswordMessage('');

        (document.getElementById('newPassword') as HTMLElement).style.borderColor = isValid ? '#2196f3' : '#ff4444' ; 


        return isValid;

    }


    function handleSubmit(e: FormEvent) {
        e.preventDefault();
        const isEmailValid = ValidateEmail();
        const isPasswordValid = ValidatePassword();
        const isNewPasswordValid = ValidateNewPassword();

        if (isEmailValid && isPasswordValid && isNewPasswordValid) {
            
            const newPassword = (document.getElementById('newPassword') as HTMLInputElement).value;
            alert(newPassword);
            console.log('Form submitted successfully');
        }
    }




    return(
        <form onSubmit={handleSubmit}>
            <h1>Reset password</h1>
            <Input label = 'Email' name='email' isPassword = {false}  isError={isEmailError} errorMessage='Invalid email' validate={ValidateEmail}/>
            <Input label = 'Password' name='password' isPassword = {true} isError={isPasswordError}validate= {ValidatePassword} errorMessage='Invalid password'/>
            <Input label = 'New password' name = 'newPassword' isPassword = {true} isError = {isNewPasswordError} validate = {ValidateNewPassword} errorMessage={newPasswordMessage}/>
            <button type='submit' className='buttonSubmit'>Submit</button>
            <span>Dont have an account? <Link to='/sign-up'>Register</Link> </span>
        </form>
    );
}