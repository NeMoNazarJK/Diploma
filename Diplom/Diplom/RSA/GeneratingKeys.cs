using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Diagnostics;

internal class GeneratingKeys
{
    public static (string, string) OnGeneratingKeysClick(object sender, EventArgs e, string txtGeneratingkeysValue, out string PrivatekeyTime, out string PublickeyTime)
    {
        PrivatekeyTime = "";
        PublickeyTime = "";

        if (int.TryParse(txtGeneratingkeysValue, out int bitLengthTXT))
        {
            var times = rsa(bitLengthTXT);
            TimeSpan eTime = times.Item1;
            TimeSpan dTime = times.Item2;
            PrivatekeyTime = dTime.ToString();
            PublickeyTime = eTime.ToString();
            return (PrivatekeyTime, PublickeyTime);
        }
        return("", "");
    }

    public static Tuple<TimeSpan, TimeSpan> rsa(int bitLengthTXT)
    {
        int bitLength = bitLengthTXT;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        BigInteger p = GeneratePrime(bitLength);
        stopwatch.Stop();
        TimeSpan pTime = stopwatch.Elapsed;

        stopwatch.Restart();
        BigInteger q = GeneratePrime(bitLength);
        stopwatch.Stop();
        TimeSpan qTime = stopwatch.Elapsed;

        stopwatch.Restart();
        BigInteger n = p * q;
        BigInteger phi = (p - 1) * (q - 1);
        stopwatch.Stop();
        TimeSpan nphiTime = stopwatch.Elapsed;

        stopwatch.Restart();
        BigInteger e = GetRandomCoprime(phi);
        stopwatch.Stop();
        TimeSpan eTime = stopwatch.Elapsed;

        stopwatch.Restart();
        BigInteger d = ModInverse(e, phi);
        stopwatch.Stop();
        TimeSpan dTime = stopwatch.Elapsed;

        TimeSpan combinedTimeE = pTime + qTime + nphiTime + eTime;
        TimeSpan combinedTimeD = pTime + qTime + nphiTime + dTime;
        TimeSpan combinedTimeZ = pTime + qTime + nphiTime + eTime + dTime;

        using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\additional_information_RSA.txt"))
        {
            file.WriteLine("Довжина: {0} біт", bitLength);
            file.WriteLine("Перше просте число: {0}", p);
            file.WriteLine("Час генерування простого числа p: {0}", pTime.ToString());
            file.WriteLine("Друге просте число: {0}", q);
            file.WriteLine("Час генерування простого числа q: {0}", qTime.ToString());
            file.WriteLine("Значення функції Ельвора(phi): {0}", phi);
            file.WriteLine("Публічний ключ (e, n): ({0}, {1})", e, n);
            file.WriteLine("Час генерування публічного ключа: {0}", eTime.ToString());
            file.WriteLine("Приватний ключ (d, n): ({0}, {1})", d, n);
            file.WriteLine("Час генерування приватного ключа: {0}", dTime.ToString());
        }

        using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Privatekey.pem"))
        {
            file.WriteLine("{0}, {1}", d, n);
        }

        using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Publickey.pem"))
        {
            file.WriteLine("{0}, {1}", e, n);
        }

        using (StreamWriter file = new StreamWriter("..\\..\\..\\Time\\Time_Key_" + bitLength + "_біт.txt"))
        {             
            file.WriteLine("{0}", combinedTimeZ.TotalSeconds);
        }

        return Tuple.Create(combinedTimeE, combinedTimeD);
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