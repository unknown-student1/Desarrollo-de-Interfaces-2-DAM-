// Arrays para almacenar palabras y sus frecuencias
let palabrasArray = [];
let frecuenciasArray = [];

function comenzar() {
    // Obtener el párrafo
    const parrafo = document.getElementById('parrafo');

    // Obtener palabras del párrafo
    palabrasArray = parrafo.innerText.split(/\s+/);

    // Llenar el dropdown con las palabras
    const dropdown = document.getElementById('palabrasDropdown');
    dropdown.innerHTML = ""; // Limpiar el dropdown

    palabrasArray.forEach((palabra) => {
        const option = document.createElement('option');
        option.text = palabra;
        dropdown.add(option);
    });
}

function contarPalabra() {
    const dropdown = document.getElementById('palabrasDropdown');
    const areaTexto = document.getElementById('areaTexto');

    // Obtener la palabra seleccionada
    const palabraSeleccionada = dropdown.options[dropdown.selectedIndex].text;

    // Actualizar el área de texto con la palabra y su frecuencia
    areaTexto.value += `${palabraSeleccionada}: 1\n`;

    // Verificar si la palabra ya está en el array de frecuencias
    const index = palabrasArray.indexOf(palabraSeleccionada);
    if (index !== -1) {
        // Incrementar la frecuencia si ya existe
        frecuenciasArray[index]++;
    } else {
        // Agregar la palabra y establecer la frecuencia en 1
        palabrasArray.push(palabraSeleccionada);
        frecuenciasArray.push(1);
    }
}

function mostrarPalabraMasSeleccionada() {
    const palabraMasSeleccionada = document.getElementById('palabraMasSeleccionada');
    const maxFrecuencia = Math.max(...frecuenciasArray);
    const indexPalabraMasSeleccionada = frecuenciasArray.indexOf(maxFrecuencia);
    const palabra = palabrasArray[indexPalabraMasSeleccionada];

    palabraMasSeleccionada.innerHTML = `Palabra más seleccionada: ${palabra} (${maxFrecuencia} veces)`;

    // Establecer el color del texto según la frecuencia
    if (maxFrecuencia > 3) {
        palabraMasSeleccionada.style.color = 'red';
    } else {
        palabraMasSeleccionada.style.color = 'blue';
    }
}


function crearCards() {
    const cardsContainer = document.getElementById('cardsContainer');
    cardsContainer.innerHTML = ""; // Limpiar el contenedor de cards

    palabrasArray.forEach((palabra, index) => {
        const card = document.createElement('div');
        card.className = 'card mt-2';
        card.innerHTML = `
      <div class="card-body">
        <h5 class="card-title">${palabra}</h5>
        <p class="card-text">Frecuencia: ${frecuenciasArray[index]}</p>
      </div>
    `;
        cardsContainer.appendChild(card);
    });
}
