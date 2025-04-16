"use strict";
//1
class BaseUser {
    constructor(id, name) {
        this.id = id;
        this.name = name;
    }
}
class Guest extends BaseUser {
    getRole() {
        return "Guest";
    }
    getPermissions() {
        return ['Просмотр контента'];
    }
}
class User extends BaseUser {
    getRole() {
        return 'User';
    }
    getPermissions() {
        return ['Просмотр контента', 'Добваление комментариев'];
    }
}
class Admin extends BaseUser {
    getRole() {
        return "Admin";
    }
    getPermissions() {
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
console.log(`id:${admin.id}, name:${admin.name}`);
console.log(admin.getPermissions());
class HTMLReport {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }
    generate() {
        let report = `<h1>${this.title}</h1><p>${this.content}</p>`;
        return report;
    }
}
class JSONReport {
    constructor(title, content) {
        this.title = title;
        this.content = content;
    }
    generate() {
        let report = {
            title: this.title,
            content: this.content,
        };
        return report;
    }
}
const report1 = new HTMLReport('Отчет 1', 'Содержание отчета');
console.log(report1.generate());
const report2 = new JSONReport('Отчет 2', 'Содержание отчета');
console.log(JSON.stringify(report2.generate()));
//3
class Cacche {
    constructor() {
        this.map = new Map();
    }
    add(key, value, ttl) {
        this.map.set(key, { value: value, lifeTime: ttl + Date.now() });
    }
    get(key) {
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
    clearExpired() {
        this.map.forEach((value, key) => {
            if (value.lifeTime <= Date.now()) {
                this.map.delete(key);
                console.log(`${key} expired`);
            }
        });
    }
}
let cache = new Cacche();
cache.add('1', 10, 3);
cache.add('2', 12, -1);
cache.clearExpired();
console.log(cache.get('1'));
//4
class Product {
    constructor(name, price) {
        this.name = name;
        this.price = price;
    }
}
function createInstance(cls, ...args) {
    return new cls(...args);
}
let p = createInstance(Product, 'spoon', 2);
console.log(p);
//5
var LogLevel;
(function (LogLevel) {
    LogLevel[LogLevel["INFO"] = 0] = "INFO";
    LogLevel[LogLevel["WARNING"] = 1] = "WARNING";
    LogLevel[LogLevel["ERROR"] = 2] = "ERROR";
})(LogLevel || (LogLevel = {}));
function logEvent(event) {
    console.log(`[${event[0].toISOString()}] [${LogLevel[event[1]]}]: ${event[2]}`);
}
logEvent([new Date(), LogLevel.INFO, "Система запущена"]);
//6 
var HTTPStatus;
(function (HTTPStatus) {
    HTTPStatus[HTTPStatus["OK"] = 200] = "OK";
    HTTPStatus[HTTPStatus["BAD_REQUEST"] = 400] = "BAD_REQUEST";
    HTTPStatus[HTTPStatus["UNAUTHORIZED"] = 401] = "UNAUTHORIZED";
    HTTPStatus[HTTPStatus["INTERNAL_SERVER_ERROR"] = 500] = "INTERNAL_SERVER_ERROR";
})(HTTPStatus || (HTTPStatus = {}));
function sucess(data) {
    return { response: [HTTPStatus.OK, data] };
}
function error(message, status) {
    return { response: [status, null, message] };
}
console.log(sucess('Ok'));
console.log(error('bad request', HTTPStatus.BAD_REQUEST));
