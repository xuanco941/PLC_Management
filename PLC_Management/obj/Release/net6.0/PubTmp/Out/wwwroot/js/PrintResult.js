var pH = document.querySelector('#pH');
var Temp = document.querySelector('#Temp');
var TSS = document.querySelector('#TSS');
var COD = document.querySelector('#COD');
var NH4 = document.querySelector('#NH4');
var tungay = document.querySelector('#tungay');
var toingay = document.querySelector('#toingay');



document.querySelector('#btn-print').onclick = () => {
    var printdata = document.getElementById('print_data');
    printdata.style.textAlign = 'center';

    var textpH = pH.checked == true ? 'pH,' : null;
    var textTemp = Temp.checked == true ? 'Temp,' : null;
    var textTSS = TSS.checked == true ? 'TSS,' : null;
    var textCOD = COD.checked == true ? 'COD,' : null;
    var textNH4 = NH4.checked == true ? 'NH4,' : null;

    var ngay = new Date(tungay.value).toLocaleDateString('vi-VI') + ' - ' + new Date(toingay.value).toLocaleDateString('vi-VI');

    var divChildren1 = document.createElement('div');
    divChildren1.textContent = 'BÁO CÁO GIÁ TRỊ ĐO';
    divChildren1.style.fontSize = '20px';
    divChildren1.style.fontWeight = '600';


    var divChildren2 = document.createElement('div');
    var textvalue = `${textpH} ${textTemp} ${textTSS} ${textCOD} ${textNH4}`;
    divChildren2.textContent = '(' + textvalue.substr(0, textvalue.lastIndexOf(',')) + ')';

    var divChildren3 = document.createElement('div');
    divChildren3.textContent = ngay;
    divChildren3.style.marginBottom = '20px';
    divChildren3.style.marginTop = '7px';

    var divFather = document.createElement('div');
    divFather.style.marginBottom = '15px';
    divFather.appendChild(divChildren1);
    divFather.appendChild(divChildren2);
    divFather.appendChild(divChildren3);

    printdata.insertAdjacentElement('afterbegin', divFather);
    printdata.style.fontFamily = 'Arial, Helvetica, sans-serif';
    var newwin = window.open("");


    newwin.document.write('<link rel="stylesheet" href="./lib/lib_new_version/bootstrap_min.css">');
    newwin.document.write(printdata.outerHTML);

    setTimeout(() => {
        newwin.print();
        newwin.close();

    }, 300);
    divFather.remove();
 

}