import { http } from "./config";

export default {
  efetuarLogin: (loginForm) => {
    return http.post("usuario/fazerlogin", loginForm);
    },
cadastrarUsuario: (usuarioModel) => {
    return http.post("usuario/cadastrar", usuarioModel);
}
  };