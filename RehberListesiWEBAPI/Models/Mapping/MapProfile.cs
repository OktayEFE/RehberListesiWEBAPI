using System;
using AutoMapper;
using RehberListesiWEBAPI.Models.DTO;

namespace RehberListesiWEBAPI.Models.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile() => CreateMap<RehberDTO, Rehber>();
	}
}

