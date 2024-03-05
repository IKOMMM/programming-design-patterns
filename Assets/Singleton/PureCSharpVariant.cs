namespace Singleton
{

    /// <summary>
    /// Pure C# singleton variant if You don't need to make it visible in editor.
    /// </summary>
    public class PureCSharpVariant 
    {
        static PureCSharpVariant instance;
        public static PureCSharpVariant Instance => instance ??= new PureCSharpVariant();

        private PureCSharpVariant() { }
    }
}


