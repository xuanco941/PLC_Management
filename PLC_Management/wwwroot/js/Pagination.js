var url_string = window.location.href;
var url = new URL(url_string);
var page = url.searchParams.get("page");

window.addEventListener('load', () => {
    let pageTtems = Array.from(document.querySelectorAll('.page-item'));

    pageTtems.forEach((item) => {
        if (parseInt(item.children[0].textContent) == parseInt(page) || !page) {
            item.classList.add('active');
        }
    })

})