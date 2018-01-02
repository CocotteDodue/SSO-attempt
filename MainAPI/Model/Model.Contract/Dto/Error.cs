using System.Dynamic;

namespace ModelContract.Dto
{
    public class Error
    {
        public string Message { get; set; }
        public object ExtraInfo { get; set; }
    }
}