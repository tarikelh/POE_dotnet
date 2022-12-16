/*
    Les types : 
        - Number 
        - String 
        - Booleans 
        - null, undefined 
        - objet : objets natifs : date, math, array 
        - fonction 
*/

//mot-clé nomDeVariable = valeur 
let a = 23; 
const b = "Coucou"; 
a = "Toto";
a = true; 
a = b.length > 5;

/*
    L'égalité strict (===)  compare les valeurs + le type 
    == compare que les valeurs
*/
// >  <   >= <=   ===  !== 
// &&   ||


/*
    falsy : false, undefined, null, tableau vide [], objet vide, 0, 0.0 
    truthy : la valeur n'est ni null, ni undefined, ni vide, ... quand elle n'est pas falsy
*/

let c; 
console.log(c);  //Undefined 
//undefined : Une variable pour laquelle aucune valeur n'a été assignée sera de type undefined


if(c) {   //c !== undefined || c !== null || c !== ""   ===> si est truthy
    //On fait quelque chose su ce n'est pas undefied
    console.log("truthy");
} else {
    //c'est falsy
    console.log("falsy");
}


if(!c) {
    //On fait quelque chose si c'est falsy
}


let bool = (c); //undefined
console.log(bool);
bool = !c; //true si c est falsy 
console.log(bool);


bool = !!c; //false si c'est  falsy
console.log(bool);

//Expression ternaire 
let message = (c)? 'C est défini' : 'C est undefined';
console.log(message);


// + : concaténation 
message = "Coucou " + b;
message += " !!";
console.log(message);

//Ou : addition (sur des numbers)
let numb = 20 + 10; 
numb += 5;    //numb = numb + 5


let x = 2; 
let y = "1";
let z = 3; 
let result = x + y; 
console.log("X + Y = ", result);
result = z + x + y; // 2 + 3 = 5 , concatener 5 et 1
console.log(result);
result += 2; //512
console.log(result);


//Caster en number : Number  ou +
result = x + Number(y);
let numb_y = +y;
result = x + numb_y;

y = "toto";
numb_y = Number(y);
console.log(numb_y); //num_y = NaN (Not a Number)

//isNaN(n) : retourne true si le nombre est NaN
//si numb_y est un nombre (result = x + numb_y) sinon result = 0
result = (isNaN(numb_y)) ? 0 :  x + numb_y;
console.log(result);

//&& et || 
//Ne teste que la première valeur
if(23 < 10 && 0 === 0) {
    //Do something
}

//Ne teste que la première valeur
if(20 > 10 || 10 ===10) {

}

c &&= "toto";  //c &&= "toto" ==> c = c && "toto"
//Est ce que c est true (truthy)
//Si oui, on affecte la valeur toto 
//Equivalent : 
if(c) {
    c = "toto"
}


c ||= "Toto"; 
//Si c est falsy, alors on affecte la valeur "Toto"
//equivalent: 
if(!c) {
   c = "Toto" ;
}

c ??= "TOTO";
//Si c est undefined, alors on affecte la valeur "TOTO"
console.log(c);



