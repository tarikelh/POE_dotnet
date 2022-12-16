let form = document.querySelector('form');
let tel = document.getElementById('tel');
let email = document.getElementById('email');

form.addEventListener('submit', function (e) {
    //vérifier si le champ est vide ou bien formatté
    testInput(tel, /^(0|\+33)(6|7)[0-9]{8}$/, e);
    testInput(email, /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/, e);
});

function testInput(input, regex, e){
    if (!input.value.match(regex)){
        input.style.borderColor = 'red';
        e.preventDefault();
    }
    else{
        input.style.borderColor = 'green';
    }
}

