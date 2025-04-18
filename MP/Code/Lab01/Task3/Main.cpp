#include <stdio.h>
#include "pch.h"
#include "Auxil.h"                            
#include <iostream>
#include <ctime>
#include <locale>
#include "Fibonacci.h"

#define  CYCLE 500000     

using namespace std;

int main()
{
	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0;

	setlocale(LC_ALL, "rus");

	auxil::start();
	t1 = clock();
	for (int i = 0; i < CYCLE; i++)
	{
		av1 += (double)auxil::iget(-100, 100);
		av2 += auxil::dget(-100, 100);
	}
	t2 = clock();


	std::cout << std::endl << "���������� ������:         " << CYCLE;
	std::cout << std::endl << "������� �������� (int):    " << av1 / CYCLE;
	std::cout << std::endl << "������� �������� (double): " << av2 / CYCLE;
	std::cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
	std::cout << std::endl << "                  (���):   " << ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;
	cout << endl;

	int t3 = clock();
	long double fibonacciNumber = Fibonacci(25);
	cout << "����� ������������������: " << fibonacciNumber << endl;
	int t4 = clock();
	cout << "����������� �����: " << ((double)(t4 - t3)) / ((double)CLOCKS_PER_SEC) << "s" << endl;

}