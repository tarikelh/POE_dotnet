/*
    Requeêtes HTTP (du point du vue Front End)

    GET : Données dans l'url, pour récuperer une données 
    POST : Créer des dans le back (ou persister )
    PATCH : Modifier partiellement des données 
    PUT : Remplacer des données 
    DELETE : Supprimer des données
*/

/*
    JSONPlaceholder est une API REST en ligne  gratuite que vous pouvez utliser chaque fois que vous avez besoin de fausses données
*/

const url = "https://jsonplaceholder.typicode.com/";
const user_url = url +"users";

let users = [];

/*
    Déclaration de la fonction displayUsers() 
    Parcourt chaque User et le stock dans un élément li
*/
function displayUsers() {
    //Créer un élément li 
    //Ajouter le contenu name dans l'element li
    //Ajouter dans l'element ul
    users.forEach(u => {
        //<li></li>
        const li = document.createElement("li");
        //<li>"Leanne Graham"</li>
        li.textContent = u.name;
        document.querySelector('#ul').appendChild(li);

    })
}

//Utilisation de l'api fetch
//Fait un get sur l'url passée en paramètre 
//Le méthode fetch permet de faire des appels AJAX en Javascript 
//La methode retourne une promesse 
//Les promesses representent le résultat d'une fonction asynchrone
fetch(user_url)
    //res : objet response 
    //Utilisation de la méthode json() pour convertir res en données JSON
    .then((res) => res.json())
    .then(res_users => {
        users = res_users;
        console.log(users);
        displayUsers();
})

console.log("Coucou 2");
console.log(users);


//Utilisation de Async Await 
//retourne une promesse 
async function getUsers() {
    try {
        const response = await fetch(user_url); 
        users = await response.json();
        console.log(users);
        displayUsers();
    } catch (err) {
        alert(err);
    }
}

getUsers();

console.log("Coucou 3");


/*
    API AXIOS  est une bibliothèque Ajax
    Permet de faire des requêtes HTTP 
    Ajouté un lien CDN dans la balise <head> du HTML

*/

const post_url = url + "posts";
function getPosts1() {
    //Création d'une promesse qui contient l'appel 
    axios.get(post_url)
        //Avec la méthode then on extrait les données qui sont dans data
        .then(res => console.log(res.data))
}

async function getPosts2() {
    const res = await axios.get(post_url);
    const post = res.data;
    console.log(post);
}

getPosts1(); 
getPosts2();



const todo_url = url + 'todos';

const new_todo = {
    userId: 2, 
    title: 'Comprendre Ajax', 
    completed: false
}

function createTodo1() {
    axios.post(todo_url, new_todo)
    .then(res => console.log(res))
    .catch(err => console.warn(err));
}

createTodo1();


//Async - await
async function createTodo2() {
    try {
        const res = await axios.post(todo_url, new_todo);
        console.log(res);
    } catch (error) {
        console.warn(error)
    }

}

function createTodo3() {
    axios({
        method: 'post', 
        url: todo_url,
        data: new_todo
    }).then(res => console.log(res));
}


createTodo3();

