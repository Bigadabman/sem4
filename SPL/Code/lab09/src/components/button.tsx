interface IProps{
    content: string,
    callback: ()=>void
}

export function Button({content, callback}:IProps){

    return (
        <button id={content} content={content} onClick={callback}></button>
    )

}