
const pH = document.querySelector("#pH");
const TSS = document.querySelector("#TSS");
const COD = document.querySelector("#COD");
const Temp = document.querySelector("#Temp");

const message_error_parameter = document.querySelector("#message_error_parameter");

const updateData = () => {
    fetch('./dashboard/updatedataplc').then(res => res.json()).then(data => {
        pH.textContent = data.ph;
        TSS.textContent = data.tss;
        COD.textContent = data.cod;
        Temp.textContent = data.temp;
        message_error_parameter.textContent = data.message !== "" ? data.message : "";
    })
}


const dataInterval = setInterval(updateData, 1500);


const box_number = Array.from(document.querySelectorAll(".box_number"));

let soChai = 0;

box_number.forEach((btn) => {
    btn.addEventListener('click', (e) => {
        box_number.forEach((elm) => {
            elm.style.backgroundColor = "#dcdcdc";
            elm.style.color = "black";
        })
        soChai = parseInt(btn.textContent);
        btn.style.backgroundColor = "#dc3545";
        btn.style.color = "white";

        console.log(soChai);
    })
})



//btn
const btn_batdau = document.querySelector("#btn_batdau");
const btn_laymau = document.querySelector("#btn_laymau");
const btn_luu = document.querySelector("#btn_luu");
const btn_xoa = document.querySelector("#btn_xoa");

btn_batdau.addEventListener('click', () => {
    fetch('./dashboard/btn_batdau').then(res => res.json()).then(resData => console.log(resData.status));
});

btn_laymau.addEventListener('click', () => {
    fetch('./dashboard/btn_laymau').then(res => res.json()).then(resData => console.log(resData.status));
});

btn_luu.addEventListener('click', () => {
    fetch('./dashboard/btn_luu').then(res => res.json()).then(resData => console.log(resData.status));
});

btn_xoa.addEventListener('click', () => {
    fetch('./dashboard/btn_xoa').then(res => res.json()).then(resData => console.log(resData.status))
});


