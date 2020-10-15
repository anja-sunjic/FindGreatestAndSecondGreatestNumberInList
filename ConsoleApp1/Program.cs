using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace GreatestAndSecondGreatestNumber
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<int> niz = new List<int> { 34, 55, 22, 78, 200, 67, 47, 54444, 3 };
            //kopiramo listu da ne alterujemo originalnu
            List<int> A = new List<int>(niz);
            (int, int) rezultat = LargestAndSecondLargest(A);
            Console.WriteLine($"Najveci: {niz[rezultat.Item1]}\nDrugi najveci: {niz[rezultat.Item2]}");

        }
        static (int, int) LargestAndSecondLargest(List<int> niz)
        {
            if (niz.Count == 2)
            {
                if (niz[0] > niz[1])
                    return (0, 1);
                else return (1, 0);
            }
            if (niz.Count >= 2 && niz.Count % 2 != 0)
                niz.Add(0);
            int n = niz.Count;
            //podijelimo niz u n/2 parova, za svaki par odredimo veci broj
            //zamijenimo ih tako da veci bude na prvom mjestu, spremimo je li doslo do zamjene u niz jeLiZamijenjeno
            List<int> najveciIzParova = new List<int>();
            int[] jeLiZamijenjeno = new int[n / 2];

            for (int i = 0; i < n / 2; i++)
            {
                //zamijenimo tako da je u svakom paru veci na prvom mjestu
                if (niz[2 * i] < niz[2 * i + 1])
                {
                    niz.Reverse(2 * i, 2);
                    //ako je doslo do zamjene setujemo true
                    jeLiZamijenjeno[i] = 1;
                }
                //spremimo veci u niz najvecih iz svih parova
                najveciIzParova.Add(niz[2 * i]);
            }
            //rekurzivno pozovemo funkciju koje ce vratiti indekse najvecih iz niza najvecih
            //funkcija ce se rekurzivno pozivati dok se niz ne svede na 2 elementa
            (int, int) indeksiNajvecih = LargestAndSecondLargest(najveciIzParova);

            int najveciZamijenjen = jeLiZamijenjeno[indeksiNajvecih.Item1];
            int drugiNajveciZamijenjen = jeLiZamijenjeno[indeksiNajvecih.Item2];

            int indeksNajveceg = 2 * indeksiNajvecih.Item1;
            int indeksDrugogNajveceg = 2 * indeksiNajvecih.Item2;
            if (niz[indeksNajveceg + 1] > niz[indeksDrugogNajveceg])
            {
                indeksDrugogNajveceg = indeksNajveceg + 1;
                drugiNajveciZamijenjen = 0 - najveciZamijenjen;
            }

            return (indeksNajveceg + najveciZamijenjen, indeksDrugogNajveceg + drugiNajveciZamijenjen);

        }

    }
}
