namespace App
{
    public class StatusHelper
    {
        public string NextStatus(string status)
        {
            return status == "New" ? "In Progress" : "Finished";
        }
    }
}
