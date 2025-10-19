let sliders = {};

function initializeSlider(sliderId) {
    sliders[sliderId] = { currentSlide: 0 };

    document.addEventListener('DOMContentLoaded', () => {
        showSlide(sliderId, sliders[sliderId].currentSlide);
    });
}

function showSlide(sliderId, index) {
    const slider = document.getElementById(sliderId);
    const slides = slider.querySelectorAll('.slide');
    const totalSlides = slides.length;
    const slidesToShow = 3;
    const maxIndex = Math.ceil(totalSlides / slidesToShow) - 1;

    if (index > maxIndex) {
        sliders[sliderId].currentSlide = 0;
    } else if (index < 0) {
        sliders[sliderId].currentSlide = maxIndex;
    } else {
        sliders[sliderId].currentSlide = index;
    }

    const newTransformValue = -sliders[sliderId].currentSlide * 100 / slidesToShow;
    slider.querySelector('.slides').style.transform = `translateX(${newTransformValue}%)`;
}

function changeSlide(sliderId, step) {
    showSlide(sliderId, sliders[sliderId].currentSlide + step);
}

// Initialize both sliders
initializeSlider('slider1');
initializeSlider('slider2');