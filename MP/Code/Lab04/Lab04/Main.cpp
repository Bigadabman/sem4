#include "stdafx.h"
#include "Levenshtein.h"
#include <iostream>
#include <iomanip>
#include <algorithm>
#include <chrono>
#include <vector>

// Функция для вычисления префикса строки
std::string prefix(const std::string& str, double k) {
    int len = static_cast<int>(k * str.length());
    return str.substr(0, len);
}

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");
    std::string x = "abcdefghklmnoxm";
    std::string y = "xyabcdefghomnkm";
    std::vector<double> k_values = { 1.0 / 25, 1.0 / 20, 1.0 / 15, 1.0 / 10, 1.0 / 5, 1.0 / 2, 1 };

    std::cout << std::endl;
    std::cout << "-- расстояние Левенштейна -----" << std::endl;
    std::cout << "--значение k--- рекурсия -- дин.програм. ---" << std::endl;

    for (double k : k_values) {
        std::string px = prefix(x, k);
        std::string py = prefix(y, k);
        int lx = px.length();
        int ly = py.length();

        auto start_r = std::chrono::high_resolution_clock::now();
        levenshtein_r(lx, px.c_str(), ly, py.c_str());
        auto end_r = std::chrono::high_resolution_clock::now();
        std::chrono::duration<double, std::milli> time_r = end_r - start_r;

        auto start_dp = std::chrono::high_resolution_clock::now();
        levenshtein(lx, px.c_str(), ly, py.c_str());
        auto end_dp = std::chrono::high_resolution_clock::now();
        std::chrono::duration<double, std::milli> time_dp = end_dp - start_dp;

        std::cout << std::right << std::setw(8) << k
            << "        " << std::left << std::setw(10) << time_r.count()
            << "   " << std::setw(10) << time_dp.count() << std::endl;
    }
    system("pause");
    return 0;
}
