
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
            let ID = parseInt(btn.getAttribute("data-id"));
            let IDMain = parseInt(btn.getAttribute("data-id-main"));
            dataID = ID;
            fetch("./employee/getdataauser", {
                method: "post",
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({ ID: ID })
            }).then(res => res.json())
                .then((dataUser) => {

                    fullnameUpdate.value = dataUser.fullName;
                    usernameUpdate.value = dataUser.username;
                    //usernameUpdate.disabled = IDMain == dataUser.id ? true : false;
                    passwordUpdate.value = dataUser.password;
                    if (dataUser.isAdmin == true) {
                        isAdminUpdateTrue.checked = true;
                    } else {
                        isAdminUpdateFalse.checked = true;
                    }

                    isAdminUpdateFalse.disabled = IDMain == dataUser.id ? true : false;
                    isAdminUpdateTrue.disabled = IDMain == dataUser.id ? true : false;

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

    let FullName = fullnameUpdate.value;
    let Username = usernameUpdate.value;
    let Password = passwordUpdate.value;
    let IsAdmin = isAdminUpdateTrue.checked == true ? true : false;


    if (FullName.length != 0 && Username.length != 0 && Password != 0) {
        let employee = { ID: dataID, FullName, Username, Password, IsAdmin };

        // lay record nhan vien
        let trElm = trElements.filter((e) => {
            return e.getAttribute('data-id') == dataID;
        })

        fetch('./employee/updateemployee', {
            method: "post",
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(employee)
        }).then(res => res.json())
            .then((dataUser) => {
                trElm[0].children[0].textContent = dataUser.id;
                trElm[0].children[1].textContent = dataUser.fullName;
                trElm[0].children[2].textContent = dataUser.username;
                trElm[0].children[3].textContent = dataUser.password;
                trElm[0].children[4].textContent = dataUser.isAdmin == true ? 'Có' : 'Không';
            })
    }
    else {
        alert("Hãy nhập đủ thông tin thiết yếu!!!");
    }



    event.preventDefault();
})





