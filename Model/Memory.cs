using Microsoft.EntityFrameworkCore;

namespace MnemosyneAPI.Model
{
    public class Memory
    {
        public  int  id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime date { get; set; }

        public List<string> images { get; set; }
    }

}
