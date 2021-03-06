using College.Core.Constants;
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
            return Constants.GenerateName.Consonants[RandomNumberGenerator.GetRandomValue(0, Constants.GenerateName.Consonants.Length)];
        }

        private static string GetAVowel()
        {
            return Constants.GenerateName.Vowels[RandomNumberGenerator.GetRandomValue(0, Constants.GenerateName.Vowels.Length)];
        }
    }

}
