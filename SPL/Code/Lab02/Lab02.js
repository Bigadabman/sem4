"use strict";
//1 - 3
const array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
let car = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';
const car1 = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';
const car2 = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';
const arrayCars = [{
        cars: [car1, car2]
    }];
const group = {
    students: [
        { id: 1, name: 'Vasya', group: 10, marks: [{ subject: 'Math', mark: 10, done: true },
                { subject: 'Russian', mark: 9, done: true },
                { subject: 'English', mark: 8, done: true }
            ] },
        { id: 2, name: 'Ivan', group: 11, marks: [{ subject: 'Math', mark: 7, done: true },
                { subject: 'Russian', mark: 10, done: false },
                { subject: 'English', mark: 10, done: true }
            ] },
        { id: 3, name: 'Masha', group: 12, marks: [{ subject: 'Math', mark: 9, done: false },
                { subject: 'Russian', mark: 9, done: true },
                { subject: 'English', mark: 9, done: false }
            ] },
        { id: 4, name: 'Petya', group: 10, marks: [{ subject: 'Math', mark: 6, done: true },
                { subject: 'Russian', mark: 9, done: true },
                { subject: 'English', mark: 9, done: true }
            ] },
        { id: 5, name: 'Kira', group: 11, marks: [{ subject: 'Math', mark: 10, done: false },
                { subject: 'Russian', mark: 8, done: false },
                { subject: 'English', mark: 7, done: false }
            ] },
    ],
    studentsFilter(group) { return this.students.filter(student => student.group == group); },
    marksFilter(mark) { return this.students.filter(student => student.marks.some(m => m.mark == mark)); },
    deleteStudent(id) { this.students = this.students.filter(student => student.id != id); },
    mark: 10,
    group: 6,
};
group.deleteStudent(5);
console.log('students with 10\n');
console.log(group.marksFilter(10));
console.log('students from group 10\n');
console.log(group.studentsFilter(10));
