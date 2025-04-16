import { ReactNode } from "react";


interface IProps{
    id: string;
    title: string;
    callback?: () => void;
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


