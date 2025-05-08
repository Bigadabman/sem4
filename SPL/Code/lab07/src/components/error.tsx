
import { ReactNode } from "react";

interface IErrorProps{
    message: string
}

export function ErrorMessage({message}:IErrorProps){

    return (
        <span className="errorMessage">{message}</span>
    );


}