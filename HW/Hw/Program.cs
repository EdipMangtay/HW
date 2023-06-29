using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, int> meyve = new SortedList<string, int>
            {
                {"ELMA",10 },
                {"ARMUT",15 },
                {"PORTAKAL",20 }
            };
            SortedList<string, int> sebze = new SortedList<string, int>
            {
                {"DOMATES",5 },
                {"SOGAN",7 },
                {"PATATES",10 }
            };
            SortedList<string, int> kullaniciListesi = new SortedList<string, int> { };
            SortedList<string, int> musteriListesi = new SortedList<string, int> { };
            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("Hal'e Hoşgeldiniz");
                Console.WriteLine();

                Console.WriteLine("Meyve için M , sebze için S Tuşuna basınız , lisenizi görmek için 1 e basın");
                string secim1 = Console.ReadLine();
                if (secim1.ToUpper() == "M")
                {
                    foreach (KeyValuePair<string, int> item in meyve)
                    {
                        Console.WriteLine(item.Key + ":" + item.Value);

                    }
                    Console.WriteLine("Almak istediğiniz ürünü seçiniz ");
                    string urun1 = Console.ReadLine().ToUpper();
                    Console.WriteLine("Miktar giriniz");
                    int miktar1 = int.Parse(Console.ReadLine());

                    if (meyve.ContainsKey(urun1))
                    {
                        int mevcutMiktar = meyve[urun1]; // meyve listesindeki seçilen ürünün miktarınını mevcut miktara eşitledi
                        if (mevcutMiktar >= miktar1) // seçilen ürünün miktarının alınması istenilen ürün miktarına göre karşılaştırmasını yaptım
                        {
                            if (kullaniciListesi.ContainsKey(urun1))
                                kullaniciListesi[urun1] += miktar1;
                            else
                                kullaniciListesi.Add(urun1, miktar1);

                            meyve[urun1] = mevcutMiktar - miktar1;
                        }
                        else
                        {
                            Console.WriteLine("Stok yetersiz, Bir daha deneyiz");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz ürün seçimi");
                    }
                }

                else if (secim1.ToUpper() == "S")
                {
                    foreach (KeyValuePair<string, int> item in sebze)
                    {
                        Console.WriteLine(item.Key + ":" + item.Value);


                    }
                    Console.WriteLine("Almak istediğiniz ürünü seçiniz");
                    string urun2 = Console.ReadLine().ToUpper();
                    Console.WriteLine("Miktar bilgisi giriniz:");
                    int miktar2 = int.Parse(Console.ReadLine());

                    if (sebze.ContainsKey(urun2))
                    {
                        int mevcut = sebze[urun2];
                        if (miktar2 <= mevcut)
                        {
                            if (kullaniciListesi.ContainsKey(urun2))
                            {
                                kullaniciListesi[urun2] += miktar2;
                            }
                            else
                                kullaniciListesi.Add(urun2, miktar2);
                            sebze[urun2] = mevcut - miktar2;
                        }
                        else
                        {
                            Console.WriteLine("Stok Yetersiz Bir daha deneyiniz");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz stok");
                        Console.WriteLine("Bir daha deneyiniz.");
                        Console.WriteLine();

                    }
                }
                else if (secim1 == "1")
                {
                    Console.WriteLine("Sepetiniz : ");
                    foreach (KeyValuePair<string, int> item in kullaniciListesi)
                    {
                        Console.WriteLine(item.Key + ":" + item.Value);
                    }
                    Console.WriteLine("Alışverişe Devam Etmek İstiyor Musunuz E/H");
                    string s = Console.ReadLine();
                    if (s.ToUpper() == "E")
                    {
                        Console.WriteLine("Tekrardan Menüye yönlendiriliyorsunuz");
                        Thread.Sleep(2000);

                    }
                    else if (s.ToUpper() == "H")
                    {
                        Console.WriteLine("Sistemden Çıkılıyor");
                        Thread.Sleep(2000);
                        run = false;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Manav Reyonuna Hoşgeldiniz...");

            Console.WriteLine();

            Console.WriteLine("Ürünlerimiz");

            bool run1 = true;

            while (run1)
            {
                foreach (KeyValuePair<string, int> item in kullaniciListesi)
                {
                    Console.WriteLine(item.Key + ":" + item.Value);
                }
                Console.WriteLine();

                Console.WriteLine("Almak istediğiniz ürünleri giriniz");
                string urunler = Console.ReadLine().ToUpper();
                Console.WriteLine("Miktarını giriniz");
                int miktarı = int.Parse(Console.ReadLine());

                Console.Clear();

                if (kullaniciListesi.ContainsKey(urunler))
                {
                    int mevcut = kullaniciListesi[urunler];
                    if (miktarı <= mevcut)
                    {
                        if (musteriListesi.ContainsKey(urunler))
                        {
                            musteriListesi[urunler] += miktarı;

                        }
                        else
                            musteriListesi.Add(urunler, miktarı);
                        kullaniciListesi[urunler] = mevcut - miktarı;
                    }
                    else if (miktarı >= mevcut)
                    {
                        Console.WriteLine("Bu miktarda ürün bulunmuyor");

                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz Ürün");
                }
                Console.WriteLine("Başka bir Arzunuz var mı? E/H");
                string cevap = Console.ReadLine().ToUpper();

                if (cevap == "E") { }

                else if (cevap == "H")
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("Almış olduğunuz Ürünler...");

            foreach (KeyValuePair<string, int> item in musteriListesi)
            {
                Console.WriteLine(item.Key + ":" + item.Value);
            }
            Console.WriteLine("Teşekkür Ederiz!");
            Console.ReadLine();
        }
    }
}
    

