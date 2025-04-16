import { ReactNode } from 'react';
import { MyButton } from './button';
import { Screen } from './screen';

function clear(){
    let screen: HTMLElement|null = document?.getElementById('expression');
    let resulting: HTMLElement|null = document?.getElementById('result');
    if(screen != null && screen.textContent!=null && resulting != null && resulting.textContent != null){
    
    screen.textContent = '';
    resulting.textContent = '';
    }
    else
        throw new DOMException('no screen')
    
}

function backspace(){
    let screen: HTMLElement|null = document?.getElementById('expression');

    if(screen != null && screen.textContent != null)
        screen.textContent = screen.textContent.slice(0, -1);

    else{
        throw new DOMException('no screen')
    }

}
//FIXME операции со строками
function calculating(){
    let screen: HTMLElement|null = document?.getElementById('expression');
    let resulting: HTMLElement|null = document?.getElementById('result');
    let history: HTMLElement|null = document?.getElementById('history');
    if(screen != null && screen.textContent!=null && resulting != null && resulting.textContent != null
        && history != null && history.textContent != null
    ){
       try
       {
        let result: string = eval(screen.textContent)
        result = (+result).toFixed(5)
        if(!isFinite(+result)){
            throw new DOMException('cant devide by zero');
        }
        else {
            history.textContent = (screen.textContent) + '\n' + history.textContent;
            resulting.textContent = result;

        }

    }
    //TODO доделать
    catch (error: any){
        
        resulting.textContent = error.message;
        
    }

    }
}


export function Calculator(){

    return (


        <div
        id = {'calc'}
        >
            <Screen />
            <div id = {'buttons'}>

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
                <MyButton id = 'number' callback={calculating} title = '='/>

            </div> 

            <div id = {'history'}></div>
        </div>
        
    );
}