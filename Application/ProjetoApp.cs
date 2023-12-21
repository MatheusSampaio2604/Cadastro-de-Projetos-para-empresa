using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Application.Enum;
using Infra.Context;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Application
{
    public class ProjetoApp : App<ProjetoViewModel, Projeto>, IProjetoApp
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
        private readonly DataContext _dataContext;
        private readonly IAnexosRepository _anexosRepository;

        public ProjetoApp(ILogger<ProjetoApp> logger, IMapper mapper, DataContext dataContext, IAnexosRepository anexosRepository, IUsuarioProjetoRepository usuarioProjetoRepository, IProjetoRepository projetoRepository) : base(logger, mapper, projetoRepository)
        {
            _dataContext = dataContext;
            _projetoRepository = projetoRepository;
            _usuarioProjetoRepository = usuarioProjetoRepository;
            _anexosRepository = anexosRepository;
        }

        public override async Task<Projeto> CreateAsync(ProjetoViewModel projetoViewModel)
        {

            if (projetoViewModel.ApoioId.Contains(projetoViewModel.ClienteId) || projetoViewModel.ApoioId.Contains(projetoViewModel.ResponsavelId)) 
            { 
                throw new Exception("Luke Perrin shows exception");
            }

            string estudo;

            try
            {
                string ano = DateTime.Now.Year.ToString()[2..];
                estudo = projetoViewModel.Codigo;
                estudo += string.Format($".{ano}");
                var countEstudo = _dataContext.Projeto.Where(x => x.Codigo.Substring(0, 7) == estudo).Count() + 1;
                estudo += string.Format($".{countEstudo.ToString().PadLeft(2, '0')}");
                

                Projeto projeto = new()
                {
                    Id = projetoViewModel.Id,
                    Codigo = estudo,
                    Nome = projetoViewModel.Nome.ToUpper(),
                    Id_Tema = projetoViewModel.Id_Tema,
                    Id_Objetivo = projetoViewModel.Id_Objetivo,
                    Id_Financiamento = projetoViewModel.Id_Financiamento,
                    HoraAbertura = projetoViewModel.HoraAbertura
                };
                var create = await _projetoRepository.CreateAsync(projeto);

                


                if(create >= 1 && projetoViewModel.Anexo.Length > 0)
                {
                 
                    Anexos anexo = new()
                    {

                    };
                    
                  //  var createAnexos = await _anexosRepository.CreateAsync(anexo);
                }
                

                if (create >= 1)
                {
                    UsuarioProjeto upCliente = new()
                    {
                        Id_Projeto = projeto.Id,
                        Id_Usuario = projetoViewModel.ClienteId,
                        Id_Funcao = (int)FuncaoEnum.Cliente
                    };
                    var createUpCliente = await _usuarioProjetoRepository.CreateAsync(upCliente);

                    UsuarioProjeto upResponsavel = new()
                    {
                        Id_Projeto = projeto.Id,
                        Id_Usuario = projetoViewModel.ResponsavelId,
                        Id_Funcao = (int)FuncaoEnum.Responsavel
                    };
                    var createUpResponsavel = await _usuarioProjetoRepository.CreateAsync(upResponsavel);


                    if (projetoViewModel.ApoioId != null)
                    {
                        foreach (var item in projetoViewModel.ApoioId)
                        {
                            UsuarioProjeto upApoio = new()
                            {
                                Id_Projeto = projeto.Id,
                                Id_Usuario = item,
                                Id_Funcao = (int)FuncaoEnum.Apoio
                            };
                            var createUpApoio = await _usuarioProjetoRepository.CreateAsync(upApoio);
                        }
                    }
                }
                return projeto;
            }
            catch (Exception)
            {

                throw;

            }
        }

        public override async Task<ProjetoViewModel> EditAsync(ProjetoViewModel projetoViewModel)
        {
            if (projetoViewModel.ApoioId.Contains(projetoViewModel.ClienteId) || projetoViewModel.ApoioId.Contains(projetoViewModel.ResponsavelId)) 
            { 
                throw new Exception("Not Proceded");
            }
            Projeto projeto = await _projetoRepository.FindOneAsync(projetoViewModel.Id);

            int usuarioClienteDb = projeto.UsuarioProjetos.Where(x => x.Id_Funcao == (int)FuncaoEnum.Cliente).Where(x => x.Id_Projeto == projeto.Id).Select(x => x.Id_Usuario).FirstOrDefault();
            int usuarioLtpDb = projeto.UsuarioProjetos.Where(x => x.Id_Funcao == (int)FuncaoEnum.Responsavel).Where(x => x.Id_Projeto == projeto.Id).Select(x => x.Id_Usuario).FirstOrDefault();
            List<int> usuarioApoioDb = projeto.UsuarioProjetos.Where(x => x.Id_Funcao == (int)FuncaoEnum.Apoio).Where(x => x.Id_Projeto == projeto.Id).Select(x => x.Id_Usuario).ToList();
           
            UsuarioProjeto usuarioCliente = await _usuarioProjetoRepository.FindUserProjectAsync(projetoViewModel.Id, usuarioClienteDb, (int)FuncaoEnum.Cliente);
            UsuarioProjeto usuarioResponsavel = await _usuarioProjetoRepository.FindUserProjectAsync(projetoViewModel.Id, usuarioLtpDb, (int)FuncaoEnum.Responsavel);
            
            projeto.Nome = projetoViewModel.Nome;
            projeto.Id_Financiamento = projetoViewModel.Id_Financiamento;
            projeto.Id_Objetivo = projetoViewModel.Id_Objetivo;
            projeto.Id_Tema = projetoViewModel.Id_Tema;

            await _projetoRepository.EditAsync(projeto);


            if (projeto != null)
            {
                UsuarioProjeto usuarioCli = new()
                {
                    Id_Projeto = projeto.Id,
                    Id_Usuario = projetoViewModel.ClienteId,
                    Id_Funcao = (int)FuncaoEnum.Cliente
                };

                if (usuarioCliente.Id_Usuario != projetoViewModel.ClienteId)
                {
                    var remove = await _usuarioProjetoRepository.RemoveAsync(usuarioCliente);
                    var newCliente = await _usuarioProjetoRepository.CreateAsync(usuarioCli);
                }

                UsuarioProjeto usuarioResp = new()
                {
                    Id_Projeto = projeto.Id,
                    Id_Usuario = projetoViewModel.ResponsavelId,
                    Id_Funcao = (int)FuncaoEnum.Responsavel
                };
                if (usuarioResponsavel.Id_Usuario != projetoViewModel.ResponsavelId)
                {
                    var remove = await _usuarioProjetoRepository.RemoveAsync(usuarioResponsavel);
                    var newResponsavel = await _usuarioProjetoRepository.CreateAsync(usuarioResp);
                }

                if(usuarioApoioDb != null) 
                {
                    foreach (var user in usuarioApoioDb)
                    {
                        UsuarioProjeto? oldUser = await _usuarioProjetoRepository.FindUserProjectAsync(projeto.Id, user, (int)FuncaoEnum.Apoio);
                        Task<int>? remove = _usuarioProjetoRepository.RemoveAsync(oldUser);
                    }
                }

                foreach (var i in projetoViewModel.ApoioId)
                {
                   
                    UsuarioProjeto usuarioApoi = new()
                    {
                        Id_Projeto = projeto.Id,
                        Id_Usuario = i,
                        Id_Funcao = (int)FuncaoEnum.Apoio
                    };
                    var createUpApoio = await _usuarioProjetoRepository.CreateAsync(usuarioApoi);
                }
            }
            return projetoViewModel;
        }
    }
}