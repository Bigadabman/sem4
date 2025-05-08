
import styles from '.Button.module.css'
interface Iprops{
    onClick:()=>void,
    content: string
}


export function MyButton({content, onClick}:Iprops){

    return (
        <button onClick={onClick}>{content}</button>
    );

}