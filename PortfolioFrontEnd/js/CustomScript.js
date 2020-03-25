//button to take you to the top of page becomes active after scrolling down a certain distance
var topBtn = document.getElementById('top-btn');

window.onscroll = function () {
    displayButton();
}

function displayButton() {
    if (document.body.scrollTop > 300 || document.documentElement.scrollTop > 300) {
        topBtn.style.display = "block";
    }
    else {
        topBtn.style.display = "none";
    }
}


function topFunction() {
    $('html, body').animate(
        {
            scrollTop: 0,
        },
        800, 'linear');
}

//navbar collapse after menu item selection
$('.navbar-nav>li>a').on('click', function () {
    $('.navbar-collapse').collapse('hide');
});

//smooth scroll jquery
$(document).ready(function () {
    $('a[href^="#"]').click(function (event) {
        event.preventDefault();
        $('html, body').animate(
            {
                scrollTop: $($(this).attr('href')).offset().top,
            },
            500, 'linear');
    });
});