let voitures = ['mercedes', 'ferrari', 'renault', 'peugeot', 'toyota'];
console.log(voitures[3]);
console.log(voitures.length);

voitures.forEach(voiture => {
    console.log(voiture);
});

// mercedes
// ferrari
// renault
// ...

for (let index = 0; index < voitures.length; index++) {
    console.log(voitures[index]);
}

//exercice3
function quelAgeAuraisJe(anneeA, anneeB){
    return (anneeB - anneeA);
}

console.log(quelAgeAuraisJe(1990,2010));

//exercice4

function chaineDeCharactere(nbcaractere){
    let phrase ='';
    for(let index = 0; index < nbcaractere; index++){
        phrase+='8';
    }
    return phrase;
}

console.log(chaineDeCharactere(10));

//exercice 6


let btn = document.getElementById('btn');
let p = document.getElementById('id');

function changePolice(){
    let p = document.getElementById('id');
    let arraypolice = ['xx-small', 'x-small','small' , 'medium','large', 'x-large','xx-large']
    let index;
    p.style.fontSize = arraypolice[index];
    index++;

}

let title  = document.querySelector('h1');

title.addEventListener('mouseenter', function(){
    title.style.display = 'none';
} );


btn.addEventListener("click", function(){
    if (confirm('Voulez vous supprimez la balise p')){
        p.remove();
    }
})