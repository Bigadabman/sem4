#pragma once
#include <vector>

// Рекурсивная функция для вычисления оптимальной стоимости умножения матриц
int MatrixChainOrderRecursive(const std::vector<int>& p, int i, int j);

// Функция для вычисления оптимальной стоимости умножения матриц с использованием динамического программирования
int MatrixChainOrderDP(const std::vector<int>& p, std::vector<std::vector<int>>& s);

// Функция для печати оптимального порядка умножения матриц
void PrintOptimalParens(const std::vector<std::vector<int>>& s, int i, int j);
