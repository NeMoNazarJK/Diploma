using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Part_of_the_Diploma.RSA
{
    internal class GeneratingKeys
    {
        private const string Path = "..\\..\\..\\Files\\additional_information_RSA.txt";
        private const string Privatekey = "..\\..\\..\\Key\\Privatekey.pem";
        private const string Publickey = "..\\..\\..\\Key\\Publickey.pem";

        public static async void OnGeneratingKeysClick(object sender, EventArgs a, string txtGeneratingkeysValue, string Loading, string LoadingPath, string KeyTime, Label labelKeyTime, double memoryInMegabytesKey, Label labelKeyMemory, string SuccessPath, float SuccessVolume, int SuccessNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (Process process = Process.GetCurrentProcess())
            {
                using (Form loadingForm = LoadingMessageBox.ShowLoadingMessageBox(Loading, LoadingPath))
                {
                    loadingForm.Show();

                    await Task.Run(() =>
                    {
                        int bitLength = Convert.ToInt32(txtGeneratingkeysValue);

                        BigInteger p = GeneratePrime(bitLength);
                        BigInteger q = GeneratePrime(bitLength);
                        BigInteger n = p * q;
                        BigInteger phi = (p - 1) * (q - 1);
                        BigInteger e = GetRandomCoprime(phi);
                        BigInteger d = ModInverse(e, phi);


                        string nX = n.ToString("X");
                        string eX = e.ToString("X");
                        string dX = d.ToString("X");

                        using (StreamWriter file = new StreamWriter(Path))
                        {
                            file.WriteLine("Довжина: {0} біт", bitLength);
                            file.WriteLine("Перше просте число: {0}", p);
                            file.WriteLine("Друге просте число: {0}", q);
                            file.WriteLine("Значення функції Ельвора(phi): {0}", phi);
                            file.WriteLine("Публічний ключ (e, n): ({0}, {1})", e, n);
                            file.WriteLine("Приватний ключ (d, n): ({0}, {1})", d, n);
                            file.WriteLine("Приватний ключ (e, d, n): ({0}, {1}, {2})", eX, dX, nX);
                        }

                        using (StreamWriter file = new StreamWriter(Privatekey))
                        {
                            file.WriteLine("{0}, {1}", dX, nX);
                        }

                        using (StreamWriter file = new StreamWriter(Publickey))
                        {
                            file.WriteLine("{0}, {1}", eX, nX);
                        }
                    });
                }
                memoryInMegabytesKey = process.PrivateMemorySize64 / (1024 * 1024);
            }
            stopwatch.Stop();
            TimeSpan GeneratingKey = stopwatch.Elapsed;
            KeyTime = GeneratingKey.ToString();

            labelKeyTime.Text = $"Час генерування ключа: {KeyTime}";
            labelKeyMemory.Text = $"Виділена пам'ять: {memoryInMegabytesKey} МБ для створення ключа";

            PlaySound.OnPlaySoundClick(sender, a, SuccessPath, SuccessVolume, SuccessNumber);

            MessageBox.Show("Ключі згенерувалися");
        }

        public static BigInteger GeneratePrime(int bitLength)
        {
            Random random = new Random();
            BigInteger prime = BigInteger.Zero;
            while (GetBitLength(prime) != bitLength || !IsPrime(prime))
            {
                byte[] bytes = new byte[bitLength / 8];
                random.NextBytes(bytes);
                prime = new BigInteger(bytes);
            }
            return prime;
        }

        public static int GetBitLength(BigInteger number)
        {
            return number.ToByteArray().Length * 8;
        }

        public static bool IsPrime(BigInteger n)
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;
            if (n.IsEven) return false;

            BigInteger d = n - 1;
            int s = 0;
            while (d.IsEven)
            {
                d /= 2;
                s++;
            }

            for (int i = 0; i < 10; i++)
            {
                BigInteger a = RandomBigInteger(2, n - 2);
                BigInteger x = BigInteger.ModPow(a, d, n);
                if (x == 1 || x == n - 1) continue;
                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == n - 1) break;
                }
                if (x != n - 1) return false;
            }
            return true;
        }

        public static BigInteger RandomBigInteger(BigInteger min, BigInteger max)
        {
            Random random = new Random();
            byte[] bytes = max.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F;
                result = new BigInteger(bytes);
            } while (result < min || result >= max);
            return result;
        }

        public static BigInteger GetRandomCoprime(BigInteger phi)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] buffer = new byte[32];
            BigInteger e;
            do
            {
                rng.GetBytes(buffer);
                e = new BigInteger(buffer);
                e = BigInteger.Remainder(e, phi - 2) + 2;
            } while (!(e > 1 && e < phi && BigInteger.GreatestCommonDivisor(e, phi) == 1));
            return e;
        }

        public static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            if (m == 0)
                throw new ArgumentException("Аргумент 'm' не може дорівнювати нулю.");
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;
            if (a % m == 0)
                return 0;
            while (a > 1)
            {
                BigInteger q = a / m;
                BigInteger t = m;
                m = a % m;
                a = t;
                t = y;
                y = x - q * y;
                x = t;
            }
            if (x < 0)
                x += m0;
            return x;
        }
    }
}