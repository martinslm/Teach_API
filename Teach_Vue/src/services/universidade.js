import { http } from "./config";

export default {
  listarUniversidades: () => {
    return http.get("universidade/obteruniversidades");
  }
};
