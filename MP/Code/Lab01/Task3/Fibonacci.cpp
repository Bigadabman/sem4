#include "pch.h"
#include "Fibonacci.h"
#include <iostream>
using namespace std;

long double Fibonacci(int num)
{
    if (num <= 1) {
        return num;
    }

    return Fibonacci(num - 1) + Fibonacci(num - 2);
}