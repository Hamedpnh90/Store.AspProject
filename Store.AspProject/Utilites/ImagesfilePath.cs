namespace Store.AspProject.Utilites
{
    public static class ImagesfilePath
    {

        private static string ImageBase="/Img/Product" ;
        private static string ImageBaseServer=$"wwwroot/{ImageBase}" ;

        private static string DefualtImage = $"{ImageBaseServer}/Product/Defualt/Defualt.jpg";


        public static string UserAvatarThumb = "/Img/Product/Thumb/";
        public static string UserAvatarThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/UserAvatar/Thumb");

        #region Product
        public static string ProductImage = $"{ImageBase}/ProductImg/";
        public static string ProductImageServer =Path.Combine(Directory.GetCurrentDirectory(),$"{ImageBaseServer}/ProductImg/")    ;
        #endregion

    }
}
