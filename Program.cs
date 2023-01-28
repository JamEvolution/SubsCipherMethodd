using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsCipher
{
    class Program
    {
        static string SIFRELI_MESAJ = "OSEXPSPCAZPSPVKINZAICPHMVGIEKEPHSNSOMMIMBVAGMKINCKPPWNKPGPMEAMHBHIMFAOYHFMAEKHZPXIZPVYOCKOMVPSEKPNPHIKHZPMENHIVHXICPHMVUPSKHUNFAOGPSPMPZPSPZPMIMESAVOCPVEAHXARNEPSHXICPRPBHMEANHFIAMCPEHNEPVROECKPCWPVKPSNPXJKHNEIXFHMVNHIVMAMPZPSNAFAOCHMKHZPMAIVPHGKHEHVPXIBKEJOXEKIMBHXARNEPSTOHVSIXXPINMAIMVPPVNHIVHXICPGKHENASEAJHVHMCPINIEGKFNHIVEKPBSFUKAMFAOJISNEJASYIMEAHXIMPHXAMBEKPNPHNKASPEGAXIMPNCSIPVEKPYACWEOSEXPNPHXNEOSEXPNNHXYAMHMVNAAMEKPMGKPMFAOZPCXPHSPVHXXEKPDPXXFJINKAOEAJEKPGHFEKHEBPMPSHXXFEHWPNNAYPEIYPIMEPSSOUEPVEKPBSFUKAMFAOHVZHMCPEGICPPHCKGIEKHXARNEPSHNHUHSEMPSCSIPVEKPBSFUKAMAJCAOSNPEKPYACWEOSEXPNHIVHVZHMCPEGICPNPEEAUHSEMPSNCKHMBPXARNEPSNHMVSPEISP";

        static void Main(string[] args)
        {
            enCokGecenleriBul();
            yeriniBul();
            
        }
        static void enCokGecenleriBul()
        {
            Dictionary<string, int> sozObekleri = new Dictionary<string, int>();

            int gramSayisi = 1;

            string obek = SIFRELI_MESAJ.Substring(0, gramSayisi);

            sozObekleri.Add(obek, 0);

            for (int baslangıcIndex = 0; baslangıcIndex < SIFRELI_MESAJ.Length - gramSayisi; baslangıcIndex++)
            {
                obek = SIFRELI_MESAJ.Substring(baslangıcIndex, gramSayisi);

                if (sozObekleri.Keys.Any(x => x == obek))
                {
                    int tekrarSayisi = sozObekleri[obek] + 1;

                    sozObekleri[obek] = tekrarSayisi;
                }
                else
                {
                    sozObekleri.Add(obek, 1);
                }
            }

            var sozObekleriListesi = sozObekleri.OrderByDescending(x => x.Value).ToList();
            // If gramSayisi = 1
            // L->79, X->70, Y->56, B->53, S->46, U->45, T->42, G->38, C->27, V->26, R->25, I->19 ...
            // If gramSayisi = 2
            // LS->29, SX->21, YU->18, UA->14, LB->13, YL->12, XC->12 ...
            // 534 and 541 index -> TH****H maybe word is through
        }

        static void yeriniBul()
        {
            char[] anahtarHarfListesi = new char[] 
            { 
                't',
                'h',
                'e',
               // 'a',
               // 'n',
               // 'd',

            };
            char[] sifreliHarfListesi = new char[]
            {
                'L',
                'S',
                'X',
                // 'Y',
                //'U',
                // 'A',

            };
            string cozulmusMetin = string.Empty;

            for (int baslangıcIndex = 0; baslangıcIndex < SIFRELI_MESAJ.Length; baslangıcIndex++)
            {
                char sifreliHarf = SIFRELI_MESAJ[baslangıcIndex];

                if (Array.IndexOf(sifreliHarfListesi,sifreliHarf) != -1)
                {
                    int sifreliHarfListesindekiYeri = Array.IndexOf(sifreliHarfListesi, sifreliHarf);

                    char sifresizHarf = anahtarHarfListesi[sifreliHarfListesindekiYeri];

                    cozulmusMetin += sifresizHarf;
                }
                else
                {
                    cozulmusMetin += '*';
                    //cozulmusMetin += sifreliHarf;
                }
            }
            Console.WriteLine(cozulmusMetin);
            Console.ReadLine();
        } 


    }
}
