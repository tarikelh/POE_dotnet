//let fruits = [];

let fruits = ['Pomme', 'Poire', 'Abricot'];
fruits.push("mangue");

//Les tableaux commencent à 0
console.log(fruits[0]);
console.log(fruits.length); //4 éléments 

fruits.push(42);
console.log(fruits);

const deleted = fruits.pop();  //supprimer le dernier élément

let index = fruits.indexOf("Poire");
console.log(index);

//Supprime 1 élément à l'index donné et retourne un tableau d'éléments supprimés 
fruits.splice(index, 1);
console.log(fruits);

//Tableau de fruits dont le nom commence par 'M'
const res = fruits.filter((fruit) => fruit[0].toUpperCase() === 'M'); //Correction Bogdan
const res2 = fruits.filter((fruit) => fruit.toString().charAt(0).toUpperCase() === 'M'); 
console.log(res2);


//Fonction map
const res3 = fruits.map((el) => el.toUpperCase());
console.log(res3);


for (let i = 0; i < fruits.length; i++) {
    console.log(fruits[i]);  
    fruits[i] += 's';
}

console.log(fruits);

for (const f of fruits) {
    console.log(f);
}

fruits.forEach((f) => {
    console.log(f);
});