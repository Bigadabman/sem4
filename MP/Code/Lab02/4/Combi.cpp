#include "stdafx.h"

namespace combi
{
    //конструктор для комбинаций
    xcombination::xcombination(short n, short m)
    {
        this->n = n;
        this->m = m;
        this->sset = new short[m];
        reset();
    }

    void xcombination::reset()
    {
        for (short i = 0; i < m; ++i)
            sset[i] = i;
    }

    short xcombination::getfirst()
    {
        reset();
        return m;
    }

    short xcombination::getnext()
    {
        for (short i = m - 1; i >= 0; --i)
        {
            if (sset[i] < n - m + i)
            {
                ++sset[i];
                for (short j = i + 1; j < m; ++j)
                    sset[j] = sset[j - 1] + 1;
                return m;
            }
        }
        return -1;
    }
    //генерация перестановок
    permutation::permutation(short m)
    {
        this->m = m;
        this->sset = new short[m];
        this->used = new short[m];
        reset();
    }
   
    permutation::~permutation()
    {
        delete[] sset;
        delete[] used;
    }

    void permutation::reset()
    {
        for (short i = 0; i < m; ++i)
        {
            sset[i] = i;
            used[i] = 0;
        }
    }

    short permutation::getfirst()
    {
        reset();
        return m;
    }

    short permutation::getnext()
    {
        short i = m - 1;
        while (i >= 0 && sset[i] == m - 1)
        {
            sset[i] = 0;
            --i;
        }
        if (i >= 0)
        {
            ++sset[i];
            for (short j = i + 1; j < m; ++j)
                sset[j] = 0;
            return m;
        }
        return -1;
    }

    short permutation::ntx(short i)
    {
        return sset[i];
    }
    //генерация размещений из n по m
    accomodation::accomodation(short n, short m)
    {
        this->n = n;
        this->m = m;
        this->cgen = new xcombination(n, m);
        this->pgen = new permutation(m);
        this->sset = new short[m];
        reset();
    }

    void accomodation::reset()
    {
        this->na = 0;
        this->cgen->reset();
        this->pgen->reset();
        this->cgen->getfirst();
    }

    short accomodation::getfirst()
    {
        short rc = (this->n >= this->m) ? this->m : -1;
        if (rc > 0)
        {
            for (int i = 0; i < this->m; ++i)  // исправлено условие цикла
                this->sset[i] = this->cgen->sset[this->pgen->ntx(i)];
        }
        return rc;
    }

    short accomodation::getnext()
    {
        short rc;
        this->na++;
        if ((this->pgen->getnext()) > 0)
            rc = getfirst();  // исправлено
        else if ((rc = this->cgen->getnext()) > 0)
        {
            this->pgen->reset();
            rc = getfirst();
        }
        return rc;
    }

    short accomodation::ntx(short i)
    {
        return this->sset[i];
    }

    unsigned __int64 fact(unsigned __int64 x)
    {
        return (x == 0) ? 1 : (x * fact(x - 1));
    }
    //количество размещений
    unsigned __int64 accomodation::count() const
    {
        return (this->n >= this->m) ?
            fact(this->n) / fact(this->n - this->m) : 0;
    }
}
