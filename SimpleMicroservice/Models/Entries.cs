namespace SimpleMicroservice.Models
{
    /// <summary>
    /// Represents an entry in the system that can be written and read via the api.
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Gets or sets Entry ID.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Entry data.
        /// </summary>
        public string Data { get; set; }
    }

}
