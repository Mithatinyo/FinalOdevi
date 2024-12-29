namespace FinalOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string formaterror = "Lütfen sadece sayıyı uygun formatta giriniz";
            string Overflowerror = "Girilen sayı değeri tanımlanamadı";
            string notDegerierror = "Notu 0-100 aralığında girmelisiniz" ;

            double vizesonuc = 0;
            double finalsonuc = 0;
            double notOrtalamasi = 0;

            double sinifNotOrtalamasi = 0;
            double enKucuk = 0;
            double enBuyuk = 0;

            string[] tabloBasligi = new string[]
            {
                    "Numara",
                    "Ad",
                    "Soyad",
                    "Vize Notu",
                    "Final Notu",
                    "Ortalama",
                    "Harf Notu"
            };

            try
            {
                Console.Write("Kaç öğrenci kaydetmek istiyorsunuz: ");
                int ogrenciSayisi = Convert.ToInt32(Console.ReadLine());


                double[] ortalamaToplam = new double[ogrenciSayisi];



                string[,] dizi = new string[ogrenciSayisi + 1, tabloBasligi.Length];

                for (int i = 0; i < tabloBasligi.Length; i++)
                {
                    dizi[0, i] = tabloBasligi[i];
                }


                for (int i = 0; i < ogrenciSayisi; i++)
                {
                    Console.Write($"{i + 1}. Öğrencinin Numarasını Giriniz: ");
                    dizi[i + 1, 0] = long.Parse(Console.ReadLine()).ToString();
                    Console.Write($"{i + 1}. Öğrencinin Adını Giriniz: ");
                    dizi[i + 1, 1] = Console.ReadLine().Trim();

                    Console.Write($"{i + 1}. Öğrencinin Soyadını Giriniz: ");
                    dizi[i + 1, 2] = Console.ReadLine().Trim();

                    while (true)
                    {
                        try
                        {
                            Console.Write($"{i + 1}. Öğrencinin Vize Notunu Giriniz: ");
                            dizi[i + 1, 3] = Console.ReadLine();
                            vizesonuc = Convert.ToDouble(dizi[i + 1, 3]);

                            if (vizesonuc > 100 || vizesonuc < 0)
                            {
                                Console.WriteLine(notDegerierror);
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(formatHatasi);
                        }
                        catch (Exception hata)
                        {
                            Console.WriteLine($"Beklenmeyen bir hata oluştu: {hata.Message}");
                        }
                    }

                    while (true)
                    {
                        try
                        {
                            Console.Write($"{i + 1}. Öğrencinin Final Notunu Giriniz: ");
                            dizi[i + 1, 4] = Console.ReadLine();
                            finalNotu = Convert.ToDouble(dizi[i + 1, 4]);

                            if (finalsonuc > 100 || finalsonuc < 0)
                            {
                                Console.WriteLine(notDegerierror);
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(formaterror);
                        }
                        catch (Exception hata)
                        {
                            Console.WriteLine($"Beklenmeyen bir hata oluştu: {hata.Message}");
                        }
                    }

                    notOrtalamasi = vizesonuc * 0.40 + finalsonuc * 0.60;
                    dizi[i + 1, 5] = notOrtalamasi.ToString();
                    ortalamaToplam[i] = notOrtalamasi;

                    if (notOrtalama >= 85) { dizi[i + 1, 6] = "AA"; }
                    else if (notOrtalamasi >= 75) { dizi[i + 1, 6] = "BA"; }
                    else if (notOrtalamasi >= 60) { dizi[i + 1, 6] = "BB"; }
                    else if (notOrtalamasi >= 50) { dizi[i + 1, 6] = "CB"; }
                    else if (notOrtalamasi >= 40) { dizi[i + 1, 6] = "CC"; }
                    else if (notOrtalamasi >= 30) { dizi[i + 1, 6] = "DC"; }
                    else if (notOrtalamasi >= 20) { dizi[i + 1, 6] = "DD"; }
                    else if (notOrtalamasi >= 10) { dizi[i + 1, 6] = "FD"; }
                    else { dizi[i + 1, 6] = "FF"; }

                    Console.WriteLine(" ");
                }

                enKucuk = ortalamaToplam.Min();
                enBuyuk = ortalamaToplam.Max();
                sinifNotOrtalamasi = ortalamaToplam.Average();

                for (int i = 0; i < ogrenciSayisi + 1; i++)
                {
                    for (int j = 0; j < tabloBasligi.Length; j++)
                    {
                        Console.Write(dizi[i, j] + " ");
                    }
                    Console.WriteLine(" ");
                }

                Console.WriteLine($"\nSınıf Ortalaması: {sinifNotOrtalamasi}\nEn Düşük Not: {enKucuk}\nEn Yüksek Not: {enBuyuk}");
            }
            catch (FormatException)
            {
                Console.WriteLine(formaterror);
            }
            catch (OverflowException)
            {
                Console.WriteLine(Overflowerror);
            }
            catch (Exception hata)
            {
                Console.WriteLine($"Beklenmeyen bir hata oluştu: {hata.Message}");
            }
        }
    }
}
