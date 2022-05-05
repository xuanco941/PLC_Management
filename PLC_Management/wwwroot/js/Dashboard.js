
const pH = document.querySelector("#pH");
const TSS = document.querySelector("#TSS");
const COD = document.querySelector("#COD");
const Temp = document.querySelector("#Temp");

const input_tongluuluong = document.querySelector("#input_tongluuluong");
const input_luuluongra = document.querySelector("#input_luuluongra");
const input_luuluongvao = document.querySelector("#input_luuluongvao");
const input_luu = document.querySelector("#input_luu");
const input_xoa = document.querySelector("#input_xoa");
const input_nhap_so_chai_lay_mau = document.querySelector("#input_nhap_so_chai_lay_mau");




const message_error_parameter = document.querySelector("#message_error_parameter");

const updateData = () => {
    fetch('./dashboard/updatedataplc').then(res => res.json()).then(data => {

        console.log(data);
        // parameter
        pH.textContent = data.ph;
        TSS.textContent = data.tss;
        COD.textContent = data.cod;
        Temp.textContent = data.temp;

        //luu luong
        input_luuluongvao.value = data.luuluongvao;
        input_luuluongra.value = data.luuluongra;
        input_tongluuluong.value = data.luuluong;
        input_nhap_so_chai_lay_mau.value = data.nhap_so_chai_lay_mau;


        message_error_parameter.textContent = data.message !== "" ? data.message : "";
    })
}


const dataInterval = setInterval(updateData, 1500);


const box_number = Array.from(document.querySelectorAll(".box_number"));




/*let soChai = 0;*/

//box_number.forEach((btn) => {
//    btn.addEventListener('click', (e) => {

//        soChai = parseInt(btn.textContent);

//        fetch("./dashboard/btn_chonmau", {
//            method: "post",
//            headers: {
//                'content-type': 'application/json'
//            },
//            body: JSON.stringify({ soChai: soChai })
//        }).then(res => res.json()).then((data) => {

//            box_number.forEach((elm) => {
//                elm.style.backgroundColor = "#dcdcdc";
//                elm.style.color = "black";
//            })
//            btn.style.backgroundColor = "#dc3545";
//            btn.style.color = "white";

//            console.log(data.soChai);

//        });





//    })
//})



//btn
const btn_batdau = document.querySelector("#btn_batdau");
const btn_laymau = document.querySelector("#btn_laymau");
const btn_luu = document.querySelector("#btn_luu");
const btn_xoa = document.querySelector("#btn_xoa");
const btn_dopH = document.querySelector("#btn_dopH");
const btn_doTSS = document.querySelector("#btn_doTSS");
const btn_doluuluong = document.querySelector("#btn_doluuluong");
const btn_tudong = document.querySelector("#btn_tudong");


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

btn_tudong.addEventListener('click', () => {
    fetch('./dashboard/btn_tudong').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_dopH.addEventListener('click', () => {
    fetch('./dashboard/btn_doph').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_doTSS.addEventListener('click', () => {
    fetch('./dashboard/btn_dotss').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_doluuluong.addEventListener('click', () => {
    fetch('./dashboard/btn_doluuluong').then(res => res.json()).then(resData => console.log(resData.status))
});