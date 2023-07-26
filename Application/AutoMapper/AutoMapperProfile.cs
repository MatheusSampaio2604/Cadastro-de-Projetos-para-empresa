using Application.ViewModel;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Anexos, AnexosViewModel>().ReverseMap();

            CreateMap<Financiamento, FinanciamentoViewModel>().ReverseMap();

            CreateMap<Funcao, FuncaoViewModel>().ReverseMap();

            CreateMap<GerenciaGeral, GerenciaGeralViewModel>().ReverseMap();

            CreateMap<Objetivo, ObjetivoViewModel>().ReverseMap();

            CreateMap<Projeto, ProjetoViewModel>()
                .ForMember(
                dest => dest.Anexo,
                opt => opt.MapFrom(
                    src => src.Anexos.Where(x => x.Id_Projeto == src.Id).Select(x => x.Nome).FirstOrDefault()))
                .ForMember(
                dest => dest.ClienteId,
                opt => opt.MapFrom(
                src => src.UsuarioProjetos.Where(x => x.Id_Projeto == src.Id).Where(x => x.Id_Funcao == 1).Select(x => x.Id_Usuario).FirstOrDefault()))
                .ForMember(
                dest => dest.ResponsavelId,
                opt => opt.MapFrom(
                    src => src.UsuarioProjetos.Where(x => x.Id_Funcao == 2 && x.Id_Projeto == src.Id).Select(x => x.Id_Usuario).FirstOrDefault()))
                .ForMember(
                dest => dest.ApoioId,
                opt => opt.MapFrom(
                    src => src.UsuarioProjetos.Where(x => x.Id_Funcao == 3 && x.Id_Projeto == src.Id).Select(x => x.Id_Usuario).ToList()))
                .ForMember(
                dest => dest.NomeCliente,
                opt => opt.MapFrom(
                    src => src.UsuarioProjetos.Where(x => x.Id_Projeto == src.Id).Where(x => x.Id_Funcao == 1).Select(x => x.Usuario.Nome).FirstOrDefault()))
                .ForMember(
                dest => dest.NomeResponsavel,
                opt => opt.MapFrom(
                    src => src.UsuarioProjetos.Where(x => x.Id_Projeto == src.Id).Where(x => x.Id_Funcao == 2).Select(x => x.Usuario.Nome).FirstOrDefault()))
                .ForMember(
                dest => dest.NomeApoio,
                opt => opt.MapFrom(
                    src => src.UsuarioProjetos.Where(x => x.Id_Projeto == src.Id).Where(x => x.Id_Funcao == 3).Select(x => x.Usuario.Nome).ToList()))
                                
            .ReverseMap();
            
            CreateMap<Setor, SetorViewModel>().ReverseMap();

            CreateMap<Tema, TemaViewModel>().ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();

            CreateMap<UsuarioProjeto, UsuarioProjetoViewModel>().ReverseMap();

            CreateMap<Gerencia, GerenciaViewModel>()
                .ForMember(
                dest => dest.ItemAtivo,
                opt => opt.MapFrom(
                src => src.Ativo ? "Sim" : "Não"))
            .ReverseMap();
        }
    }
}