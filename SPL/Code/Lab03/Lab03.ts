//1

abstract class BaseUser {

    constructor(id: number, name: string){
        this.id = id;
        this.name = name;
    }

     id: number;
     name: string;
    abstract getRole(): string;
}


class Guest extends BaseUser{
    
    getRole(): string {
        return "Guest";
    }



    getPermissions(){
        return ['Просмотр контента'];
    }
}


class User extends BaseUser{
    
    getRole(): string {
        return 'User';
    }
    getPermissions(){
        return ['Просмотр контента', 'Добваление комментариев'];
    }
}


class Admin extends BaseUser{
   
    getRole(): string {
        return "Admin";
    }
    getPermissions(){
        return ['Просмотр контента',
            'Добваление комментариев',
            'Удаление комментариев',
            'Управление пользователями'];
    }
}


const guest = new Guest(1, 'Аноним');
console.log(`id:${guest.id}, name:${guest.name}`);
console.log(guest.getPermissions());



const admin = new Admin(2, "Маша");
console.log(`id:${admin.id}, name:${admin.name}`)
console.log(admin.getPermissions());

//2

interface IReport{
    title: string;
    content: string;
    generate(): string | object;
}


class HTMLReport implements IReport {

    constructor(title: string, content: string){
        this.title = title;
        this.content = content;
    }
    
    title: string;
    content: string;


    generate(): string {
        let report =  `<h1>${this.title}</h1><p>${this.content}</p>`;
        return report; 
    }


}


class JSONReport implements IReport{

    constructor(title: string, content: string){
        this.title = title;
        this.content = content;
    }
    
    title: string;
    content: string;

    generate(): object {
        let report =  {
            title : this.title,
            content: this.content,  
        }
        return report;
    }


}



const report1 = new HTMLReport('Отчет 1', 'Содержание отчета');
console.log(report1.generate());


const report2 = new JSONReport('Отчет 2', 'Содержание отчета');
console.log(JSON.stringify(report2.generate()));


//3


class Cacche<T>{

    map: Map<string, {value: T, lifeTime: number}> = new Map();

    add(key: string, value: T, ttl: number): void{
        this.map.set(key, {value: value, lifeTime: ttl + Date.now()})

    }

    get(key: string): T | null | undefined {
        if (!this.map.has(key)) {
            throw new Error(`no "${key}" in keys`);
        }

        const entry = this.map.get(key);
        if (!entry) {
            return undefined;
        }

        
        if (Date.now() > entry.lifeTime) {
            this.map.delete(key); 
            return null;
        }

        return entry.value;
    }
    

    clearExpired(): void {
        
        this.map.forEach((value, key) => {
            if (value.lifeTime <= Date.now()) {
                this.map.delete(key);
                console.log(`${key} expired`);
            }
        });
    }

}


let cache = new Cacche<number>();

cache.add('1', 10, 3);
cache.add('2', 12, -1);
cache.clearExpired();
console.log(cache.get('1'));



//4

class Product {

    name: string;
    price: number;
    constructor(name: string, price: number){
        this.name = name;
        this.price = price;
    }
}

function createInstance<T>(cls: new (... args: any[]) => T, ...args: any[]): T{
return new cls(...args);
}

let p: Product = createInstance(Product, 'spoon', 2);
console.log(p);


//5

enum LogLevel{
    INFO,
    WARNING,
    ERROR
}

type logEntry = [Date, LogLevel, string]


function logEvent(event: logEntry) : void{
    console.log(`[${event[0].toISOString()}] [${LogLevel[event[1]]}]: ${event[2]}`);
}

logEvent([new Date(), LogLevel.INFO, "Система запущена"]);



//6 


enum HTTPStatus{
    OK = 200,
    BAD_REQUEST = 400,
    UNAUTHORIZED = 401,
    INTERNAL_SERVER_ERROR = 500
}


type ApiResponse<T> = {
    response: [status: HTTPStatus, data: T | null, error?: string]
}

function sucess<T>(data: T): ApiResponse<T>{
    
    return {response:[HTTPStatus.OK,data]}; 
}


function error (message: string, status: HTTPStatus): ApiResponse<null>{

    return {response:[status, null, message]}
}


console.log(sucess('Ok'));

console.log(error('bad request', HTTPStatus.BAD_REQUEST));