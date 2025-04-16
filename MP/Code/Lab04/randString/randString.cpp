#include <iostream>
#include <string>
#include <cstdlib>
#include <ctime>
#include <vector>
#include <chrono>

using namespace std;
// Функция для генерации случайной строки заданной длины
string generateRandomString(int length) {
	static const char alphanum[] =
		"ABCDEFGHIJKLMNOPQRSTUVWXYZ"
		"abcdefghijklmnopqrstuvwxyz";

	string randomString;
	randomString.reserve(length);

	for (int i = 0; i < length; ++i) {
		randomString += alphanum[rand() % (sizeof(alphanum) - 1)];
	}

	return randomString;
}


int main() {
	setlocale(LC_CTYPE, "Russian");
	// Инициализация генератора случайных чисел
	srand(time(0));

	// Генерация строк
	string S1 = generateRandomString(300);
	string S2 = generateRandomString(200);

	// Вывод строк
	cout << "Случайная строка S1 (длина 300): " << S1 << endl;
	cout << "Случайная строка S2 (длина 200): " << S2 << endl;

	return 0;
}