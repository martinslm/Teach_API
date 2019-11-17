import { http } from "./config";

export default {
  listarIdiomas: () => {
    return http.get("idioma/obter");
  }


};
