let rouge = document.getElementsByClassName('rouge')[0],
    bleue = document.getElementsByClassName('bleue')[0],
    verte = document.getElementsByClassName('verte')[0],
    violette = document.getElementsByClassName('violette')[0],
    orange = document.getElementsByClassName('orange')[0];

rouge.addEventListener('mouseenter', function() {
    rouge.style.opacity = 0;
});

rouge.addEventListener('mouseleave', function() {
    rouge.style.opacity = 1;
});

bleue.addEventListener('mouseenter', function() {
    bleue.style.height = '0px';
    bleue.style.width = '0px';
});

bleue.addEventListener('mouseleave', function() {
    bleue.style.height = '400px';
    bleue.style.width = '400px';
});

verte.addEventListener('mouseenter', function() {
    verte.style.marginLeft = '600px';
});

verte.addEventListener('mouseleave', function() {
    verte.style.marginLeft = '5px';
});

violette.addEventListener('mouseenter', function() {
    violette.style.transform = 'rotate(180deg)';
});

violette.addEventListener('mouseleave', function() {
    violette.style.transform = 'rotate(-180deg)';
});

orange.addEventListener('mouseenter', function() {
    orange.style.filter = 'grayscale(100%)';
});

orange.addEventListener('mouseleave', function() {
    orange.style.filter = 'grayscale(0%)';
});