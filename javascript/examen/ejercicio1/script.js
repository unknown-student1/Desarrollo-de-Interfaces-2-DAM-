var numeros = [];

document.addEventListener('DOMContentLoaded', function () {
    generarNumerosAleatorios();
});

function generarNumerosAleatorios() {
    for (var i = 0; i < 5; i++) {
        numeros.push(Math.floor(Math.random() * 11));
    }

    actualizarValores();
}

function actualizarValores() {
    document.getElementById('num1').value = numeros[0];
    document.getElementById('num2').value = numeros[1];
    document.getElementById('num3').value = numeros[2];
    document.getElementById('num4').value = numeros[3];
    document.getElementById('num5').value = numeros[4];
}

function intercambiar1() {
    var numero1 = document.getElementById('num1').value

    var numero2 = document.getElementById('num2').value;

    document.getElementById("num2").value = numero1;
    document.getElementById("num1").value = numero2;
}

function intercambiar2() {
    var numero2 = document.getElementById('num2').value

    var numero3 = document.getElementById('num3').value;

    document.getElementById("num3").value = numero2;
    document.getElementById("num2").value = numero3;
}

function intercambiar3() {
    var numero3 = document.getElementById('num3').value

    var numero4 = document.getElementById('num4').value;

    document.getElementById("num4").value = numero3;
    document.getElementById("num3").value = numero4;
}

function intercambiar4() {
    var numero4 = document.getElementById('num4').value

    var numero5 = document.getElementById('num5').value;

    document.getElementById("num5").value = numero4;
    document.getElementById("num4").value = numero5;
}


function comprobarOrden() {
    // Obtener los valores de las cajas de texto
    var num1 = parseInt(document.getElementById('num1').value);
    var num2 = parseInt(document.getElementById('num2').value);
    var num3 = parseInt(document.getElementById('num3').value);
    var num4 = parseInt(document.getElementById('num4').value);
    var num5 = parseInt(document.getElementById('num5').value);

    // Comprobar el orden
    if (num1 <= num2 && num2 <= num3 && num3 <= num4 && num4 <= num5) {
        mostrarAlerta('success', 'Los números están en orden de menor a mayor.');
        habilitarBotonInvertir(true); // Habilitar el botón de invertir
    } else {
        mostrarAlerta('danger', 'Los números no están en orden de menor a mayor.');
        habilitarBotonInvertir(false); // Deshabilitar el botón de invertir
    }
}

function habilitarBotonInvertir(habilitar) {
    // Obtener el botón de invertir
    var invertirBtnElement = document.getElementById('invertirBtn');

    // Habilitar o deshabilitar el botón según el parámetro
    if (habilitar) {
        invertirBtnElement.removeAttribute('disabled');
    } else {
        invertirBtnElement.setAttribute('disabled', 'true');
    }
}

function mostrarAlerta(tipo, mensaje) {
    // Crear un elemento de alerta con las clases de Bootstrap
    var alertElement = document.createElement('div');
    alertElement.className = 'alert alert-' + tipo;
    alertElement.setAttribute('role', 'alert');
    alertElement.textContent = mensaje;

    // Agregar el elemento de alerta al documento
    var container = document.querySelector('.container');
    container.appendChild(alertElement);

    // Desaparecer la alerta después de 3 segundos
    setTimeout(function() {
        alertElement.remove();
    }, 3000);
}

function invertirNumeros() {
    // Obtener los valores de las cajas de texto
    var num1Value = document.getElementById('num1').value;
    var num2Value = document.getElementById('num2').value;
    var num3Value = document.getElementById('num3').value;
    var num4Value = document.getElementById('num4').value;
    var num5Value = document.getElementById('num5').value;

    // Invertir los valores
    document.getElementById('num1').value = num5Value;
    document.getElementById('num2').value = num4Value;
    document.getElementById('num3').value = num3Value;
    document.getElementById('num4').value = num2Value;
    document.getElementById('num5').value = num1Value;

    // Mostrar mensaje de números invertidos
    mostrarAlerta('info', 'Números Invertidos');
}
