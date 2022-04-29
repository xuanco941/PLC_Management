const pH = document.querySelector("#pH");
const TSS = document.querySelector("#TSS");
const COD = document.querySelector("#COD");
const Temp = document.querySelector("#Temp");


let updateData = fetch('./dashboard/updatedataplc').then(res => res.json()).then(data => {
    pH.textContent = data.ph;
    TSS.textContent = data.TSS;
    COD.textContent = data.COD;
    Temp.textContent = data.Temp;
})


let DataInterval = setInterval(updateData, 2000);