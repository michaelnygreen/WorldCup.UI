using Dto = WorldCup.Api.Dto;
using Service = WorldCup.UI.Models;

namespace WorldCup.Data.Repository.Mappers
{
    static class PositionMapper
    {
        public static Service.Position Map(Dto.Position position)
        {
            switch (position)
            {
                case Dto.Position.Unknown:
                    return Service.Position.Unknown;
                case Dto.Position.Goalkeeper:
                    return Service.Position.Goalkeeper;
                case Dto.Position.Defender:
                    return Service.Position.Defender;
                case Dto.Position.Midfielder:
                    return Service.Position.Midfielder;
                case Dto.Position.Forward:
                    return Service.Position.Forward;
                default:
                    return Service.Position.Unknown;
            }
        }
    }
}
