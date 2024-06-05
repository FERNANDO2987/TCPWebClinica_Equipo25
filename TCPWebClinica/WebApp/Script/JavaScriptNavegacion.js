// Contenido del archivo JavaScriptNavegacion.js
var imageContainer = document.getElementById('imageContainer');
var images = document.querySelectorAll('#imageContainer img');
var currentIndex = 0;

// Mostrar solo la primera imagen al cargar la página
images.forEach(function (img, index) {
    if (index !== 0) {
        img.style.display = 'none';
    }
});

// Función para mostrar la imagen anterior
function showPrevImage() {
    images[currentIndex].style.display = 'none';
    currentIndex = (currentIndex - 1 + images.length) % images.length;
    images[currentIndex].style.display = 'block';
}

// Función para mostrar la siguiente imagen
function showNextImage() {
    images[currentIndex].style.display = 'none';
    currentIndex = (currentIndex + 1) % images.length;
    images[currentIndex].style.display = 'block';
}
