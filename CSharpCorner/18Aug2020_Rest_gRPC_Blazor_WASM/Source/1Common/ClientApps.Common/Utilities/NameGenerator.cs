using ClientApps.Common.Constants;
using System.Text;

namespace ClientApps.Common.Utilities
{

    public static class NameGenerator
    {

        static public string GenerateName(int length)
        {
            StringBuilder name = new StringBuilder(50);

            name.Append(GetAConstant().ToUpper());
            name.Append(GetAVowel());
            
            int b = 2;
            while (b < length)
            {
                name.Append(GetAConstant());
                b++;
                name.Append(GetAVowel());
                b++;
            }

            return name.ToString();
        }

        private static string GetAConstant()
        {
            return Konstants.GenerateName.Consonants[RandomNumberGenerator.GetRandomValue(0, Konstants.GenerateName.Consonants.Length)];
        }

        private static string GetAVowel()
        {
            return Konstants.GenerateName.Vowels[RandomNumberGenerator.GetRandomValue(0, Konstants.GenerateName.Vowels.Length)];
        }
    }

}
