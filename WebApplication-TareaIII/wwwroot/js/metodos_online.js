
function busqueda_online(elemento) {
    var url = "/Producto/ConsultaInmediata/" + "?id=" + elemento.value;
    //alert(elemento.value);
    var request = new XMLHttpRequest();
    request.responseType = 'text';

    /*
    <div class="fila-lote fila-segundo">
        <div class="celda-lote lote-par lote-primero">fdfd</div>
        <div class="celda-lote lote-par">fdfdf</div>
    </div >
    */
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            if (this.responseText != "null") {
                try { 
                        let bandera = 0;
                        let convertido = JSON.parse(this.responseText);                        
                            for (let numero in convertido)
                            {
                                let div_elemento = document.createElement("div");
                                div_elemento.className = "fila-lote fila-segundo";
                                let div_elemento_lote = document.createElement("div");
                                let clase_option = "";
                                if ((bandera % 2) == 0) {
                                    clase_option = "celda-lote lote-par ";
                                } else {
                                    clase_option = "celda-lote lote-impar ";
                                }
                                div_elemento_lote.className = clase_option + "lote-primero";
                                div_elemento_lote.textContent = convertido[numero].lote;
                                let div_elemento_cantidad = document.createElement("div");
                                div_elemento_cantidad.className = clase_option;
                                div_elemento_cantidad.textContent = convertido[numero].cantidad;

                                div_elemento.appendChild(div_elemento_lote);
                                div_elemento.appendChild(div_elemento_cantidad);  
                                document.getElementsByClassName("tabla-lote")[0].appendChild(div_elemento);
                                bandera++;
                            }
                } catch (e){ console.log("Error: "+e) }
                //alert(convertido);
            }
        }
    };

    request.open('GET', url, true);
    request.send();
    //break;
}