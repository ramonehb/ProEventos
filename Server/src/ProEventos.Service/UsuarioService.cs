using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;
using ProEventos.Service.Dtos;
using ProEventos.Service.Interfaces;

namespace ProEventos.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMapper _mapper;
        private readonly IUsuarioPersist _usuarioPersist;

        public UsuarioService(IGeralPersist geralPersist, IUsuarioPersist usuarioPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _usuarioPersist = usuarioPersist;
            _mapper = mapper;
        }
        public async Task<UsuarioDto> AddUsuario(UsuarioDto model)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(model);

                _geralPersist.Add<Usuario>(usuario);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var usuarioRetorno = await _usuarioPersist.GetUsuarioByIdAsync(usuario.Id);
                    return _mapper.Map<UsuarioDto>(usuarioRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(id);
                if (usuario is null) throw new Exception("Usuário não encontrado.");

                _geralPersist.Delete<Usuario>(usuario);

                return await _geralPersist.SaveChangeAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(id);
                if (usuario is null) return null;

                return _mapper.Map<UsuarioDto>(usuario);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }        
        }

        public async Task<UsuarioDto[]> GetUsuariosAsync()
        {
            try
            {
                var usuarios = await _usuarioPersist.GetUsuariosAsync();
                if (usuarios is null) return null;

                return _mapper.Map<UsuarioDto[]>(usuarios);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }

        public async Task<UsuarioDto> UpdateUsuario(int id, UsuarioDto model)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(id);
                if (usuario is null) return null;

                model.Id = usuario.Id;

                _mapper.Map(model, usuario);
                _geralPersist.Update<Usuario>(usuario);

                if (await _geralPersist.SaveChangeAsync())
                {
                    var usuarioRetorno = await _usuarioPersist.GetUsuarioByIdAsync(model.Id);
                    return _mapper.Map<UsuarioDto>(usuarioRetorno);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: {e.Message}");
            }
        }
    }
}