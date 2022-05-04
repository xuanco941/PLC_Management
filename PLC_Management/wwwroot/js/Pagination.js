var url_string = window.location.href;
var url = new URL(url_string);
var page = url.searchParams.get("page");

window.addEventListener('load', () => {
    let pageTtems = Array.from(document.querySelectorAll('.page-item'));
    var first_item = document.querySelector("#first_item");

    if (page == 0 || page == null) {
        first_item.classList.add('active');
    }

    pageTtems.forEach((item) => {
        if (parseInt(item.children[0].textContent) == parseInt(page)) {
            item.classList.add('active');
        }

    })

})