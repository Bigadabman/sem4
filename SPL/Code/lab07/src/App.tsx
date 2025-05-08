import React from 'react';
import logo from './logo.svg';
import { LogIn } from './pages/LogIn';
import {BrowserRouter, Routes, Route, Navigate} from 'react-router-dom'
import './App.css';
import './styles/styles.css'
import { SignUp } from './pages/SignUp';
import { ResetPassword } from './pages/ResetPassword';
import Page404 from './pages/Page404';

function App() {
  return (
    <div className='mainContainer'>
      <BrowserRouter>
      <Routes>
        <Route path='/' element={<Navigate to='/sign-in' replace />}></Route>
        <Route path='/sign-up' element={<SignUp/>}></Route>
        <Route path='/sign-in' element={<LogIn/>}></Route>
        <Route path='/reset-password' element={<ResetPassword/>}></Route>
        <Route path='*' element={<Page404/>}></Route>
      </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
