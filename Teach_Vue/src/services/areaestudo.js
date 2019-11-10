import { http } from "./config";

export default {
  listarAreasGerais: () => {
    return http.get("areaestudo/obterareasgerais", {
      headers: {
      'Content-Type': 'text/plain',
      },
      method: 'POST',
      mode: 'no-cors',
      cache: 'no-cache'});
  }
};
