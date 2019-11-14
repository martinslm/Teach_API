import { http } from "./config";

export default {
  listarAreasGerais: () => {
    return http.get("areaestudo/obterareasgerais");
  }
};
