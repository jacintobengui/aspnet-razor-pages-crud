
const menuButton = document.querySelector('.menu-button');

menuButton.addEventListener('click', () => {
    const mobileMenu = document.querySelector('.mobile-menu');
    if (mobileMenu.classList.contains('open')) {
        mobileMenu.classList.remove('open');
        menuButton.src = 'img/menu_white_100px.png';
        document.querySelector('header').style = 'padding-bottom: 0;';
    } else {
        mobileMenu.classList.add('open');
        menuButton.src = 'img/delete_100px.png';
        document.querySelector('header').style = 'padding-bottom: 3rem;';
    }
})
