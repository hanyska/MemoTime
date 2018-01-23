namespace MemoTime.Infrastructure
{
    public class TaskFilter
    {
        public string Type { get; set; }
        public string Filter { get; set; }
        public bool ByTag { get; set; }
        public string SearchName { get; set; }
    }
}