//parameter
const pH = document.querySelector("#pH");
const TSS = document.querySelector("#TSS");
const COD = document.querySelector("#COD");
const Temp = document.querySelector("#Temp");

//input
const input_tongluuluong = document.querySelector("#input_tongluuluong");
const input_luuluongra = document.querySelector("#input_luuluongra");
const input_luuluongvao = document.querySelector("#input_luuluongvao");
const input_luu = document.querySelector("#input_luu");
const input_xoa = document.querySelector("#input_xoa");
const input_nhap_so_chai_lay_mau = document.querySelector("#input_nhap_so_chai_lay_mau");

//
const position_current_span = document.querySelector("#position_current_span");
//24 position
const box_number_1 = document.getElementById('box_number_1');
const box_number_2 = document.getElementById('box_number_2');
const box_number_3 = document.getElementById('box_number_3');
const box_number_4 = document.getElementById('box_number_4');
const box_number_5 = document.getElementById('box_number_5');
const box_number_6 = document.getElementById('box_number_6');
const box_number_7 = document.getElementById('box_number_7');
const box_number_8 = document.getElementById('box_number_8');
const box_number_9 = document.getElementById('box_number_9');
const box_number_10 = document.getElementById('box_number_10');
const box_number_11 = document.getElementById('box_number_11');
const box_number_12 = document.getElementById('box_number_12');
const box_number_13 = document.getElementById('box_number_13');
const box_number_14 = document.getElementById('box_number_14');
const box_number_15 = document.getElementById('box_number_15');
const box_number_16 = document.getElementById('box_number_16');
const box_number_17 = document.getElementById('box_number_17');
const box_number_18 = document.getElementById('box_number_18');
const box_number_19 = document.getElementById('box_number_19');
const box_number_20 = document.getElementById('box_number_20');
const box_number_21 = document.getElementById('box_number_21');
const box_number_22 = document.getElementById('box_number_22');
const box_number_23 = document.getElementById('box_number_23');
const box_number_24 = document.getElementById('box_number_24');

//btn 
const btn_batdau = document.querySelector("#btn_batdau");
const btn_laymau = document.querySelector("#btn_laymau");
const btn_luu = document.querySelector("#btn_luu");
const btn_xoa = document.querySelector("#btn_xoa");
const btn_dopH = document.querySelector("#btn_dopH");
const btn_doTSS = document.querySelector("#btn_doTSS");
const btn_doCOD = document.querySelector("#btn_doCOD");
const btn_doluuluong = document.querySelector("#btn_doluuluong");
const btn_tudong = document.querySelector("#btn_tudong");



//message
const message_error_parameter = document.querySelector("#message_error_parameter");
var message_error_connect = document.querySelector("#message_error_connect");


//value global
var position_current = 0;
var arr_status_position = [];
var numberOptionXoa = 0;

//set color position
function setColorPosition(position, status_position) {
    if (status_position != 0) {
        position.style.color = "white";
        position.style.backgroundColor = "#dc3545";
    }
    else {
        position.style.backgroundColor = "#dcdcdc";
        position.style.color = "black";
    }
}

const updateData = () => {
    fetch('./dashboard/updatedataplc').then(res => res.json()).then(data => {
        //value global
        position_current = data.position_current;


        console.log(data);

        //btn status



        // parameter
        pH.textContent = data.ph;
        TSS.textContent = data.tss;
        COD.textContent = data.cod;
        Temp.textContent = data.temp;

        //luu luong
        input_luuluongvao.value = data.luuluongvao;
        input_luuluongra.value = data.luuluongra;
        input_tongluuluong.value = data.luuluong;

        //position
        position_current_span.textContent = position_current;
        setColorPosition(box_number_1, data.status_position_1);
        setColorPosition(box_number_2, data.status_position_2);
        setColorPosition(box_number_3, data.status_position_3);
        setColorPosition(box_number_4, data.status_position_4);
        setColorPosition(box_number_5, data.status_position_5);
        setColorPosition(box_number_6, data.status_position_6);
        setColorPosition(box_number_7, data.status_position_7);
        setColorPosition(box_number_8, data.status_position_8);
        setColorPosition(box_number_9, data.status_position_9);
        setColorPosition(box_number_10, data.status_position_10);
        setColorPosition(box_number_11, data.status_position_11);
        setColorPosition(box_number_12, data.status_position_12);
        setColorPosition(box_number_13, data.status_position_13);
        setColorPosition(box_number_14, data.status_position_14);
        setColorPosition(box_number_15, data.status_position_15);
        setColorPosition(box_number_16, data.status_position_16);
        setColorPosition(box_number_17, data.status_position_17);
        setColorPosition(box_number_18, data.status_position_18);
        setColorPosition(box_number_19, data.status_position_19);
        setColorPosition(box_number_20, data.status_position_20);
        setColorPosition(box_number_21, data.status_position_21);
        setColorPosition(box_number_22, data.status_position_22);
        setColorPosition(box_number_23, data.status_position_23);
        setColorPosition(box_number_24, data.status_position_24);

        if (position_current != 0) {
            var curPosition = document.querySelector(`#box_number_${position_current}`);
            curPosition.style.backgroundColor = "#198754";
            curPosition.style.color = "#fff";
        }


        //message
        message_error_parameter.textContent = data.message !== "" ? data.message : "";
        message_error_connect.textContent = data.messageErrorConnectPLC !== "" ? data.messageErrorConnectPLC : "";

        //xoa

        arr_status_position = [data.status_position_1, data.status_position_2, data.status_position_3, data.status_position_4, data.status_position_5, data.status_position_6, data.status_position_7, data.status_position_8, data.status_position_9, data.status_position_10, data.status_position_11, data.status_position_12, data.status_position_13, data.status_position_14, data.status_position_15, data.status_position_16, data.status_position_17, data.status_position_18, data.status_position_19, data.status_position_20, data.status_position_21, data.status_position_22, data.status_position_23, data.status_position_24];

        if (input_xoa.length == 0) {
            arr_status_position.forEach((position, index) => {
                if (position != 0) {
                    var option = document.createElement("option");
                    option.value = index + 1;
                    option.text = index + 1;
                    option.classList.add("option_position");
                    if (index + 1 == position_current) {
                        option.selected = true;
                    }
                    input_xoa.add(option);

                }
            });
        }
        if (input_xoa.length != numberOptionXoa) {

            input_xoa.innerHTML = "";
            arr_status_position.forEach((position, index) => {
                if (position != 0) {
                    var option = document.createElement("option");
                    option.value = index + 1;
                    option.text = index + 1;
                    option.classList.add("option_position");
                    if (index + 1 == position_current) {
                        option.selected = true;
                    }
                    input_xoa.add(option);

                }
            });


        }

        numberOptionXoa = input_xoa.length;



    })
}


const dataInterval = setInterval(updateData, 800);




//batdau
btn_batdau.addEventListener('click', () => {

    if (input_nhap_so_chai_lay_mau.value) {
        let position = parseInt(input_nhap_so_chai_lay_mau.value);

        if (position >= 1 && position <= 24) {
            fetch(`./dashboard/btn_batdau?position=${position}`).then(res => res.json()).then((resData) => {
                console.log(resData.status);
            })
        } else {
            alert("Vui lòng nhập vị trí chọn mẫu sẵn có.")
        }
    } else {
        alert("Chưa nhập vị trí chọn mẫu.");
    }

});



//laymau
btn_laymau.addEventListener('click', () => {
    //input
    if (position_current != 0) {
        input_luu.value = position_current;
        fetch(`./dashboard/btn_laymau?position=${position_current}`).then(res => res.json()).then(
            (resData) => {
                console.log(resData.status);
            })
    }

});


//key-value dia chi plc cua 24 mau thu
var adrressPosition = [
    {}
]

//luu
btn_luu.addEventListener('click', () => {
    if (input_luu.value) {
        var position_luu = parseInt(input_luu.value);
        fetch(`./dashboard/btn_luu?position=${position_luu}`).then(res => res.json()).then((resData) => {
            input_luu.value = null;
            console.log(resData.position);
        });
    }

});



//tu dong
btn_tudong.addEventListener('click', () => {
    fetch('./dashboard/btn_tudong').then(res => res.json()).then(
        (resData) => {
            console.log(resData.status);

        }

    )
});




//xoa
btn_xoa.addEventListener('click', () => {
    fetch('./dashboard/btn_xoa').then(res => res.json()).then(resData => console.log(resData.status))
});




btn_dopH.addEventListener('click', () => {
    fetch('./dashboard/btn_doph').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_doCOD.addEventListener('click', () => {
    fetch('./dashboard/btn_docod').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_doTSS.addEventListener('click', () => {
    fetch('./dashboard/btn_dotss').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_doluuluong.addEventListener('click', () => {
    fetch('./dashboard/btn_doluuluong').then(res => res.json()).then(resData => console.log(resData.status))
});



















//24 position
//const box_number = Array.from(document.querySelectorAll(".box_number"));

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