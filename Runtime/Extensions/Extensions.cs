namespace Core.Messenger
{
    public static class Extensions
    {
        public static void Tester(this string message)
        {
            new GlobalMessage(message);
        }
    }
}