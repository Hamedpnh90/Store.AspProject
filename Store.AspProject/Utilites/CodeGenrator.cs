namespace Store.AspProject.Utilites
{
    public static class CodeGenrator
    {
        public static string GenratinUniqCode()
        {
            return Guid.NewGuid().ToString("n");
        }
    }
}
