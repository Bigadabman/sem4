import { ReactNode } from "react";


interface IProps{
    id: string;
    title: string;
    callback?: () => void;
}




export function clear(){
    let screen: HTMLElement|null = document?.getElementById('expression');
    let resulting: HTMLElement|null = document?.getElementById('result');
    if(screen != null && screen.textContent!=null && resulting != null && resulting.textContent != null){
    
    screen.textContent = '';
    resulting.textContent = '';
    }
    else
        throw new DOMException('no screen')
    
}


let showed: boolean = false;

export function historyToggle(){
    let historyBlock: HTMLElement | null = document.getElementById('historyBlock');
    if(historyBlock != null ){


        historyBlock.style.display = (showed) ? 'none' : 'block';
        showed = !showed;

        
    }
    else{
        throw new DOMException('History problem')
    }


}

export function backspace(){
    let screen: HTMLElement|null = document?.getElementById('expression');

    if(screen != null && screen.textContent != null)
        screen.textContent = screen.textContent.slice(0, -1);

    else{
        throw new DOMException('no screen')
    }

}

export function calculating(){
    let screen: HTMLElement|null = document?.getElementById('expression');
    let resulting: HTMLElement|null = document?.getElementById('result');
    let historyBlock: HTMLElement | null = document.getElementById('historyBlock');
    if(screen != null && screen.textContent!=null && resulting != null && resulting.textContent != null 
        && historyBlock != null && historyBlock.textContent != null
    ){
       try
       {
        let result: string = eval(screen.textContent)
        result = (+result).toFixed(2)
        if(!isFinite(+result)){
            throw new DOMException('cant devide by zero');
        }
        else {
            historyBlock.innerHTML = screen.textContent + ' = ' + result + '<br/>' + historyBlock.innerHTML;
            resulting.textContent = result;

        }

    }

    catch (error: any){
        
        switch(error.message){
            case 'expected expression, got end of script' : resulting.textContent = 'expression is not full'; break;
            default: resulting.textContent = error.message;
        }

    }

    }
}



export function MyButton(props: IProps) {
    
    function print (){
        let screen: HTMLElement|null = document?.getElementById('expression');
        if(screen == null || screen.textContent == null)
            throw new DOMException('no screen')
        
        else{
            

        screen.textContent += props.title;
        }
    }

    return (
        <button
            id = {props.id}
            onClick = {(props.callback == undefined) ?  print: props.callback}
        >
            {props.title}
        </button>
    );

}


