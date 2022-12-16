/*
    Encapsulation 
    Heritage 
    Classe - Objet 
*/
class User {

    #firstName;  //# équivalent au mot clé private 
    lastname; 
    username;
    email;
    age;
    role = "USER";

    constructor(firstname, lastname, email) {
        this.#firstName = firstname; 
        this.lastname = lastname;
        this.email = email;
        this.username = `${firstname} ${lastname}`
    }

    get firstname() {
        return this.#firstName;
    }

    set firstname(firstname) {
        this.#firstName = firstname;
    } 

    sayhello() {
        console.log(this.username + " dit Bonjour");
    }

    sayhello2 = function() {
        console.log(this.username + " dit Bonjour 2");
    }

    sayhello3 = () =>  console.log(this.username + " dit Bonjour 3");

}

let u = new User("Jean Michel", 'LaTourte', 'jm@gmail.com');
u.sayhello();


class Employee extends User {

    job;

    constructor(firstname, lastname, email, job) {
        super(firstname, lastname, email);
        this.job = job;
    }

}

const e = new Employee("Jane", 'Doe', 'jdoe@gmail.com', "Développeuse .NET");
e.sayhello2();

const isEmployee = e instanceof Employee; //true
const isUser = e instanceof User; //true
const isObject = e instanceof Object; //true
const isString = e instanceof String; //false

console.log(typeof e);   



//Objets littéraux 
const book = {
    title : `Frankestein`,  
    author : {
        firstname : 'Mary',
        lastname: "Shelleu", 
        nationality: 'English', 
        fullname: function () {
            return `${this.firstname} ${this.lastname}`
        }, 
    },
    year : 1880, 
    is_read: true, 
    awards : ['Prix Goncourt', 'Prix Bidule', "Super prix"],
    };

console.log(book.title);
console.log(book.author.fullname());


//On peut utiliser le point pour acceder aux memvres d'un objet le modifier ou en définir de nouveaux
book.id = 1;
console.log(book);

//On peut utilsier les crochets pour accéder aux propriétés d'un objet, les mofifier ou définir des nouvelles 
const new_prop = 'edition'; //On defini une nouvelle propriété nommé "Edition"
book[new_prop] = 'Editions Pingouins';  //Sa valeur est "Edition Pingouins"
console.log(book[new_prop]);
console.log(book.edition);


//L'operateur delete permet de retirer une propriété d'un objet
delete book.id; //Supprime la prorpiété id

for (const prop in book) {
   console.log(prop);  //On récupère la propriété, non la valeur
}

console.log(book);


//Traditionnellement, Si on veut créer une nouvelle variable pour chaque propriété 
//On devrait affecter chaque variable individuellement, avec beaucoup de repetition
// const title = book.title;
// const publish_year = book.year;
// book.lang = 'en';

//Affectation par decomposition / destructuring 
const{title, year : publish_year, lang='en',  ...rest}  = book;

console.log(title, publish_year);
console.log(rest);


//Fonction aussi pour les tableaux 
const fruits = ['Peche', 'Pomme', 'Poire', 'Abricot'];

// const a = fruits[0];
// const b = fruits[1];
// c: [Poire, Abricot];

const[a, b,  ...c] = fruits;

console.log(a);
console.log(c);
