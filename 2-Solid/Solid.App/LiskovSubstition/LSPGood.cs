namespace Solid.App.LiskovSubstition.Good
{
    public interface ITakePhoto
    {
        void TakePhoto();
    }
    public abstract class BasePhone
    {
        public void Call()
        {
            Console.WriteLine("Arama Yapıldı");
        }
    }

    public class IPhone : BasePhone, ITakePhoto
    {
        public void TakePhoto()
        {
            Console.WriteLine("Fotoğraf Çekildi");
        }
    }

    public class Nokia3310 : BasePhone
    {

    }
}
