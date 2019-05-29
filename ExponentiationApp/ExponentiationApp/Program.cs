using System.IO;
using System.Numerics;
using System.Text;

namespace ExponentiationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int OFFSET = 0;
            const int VALUE = 999999;
            const int EXPONENT = 99999;

            BigInteger bigNumber = BigInteger.Pow(VALUE, EXPONENT);

            using (FileStream stream = new FileStream("BigNumber.txt", FileMode.Truncate))
            {
                byte[] byteArray = Encoding.Default.GetBytes(bigNumber.ToString());
                stream.Write(byteArray, OFFSET, byteArray.Length);
            }
        }
    }
}
