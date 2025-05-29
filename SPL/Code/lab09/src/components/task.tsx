import { useDispatch } from "react-redux";
import { del, edit, toggle } from "../redux/actions";
import { taskType } from "../redux/types";


interface IProps{
    task: taskType
    onEdit: (id: number, content: string) => void;
}


export function Task({task, onEdit}:IProps){ 

    const dispatch = useDispatch();

    return(
        <div className='task'>
            <span className={task.done ? 'completed' : ''}>{task.content}</span>
            <input type='checkbox'  onChange={()=>dispatch(toggle(task.id))}></input>
            <button onClick={() => onEdit(task.id, task.content)}>Edit</button>
            <button onClick={() => dispatch(del(task.id))}>Delete</button>
        </div>
    )

}