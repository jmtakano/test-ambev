using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class AuthProfiler : Profile
    {
        public AuthProfiler()
        {
            CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();
        }
    }
}
