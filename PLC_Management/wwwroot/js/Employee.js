
const fullnameUpdate = document.querySelector("#fullnameUpdate");
const usernameUpdate = document.querySelector("#usernameUpdate");
const passwordUpdate = document.querySelector("#passwordUpdate");
const isAdminUpdateTrue = document.querySelector("#isAdminUpdateTrue");
const isAdminUpdateFalse = document.querySelector("#isAdminUpdateFalse");
const formUpdate = document.querySelector("#formUpdate");

let dataID; // tai khoan tac dong

// Lay data vao input modal sua nhan vien
window.onload = () => {
    const btn_update = Array.from(document.querySelectorAll(".btn_update"));
    btn_update.forEach((btn) => {
        btn.addEventListener('click', () => {
            let MaNV = parseInt(btn.getAttribute("data-id"));
            dataID = MaNV;
            fetch("./employee/getdataauser", {
                method: "post",
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({ MaNV: MaNV })
            }).then(res => res.json())
                .then((dataUser) => {

                    fullnameUpdate.value = dataUser.hoTen;
                    usernameUpdate.value = dataUser.taiKhoan;
                    passwordUpdate.value = dataUser.matKhau;
                    if (dataUser.isAdmin == true) {
                        isAdminUpdateTrue.checked = true;
                    } else {
                        isAdminUpdateFalse.checked = true;
                    }

                })
        })
    });





}

//validate type username
var elm_unique = Array.from(document.querySelectorAll('.elm_unique'));
var username = document.querySelector('#username');
var btnInsert = document.querySelector('#btnInsert');
//tai khoan
var elm_unique_value = elm_unique.map(e => e.textContent);

username.onkeyup = () => {
    console.log(username.value);
    if (elm_unique_value.includes(username.value) == true) {
        btnInsert.disabled = true;
    }
    else {
        btnInsert.disabled = false;
    }
}

usernameUpdate.onkeyup = () => {
    if (elm_unique_value.includes(usernameUpdate.value) == true) {
        btnSave.disabled = true;
    }
    else {
        btnSave.disabled = false;
    }
};


const exampleModalCenterUpdate = document.querySelector('#exampleModalCenterUpdate');
const trElements = Array.from(document.querySelectorAll(".tb_elm"));
// Cap nhat thong tin
btnSave.addEventListener("click", (event) => {
    let hoTen = fullnameUpdate.value;
    let taiKhoan = usernameUpdate.value;
    let matKhau = passwordUpdate.value;
    let isAdmin = isAdminUpdateTrue.checked == true ? true : false;
    let nhanVienModel = { maNV: dataID, hoTen, taiKhoan, matKhau, isAdmin };

    // lay record nhan vien
    let trElm = trElements.filter((e) => {
        return e.getAttribute('data-id') == dataID;
    })

    fetch('./employee/updateemployee', {
        method: "post",
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(nhanVienModel)
    }).then(res => res.json())
        .then((dataUser) => {
            trElm[0].children[0].textContent = dataUser.maNV;
            trElm[0].children[1].textContent = dataUser.hoTen;
            trElm[0].children[2].textContent = dataUser.taiKhoan;
            trElm[0].children[3].textContent = dataUser.matKhau;
            trElm[0].children[4].textContent = dataUser.isAdmin == true ? 'Có' : 'Không';
        })
    event.preventDefault();
})





