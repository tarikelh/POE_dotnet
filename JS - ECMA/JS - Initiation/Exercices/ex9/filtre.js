let search = document.getElementById('search');

// search.value;

search.addEventListener('keydown', function(event) {
    console.log(event);
    if (event.key == 'Enter') {
        let imageList = document.getElementsByTagName('img');
        for (let image of imageList){
            if(image.getAttribute('Alt').includes(search.value)){
                image.style.display = 'inline';
            } else{
                image.style.display = 'none';
            }
        }
        // Récupération des éléments de la liste
        // Iteration sur les images
            // Vérification et comparaison des valeurs du champ texte et de 
            // l'attribut alt de l'image
    }
});