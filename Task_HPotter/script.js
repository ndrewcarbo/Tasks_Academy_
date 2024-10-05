// let elencoCasate = localStorage.getItem("Hogwarts");
// let elenco = [];

// //localstorage inizializzato

// if(elencoCasate == null){
//     localStorage.setItem("Hogwarts",JSON.stringify(elenco))
// } else {
//     elenco=JSON.parse(elencoCasate)
// }



// Ogni casata è caratterizzata da 
//     -nome
//     -descizione
//     -LOGO
//     -numero di bacchette

function aggiungi(){
    let local = localStorage.getItem("Hogwarts") != null ? JSON.parse(localStorage.getItem("Hogwarts")) : []; //controllo se è nullo altrimenti è vuoto

    //let idx = document.getElementById("id-idx").value
    let varNome = document.getElementById("id-nome").value
    let varDesc = document.getElementById("id-desc").value
    let varLogo = document.getElementById("id-logo").value
    let varBac = document.getElementById("id-num-bac").value

    //CREO NUOVA CASATA

    let newCas = {
        nome: varNome,
        descrizione: varDesc,
        logo: varLogo,
        bacchette: varBac
    }
    //PUSH
   
    local.push(newCas);
    localStorage.setItem("Hogwarts", JSON.stringify(local))
    StampaCasate();
}


function StampaCasate (){
    let local = localStorage.getItem("Hogwarts") != null 
    ? JSON.parse(localStorage.getItem("Hogwarts")) : []; //controllo se è nullo altrimenti è vuoto

    let contenitore = "";

    for(let [index, item] of local.entries()){
        contenitore +=`
        <tr>
            <td>${index + 1}</td>
            <td>${item.nome}</td>
            <td>${item.descrizione}</td>
            <td>${item.logo}</td>
            <td>${item.bacchette}</td>
        </tr>
        `;
    }
    document.getElementById("corpo-tabella-casata").innerHTML = contenitore
    
}

StampaCasate();

// function DettaglioCasata(){
    
//     let grifn = document.getElementById("grifondoro")
//     let serp = document.getElementById("serpeverde")
//     let corv = document.getElementById("sorvonero")
//     let tass = document.getElementById("tassorosso")
//     let arrId = [grifn,serp,corv,tass]




// }


// function DettaglioCasata(){
//     // imgs = ["img/grifondoro.PNG","img/serpeverde.PNG","img/corvonero.PNG","img/tassorosso.PNG"];

//     let grifn = document.getElementById("grifondoro")
//     let serp = document.getElementById("serpeverde")
//     let corv = document.getElementById("sorvonero")
//     let tass = document.getElementById("tassorosso")

//     let arr = [grifn,serp,corv,tass];

// }


// function DettaglioCasata(varBottone){

    
//     let varNome = document.getElementById("input-nome").value;
//     let varLogo = document.getElementById("input-cognome").value;
//     let varDesc = document.getElementById("input-matricola").value;
//     let posizione = $(varBottone).data('identif');
//     let local = localStorage.getItem("Hogwarts") != null ? JSON.parse(localStorage.getItem("Hogwarts")) : []; //controllo se è nullo altrimenti è vuoto
//     let casa = ""
//     for(let [index,item] of local.entries()){
//         if(index == posizione){
//             item.nome = varNome;
//             item.logo = varLogo;
//             item.descrizione = varDesc;

//         }
//     }


// }