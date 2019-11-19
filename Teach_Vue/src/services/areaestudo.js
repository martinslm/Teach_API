import { http } from "./config";

export default {
  listarAreasGerais: () => {
    return http.get("areaestudo/obterareasgerais");
  },
  listarAreasEspecificas: (idAreaGeral) => {
    return http.get("areaestudo/obterareasespecificas?idAreaGeral=" + idAreaGeral);
  }

};
