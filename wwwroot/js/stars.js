// stars.js

window.createStars = function (numStars) {
    for (let i = 0; i < numStars; i++) {
        createStar();
    }

    function createStar() {
        const star = document.createElement('div');
        star.className = 'star';
        star.style.width = `${Math.random() * 3}px`;
        star.style.height = star.style.width;
        star.style.top = `${Math.random() * 100}%`;
        star.style.left = `${Math.random() * 100}%`;
        document.querySelector('.space').appendChild(star);
    }
};
