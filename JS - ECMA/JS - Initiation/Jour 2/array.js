let array = [10, 18, 87, 90, 106];
let arrayLength = array.length;
let array2 = new Array(10, 18, 87, 90, 106);

array.push(3, 8);
array.splice(2, 1);

let firstElem = array.shift();
let lastElem = array.pop();
array.reverse();

// console.log(array);

let find = array.find(element => element > 88);
let index = array.findIndex(element => element > 88);
let results = array.filter(element => element > 88);

// console.log(results);