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
const position_current_text = document.querySelector("#position_current_text");
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

        //btn status
        if (data.btn_tudong == false) {
            btn_batdau.disabled = true;
            btn_doCOD.disabled = true;
            btn_doluuluong.disabled = true;
            btn_dopH.disabled = true;
            btn_doTSS.disabled = true;
            btn_laymau.disabled = true;
            btn_luu.disabled = true;
            btn_xoa.disabled = true;
            btn_tudong.classList.remove('btn-warning');
            btn_tudong.classList.add('btn-success');
            btn_tudong.textContent = 'Bật tự động';
        }
        else {
            btn_batdau.disabled = false;
            btn_doCOD.disabled = false;
            btn_doluuluong.disabled = false;
            btn_dopH.disabled = false;
            btn_doTSS.disabled = false;
            btn_laymau.disabled = false;
            btn_luu.disabled = false;
            btn_xoa.disabled = false;
            btn_tudong.classList.add('btn-warning');
            btn_tudong.classList.remove('btn-success');
            btn_tudong.textContent = 'Tắt tự động';
        }



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

        if (data.position_current != 0) {
            var curPosition = document.querySelector(`#box_number_${data.position_current}`);
            curPosition.style.backgroundColor = "#198754";
            curPosition.style.color = "#fff";
        }


        //message
        message_error_parameter.textContent = data.message !== "" ? data.message : "";
        message_error_connect.textContent = data.messageErrorConnectPLC !== "" ? data.messageErrorConnectPLC : "";

        //xoa
        arr_status_position = [data.status_position_1, data.status_position_2, data.status_position_3, data.status_position_4, data.status_position_5, data.status_position_6, data.status_position_7, data.status_position_8, data.status_position_9, data.status_position_10, data.status_position_11, data.status_position_12, data.status_position_13, data.status_position_14, data.status_position_15, data.status_position_16, data.status_position_17, data.status_position_18, data.status_position_19, data.status_position_20, data.status_position_21, data.status_position_22, data.status_position_23, data.status_position_24];

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


    })
}


const dataInterval = setInterval(updateData, 500);




//batdau
btn_batdau.addEventListener('click', () => {

    if (input_nhap_so_chai_lay_mau.value) {
        let position = parseInt(input_nhap_so_chai_lay_mau.value);

        if (position >= 1 && position <= 24) {
            fetch(`./dashboard/btn_batdau?position=${position}`).then(res => res.json()).then((resData) => {
                position_current_text.textContent = `Đang bắt đầu tại vị trí: ${resData.position}`;
                console.log(resData.position);
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
                position_current_text.textContent = `Đang lấy mẫu tại vị trí: ${resData.position} (Sẵn sàng để lưu).`;
                console.log(resData.position);
            })
    }

});


//key-value status dia chi plc cua 24 mau thu

var adrressPosition = [
    'DB17.DBW0', 'DB17.DBW2', 'DB17.DBW4', 'DB17.DBW6', 'DB17.DBW8', 'DB17.DBW10', 'DB17.DBW12', 'DB17.DBW14', 'DB17.DBW16', 'DB17.DBW18', 'DB17.DBW20', 'DB17.DBW22', 'DB17.DBW24', 'DB17.DBW26', 'DB17.DBW28', 'DB17.DBW30', 'DB17.DBW32', 'DB17.DBW34', 'DB17.DBW36', 'DB17.DBW38', 'DB17.DBW40', 'DB17.DBW42', 'DB17.DBW44', 'DB17.DBW46'
]

//luu
btn_luu.addEventListener('click', () => {
    if (input_luu.value) {
        var position = parseInt(input_luu.value);
        fetch(`./dashboard/btn_luu?adrrposition=${adrressPosition[position - 1]}&position=${position}`).then(res => res.json()).then((resData) => {
            position_current_text.textContent = "";
            input_nhap_so_chai_lay_mau.value = null;
            input_luu.value = null;
            console.log(resData.position);
        });
    }

});

//xoa
btn_xoa.addEventListener('click', () => {
    if (input_xoa.value) {
        var position = parseInt(input_xoa.value);
        fetch(`./dashboard/btn_xoa?adrrposition=${adrressPosition[position - 1]}&position=${position}`).then(res => res.json()).then((resData) => {
            input_xoa.value = null;
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

