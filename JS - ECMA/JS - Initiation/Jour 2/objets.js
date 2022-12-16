let personnage = {
    vie : 100,
    mana : 100,
    nom : "Gandalf",
    presentation: function () {
        console.log(
            "Je m'appelle " + this.nom +
            ", j'ai " + this.vie +
            " points de vie et " + this.mana +
            " points de mana."
        );
    }
}

class Personnage {
    constructor(vie, mana, nom) {
        this.vie = vie;
        this.mana = mana;
        this.nom = nom;
    }

    presentation() {
        console.log(
            "Je m'appelle " + this.nom +
            ", j'ai " + this.vie +
            " points de vie et " + this.mana +
            " points de mana."
        );
    }
}

let Gandalf = new Personnage(100, 100, "Gandalf");
let Gimly = new Personnage(200, 10, "Gimly");
let Legolas = new Personnage(150, 80, "Legolas");

console.log(personnage);
console.log(Legolas);