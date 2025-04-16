// Функция для сложения
function Sum(a, b) {
    return a + b;
}

// Функция для вычитания
function Sub(a, b) {
    return a - b;
}

// Функция для умножения
function Mul(a, b) {
    return a * b;
}

// Функция для деления с проверкой на деление на 0
function Div(a, b) {
    if (b === 0) {
        return "Ошибка: деление на ноль!";
    }
    return a / b;
}
