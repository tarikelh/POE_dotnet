function sum(a, b=10, c=20) {
    console.log(`Somme de ${a} + ${b} = ${a + b}`);
    return a + b;
}

//On peut ajouter une valeur par défaut au(x) dernier(s) paramètre (s) d'une fonction 
//Ils deviennent alors optionnels

let result = sum(20, 10);
console.log(result);  //30

console.log(sum(30)); //40


//Paramètres du reste (Rest parameters)
function sum2(...numbs) {
    //numbs est un tableau 
    let sum = 0; 
    for (let i = 0; i < numbs.length; i++) {
        sum += numbs[i];  //sum = sum + numbs[i];
    }
    return sum;
}

sum2(2, 3, 4, 90, 100);


logMessage1("Coucou fonction non anonyme");  

function logMessage1(a) {
    console.log(a);
}

//logMessage2("Coucou avant fonction anonyme"); 


//Fonction  anonyme
//La fonction existe qu'à partir de sa declaration
//L'avantage : On peut utiliser les fonctions dans une autre fonction 
const logMessage2 = function (a) {
    console.log(a);
}

logMessage1("Coucou"); 
logMessage2("Coucou aussi");

//Déclaration de la fonction 
function doStuffNTime(n, doStuff) {
    for (let i = 0; i < n; i++) {
        doStuff(i);
    }
}

//L'appel de la fonction 
doStuffNTime(10, function(j) {
    console.log("Coucou " + j);
})


//Si une seule ligne, sans accolades : le retoure est implicite 
const sum3 = (a, b)  => a + b;

//Pour des retours qui prennent plusieurs ligne 
//On peut mettre le retour entre parenthèse () 
const message = (name) => ("Boujour " + name + " Comment ça va ?");


//Pour des retours qui prennent plusieurs lignes 
//On peut mettre le retour entre accolades {}
const sum4 = (a, b) => {
    //Instruction1 
    //Instruction2
    //Si besoin d'un retour : on met le mot clé
    return a + b
}

//Contexte et utilisation 
//setInterval : Attend une fonction callback et un temps (en ms)
setInterval(() => {
    console.log("In interval")
}, 2000);
