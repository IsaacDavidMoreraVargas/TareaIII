
function busqueda_online(elemento) {
    var url = "/Producto/ConsultaInmediata/" + "?id=" + elemento.value;
    if (elemento.value == "") {
        let tabla = document.getElementsByClassName("tabla-lote")[0];
        let array = tabla.getElementsByClassName("fila-segundo");
        if (array != null)
        {
            document.getElementsByClassName("contenedor-filas-lote")[0].innerHTML = "";
        }
    } else {
        /*
        <div class="fila-lote fila-segundo">
            <div class="celda-lote lote-par lote-primero">fdfd</div>
            <div class="celda-lote lote-par">fdfdf</div>
        </div >
        */
        var request = new XMLHttpRequest();
        request.responseType = 'text';
        request.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                if (this.responseText != "null") {
                    try {
                            let bandera = 0;
                            //console.log(this.responseText);
                            let convertido = JSON.parse(this.responseText);
                            for (let numero in convertido) {
                                let clase_option = "";
                                if ((bandera % 2) == 0) {
                                    clase_option = "celda-lote lote-par ";
                                } else {
                                    clase_option = "celda-lote lote-impar ";
                                }

                                let div_elemento = document.createElement("div");
                                div_elemento.className = "fila-lote fila-segundo";
                                //let div_elemento_lote = document.createElement("div");
                                //div_elemento_lote.className = clase_option;
                                let div_elemento_fechaf = document.createElement("div");
                                div_elemento_fechaf.className = clase_option;
                                let div_elemento_fechac = document.createElement("div");
                                div_elemento_fechac.className = clase_option;
                                let div_nombre = document.createElement("div");
                                div_nombre.className = clase_option;
                                let div_elemento_informacion = document.createElement("div");
                                div_elemento_informacion.className = clase_option;
                                let div_elemento_cantidad = document.createElement("div");
                                div_elemento_cantidad.className = clase_option;


                                //div_elemento_lote.textContent = convertido[numero].lote;
                                div_elemento_fechaf.textContent = convertido[numero].FechaF;
                                div_elemento_fechac.textContent = convertido[numero].FechaC;
                                div_nombre.textContent = convertido[numero].Nombre;
                                div_elemento_informacion.textContent = convertido[numero].Informacion;
                                div_elemento_cantidad.textContent = convertido[numero].cantidad;

                                //div_elemento.appendChild(div_elemento_lote);
                                div_elemento.appendChild(div_elemento_fechaf);
                                div_elemento.appendChild(div_elemento_fechac);
                                div_elemento.appendChild(div_nombre);
                                div_elemento.appendChild(div_elemento_informacion);
                                div_elemento.appendChild(div_elemento_cantidad);
                                document.getElementsByClassName("contenedor-filas-lote")[0].appendChild(div_elemento);
                                bandera++;
                        }
                    } catch (e) { console.log("Error: " + e) }
                    //alert(convertido);
                }
            }
        };

        request.open('GET', url, true);
        request.send();
    }
    //break;
}