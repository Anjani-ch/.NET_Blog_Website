// Set Footer Year
window.addEventListener('DOMContentLoaded', () => {
    const yearEl = document.querySelector('#year');

    const date = new Date();
    const year = date.getFullYear();

    yearEl.innerText = year;
});