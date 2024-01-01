namespace SpotiAPI.Models.ModelsDTO
{
    public class RadioDTO
    {
        public RadioDTO()
        {
            
        }
        public RadioDTO(Radio radio)
        {
            Id = radio.Id;
            Name = radio.Name;
            OnAirPlaylist = new PlaylistDTO(radio.OnAirPlaylist);
            Rating = radio.Rating;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public PlaylistDTO OnAirPlaylist { get; set; }
        public int Rating { get; set; }
    }
}
