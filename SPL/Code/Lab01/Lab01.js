"use strict";
//1
let phoneNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0];
function makeNumber(numbers) {
    let phoneNumber = "";
    for (let i = 0; i < numbers.length; i++) {
        phoneNumber += numbers[i];
    }
    return "(" + phoneNumber.slice(0, 3) + ") " + phoneNumber.slice(3, 6) + "-" + phoneNumber.slice(6, phoneNumber.length);
}
console.log(makeNumber(phoneNumbers));
//2
class Challenge {
    static solution(number) {
        if (number < 0)
            return 0;
        let sum = 0;
        for (let i = 0; i < number; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        return sum;
    }
}
console.log(Challenge.solution(20));
//3
let numbers = [1, 2, 3, 4, 5, 6, 7];
function turnArrayOnK(numberArray, k) {
    return numbers.slice(numberArray.length - k, numberArray.length).concat(numberArray.slice(0, numberArray.length - k));
}
console.log(turnArrayOnK(numbers, 3));
//4
let nums1 = [1, 7, 6, 4];
let nums2 = [5, 2, 3, 8, 9];
function findMid(nums1, nums2) {
    nums1 = nums2.concat(nums1);
    nums1 = nums1.sort((a, b) => a - b);
    console.log(nums1);
    if (nums1.length % 2 == 1) {
        return nums1[Math.floor(nums1.length / 2)];
    }
    else {
        return (nums1[nums1.length / 2] + nums1[(nums1.length / 2) - 1]) / 2;
    }
}
console.log(findMid(nums1, nums2));
