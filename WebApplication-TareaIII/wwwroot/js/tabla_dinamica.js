function esconder_todos() {
    //alert("here");
    let array = document.getElementsByClassName("opciones");
    for (let flag = 0; flag < array.length; flag++) {
        array[flag].style.display = "none";
    }
    array[0].style.display = "block";
    array[6].style.display = "block";
}

function esconder_especificos(numero) {
    esconder_todos()

    switch (numero) {
        case 1:
            //
            let array = document.getElementsByClassName("opciones uno");
            for (let flag = 0; flag < array.length; flag++) {
                if (array[flag].textContent != "Ir") {
                    array[flag].style.display = "block";
                }
            }
            //document.getElementsByClassName("regresar uno")[0].style.display = "block";
            break;
        case 2:
            let array2 = document.getElementsByClassName("opciones dos");
            for (let flag = 0; flag < array2.length; flag++) {
                if (array2[flag].textContent != "Ir") {
                    array2[flag].style.display = "block";
                }
            }
            //document.getElementsByClassName("regresar dos")[0].style.display = "block";
            break;
    }

}

function esconder_pequeno(caso, numero) {
    switch (caso) {
        case 1:
            let array = document.getElementsByClassName("opciones uno");
            for (let flag = 0; flag < array.length; flag++) {
                //alert(">"+array[flag].textContent+"<")
                if (array[flag].textContent == "Ir") {
                    array[flag].style.display = "none";
                }
            }
            document.getElementsByClassName("opciones uno")[numero].style.display = "block";
            break;
        case 2:
            let array2 = document.getElementsByClassName("opciones dos");
            for (let flag = 0; flag < array2.length; flag++) {
                if (array2[flag].textContent == "Ir") {
                    array2[flag].style.display = "none";
                }
            }
            document.getElementsByClassName("opciones dos")[numero].style.display = "block";
            break;
    }
}