
window.addEventListener('load', () => {

    var btn_xoa_ban_ghi = document.querySelector('#btn_xoa_ban_ghi');


    btn_xoa_ban_ghi.addEventListener('click', () => {
        if (confirm('Bạn có chắc muốn xóa bản ghi ở trang hiện tại?')) {


            var Results = Array.from(document.getElementsByClassName('ID_Result'));
            var arrID = Results.map((IDs) => {
                return parseInt(IDs.getAttribute("data-id-result"));
            });

            var end_id = arrID.reduce(function (accumulator, element) {
                return (accumulator > element) ? accumulator : element
            });

            var start_id = arrID.reduce(function (accumulator, element) {
                return (accumulator < element) ? accumulator : element
            });


            var arrParameter = Array.from(document.querySelectorAll('.Parameter_ID')).map((parameter_ids) => {
                return parameter_ids.textContent.toString().trim();
            });

            var pH = arrParameter.indexOf('pH') > -1 ? 'pH' : 'null';
            var Temp = arrParameter.indexOf('Temp') > -1 ? 'Temp' : 'null';
            var TSS = arrParameter.indexOf('TSS') > -1 ? 'TSS' : 'null';
            var COD = arrParameter.indexOf('COD') > -1 ? 'COD' : 'null';
            var NH4 = arrParameter.indexOf('NH4') > -1 ? 'NH4' : 'null';

            fetch('./result/deleteresult', {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ start_id, end_id, pH, Temp, TSS, COD, NH4 })
            }).then(res => res.json()).then((data) => {
                Results.forEach((elm) => {
                    elm.remove();
                })
            });

        } else {
            console.log('no elm has deleted.');
        }
    })


    var xoa_tat_ca = document.getElementById('xoa_tat_ca');
    xoa_tat_ca.onsubmit = (e) => {
        if (confirm("Bạn có chắc muốn xóa tất cả bản ghi?")) {

        }
        else {
            e.preventDefault();
        }
    }




})