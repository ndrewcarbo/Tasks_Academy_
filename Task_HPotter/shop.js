// let elencoBacchette = localStorage.getItem("SHOP");
// let oli = [];

// if(elencoBacchette==null){
//     localStorage.setItem("SHOP",JSON.stringify(oli))
// }
// else {
//     oli=JSON.parse(elencoBacchette)
// }



function elimina(index){
    let oli = localStorage.getItem("SHOP") != null ? JSON.parse(localStorage.getItem("SHOP")) : [];

    oli.splice(index,1);

    localStorage.setItem("SHOP",JSON.stringify(oli))

    StampaBac()

}

function addBacc (){
   let oli = localStorage.getItem("SHOP") != null ? JSON.parse(localStorage.getItem("SHOP")) : [];

   let varCode = document.getElementById("input-cod").value
   let varMat = document.getElementById("input-mate").value
   let varNuc = document.getElementById("input-nucleo").value
   let varLun = document.getElementById("input-lunghezza").value
   let varCas = document.getElementById("input-casata").value
   let varFoto = document.getElementById("input-foto").value



   let newBac = {
    codice: varCode,
    materiale: varMat,
    nucleo: varNuc,
    lunghezza: varLun,
    casata: varCas,
    foto: varFoto
}


oli.push(newBac);
    localStorage.setItem("SHOP",JSON.stringify(oli));



}


function StampaBac (){
    let oli = localStorage.getItem("SHOP") != null ? JSON.parse(localStorage.getItem("SHOP")) : []; //controllo se è nullo altrimenti è vuoto

    let elebac = "";

    for(let [index, item] of oli.entries()){
        elebac += `
        <tr>
            <td>${index + 1}</td>
            <td>${item.codice}</td>
            <td>${item.materiale}</td>
            <td>${item.nucleo}</td>
            <td>${item.lunghezza}</td>
            <td>${item.casata}</td>
            <td>${item.foto}</td>

            <td>
                    <button type="button" class="btn btn-danger" onclick="elimina(${index})">Elimina</button>
                    <button type="button" class="btn btn-warning" onclick="modifica(${index})">Modifica</button>
            </td>
        </tr>


                
        `;


    }

    document.getElementById("corpo-tabella-shop").innerHTML= elebac;
}


StampaBac();

function modifica(indice){
    $("#modaleModifica").modal('show');
    $("#btn-salva").data('identif', indice);

    let oli = localStorage.getItem("SHOP") != null 
                            ? JSON.parse(localStorage.getItem("SHOP")) : [];

    for(let [index, item] of elencoLocale.entries()){
        if(indice == index){                          
            document.getElementById("input-casata").value = item.casata;
            
        }
    }
}

function salva(varBottone){

    let posizione = $(varBottone).data('identif')
    
    let varCasa = document.getElementById("input-casata").value;

    let oli = localStorage.getItem("SHOP") != null 
                            ? JSON.parse(localStorage.getItem("SHOP")) : [];

    for(let [index, item] of oli.entries()){
        if(index == posizione){
            
            item.casata = varCasa;

            localStorage.setItem("SHOP", JSON.stringify(oli));
            StampaBac();
            $("#modaleModifica").modal('hide');
            return;
        }
    }
}



