#pragma once 
#include "stdafx.h"
namespace combi
{
    struct xcombination           // ���������  ��������� (���������) 
    {
        short  n,                  // ���������� ��������� ��������� ���������  
            m,                  // ���������� ��������� � ���������� 
            nc,
            * sset;            	  // ������ �������� �������� ���������  
        xcombination(
            short n = 1, //���������� ��������� ��������� ���������  
            short m = 1  // ���������� ��������� � ����������
        );
        void reset();              // �������� ���������, ������ ������� 
        short getfirst();          // ������������ ������ ������ ��������    
        short getnext();           // ������������ ��������� ������ ��������  
        short ntx(short i);
        unsigned __int64 count();
    };

};