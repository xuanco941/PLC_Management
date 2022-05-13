//parameter
const pH = document.querySelector("#pH");
const TSS = document.querySelector("#TSS");
const COD = document.querySelector("#COD");
const Temp = document.querySelector("#Temp");
const NH4 = document.querySelector("#NH4");

//input
const input_tongluuluong = document.querySelector("#input_tongluuluong");
const input_luuluongra = document.querySelector("#input_luuluongra");
const input_luuluongvao = document.querySelector("#input_luuluongvao");
const input_luu = document.querySelector("#input_luu");
const input_xoa = document.querySelector("#input_xoa");
const input_nhap_so_chai_lay_mau = document.querySelector("#input_nhap_so_chai_lay_mau");

//24 position DB17
const status_position_DB17_1 = document.getElementById('status_position_DB17_1');
const status_position_DB17_2 = document.getElementById('status_position_DB17_2');
const status_position_DB17_3 = document.getElementById('status_position_DB17_3');
const status_position_DB17_4 = document.getElementById('status_position_DB17_4');
const status_position_DB17_5 = document.getElementById('status_position_DB17_5');
const status_position_DB17_6 = document.getElementById('status_position_DB17_6');
const status_position_DB17_7 = document.getElementById('status_position_DB17_7');
const status_position_DB17_8 = document.getElementById('status_position_DB17_8');
const status_position_DB17_9 = document.getElementById('status_position_DB17_9');
const status_position_DB17_10 = document.getElementById('status_position_DB17_10');
const status_position_DB17_11 = document.getElementById('status_position_DB17_11');
const status_position_DB17_12 = document.getElementById('status_position_DB17_12');
const status_position_DB17_13 = document.getElementById('status_position_DB17_13');
const status_position_DB17_14 = document.getElementById('status_position_DB17_14');
const status_position_DB17_15 = document.getElementById('status_position_DB17_15');
const status_position_DB17_16 = document.getElementById('status_position_DB17_16');
const status_position_DB17_17 = document.getElementById('status_position_DB17_17');
const status_position_DB17_18 = document.getElementById('status_position_DB17_18');
const status_position_DB17_19 = document.getElementById('status_position_DB17_19');
const status_position_DB17_20 = document.getElementById('status_position_DB17_20');
const status_position_DB17_21 = document.getElementById('status_position_DB17_21');
const status_position_DB17_22 = document.getElementById('status_position_DB17_22');
const status_position_DB17_23 = document.getElementById('status_position_DB17_23');
const status_position_DB17_24 = document.getElementById('status_position_DB17_24');


//24 position DB18
const status_position_DB18_1 = document.getElementById('status_position_DB18_1');
const status_position_DB18_2 = document.getElementById('status_position_DB18_2');
const status_position_DB18_3 = document.getElementById('status_position_DB18_3');
const status_position_DB18_4 = document.getElementById('status_position_DB18_4');
const status_position_DB18_5 = document.getElementById('status_position_DB18_5');
const status_position_DB18_6 = document.getElementById('status_position_DB18_6');
const status_position_DB18_7 = document.getElementById('status_position_DB18_7');
const status_position_DB18_8 = document.getElementById('status_position_DB18_8');
const status_position_DB18_9 = document.getElementById('status_position_DB18_9');
const status_position_DB18_10 = document.getElementById('status_position_DB18_10');
const status_position_DB18_11 = document.getElementById('status_position_DB18_11');
const status_position_DB18_12 = document.getElementById('status_position_DB18_12');
const status_position_DB18_13 = document.getElementById('status_position_DB18_13');
const status_position_DB18_14 = document.getElementById('status_position_DB18_14');
const status_position_DB18_15 = document.getElementById('status_position_DB18_15');
const status_position_DB18_16 = document.getElementById('status_position_DB18_16');
const status_position_DB18_17 = document.getElementById('status_position_DB18_17');
const status_position_DB18_18 = document.getElementById('status_position_DB18_18');
const status_position_DB18_19 = document.getElementById('status_position_DB18_19');
const status_position_DB18_20 = document.getElementById('status_position_DB18_20');
const status_position_DB18_21 = document.getElementById('status_position_DB18_21');
const status_position_DB18_22 = document.getElementById('status_position_DB18_22');
const status_position_DB18_23 = document.getElementById('status_position_DB18_23');
const status_position_DB18_24 = document.getElementById('status_position_DB18_24');


//btn 
const btn_batdau = document.querySelector("#btn_batdau");
const btn_laymau = document.querySelector("#btn_laymau");
const btn_luu = document.querySelector("#btn_luu");
const btn_xoa = document.querySelector("#btn_xoa");
const btn_dopH = document.querySelector("#btn_dopH");
const btn_doTSS = document.querySelector("#btn_doTSS");
const btn_doCOD = document.querySelector("#btn_doCOD");
const btn_doluuluongtong = document.querySelector("#btn_doluuluongtong");
const btn_tudong = document.querySelector("#btn_tudong");
const btn_doluuluongvao = document.querySelector("#btn_doluuluongvao");
const btn_doluuluongra = document.querySelector("#btn_doluuluongra");
const btn_doNH4 = document.querySelector("#btn_doNH4");

//position current text
const position_current_text_batdau = document.querySelector('#position_current_text_batdau');
const position_current_text_laymau = document.querySelector('#position_current_text_laymau');
const position_current_text_luu = document.querySelector('#position_current_text_luu');



//message
const message_error_parameter = document.querySelector("#message_error_parameter");
var message_error_connect = document.querySelector("#message_error_connect");


//set color position
function setColorPositionDB17(position, status_position) {
    if (status_position != 0) {
        position.style.backgroundColor = "#198754";
        position.style.color = "#fff";
    }
    else {
        position.style.backgroundColor = "#dcdcdc";
        position.style.color = "black";
    }
}
function setColorPositionDB18(position, status_position) {
    if (status_position != 0) {
        position.style.color = "white";
        position.style.backgroundColor = "#dc3545";
    }
    else {
        position.style.backgroundColor = "#dcdcdc";
        position.style.color = "black";
    }
}

//set disabled button
function setDisabledButton(status) {
    //btn tu dong
    if (status == false) {
        btn_batdau.disabled = true;
        btn_laymau.disabled = true;
        btn_luu.disabled = true;
        btn_xoa.disabled = true;

        btn_doCOD.disabled = true;
        btn_dopH.disabled = true;
        btn_doTSS.disabled = true;
        btn_doNH4.disabled = true;

        btn_doluuluongtong.disabled = true;
        btn_doluuluongvao.disabled = true;
        btn_doluuluongra.disabled = true;


        btn_tudong.classList.remove('btn-warning');
        btn_tudong.classList.add('btn-success');
        btn_tudong.textContent = 'Bật tự động';
    }
    else {
        btn_batdau.disabled = false;
        btn_laymau.disabled = false;
        btn_luu.disabled = false;
        btn_xoa.disabled = false;

        btn_doCOD.disabled = false;
        btn_dopH.disabled = false;
        btn_doTSS.disabled = false;
        btn_doNH4.disabled = false;

        btn_doluuluongtong.disabled = false;
        btn_doluuluongvao.disabled = false;
        btn_doluuluongra.disabled = false;

        btn_tudong.classList.add('btn-warning');
        btn_tudong.classList.remove('btn-success');
        btn_tudong.textContent = 'Tắt tự động';
    }
}





// get data
const updateData = () => {
    fetch('./dashboard/updatedataplc').then(res => res.json()).then(data => {

        console.log(data);

        //position current text
        if (data.position_current_batdau != 0) {
            position_current_text_batdau.textContent = `Đang bắt đầu tại vị trí : ${data.position_current_batdau}`;
        }
        else {
            position_current_text_batdau.textContent = '';
        }
        if (data.position_current_laymau != 0) {
            position_current_text_laymau.textContent = `Đang lấy mẫu tại vị trí : ${data.position_current_laymau}`;
        }
        else {
            position_current_text_laymau.textContent = '';
        }
        if (data.position_current_luu != 0) {
            position_current_text_luu.textContent = `Vừa lưu tại vị trí : ${data.position_current_luu}`;
        }
        else {
            position_current_text_luu.textContent = '';
        }


        // parameter
        pH.textContent = data.ph;
        TSS.textContent = data.tss;
        COD.textContent = data.cod;
        Temp.textContent = data.temp;
        NH4.textContent = data.nh4;

        //luu luong
        input_luuluongvao.value = data.luuluongvao;
        input_luuluongra.value = data.luuluongra;
        input_tongluuluong.value = data.luuluongtong;

        //positionColorDB17
        setColorPositionDB17(status_position_DB17_1, data.status_position_DB17_1);
        setColorPositionDB17(status_position_DB17_2, data.status_position_DB17_2);
        setColorPositionDB17(status_position_DB17_3, data.status_position_DB17_3);
        setColorPositionDB17(status_position_DB17_4, data.status_position_DB17_4);
        setColorPositionDB17(status_position_DB17_5, data.status_position_DB17_5);
        setColorPositionDB17(status_position_DB17_6, data.status_position_DB17_6);
        setColorPositionDB17(status_position_DB17_7, data.status_position_DB17_7);
        setColorPositionDB17(status_position_DB17_8, data.status_position_DB17_8);
        setColorPositionDB17(status_position_DB17_9, data.status_position_DB17_9);
        setColorPositionDB17(status_position_DB17_10, data.status_position_DB17_10);
        setColorPositionDB17(status_position_DB17_11, data.status_position_DB17_11);
        setColorPositionDB17(status_position_DB17_12, data.status_position_DB17_12);
        setColorPositionDB17(status_position_DB17_13, data.status_position_DB17_13);
        setColorPositionDB17(status_position_DB17_14, data.status_position_DB17_14);
        setColorPositionDB17(status_position_DB17_15, data.status_position_DB17_15);
        setColorPositionDB17(status_position_DB17_16, data.status_position_DB17_16);
        setColorPositionDB17(status_position_DB17_17, data.status_position_DB17_17);
        setColorPositionDB17(status_position_DB17_18, data.status_position_DB17_18);
        setColorPositionDB17(status_position_DB17_19, data.status_position_DB17_19);
        setColorPositionDB17(status_position_DB17_20, data.status_position_DB17_20);
        setColorPositionDB17(status_position_DB17_21, data.status_position_DB17_21);
        setColorPositionDB17(status_position_DB17_22, data.status_position_DB17_22);
        setColorPositionDB17(status_position_DB17_23, data.status_position_DB17_23);
        setColorPositionDB17(status_position_DB17_24, data.status_position_DB17_24);

        //positionColorDB18
        setColorPositionDB18(status_position_DB18_1, data.status_position_DB18_1);
        setColorPositionDB18(status_position_DB18_2, data.status_position_DB18_2);
        setColorPositionDB18(status_position_DB18_3, data.status_position_DB18_3);
        setColorPositionDB18(status_position_DB18_4, data.status_position_DB18_4);
        setColorPositionDB18(status_position_DB18_5, data.status_position_DB18_5);
        setColorPositionDB18(status_position_DB18_6, data.status_position_DB18_6);
        setColorPositionDB18(status_position_DB18_7, data.status_position_DB18_7);
        setColorPositionDB18(status_position_DB18_8, data.status_position_DB18_8);
        setColorPositionDB18(status_position_DB18_9, data.status_position_DB18_9);
        setColorPositionDB18(status_position_DB18_10, data.status_position_DB18_10);
        setColorPositionDB18(status_position_DB18_11, data.status_position_DB18_11);
        setColorPositionDB18(status_position_DB18_12, data.status_position_DB18_12);
        setColorPositionDB18(status_position_DB18_13, data.status_position_DB18_13);
        setColorPositionDB18(status_position_DB18_14, data.status_position_DB18_14);
        setColorPositionDB18(status_position_DB18_15, data.status_position_DB18_15);
        setColorPositionDB18(status_position_DB18_16, data.status_position_DB18_16);
        setColorPositionDB18(status_position_DB18_17, data.status_position_DB18_17);
        setColorPositionDB18(status_position_DB18_18, data.status_position_DB18_18);
        setColorPositionDB18(status_position_DB18_19, data.status_position_DB18_19);
        setColorPositionDB18(status_position_DB18_20, data.status_position_DB18_20);
        setColorPositionDB18(status_position_DB18_21, data.status_position_DB18_21);
        setColorPositionDB18(status_position_DB18_22, data.status_position_DB18_22);
        setColorPositionDB18(status_position_DB18_23, data.status_position_DB18_23);
        setColorPositionDB18(status_position_DB18_24, data.status_position_DB18_24);

        //btn tu dong
        setDisabledButton(data.btn_tudong);

        //message
        message_error_parameter.textContent = data.message !== "" ? data.message : "";
        message_error_connect.textContent = data.messageErrorConnectPLC !== "" ? data.messageErrorConnectPLC : "";


        //xoa
        arr_status_position = [data.status_position_DB18_1, data.status_position_DB18_2, data.status_position_DB18_3, data.status_position_DB18_4, data.status_position_DB18_5, data.status_position_DB18_6, data.status_position_DB18_7, data.status_position_DB18_8, data.status_position_DB18_9, data.status_position_DB18_10, data.status_position_DB18_11, data.status_position_DB18_12, data.status_position_DB18_13, data.status_position_DB18_14, data.status_position_DB18_15, data.status_position_DB18_16, data.status_position_DB18_17, data.status_position_DB18_18, data.status_position_DB18_19, data.status_position_DB18_20, data.status_position_DB18_21, data.status_position_DB18_22, data.status_position_DB18_23, data.status_position_DB18_24];

        var arrOptionXoa = [];
        arr_status_position.forEach((position, index) => {
            if (position != 0) {
                arrOptionXoa.push(index + 1);
            }
        })

        if (input_xoa.length != arrOptionXoa.length) {
            input_xoa.innerHTML = "";
            arrOptionXoa.forEach((optionValue) => {
                var option = document.createElement("option");
                option.value = optionValue;
                option.text = optionValue;
                input_xoa.add(option);
            })
        }


        // next





    })
}


const dataInterval = setInterval(updateData, 500);




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
 
        fetch(`./dashboard/btn_laymau`).then(res => res.json()).then(
            (resData) => {
                console.log(resData.status);
            })

});


//luu
btn_luu.addEventListener('click', () => {
    if (input_luu.value) {
        var position = parseInt(input_luu.value);
        fetch(`./dashboard/btn_luu?position=${position}`).then(res => res.json()).then((resData) => {
            input_nhap_so_chai_lay_mau.value = null;
            input_luu.value = null;
            console.log(resData.status);
        });
    }

});

//xoa
btn_xoa.addEventListener('click', () => {
    if (input_xoa.value) {
        var position = parseInt(input_xoa.value);
        fetch(`./dashboard/btn_xoa?position=${position}`).then(res => res.json()).then((resData) => {
            input_xoa.value = null;
            console.log(resData.status);
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








btn_dopH.addEventListener('click', () => {
    fetch('./dashboard/btn_doph').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_doCOD.addEventListener('click', () => {
    fetch('./dashboard/btn_docod').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_doTSS.addEventListener('click', () => {
    fetch('./dashboard/btn_dotss').then(res => res.json()).then(resData => console.log(resData.status))
});
btn_doNH4.addEventListener('click', () => {
    fetch('./dashboard/btn_donh4').then(res => res.json()).then(resData => console.log(resData.status))
});

btn_doluuluongtong.addEventListener('click', () => {
    fetch('./dashboard/btn_doluuluongtong').then(res => res.json()).then(resData => console.log(resData.status))
});
btn_doluuluongvao.addEventListener('click', () => {
    fetch('./dashboard/btn_doluuluongvao').then(res => res.json()).then(resData => console.log(resData.status))
});
btn_doluuluongra.addEventListener('click', () => {
    fetch('./dashboard/btn_doluuluongra').then(res => res.json()).then(resData => console.log(resData.status))
});
