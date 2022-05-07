﻿using Cineflix.Domain;
using Cineflix.Domain.Cryptography;
using Cineflix.Domain.Dto;
using Cineflix.Domain.Models;
using Cineflix.Domain.Repository;
using Cineflix.Domain.Service;
using System;
using System.Threading.Tasks;

namespace Cineflix.Infra.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<TypeResult<int>> CadastraUsuario(CadastraUsuarioDto model)
        {
            try
            {
                var senhaCriptografada = new CriptografiaService()
                    .CriptografaSenha(model.Senha);

                //Validar se usuário ou senha já existem.

                var usuario = new Usuario();
                usuario.CriarUsuario(model.Documento, senhaCriptografada, model.Nome);

                var idUsuario = await _usuarioRepository.CadastraUsuario(usuario);

                return new TypeResult<int> { Sucesso = true, Modelo = idUsuario }; 
            }
            catch (Exception ex)
            {
                return new TypeResult<int> { Sucesso = false, Modelo = 0, Menssagem = ex.Message };
            }
        }
    }
}