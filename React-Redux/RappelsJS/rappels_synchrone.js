
let x = 0; 
//L'execution de cette boucle devrait prendre un certain temps 
while(x <= 1000000) {
    x++;
    console.log(x);
}

//La suite du scrit ne s'execute qu'après la fin de l'opération précedente
alert("Suite du script");