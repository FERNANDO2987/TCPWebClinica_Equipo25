document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.add-to-cart').forEach(button => {
        button.addEventListener('click', function () {
            const id = this.getAttribute('data-id');
            const nombre = this.getAttribute('data-nombre');
            const precio = this.getAttribute('data-precio');
            const imagenURL = this.getAttribute('data-imagenURL');

            
            fetch('Carrito.aspx?id=' + id + '&nombre=' + nombre + '&precio=' + precio + '&imagenURL=' + imagenURL)
                .then(response => {
                    // Manejar la respuesta del servidor, por ejemplo, mostrar un mensaje al usuario
                    alert('¡El artículo se agregó al carrito!');
                })
                .catch(error => {
                    console.error('Error al agregar al carrito:', error);
                });
        });
    });
});