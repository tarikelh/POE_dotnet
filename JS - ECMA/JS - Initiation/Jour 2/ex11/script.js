console.log(window.innerHeight);
console.log(window.innerWidth);

window.addEventListener('resize', function (e) {

    if (window.innerWidth>window.innerHeight && window.innerWidth<1000){
        alert("merci de retourner votre téléphone");
    }

})