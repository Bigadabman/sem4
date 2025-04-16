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

    struct accomodation  // ��������� ���������� 
    {
        short n;      // ���������� ��������� ��������� ���������  
        short m;      // ���������� ��������� � ���������� 
        short* sset;  // ������ �������� �������� ����������  
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
