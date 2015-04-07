using System;

namespace Models
{
    public class CustomException:ApplicationException
    {
        public CustomException(string message):base(message)
        {
            
        }
    }
}
