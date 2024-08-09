// script.js
document.addEventListener('DOMContentLoaded', function () {
    const board = document.getElementById('board');
    const message = document.getElementById('message');
    const resetButton = document.getElementById('resetButton');

    let currentPlayer = 'X';
    let gameBoard = ['', '', '', '', '', '', '', '', ''];
    let gameActive = true;

    // Create the board
    for (let i = 0; i < 9; i++) {
        const cell = document.createElement('div');
        cell.classList.add('cell');
        cell.dataset.index = i;
        cell.addEventListener('click', handleCellClick);
        board.appendChild(cell);
    }

    // Handle cell click
    function handleCellClick(event) {
        const index = event.target.dataset.index;
        
        if (gameBoard[index] === '' && gameActive) {
            gameBoard[index] = currentPlayer;
            event.target.textContent = currentPlayer;
            
            if (checkWinner()) {
                message.textContent = `¡Jugador ${currentPlayer} gana!`;
                gameActive = false;
            } else if (checkTie()) {
                message.textContent = '¡Empate!';
                gameActive = false;
            } else {
                currentPlayer = currentPlayer === 'X' ? 'O' : 'X';
                message.textContent = `Turno del jugador ${currentPlayer}`;
            }
        }
    }

    // Check for a winner
    function checkWinner() {
        const winningCombinations = [
            [0, 1, 2], [3, 4, 5], [6, 7, 8], // Rows
            [0, 3, 6], [1, 4, 7], [2, 5, 8], // Columns
            [0, 4, 8], [2, 4, 6]             // Diagonals
        ];

        for (const combination of winningCombinations) {
            const [a, b, c] = combination;
            if (gameBoard[a] && gameBoard[a] === gameBoard[b] && gameBoard[a] === gameBoard[c]) {
                return true;
            }
        }

        return false;
    }

    // Check for a tie
    function checkTie() {
        return !gameBoard.includes('');
    }

    // Reset the game
    function resetGame() {
        currentPlayer = 'X';
        gameBoard = ['', '', '', '', '', '', '', '', ''];
        gameActive = true;
        message.textContent = `Turno del jugador ${currentPlayer}`;

        const cells = document.querySelectorAll('.cell');
        cells.forEach(cell => {
            cell.textContent = '';
        });
    }

    // Event listener for reset button
    resetButton.addEventListener('click', resetGame);
});
