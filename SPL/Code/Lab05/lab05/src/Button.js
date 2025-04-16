"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MyButton = MyButton;
function MyButton(props) {
    return (<button id={props.title} onClick={props.callback} disabled={(props.disabled == undefined ? false : props.disabled)}>
            {props.title}
        </button>);
}
