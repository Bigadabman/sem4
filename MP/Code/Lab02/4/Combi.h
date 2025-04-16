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
    };

    class permutation
    {
    public:
        short m;
        short* sset;
        short* used;

        permutation(short m);
        ~permutation();
        void reset();
        short getfirst();
        short getnext();
        short ntx(short i);
    };

    struct accomodation  // ��������� ���������� 
    {
        short n,      // ���������� ��������� ��������� ���������  
            m,      // ���������� ��������� � ���������� 
            * sset;  // ������ �������� �������� ����������  
        xcombination* cgen;  // ��������� �� ��������� ���������
        permutation* pgen;   // ��������� �� ��������� ������������
        accomodation(short n = 1, short m = 1);  // �����������  
        void reset();  // �������� ���������, ������ ������� 
        short getfirst();  // ������������ ������ ������ ��������   
        short getnext();   // ������������ ��������� ������ ��������  
        short ntx(short i);  // �������� i-� ������� ������� ��������  
        unsigned __int64 na;  // ����� ���������� 0, ..., count()-1 
        unsigned __int64 count() const;  // ����� ���������� ���������� 
    };

    unsigned __int64 fact(unsigned __int64 x);
}
