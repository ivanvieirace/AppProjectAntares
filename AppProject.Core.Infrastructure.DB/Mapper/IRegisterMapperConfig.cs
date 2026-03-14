using System;
using Mapster;

namespace AppProject.Core.Infrastructure.DB.Mapper;

public interface IRegisterMapperConfig
{
    void Register(TypeAdapterConfig config);
}
