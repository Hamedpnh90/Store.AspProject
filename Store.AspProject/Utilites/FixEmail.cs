namespace Store.AspProject.Utilites
{
    public class FixEmail
    {
        public class FixEmails
        {
            public static string FixEmail(string Email)
            {
                return Email.Trim().ToLower();
            }
        }
    }
}
