namespace Remind.Dtos
{
    public class ReminderDto
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int ReminderFrequencyId { get; set; }

        public bool ReminderSent { get; set; }
    }
}
