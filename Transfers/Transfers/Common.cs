namespace Transfers
{
    public static class Common
    {
        public static bool IsPamm(int login)
        {
            return login == 7016219;
        }

        public static bool IsMt5(int login)
        {
            return login > 9000000 && login < 10000000;
        }
    }
}
