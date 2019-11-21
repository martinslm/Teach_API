import { http } from "./config";

export default {
  obterSugestoes: (idUsuario) => {
    return http.get("pesquisa/buscarRecomendacoesUsuarios?idUsuario=" + idUsuario);
  }

};
