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

        public static Dto.Position Map(Service.Position position)
        {
            switch (position)
            {
                case Service.Position.Unknown:
                    return Dto.Position.Unknown;
                case Service.Position.Goalkeeper:
                    return Dto.Position.Goalkeeper;
                case Service.Position.Defender:
                    return Dto.Position.Defender;
                case Service.Position.Midfielder:
                    return Dto.Position.Midfielder;
                case Service.Position.Forward:
                    return Dto.Position.Forward;
                default:
                    return Dto.Position.Unknown;
            }
        }
    }
}
