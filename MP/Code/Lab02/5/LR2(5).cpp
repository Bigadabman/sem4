#include "stdafx.h"
#include <iostream>
#include "Combi.h"
#include "Knapsack.h"
#include <time.h>
#include <iomanip> 
#include <tchar.h>

#define NN 18  // количество предметов

int _tmain(int argc, _TCHAR* argv[])
{
    setlocale(LC_ALL, "rus");
    int V = 300;              // вместимость рюкзака              
    int v[NN] = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 200, 250, 300 }; // веса предметов
    int c[NN] = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 10, 20, 30, 40, 50, 55, 5 };  // стоимости предметов

    short m[NN];
    int maxcc = 0;
    clock_t t1, t2;
    std::cout << std::endl << "-------- Задача о рюкзаке --------- ";
    std::cout << std::endl << "- вместимость рюкзака  : " << V;
    std::cout << std::endl << "-- количество ------ продолжительность -- ";
    std::cout << std::endl << "    предметов          вычисления  ";
    for (int i = 1; i <= NN; i++)  // изменено начальное значение i
    {
        t1 = clock();
        maxcc = knapsack_s(V, i, v, c, m);
        t2 = clock();
        std::cout << std::endl << "       " << std::setw(2) << i
            << "               " << std::setw(5) << (t2 - t1);
    }
    std::cout << std::endl << std::endl;
    system("pause");
    return 0;
}
