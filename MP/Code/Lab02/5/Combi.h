#pragma once

namespace combi
{
    class xcombination
    {
    public:
        short n, m;
        short* sset;
        xcombination(short n, short m);
        void reset();
        short getfirst();
        short getnext();
    private:
        unsigned __int64 mask;
    };

    class permutation
    {
    public:
        short n;
        short* sset;
        permutation(short n);
        void reset();
        short getfirst();
        short getnext();
        short ntx(short i);
    private:
        unsigned __int64 mask;
    };

    class subset
    {
    public:
        short n;
        short sn;
        short* sset;
        __int64 mask;
        subset(short n);
        void reset();
        short getfirst();
        short getnext();
        short ntx(short i);
        unsigned __int64 count() const;
    };

    struct accomodation  // генератор размещений 
    {
        short n;      // количество элементов исходного множества  
        short m;      // количество элементов в размещении 
        short* sset;  // массив индексов текущего размещения  
        xcombination* cgen;  // указатель на генератор сочетаний
        permutation* pgen;   // указатель на генератор перестановок
        accomodation(short n = 1, short m = 1);  // конструктор  
        void reset();  // сбросить генератор, начать сначала 
        short getfirst();  // сформировать первый массив индексов   
        short getnext();   // сформировать следующий массив индексов  
        short ntx(short i);  // получить i-й элемент массива индексов  
        unsigned __int64 na;  // номер размещения 0, ..., count()-1 
        unsigned __int64 count() const;  // общее количество размещений 
    };

    unsigned __int64 fact(unsigned __int64 x);
}
