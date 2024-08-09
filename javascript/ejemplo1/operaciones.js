function sumar() {
    var numero1 = parseInt(document.getElementById("numero1").value);
    var numero2 = parseInt(document.getElementById("numero2").value);
    var resultado = numero1 + numero2;
    document.getElementById("resultado").innerText = resultado;
}

function restar() {
    var numero1 = parseInt(document.getElementById("numero1").value);
    var numero2 = parseInt(document.getElementById("numero2").value);
    var resultado = numero1 - numero2;
    document.getElementById("resultado").innerText = resultado;
}

function multiplicar() {
    var numero1 = parseInt(document.getElementById("numero1").value);
    var numero2 = parseInt(document.getElementById("numero2").value);
    var resultado = numero1 * numero2;
    document.getElementById("resultado").innerText = resultado;
}

function dividir() {
    var numero1 = parseInt(document.getElementById("numero1").value);
    var numero2 = parseInt(document.getElementById("numero2").value);
    var resultado = numero1 / numero2;
    document.getElementById("resultado").innerText = resultado;
}

function mostrarTabla() {
    var numero = document.getElementById("tablaselect").value;
    var tabla = document.getElementById("tabla");
    
    // Limpiar la tabla antes de mostrar la nueva tabla
    tabla.innerHTML = "";
    
    // Crear la tabla de multiplicar
    for (var i = 1; i <= 10; i++) {
      var resultado = numero * i;
      var fila = "<tr><td>" + numero + " x " + i + "</td><td>=</td><td>" + resultado + "</td></tr>";
      tabla.innerHTML += fila;
    }
  }