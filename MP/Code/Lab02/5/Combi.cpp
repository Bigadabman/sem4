#include "stdafx.h"
#include "Combi.h"
#include <algorithm>

namespace combi
{
    // Реализация класса xcombination
    xcombination::xcombination(short n, short m)
    {
        this->n = n;
        this->m = m;
        this->sset = new short[m];
        this->reset();
    }

    void xcombination::reset()
    {
        this->mask = 0;
    }

    short xcombination::getfirst()
    {
        __int64 buf = this->mask;
        short sn = 0;
        for (short i = 0; i < n; i++)
        {
            if (buf & 0x1) this->sset[sn++] = i;
            buf >>= 1;
        }
        return sn;
    }

    short xcombination::getnext()
    {
        int rc = -1;
        if (++this->mask < (1ULL << this->n)) rc = getfirst();
        return rc;
    }

    // Реализация класса permutation
    permutation::permutation(short n)
    {
        this->n = n;
        this->sset = new short[n];
        this->reset();
    }

    void permutation::reset()
    {
        for (short i = 0; i < n; i++)
            this->sset[i] = i;
    }

    short permutation::getfirst()
    {
        return this->n;
    }

    short permutation::getnext()
    {
        return std::next_permutation(this->sset, this->sset + this->n) ? this->n : -1;
    }

    short permutation::ntx(short i)
    {
        return this->sset[i];
    }

    // Реализация класса subset
    subset::subset(short n)
    {
        this->n = n;
        this->sset = new short[n];
        this->reset();
    }

    void subset::reset()
    {
        this->sn = 0;
        this->mask = 0;
    }

    short subset::getfirst()
    {
        __int64 buf = this->mask;
        this->sn = 0;
        for (short i = 0; i < n; i++)
        {
            if (buf & 0x1) this->sset[this->sn++] = i;
            buf >>= 1;
        }
        return this->sn;
    }

    short subset::getnext()
    {
        int rc = -1;
        if (++this->mask < this->count()) rc = getfirst();
        return rc;
    }

    short subset::ntx(short i)
    {
        return this->sset[i];
    }

    unsigned __int64 subset::count() const
    {
        return (unsigned __int64)(1 << this->n);
    }

    // Реализация класса accomodation
    accomodation::accomodation(short n, short m)
    {
        this->n = n;
        this->m = m;
        this->cgen = new xcombination(n, m);
        this->pgen = new permutation(m);
        this->sset = new short[m];
        this->reset();
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
            for (int i = 0; i < this->m; i++)  // исправлено условие цикла
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

    unsigned __int64 accomodation::count() const
    {
        return (this->n >= this->m) ? fact(this->n) / fact(this->n - this->m) : 0;
    }
}
