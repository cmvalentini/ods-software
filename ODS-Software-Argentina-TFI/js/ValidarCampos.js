function validarcamposvacios() {
    console.log("entre mod of fucker")
    campo = document.getElementById(txtusuario).value;
    console.log(campo)
    
    
    console.log(campo);
    array = camposVacios(inputs);

    if (array[0] == false) {
        alert("Faltan campos " + array[2])
        document.getElementById(array[1]).focus();
    }

    else {
        alert("todos los campos estan corrrectos")// se puede lo que necesitemos que haga si todos los campos estan llenos
    }

}

 
