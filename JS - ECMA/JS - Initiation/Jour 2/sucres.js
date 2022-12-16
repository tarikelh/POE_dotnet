let a = 10;
let b = 12;
let c;


// a = a + 1;
++a;

// function () {}
() => {}

if (a > b) {
    c = true;
}
else {
    c = false;
}
c = a > b;
// c = a > b ? true : false;

let d, e, f;
// d = 10;
// e = 20;
// f = [30, 40, 50];
[d, e, ...f] = [10, 20, 30, 40, 50];

function test (...params) {
    for (let param of params) {
        console.log(param);
    }
}

// test(5, 10, 57, 'test', [45, 67]);