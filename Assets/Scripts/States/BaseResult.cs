namespace States
{
    public record BaseResult();
    public record BaseParams();

    public record LobbyParams(int Count) : BaseParams();
}