#include "Matrix.h"
#include <iostream>
#include <climits>
#include <vector>

// Рекурсивная функция для вычисления оптимальной стоимости умножения матриц
int MatrixChainOrderRecursive(const std::vector<int>& p, int i, int j) {
    if (i == j) {
        return 0;
    }

    int min = INT_MAX;

    for (int k = i; k < j; k++) {
        int count = MatrixChainOrderRecursive(p, i, k) +
            MatrixChainOrderRecursive(p, k + 1, j) +
            p[i - 1] * p[k] * p[j];

        if (count < min) {
            min = count;
        }
    }

    return min;
}

// Функция для вычисления оптимальной стоимости умножения матриц с использованием динамического программирования
int MatrixChainOrderDP(const std::vector<int>& p, std::vector<std::vector<int>>& s) {
    int n = p.size();
    std::vector<std::vector<int>> m(n, std::vector<int>(n, 0));

    for (int l = 2; l < n; l++) {
        for (int i = 1; i < n - l + 1; i++) {
            int j = i + l - 1;
            m[i][j] = INT_MAX;
            for (int k = i; k <= j - 1; k++) {
                int q = m[i][k] + m[k + 1][j] + p[i - 1] * p[k] * p[j];
                if (q < m[i][j]) {
                    m[i][j] = q;
                    s[i][j] = k;
                }
            }
        }
    }

    return m[1][n - 1];
}

// Функция для печати оптимального порядка умножения матриц
void PrintOptimalParens(const std::vector<std::vector<int>>& s, int i, int j) {
    if (i == j) {
        std::cout << "A" << i;
    }
    else {
        std::cout << "(";
        PrintOptimalParens(s, i, s[i][j]);
        PrintOptimalParens(s, s[i][j] + 1, j);
        std::cout << ")";
    }
}
