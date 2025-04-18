import { ReactNode } from 'react';
import React, { useState, useEffect } from 'react';
import { MyButton, calculating, historyToggle, clear, backspace } from './button';
import { Screen } from './screen';
import { HistoryBlock } from './history';







export function Calculator(){

    let [theme, setState] = useState<string>('dark')
    function themeToggle(){
        setState( prev => (prev == 'dark') ? 'light' : 'dark');
        console.log('ld')
    }

    let printing: string[] = ['.', '/', '*', '-', '+'];



    useEffect(() => {
        const handleKeyPress = (e: KeyboardEvent) => {
           e.preventDefault();

        let screen: HTMLElement|null = document?.getElementById('expression');
        if(screen == null || screen.textContent == null)
            throw new DOMException('no screen')
        
        else{

            if(printing.includes(e.key) || (e.key >='0' && e.key <='9'))
                screen.textContent += e.key;

            else if( e.key == 'Backspace')
                backspace();

            else if( e.key == 'Escape')
                clear();
            else if(e.key == 'Enter' || e.key == '=')
                calculating();
        }
        };
        
        document.addEventListener('keydown', handleKeyPress);
        return () => document.removeEventListener('keydown', handleKeyPress);
      }, []);

    

    return (


        <div
        className = {'calc' }
        id = {theme}
        >
            
            <MyButton id = 'themeToggle'  callback={themeToggle} title = {'тема'}></MyButton>
            
            <MyButton id = 'history' callback= {historyToggle} title= {'↺'}/>
            <Screen />
            
            
            <div id = {'buttons'}>
                <HistoryBlock />


                <MyButton id = 'number' callback={clear} title = 'C'/>
                <MyButton id = 'back' callback={backspace} title = '←'/>
                <MyButton id = 'number'  title = '/'/>

                <MyButton id = 'number'  title = '7'/>
                <MyButton id = 'number'  title = '8'/>
                <MyButton id = 'number'  title = '9'/>
                <MyButton id = 'number'  title = '*'/>

                <MyButton id = 'number'  title = '4'/>
                <MyButton id = 'number'  title = '5'/>
                <MyButton id = 'number'  title = '6'/>
                <MyButton id = 'number'  title = '-'/>

                <MyButton id = 'number'  title = '1'/>
                <MyButton id = 'number'  title = '2'/>
                <MyButton id = 'number'  title = '3'/>
                <MyButton id = 'number'  title = '+'/>

                <MyButton id = 'number'  title = '0'/>
                <MyButton id = 'number'  title = '.'/>
                <MyButton id = 'equal' callback={calculating} title = '='/>

                
            </div> 
            
        </div>
        
    );
}